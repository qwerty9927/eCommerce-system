using Fashion.Application.Configurations;
using Fashion.Application.Interfaces.Service;
using Fashion.Application.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fashion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuration
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Name));

        // Services
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }
}
