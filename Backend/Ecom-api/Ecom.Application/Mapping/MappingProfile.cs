using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Application.Mapping;

public static class MappingProfile
{
    public static void RegisterMapping(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}
