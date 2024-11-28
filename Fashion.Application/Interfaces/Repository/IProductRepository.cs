using Fashion.Domain.Entities;
using Fashion.Services.repository;

namespace Fashion.Application.Interfaces.Repository;

public interface IProductRepository : IRepositoryAsync<Product>
{

}
