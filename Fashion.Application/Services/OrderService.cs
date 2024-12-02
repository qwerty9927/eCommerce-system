using System.Net;
using Fashion.Application.Configurations;
using Fashion.Application.Interfaces.Repository;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Constants;
using Fashion.Domain.Entities;
using Fashion.Domain.Shared;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Fashion.Application.Service;

public class OrderService(
    UserManager<User> userManager,
    IStripeProvider stripeProvider,
    IPaymentProfileRepository paymentProfileRepository,
    ITransactionRepository transactionRepository,
    IOrderRepository orderRepository,
    ICartRepository cartRepository,
    IOptions<StripeSettings> options,
    IHttpContextAccessor httpContextAccessor) : IOrderService
{
    public async Task<BaseResponse<bool>> CreateCustomerAsync()
    {
        try
        {
            string userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            var foundUser = await userManager.FindByIdAsync(userId);

            if (foundUser == null)
            {
                throw new BaseException
                {
                    Message = "User not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            if (!string.IsNullOrWhiteSpace(foundUser.UserPaymentId))
            {
                return new SuccessResponse<bool>(true);
            }

            var customer = await stripeProvider.CreateCustomerAsync(foundUser);
            if (customer == null)
            {
                throw new BaseException();
            }

            foundUser.UserPaymentId = customer.Id;

            var isCreated = (await userManager.UpdateAsync(foundUser)).Succeeded;

            if (!isCreated)
            {
                throw new BaseException();
            }

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Create failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> AddCardAsync(string source)
    {
        try
        {
            string userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            var foundUser = await userManager.FindByIdAsync(userId);

            if (foundUser == null)
            {
                throw new BaseException
                {
                    Message = "User not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            if (foundUser.UserPaymentId == null)
            {
                throw new BaseException
                {
                    Message = "Payment needed to be created",
                };
            }

            var cartId = await stripeProvider.AddCardAsync(foundUser.UserPaymentId, source);

            await paymentProfileRepository.UpdateAsync(new PaymentProfile
            {
                CardId = cartId,
                Last4 = "",
                Brand = "",
                UserId = userId
            });

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Add failed"
            };
        }
    }

    public async Task<BaseResponse<string>> CreatePaymentAsync(int amount)
    {
        try
        {
            string userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            var foundUser = await userManager.FindByIdAsync(userId);

            if (foundUser == null)
            {
                throw new BaseException
                {
                    Message = "User not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            if (foundUser.UserPaymentId == null)
            {
                throw new BaseException
                {
                    Message = "Payment needed to be created",
                };
            }

            var paymentInfo = await stripeProvider.CreatePaymentAsync(foundUser.UserPaymentId, amount);

            // await transactionRepository.CreateAsync(new Transaction{
            //     PaymentId = paymentInfo.Id,
            //     Status = paymentInfo.Status
            // });

            return new SuccessResponse<string>(paymentInfo.Id);
        }
        catch (BaseException ex)
        {
            return new BadResponse<string>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Create failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> ConfirmPaymentAsync(string paymentId)
    {
        try
        {
            string userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            var foundUser = await userManager.FindByIdAsync(userId);

            if (foundUser == null)
            {
                throw new BaseException
                {
                    Message = "User not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            if (foundUser.UserPaymentId == null)
            {
                throw new BaseException
                {
                    Message = "Payment needed to be created",
                };
            }

            var paymentInfo = await stripeProvider.ConfirmPaymentAsync(paymentId);

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Create failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> PlaceOrderAsync()
    {
        try
        {
            string userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            Cart foundCart = await cartRepository.GetByUserIdAsync(userId);
            if (foundCart == null)
            {
                throw new BaseException
                {
                    Message = "Cart not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            Order newOrder = foundCart.Adapt<Order>();
            newOrder.Status = OrderStatusConstant.Created.ToString();
            newOrder.Total = (decimal)newOrder.OrderDetails.Sum(cd => cd.ProductPrice * cd.Quantity);

            var isCreated = await orderRepository.CreateAsync(newOrder);
            if (!isCreated)
            {
                throw new BaseException();
            }

            foundCart.IsActive = false;
            var isUpdated = await cartRepository.UpdateAsync(foundCart);

            if (!isUpdated)
            {
                throw new BaseException();
            }

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Convert failed"
            };
        }
    }
}
