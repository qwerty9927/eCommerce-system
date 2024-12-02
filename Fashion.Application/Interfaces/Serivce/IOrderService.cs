using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface IOrderService
{
    Task<BaseResponse<bool>> CreateCustomerAsync();
    Task<BaseResponse<bool>> AddCardAsync(string source);
    Task<BaseResponse<string>> CreatePaymentAsync(int amount);
    Task<BaseResponse<bool>> ConfirmPaymentAsync(string paymentId);
    Task<BaseResponse<bool>> PlaceOrderAsync();
}
