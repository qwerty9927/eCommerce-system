using Ecom.Application.Interfaces.Repositories;
using Ecom.Domain.Entities;
using Ecom.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Infrastructure.Data.Repositories;

public class ProductRepository(ApplicationDbContext context) : RepositoryAsync<Product>(context), IProductRepository
{
    public async Task<PagingResponse<Product>> SearchAsync(SearchRequest request)
    {
        string keyWord = !string.IsNullOrWhiteSpace(request.KeyWord) ? request.KeyWord.ToLower() : "";
        List<Product> products = await Table.Where(p => p.ProductName.Contains(keyWord)
                                                        && !p.IsDeleted)
            .Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
    
        int total = await Table.Where(p => p.ProductName.Contains(keyWord)
                                           && !p.IsDeleted)
            .CountAsync();
    
        return new PagingResponse<Product>
        {
            Records = products,
            TotalRecord = total
        };
    }
    
    public new async Task<Product> GetByIdAsync(Guid id)
    {
        Product? product = await Table.Where(p => p.Id == id)
            .Include(p => p.ProductOptionSets)
            .FirstOrDefaultAsync();

        return product;
    }
}
