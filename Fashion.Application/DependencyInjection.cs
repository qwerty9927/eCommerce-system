using Fashion.Application.Configurations;
using Fashion.Application.Interfaces.Service;
using Fashion.Application.Mapping;
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
        services.Configure<StripeSettings>(configuration.GetSection(StripeSettings.Name));

        // System Services
        services.RegisterMapping();

        // Services
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}
