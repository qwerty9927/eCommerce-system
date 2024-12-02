using Fashion.Application.Interfaces.Repository;
using Fashion.Domain.Entities;
using Fashion.Services.repository;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Infrastructure.Data.Repository;

public class CategoryRepository(ApplicationDbContext context) : RepositoryAsync<Category>(context), ICategoryRepository
{
    public async Task<List<Category>> GetAllAsync()
    {
        List<Category> categories = await Table.Where(c => c.IsActive)
                                    .ToListAsync();


        return categories;
    }

    public async Task<Category> GetByNameAsync(string categoryName)
    {
        Category categories = await Table.Where(c => c.IsActive)
                                    .Include(c => c.IsActive)
                                    .FirstAsync();

        return categories;
    }
}
