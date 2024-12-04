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

    public async Task<BaseResponse<CartDto>> AddItemAsync(AddItemRequest request)
    {
        try
        {
            var userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            // Validate
            request.Quantity = request.Quantity > 0 ? request.Quantity : 1;

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

            Product foundProduct = await productRepository.GetByIdAsync(request.ProductId);
            if (foundProduct == null)
            {
                throw new BaseException
                {
                    Message = "Product not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            var productExisted = foundCart.CartDetails.FirstOrDefault(cd => cd.ProductId == request.ProductId && cd.SizeId == request.SizeId);

            if (productExisted != null)
            {
                // Update
                foundCart.CartDetails.ForEach(cd =>
                {
                    if (cd.ProductId == request.ProductId && cd.SizeId == request.SizeId)
                    {
                        cd.Quantity += request.Quantity;
                    }
                });
            }
            else
            {
                // Update
                foundCart.CartDetails.Add(
                    new CartDetail
                    {
                        ProductId = request.ProductId,
                        Quantity = request.Quantity,
                        SizeId = request.SizeId
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

    public async Task<BaseResponse<CartDto>> RemoveItemAsync(RemoveItemRequest request)
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

            CartDetail foundCartItem = foundCart.CartDetails.First(cd => cd.Id == request.CartDetailId);

            if (foundCartItem.Quantity <= request.Quantity)
            {
                foundCart.CartDetails.Remove(foundCartItem);
            }
            else
            {
                foundCartItem.Quantity -= request.Quantity < 0 ? 0 : request.Quantity;
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
            result.Total = (decimal)result.CartDetails.Sum(cd => cd.Size.Price * cd.Quantity);

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
