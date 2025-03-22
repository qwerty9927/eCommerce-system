using Ecom.Application.Dtos.Product;
using Ecom.Application.Interfaces.Repositories;
using Ecom.Application.Interfaces.Services;
using Ecom.Domain.Entities;
using Ecom.Domain.Shared;
using Mapster;

namespace Ecom.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<BaseResponse<PagingResponse<ProductDto>>> SearchAsync(SearchRequest request)
    {
        PagingResponse<Product> result = await productRepository.SearchAsync(request);

        return new SuccessResponse<PagingResponse<ProductDto>>(
            result.Adapt<PagingResponse<ProductDto>>());
    }

    public async Task<BaseResponse<ProductDto>> GetByIdAsync(string productId)
    {
        Product result = await productRepository.GetByIdAsync(productId);

        return new SuccessResponse<ProductDto>(result.Adapt<ProductDto>());
    }

    public async Task<BaseResponse<List<ProductDto>>> GetAllAsync()
    {
        List<Product> result = await productRepository.GetAllAsync();

        return new SuccessResponse<List<ProductDto>>(result.Adapt<List<ProductDto>>());
    }
}
