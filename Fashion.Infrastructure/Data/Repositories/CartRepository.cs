using Fashion.Application.Interfaces.Repository;
using Fashion.Domain.Entities;
using Fashion.Services.repository;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Infrastructure.Data.Repository;

public class CartRepository(ApplicationDbContext context) : RepositoryAsync<Cart>(context), ICartRepository
{
    public new async Task<Cart> GetByIdAsync(string id)
    {
        return await Table
            .Where(cart => cart.Id == id)
            .Include(c => c.CartDetails)
            .ThenInclude(cd => cd.Product)
            .FirstAsync();
    }

    public async Task<Cart> GetByUserIdAsync(string userId)
    {
        return await Table
            .Where(cart => cart.UserId == userId && cart.IsActive)
            .Include(c => c.CartDetails)
            .ThenInclude(cd => cd.Product)
            .Include(c => c.CartDetails)
            .ThenInclude(cd => cd.Size)
            .FirstAsync();
    }
}
