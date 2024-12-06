using System.Net;
using Fashion.Application.Configurations;
using Fashion.Application.Dtos.Order;
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
    IDeliveryInformationRepository deliveryInformationRepository,
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
                    Message = "User payment needed to be created",
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

    public async Task<BaseResponse<bool>> CreatePaymentAsync(int amount, string orderId)
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

            var isCreatedTransaction = await transactionRepository.CreateAsync(new Transaction
            {
                PaymentId = paymentInfo.Id,
                Status = paymentInfo.Status,
                OrderId = orderId
            });

            if (!isCreatedTransaction)
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

    public async Task<BaseResponse<bool>> ConfirmPaymentAsync(string orderId)
    {
        try
        {
            var foundOrder = await orderRepository.GetByIdAsync(orderId);
            if (foundOrder == null)
            {
                throw new BaseException
                {
                    Message = "Order not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            var foundUser = await userManager.FindByIdAsync(foundOrder.UserId);

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

            var foundTransaction = await transactionRepository.GetByOrderId(orderId);
            if (foundTransaction == null)
            {
                throw new BaseException();
            }

            var paymentInfo = await stripeProvider.ConfirmPaymentAsync(foundTransaction.PaymentId);

            foundOrder.Status = OrderStatusConstant.Succeed;
            foundOrder.UpdatedAt = DateTime.Now;
            await orderRepository.UpdateAsync(foundOrder);

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

            // Covert to order
            Order newOrder = new();
            newOrder.Id = Guid.NewGuid().ToString();
            newOrder.UserId = userId;
            newOrder.OrderDetails = foundCart.CartDetails.Select(c => new OrderDetail
            {
                ProductId = c.ProductId,
                Quantity = c.Quantity,
                OrderId = newOrder.Id,
                ProductPrice = c.Size.Price
            }).ToList();
            newOrder.Status = OrderStatusConstant.Pending.ToString();
            newOrder.Total = (decimal)newOrder.OrderDetails.Sum(cd => cd.ProductPrice * cd.Quantity);
            newOrder.CreatedAt = DateTime.Now;
            newOrder.UpdatedAt = DateTime.Now;

            var isCreated = await orderRepository.CreateAsync(newOrder);
            if (!isCreated)
            {
                throw new BaseException();
            }

            // Close cart
            foundCart.IsActive = false;
            var isUpdated = await cartRepository.UpdateAsync(foundCart);

            if (!isUpdated)
            {
                throw new BaseException();
            }

            // Create payment
            var isCreatedPayment = (await CreatePaymentAsync((int)newOrder.Total, newOrder.Id)).Data;
            if (!isCreatedPayment)
            {
                throw new BaseException();
            }

            // Init new cart
            var isCreatedNewCart = await cartRepository.CreateAsync(new Cart
            {
                UserId = userId,
                IsActive = true
            });

            if (!isCreatedNewCart)
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

    public async Task<BaseResponse<bool>> PaymentMockupAsync(MockupRequest request)
    {
        try
        {
            // Create customer stripe
            var isCreatedCustomer = (await CreateCustomerAsync()).Data;
            if (!isCreatedCustomer)
            {
                throw new BaseException();
            }

            // Add card
            var isAddCard = (await AddCardAsync(request.SourceId)).Data;
            if (!isAddCard)
            {
                throw new BaseException();
            }

            // var isCreateDeliveryInfo = await deliveryInformationRepository.CreateAsync(request.Adapt<DeliveryInformation>());
            // if (!isCreateDeliveryInfo)
            // {
            //     throw new BaseException();
            // }

            // Place other
            var isPlacedOrder = (await PlaceOrderAsync()).Data;
            if (!isPlacedOrder)
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
                Message = ex.Message ?? "Mockup failed"
            };
        }
    }

    public async Task<BaseResponse<List<OrderDto>>> GetMyOrderAsync()
    {
        try
        {
            string userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            var foundOrders = await orderRepository.GetAllAsync(userId);

            var result = foundOrders.Adapt<List<OrderDto>>();

            return new SuccessResponse<List<OrderDto>>(result);
        }
        catch (BaseException ex)
        {
            return new BadResponse<List<OrderDto>>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Get failed"
            };
        }
    }

    public async Task<BaseResponse<List<OrderDto>>> GetAllAsync()
    {
        try
        {
            var foundOrders = await orderRepository.GetAllAsync(null, true);

            var result = foundOrders.Adapt<List<OrderDto>>();

            return new SuccessResponse<List<OrderDto>>(result);
        }
        catch (BaseException ex)
        {
            return new BadResponse<List<OrderDto>>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Get failed"
            };
        }
    }
}
