using Fashion.Application.Interfaces.Repository;
using Fashion.Domain.Entities;
using Fashion.Services.repository;

namespace Fashion.Infrastructure.Data.Repository;

public class TransactionRepository(ApplicationDbContext context) : RepositoryAsync<Transaction>(context), ITransactionRepository
{
}
