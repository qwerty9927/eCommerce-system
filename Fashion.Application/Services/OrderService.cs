using Fashion.Application.Configurations;
using Fashion.Application.Interfaces.Repository;
using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Fashion.Application.Service;

public class OrderService(
    IOrderRepository orderRepository,
    ICartRepository cartRepository,
    IOptions<StripeSettings> options,
    IHttpContextAccessor httpContextAccessor) : IOrderService
{
    public async Task PlaceOrderAsync()
    {

    }

    public async Task CreatePaymentCard()
    {

    }
}
