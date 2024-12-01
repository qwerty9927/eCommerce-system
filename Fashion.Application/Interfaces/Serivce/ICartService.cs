using Fashion.Application.Dtos.Cart;
using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface ICartService
{
    Task<BaseResponse<CartDto>> GetByIdAsync(string id);
    Task<BaseResponse<CartDto>> GetByUserIdAsync();
    Task<BaseResponse<CartDto>> CreateAsync();
    // Task<BaseResponse<bool>> RemoveAsync(string cartId)
    Task<BaseResponse<CartDto>> AddItemAsync(string productId, int quantity);
    Task<BaseResponse<CartDto>> RemoveItemAsync(string cartDetailId);
    Task<BaseResponse<CartSummary>> GetSummaryAsync();
}
