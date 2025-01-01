using Ecom.Application.Dtos.Product;
using Ecom.Domain.Shared;

namespace Ecom.Application.Interfaces.Services;

public interface IProductService
{
    Task<BaseResponse<PagingResponse<ProductDto>>> SearchAsync(SearchRequest request);

    Task<BaseResponse<ProductDto>> GetByIdAsync(string productId);
}
