using Fashion.Domain.Entities;
using Fashion.Services.repository;

namespace Fashion.Application.Interfaces.Repository;

public interface IPaymentProfileRepository : IRepositoryAsync<PaymentProfile>
{
    Task<List<PaymentProfile>> GetByUserIdAsync(string userId);
}
