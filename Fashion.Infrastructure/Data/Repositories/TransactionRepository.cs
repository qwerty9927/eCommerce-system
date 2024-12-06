using Fashion.Application.Interfaces.Repository;
using Fashion.Domain.Entities;
using Fashion.Services.repository;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Infrastructure.Data.Repository;

public class TransactionRepository(ApplicationDbContext context) : RepositoryAsync<Transaction>(context), ITransactionRepository
{
    public async Task<Transaction> GetByOrderId(string orderId)
    {
        return await Table.Where(t => t.OrderId == orderId).FirstAsync();
    }
}
