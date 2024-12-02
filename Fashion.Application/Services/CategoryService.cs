using System.Net;
using Fashion.Application.Dtos.Category;
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

            List<CategoryDto> result = foundCategories.Adapt<List<CategoryDto>>();

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

    public async Task<BaseResponse<CategoryDto>> GetByNameAsync(string categoryName)
    {
        try
        {
            Category foundCategory = await categoryRepository.GetByNameAsync(categoryName);
            if (foundCategory == null)
            {
                throw new BaseException
                {
                    Message = "Category not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            CategoryDto result = foundCategory.Adapt<CategoryDto>();

            return new SuccessResponse<CategoryDto>(result);
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
}
