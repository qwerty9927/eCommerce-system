using Ecom.Application.Interfaces.Services;
using Ecom.Application.Mapping;
using Ecom.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuration

        // System Services
        services.RegisterMapping();

        // Services
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }
}
