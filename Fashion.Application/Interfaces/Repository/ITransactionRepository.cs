using Fashion.Domain.Entities;
using Fashion.Services.repository;

namespace Fashion.Application.Interfaces.Repository;

public interface ITransactionRepository : IRepositoryAsync<Transaction>
{
    Task<Transaction> GetByOrderId(string orderId);
}
