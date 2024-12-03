using System.Reflection;
using Fashion.Application.Dtos.Category;
using Fashion.Application.Dtos.Product;
using Fashion.Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Fashion.Application.Mapping;

public static class MappingProfile
{
    public static void RegisterMapping(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        TypeAdapterConfig<CartDetail, OrderDetail>
            .NewConfig()
            .Map(dest => dest.ProductPrice, src => src.Size.Price);

        // TypeAdapterConfig<Product, ProductDto>
        //     .NewConfig()
        //     .Map(dest => dest.ProductPrice, src => src.Size.Price);

        // TypeAdapterConfig<Category, CategoryDto>
        //     .NewConfig()
        //     .Map(dest => dest.Products, src => src.Size.Price);
    }
}
