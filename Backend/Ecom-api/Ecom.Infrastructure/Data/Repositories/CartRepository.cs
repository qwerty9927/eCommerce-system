using Ecom.Application.Interfaces.Repositories;
using Ecom.Domain.Entities;

namespace Ecom.Infrastructure.Data.Repositories;

public class CartRepository(ApplicationDbContext context) : RepositoryAsync<Cart>(context), ICartRepository
{

}
