using Fashion.Application.Dtos.Category;
using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface ICategoryService
{
    Task<BaseResponse<List<CategoryDto>>> GetAllAsync();
    Task<BaseResponse<CategoryDto>> GetByIdAsync(string categoryId);
    Task<BaseResponse<bool>> CreateAsync(CreateCategoryDto request);
    Task<BaseResponse<bool>> UpdateAsync(UpdateCategoryDto request);
}
