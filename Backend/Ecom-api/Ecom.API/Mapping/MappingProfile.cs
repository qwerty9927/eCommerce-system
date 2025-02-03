using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using Ecom.API.Protos;
using Ecom.Domain.Shared;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Mapster;

namespace Ecom.API.Mapping;

public static class MappingProfile
{
    public static void MappingConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        config.Default.UseDestinationValue(member => member.SetterModifier == AccessModifier.None &&
                                                     member.Type.IsGenericType &&
                                                     member.Type.GetGenericTypeDefinition() ==
                                                     typeof(RepeatedField<>));

        config.NewConfig<Guid, string>().MapWith(src => src.ToString());
        config.NewConfig<string, Guid>().MapWith(src => Guid.Parse(src));
        // config.NewConfig<object, Any>().MapWith(src => Any.Pack((IMessage) src));
        // config.NewConfig<List<object>, RepeatedField<Any>>().MapWith(src => new RepeatedField<Any>()
        // {
        //     src.ConvertAll(item => Any.Pack((IMessage)item))
        // });
    }

    public static void ServiceMappingConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
    }
}
