using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Mapster;
using Type = System.Type;

namespace Ecom.API.Helpers;

public static class GrpcHelper
{
    public static TK TypeConverting<T, TK>(T source) where TK : new()
    {
        TK target = new TK();

        foreach (var sourceProp in typeof(T).GetProperties())
        {
            var targetProp = typeof(TK).GetProperty(sourceProp.Name);
            var sourceValue = sourceProp.GetValue(source);

            if (targetProp == null || sourceValue == null) continue;
            if (targetProp.PropertyType == typeof(Any))
            {
                var typeName = sourceProp.PropertyType?.Name.Split("`")[0]!;
                var type = Type.GetType("Ecom.API.Protos.Dtos.Product.ProductGrpcDto")!;
                dynamic instance = Activator.CreateInstance(type)!;
                dynamic test2 = Adapt(sourceValue, instance);
                dynamic test = instance.Adapt(sourceValue);
                targetProp.SetValue(target, Any.Pack((IMessage)instance));
                continue;
            }

            targetProp.SetValue(target, sourceValue);
        }

        return target;
    }

    private static TK Adapt<T,TK>(T source, TK target)
    {
        return target;
    }
}
