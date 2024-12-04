using Fashion.Application.Interfaces.Repository;
using Fashion.Domain.Entities;
using Fashion.Services.repository;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Infrastructure.Data.Repository;

public class OrderRepository(ApplicationDbContext context) : RepositoryAsync<Order>(context), IOrderRepository
{
    public async Task<Order> GetOrderAsync(string id, string userId, bool isAdmin = false)
    {
        return await Table.Where(o => (isAdmin || o.UserId == userId) && o.Id == id)
                                .Include(o => o.OrderDetails)
                                .ThenInclude(od => od.Product)
                                .FirstAsync();
    }

    public async Task<List<Order>> GetAllAsync(string? userId, bool isAdmin = false)
    {
        return await Table.Where(o => isAdmin || o.UserId == userId)
                                .Include(o => o.OrderDetails)
                                .ThenInclude(od => od.Product)
                                .ToListAsync();
    }
}
