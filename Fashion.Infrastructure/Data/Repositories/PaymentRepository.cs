using Fashion.Application.Interfaces.Repository;
using Fashion.Domain.Entities;
using Fashion.Services.repository;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Infrastructure.Data.Repository;

public class PaymentProfileRepository(ApplicationDbContext context) : RepositoryAsync<PaymentProfile>(context), IPaymentProfileRepository
{
    public async Task<List<PaymentProfile>> GetByUserIdAsync(string userId)
    {
        return await Table.Where(p => p.UserId == userId).ToListAsync();
    }
}
