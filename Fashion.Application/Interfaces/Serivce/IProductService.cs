using Fashion.Entities;

namespace Fashion.Application.Interfaces.Service;

public interface IProductService
{
    Task<bool> CreateAsync(Product product);

    Task<IList<Product>> GetAsync();
}
