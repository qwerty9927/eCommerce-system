using Fashion.Application.Dtos.Category;
using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface ICategoryService
{
    Task<BaseResponse<List<CategoryDto>>> GetAllAsync();
    Task<BaseResponse<CategoryDto>> GetByNameAsync(string categoryName);
}
