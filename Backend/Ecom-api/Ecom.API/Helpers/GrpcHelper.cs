using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Mapster;
using Type = System.Type;

namespace Ecom.API.Helpers;

public static class GrpcHelper
{
    public static TK TypeConverting<T, TK>(T source) where TK : new()
    {
        var target = new TK();

        foreach (var sourceProp in typeof(T).GetProperties())
        {
            var targetProp = typeof(TK).GetProperty(sourceProp.Name);
            var sourceValue = sourceProp.GetValue(source);

            if (targetProp == null || sourceValue == null) continue;
            if (targetProp.PropertyType == typeof(Any))
            {
                var test = Type.GetType(sourceProp.PropertyType.FullName!);
                var instance = Activator.CreateInstance(Type.GetType(sourceProp.PropertyType.ToString())!);
                targetProp.SetValue(target, Any.Pack((IMessage)instance.Adapt(sourceValue)));
                continue;
            }

            targetProp.SetValue(target, sourceValue);
        }

        return target;
    }
}
