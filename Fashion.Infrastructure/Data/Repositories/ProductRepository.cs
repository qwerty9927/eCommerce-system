using Fashion.Application.Interfaces.Repository;
using Fashion.Domain.Entities;
using Fashion.Services.repository;

namespace Fashion.Infrastructure.Data.Repository;

public class ProductRepository(ApplicationDbContext context) : RepositoryAsync<Product>(context), IProductRepository
{

}
