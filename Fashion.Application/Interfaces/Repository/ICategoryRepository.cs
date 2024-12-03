using Fashion.Domain.Entities;
using Fashion.Services.repository;

namespace Fashion.Application.Interfaces.Repository;

public interface ICategoryRepository : IRepositoryAsync<Category>
{
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(string categoryId);
}
