using Fashion.Domain.Entities;
using Stripe;

namespace Fashion.Application.Interfaces.Repository;

public interface IStripeProvider
{
    Task<Customer> CreateCustomerAsync(User user);
    Task<string> AddCardAsync(string userPaymentId, string source);
    Task<PaymentIntent> CreatePaymentAsync(string customerId, int amount);
    Task<PaymentIntent> ConfirmPaymentAsync(string paymentId);
}
