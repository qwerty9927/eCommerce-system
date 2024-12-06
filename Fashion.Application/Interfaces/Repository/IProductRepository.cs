using Fashion.Domain.Entities;
using Fashion.Domain.Shared;
using Fashion.Services.repository;

namespace Fashion.Application.Interfaces.Repository;

public interface IProductRepository : IRepositoryAsync<Product>
{
    Task<PagingResponse<Product>> SearchAsync(SearchRequest request, string? categoryId = null);
}
