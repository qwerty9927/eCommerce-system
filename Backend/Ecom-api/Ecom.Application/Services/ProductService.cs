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
        PagingResponse<Product> searchResponse = await productRepository.SearchAsync(request);

        PagingResponse<ProductDto> result = searchResponse.Adapt<PagingResponse<ProductDto>>();

        return new SuccessResponse<PagingResponse<ProductDto>>(result);
    }
}
