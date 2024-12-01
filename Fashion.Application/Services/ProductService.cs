using System.Net;
using Fashion.Application.Dtos.Product;
using Fashion.Application.Interfaces.Repository;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Entities;
using Fashion.Domain.Shared;
using Mapster;

namespace Fashion.Application.Service;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<BaseResponse<PagingResponse<ProductDto>>> SearchAsync(SearchRequest request)
    {
        try
        {
            var searchResponse = await productRepository.SearchAsync(request);

            var result = searchResponse.Adapt<PagingResponse<ProductDto>>();

            return new SuccessResponse<PagingResponse<ProductDto>>(result);
        }
        catch (BaseException ex)
        {
            return new BadResponse<PagingResponse<ProductDto>>(new PagingResponse<ProductDto>())
            {
                Message = ex.Message ?? "Search failed",
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest
            };
        }
    }

    public async Task<BaseResponse<ProductDto>> GetByIdAsync(string id)
    {
        try
        {
            var foundProduct = await productRepository.GetByIdAsync(id);
            if (foundProduct == null)
            {
                throw new BaseException
                {
                    Message = "Product not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            var result = foundProduct.Adapt<ProductDto>();

            return new SuccessResponse<ProductDto>(result);
        }
        catch (BaseException ex)
        {
            return new BadResponse<ProductDto>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Get failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> CreateAsync(CreateProduct request)
    {
        try
        {
            var product = request.Adapt<Product>();
            var isCreated = await productRepository.CreateAsync(product);
            if (!isCreated)
            {
                throw new BaseException();
            }

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Create failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> UpdateAsync(UpdateProduct request)
    {
        try
        {
            var product = request.Adapt<Product>();
            var isUpdated = await productRepository.UpdateAsync(product);
            if (!isUpdated)
            {
                throw new BaseException();
            }

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Update failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> DeleteAsync(string id)
    {
        try
        {
            var foundProduct = await productRepository.GetByIdAsync(id);
            if (foundProduct == null)
            {
                throw new BaseException
                {
                    Message = "Product not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            var isDelete = await productRepository.DeleteAsync(foundProduct);
            if (!isDelete)
            {
                throw new BaseException();
            }

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Delete failed"
            };
        }
    }
}
