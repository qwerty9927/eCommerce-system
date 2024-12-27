using Ecom.Application.Interfaces.Repositories;
using Ecom.Domain.Entities;

namespace Ecom.Infrastructure.Data.Repositories;

public class ProductRepository(ApplicationDbContext context) : RepositoryAsync<Product>(context), IProductRepository
{
    
}
