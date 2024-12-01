using Fashion.Application.Interfaces.Repository;
using Fashion.Domain.Entities;
using Fashion.Domain.Shared;
using Fashion.Services.repository;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Infrastructure.Data.Repository;

public class ProductRepository(ApplicationDbContext context) : RepositoryAsync<Product>(context), IProductRepository
{
    public async Task<PagingResponse<Product>> SearchAsync(SearchRequest request)
    {
        string keyWord = !string.IsNullOrWhiteSpace(request.KeyWord) ? request.KeyWord.ToLower() : "";
        List<Product> products = await Table.Where(p => p.ProductName.Contains(keyWord)
                                        && p.IsActive
                                        && p.Category.IsActive)
                                    .Skip(request.PageIndex * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync();

        int total = await Table.Where(p => p.ProductName.Contains(keyWord)
                                        && p.IsActive
                                        && p.Category.IsActive)
                                    .CountAsync();

        return new PagingResponse<Product>
        {
            Records = products,
            TotalRecord = total
        };
    }

    public async Task<Product> GetByIdAsync(string id)
    {
        Product product = await Table.Where(p => p.Id == id)
                                    .Include(p => p.Sizes).FirstOrDefaultAsync();

        return product;
    }
}
