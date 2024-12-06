using Fashion.Application.Dtos.Cart;
using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface ICartService
{
    Task<BaseResponse<CartDto>> GetByIdAsync(string id);
    Task<BaseResponse<CartDto>> GetByUserIdAsync();
    Task<BaseResponse<CartDto>> CreateAsync();
    Task<BaseResponse<CartDto>> AddItemAsync(AddItemRequest request);
    Task<BaseResponse<CartDto>> RemoveItemAsync(RemoveItemRequest request);
    Task<BaseResponse<CartSummary>> GetSummaryAsync();
}
