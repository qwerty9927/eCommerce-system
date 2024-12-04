using Fashion.Application.Dtos.Order;
using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface IOrderService
{
    Task<BaseResponse<bool>> CreateCustomerAsync();
    Task<BaseResponse<bool>> AddCardAsync(string source);
    Task<BaseResponse<bool>> CreatePaymentAsync(int amount, string orderId);
    Task<BaseResponse<bool>> ConfirmPaymentAsync(string orderId);
    Task<BaseResponse<bool>> PlaceOrderAsync();
    Task<BaseResponse<bool>> PaymentMockupAsync(string sourceId);
    Task<BaseResponse<List<OrderDto>>> GetMyOrderAsync();
    Task<BaseResponse<List<OrderDto>>> GetAllAsync();
}
