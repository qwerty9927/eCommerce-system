using Fashion.Application.Dtos.Product;
using Fashion.Domain.Entities;
using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface IProductService
{
    Task<BaseResponse<PagingResponse<ProductDto>>> SearchAsync(SearchRequest request);
    Task<BaseResponse<ProductDto>> GetByIdAsync(string id);
    Task<BaseResponse<bool>> CreateAsync(CreateProduct request);
    Task<BaseResponse<bool>> UpdateAsync(UpdateProduct request);
    Task<BaseResponse<bool>> DeleteAsync(string id);
}
