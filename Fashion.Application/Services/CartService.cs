using System.Net;
using Fashion.Application.Dtos.Cart;
using Fashion.Application.Interfaces.Repository;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Constants;
using Fashion.Domain.Entities;
using Fashion.Domain.Shared;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Fashion.Application.Service;

public class CartService(
    ICartRepository cartRepository,
    IProductRepository productRepository,
    IHttpContextAccessor httpContextAccessor) : ICartService
{
    public async Task<BaseResponse<CartDto>> GetByIdAsync(string id)
    {
        try
        {
            Cart foundCart = await cartRepository.GetByIdAsync(id);
            if (foundCart == null)
            {
                throw new BaseException
                {
                    Message = "Cart not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            CartDto result = foundCart.Adapt<CartDto>();
            return new SuccessResponse<CartDto>(result);

        }
        catch (BaseException ex)
        {
            return new BadResponse<CartDto>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Get failed"
            };
        }
    }

    public async Task<BaseResponse<CartDto>> GetByUserIdAsync()
    {
        try
        {
            var userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            Cart foundCart = await cartRepository.GetByUserIdAsync(userId);
            if (foundCart == null)
            {
                throw new BaseException
                {
                    Message = "Cart not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            CartDto result = foundCart.Adapt<CartDto>();

            return new SuccessResponse<CartDto>(result);
        }
        catch (BaseException ex)
        {
            return new BadResponse<CartDto>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Get failed"
            };
        }
    }

    public async Task<BaseResponse<CartDto>> CreateAsync()
    {
        try
        {
            var userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            // Check cart not existed
            Cart foundCart = await cartRepository.GetByUserIdAsync(userId);
            if (foundCart != null)
            {
                return new SuccessResponse<CartDto>(foundCart.Adapt<CartDto>());
            }

            // Create
            bool isCreated = await cartRepository.CreateAsync(
                new Cart
                {
                    UserId = userId,
                    IsActive = true
                });

            if (!isCreated)
            {
                throw new BaseException();
            }

            CartDto result = (await cartRepository.GetByUserIdAsync(userId)).Adapt<CartDto>();

            return new SuccessResponse<CartDto>(result);
        }
        catch (BaseException ex)
        {
            return new BadResponse<CartDto>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Create failed"
            };
        }
    }

    // public async Task<BaseResponse<bool>> RemoveAsync(string cartId)
    // {
    //     try
    //     {
    //         var foundCart = await car
    //         bool isDeleted = await cartRepository.DeleteAsync(cartId);

    //         return new BaseResponse<bool> { Data = isDeleted };
    //     }
    //     catch (Exception ex)
    //     {
    //         return new BadResponse<CartDto>(default)
    //         {
    //             Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
    //             Message = ex.Message ?? "Remove failed"
    //         };
    //     }
    // }

    public async Task<BaseResponse<CartDto>> AddItemAsync(string productId, int quantity)
    {
        try
        {
            var userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            // Validate
            quantity = quantity > 0 ? quantity : 1;

            // Check cart and product existed
            Cart foundCart = await cartRepository.GetByUserIdAsync(userId);
            if (foundCart == null)
            {
                throw new BaseException
                {
                    Message = "Cart not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            Product foundProduct = await productRepository.GetByIdAsync(productId);
            if (foundProduct == null)
            {
                throw new BaseException
                {
                    Message = "Product not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            var productExisted = foundCart.CartDetails.FirstOrDefault(cd => cd.ProductId == productId);

            if (productExisted != null)
            {
                // Update
                foundCart.CartDetails.ForEach(cd =>
                {
                    if (cd.ProductId == productId)
                    {
                        cd.Quantity = quantity;
                    }
                });
            }
            else
            {
                // Update
                foundCart.CartDetails.Add(
                    new CartDetail
                    {
                        ProductId = productId,
                        Quantity = quantity,
                    });
            }

            bool isUpdated = await cartRepository.UpdateAsync(foundCart);
            if (!isUpdated)
            {
                throw new BaseException();
            }

            CartDto result = (await cartRepository.GetByUserIdAsync(userId)).Adapt<CartDto>();

            return new SuccessResponse<CartDto>(result);
        }
        catch (BaseException ex)
        {
            return new BadResponse<CartDto>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Modify failed"
            };
        }
    }

    public async Task<BaseResponse<CartDto>> RemoveItemAsync(string cartDetailId)
    {
        try
        {
            var userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            Cart foundCart = await cartRepository.GetByUserIdAsync(userId);
            if (foundCart == null)
            {
                throw new Exception("Cart is not found");
            }

            foundCart.CartDetails.Remove(foundCart.CartDetails.First(cd => cd.Id == cartDetailId));

            bool isUpdated = await cartRepository.UpdateAsync(foundCart);
            if (!isUpdated)
            {
                throw new Exception("Service is problem");
            }

            CartDto result = (await cartRepository.GetByUserIdAsync(userId)).Adapt<CartDto>();

            return new SuccessResponse<CartDto>(result);
        }
        catch (BaseException ex)
        {
            return new BadResponse<CartDto>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Remove failed"
            };
        }
    }

    public async Task<BaseResponse<CartSummary>> GetSummaryAsync()
    {
        try
        {
            var userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            Cart foundCart = await cartRepository.GetByUserIdAsync(userId);
            if (foundCart == null)
            {
                throw new BaseException
                {
                    Message = "Cart not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            CartSummary result = foundCart.Adapt<CartSummary>();
            result.SubTotal = (decimal)result.CartDetails.Sum(cd => cd.Size.Price * cd.Quantity);
            result.Total = result.SubTotal - result.DiscountPrice;

            return new SuccessResponse<CartSummary>(result);

        }
        catch (BaseException ex)
        {
            return new BadResponse<CartSummary>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Get failed"
            };
        }
    }
}
