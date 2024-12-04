using Fashion.Domain.Entities;
using Fashion.Services.repository;

namespace Fashion.Application.Interfaces.Repository;

public interface IOrderRepository : IRepositoryAsync<Order>
{
    Task<Order> GetOrderAsync(string id, string userId, bool isAdmin = false);
    Task<List<Order>> GetAllAsync(string? userId, bool isAdmin = false);
}
