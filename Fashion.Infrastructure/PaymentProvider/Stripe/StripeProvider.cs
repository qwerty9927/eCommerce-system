using Fashion.Application.Configurations;
using Fashion.Application.Interfaces.Repository;
using Fashion.Domain.Entities;
using Microsoft.Extensions.Options;
using Stripe;

namespace Fashion.Infrastructure.PaymentProvider;

public class StripeProvider : IStripeProvider
{
    public StripeProvider(IOptions<StripeSettings> options)
    {
        StripeConfiguration.ApiKey = options.Value.SecretKey;
    }

    public async Task<Customer> CreateCustomerAsync(User user)
    {

        var createCustomerOptions = new CustomerCreateOptions
        {
            Name = user.FullName,
            Email = user.Email
        };

        var service = new CustomerService();
        return await service.CreateAsync(createCustomerOptions);
    }

    public async Task<string> AddCardAsync(string userPaymentId, string source)
    {
        var options = new CustomerPaymentSourceCreateOptions { Source = source };
        var service = new CustomerPaymentSourceService();

        var result = await service.CreateAsync(userPaymentId, options);

        return result.Id;
    }

    public async Task<PaymentIntent> CreatePaymentAsync(string customerId, int amount)
    {
        var options = new PaymentIntentCreateOptions
        {
            Amount = amount,
            Currency = "usd",
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
            {
                Enabled = true,
            },
            Customer = customerId
        };

        var service = new PaymentIntentService();
        var result = await service.CreateAsync(options);

        return result;
    }

    public async Task<PaymentIntent> ConfirmPaymentAsync(string paymentId)
    {
        var options = new PaymentIntentConfirmOptions
        {
            PaymentMethod = "pm_card_visa",
            ReturnUrl = "https://www.example.com",
        };
        var service = new PaymentIntentService();
        var result = await service.ConfirmAsync(paymentId, options);

        return result;
    }
}
