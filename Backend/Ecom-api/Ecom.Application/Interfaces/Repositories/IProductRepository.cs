using Ecom.Domain.Entities;
using Ecom.Domain.Shared;

namespace Ecom.Application.Interfaces.Repositories;

public interface IProductRepository : IRepositoryAsync<Product>
{
    Task<PagingResponse<Product>> SearchAsync(SearchRequest request);
    new Task<Product> GetByIdAsync(string id);
    new Task<List<Product>> GetAllAsync();
}
