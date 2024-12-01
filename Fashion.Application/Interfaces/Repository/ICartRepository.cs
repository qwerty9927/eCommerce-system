using Fashion.Domain.Entities;
using Fashion.Services.repository;

namespace Fashion.Application.Interfaces.Repository;

public interface ICartRepository : IRepositoryAsync<Cart>
{
    Task<Cart> GetByIdAsync(string id);
    Task<Cart> GetByUserIdAsync(string userId);
}
