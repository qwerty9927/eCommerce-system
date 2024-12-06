using System.Net;
using Fashion.Application.Dtos.Category;
using Fashion.Application.Dtos.Product;
using Fashion.Application.Interfaces.Repository;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Entities;
using Fashion.Domain.Shared;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Fashion.Application.Service;

public class CategoryService(
    ICategoryRepository categoryRepository,
    IHttpContextAccessor httpContextAccessor) : ICategoryService
{
    public async Task<BaseResponse<List<CategoryDto>>> GetAllAsync()
    {
        try
        {
            List<Category> foundCategories = await categoryRepository.GetAllAsync();
            if (foundCategories == null)
            {
                throw new BaseException
                {
                    Message = "Categories not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            List<CategoryDto> result = foundCategories.Select(c =>
            {
                var mappedCategory = new CategoryDto();
                mappedCategory.Id = c.Id;
                mappedCategory.CategoryName = c.CategoryName;
                mappedCategory.CategoryDescription = c.CategoryDescription;

                return mappedCategory;
            }).ToList();

            // List<CategoryDto> result = foundCategories.Adapt<List<CategoryDto>>();

            return new SuccessResponse<List<CategoryDto>>(result);
        }
        catch (BaseException ex)
        {
            return new BadResponse<List<CategoryDto>>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Get all failed"
            };
        }
        catch (Exception ex)
        {
            return new BadResponse<List<CategoryDto>>(default)
            {
                Message = ex.Message ?? "Get all failed"
            };
        }
    }

    public async Task<BaseResponse<CategoryDto>> GetByIdAsync(string categoryId)
    {
        try
        {
            Category foundCategory = await categoryRepository.GetByIdAsync(categoryId);
            if (foundCategory == null)
            {
                throw new BaseException
                {
                    Message = "Category not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            var mappedCategory = new CategoryDto();
            mappedCategory.Id = foundCategory.Id;
            mappedCategory.CategoryName = foundCategory.CategoryName;
            mappedCategory.CategoryDescription = foundCategory.CategoryDescription;
            mappedCategory.Products = foundCategory.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                URLImage = p.URLImage,
                Sizes = p.Sizes.Adapt<List<SizeDto>>()
            }).ToList();

            // CategoryDto result = foundCategory.Adapt<CategoryDto>();

            return new SuccessResponse<CategoryDto>(mappedCategory);
        }
        catch (BaseException ex)
        {
            return new BadResponse<CategoryDto>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Get failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> CreateAsync(CreateCategoryDto request)
    {
        try
        {
            var createdCategory = request.Adapt<Category>();

            var isCreated = await categoryRepository.CreateAsync(createdCategory);
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

    public async Task<BaseResponse<bool>> UpdateAsync(UpdateCategoryDto request)
    {
        try
        {
            Category foundCategory = await categoryRepository.GetByIdAsync(request.Id);
            if (foundCategory == null)
            {
                throw new BaseException
                {
                    Message = "Category not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            var updatedCategory = request.Adapt(foundCategory);

            var isUpdated = await categoryRepository.UpdateAsync(updatedCategory);
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
                Message = ex.Message ?? "Update failed"
            };
        }
    }
}
