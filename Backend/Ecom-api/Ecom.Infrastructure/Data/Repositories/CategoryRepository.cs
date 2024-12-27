using Ecom.Application.Interfaces.Repositories;
using Ecom.Domain.Entities;

namespace Ecom.Infrastructure.Data.Repositories;

public class CategoryRepository(ApplicationDbContext context) : RepositoryAsync<Category>(context), ICategoryRepository
{
}
