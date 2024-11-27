using Fashion.Application.Interfaces.Repository;
using Fashion.Application.Interfaces.Service;
using Fashion.Entities;

namespace Fashion.Application.Service;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> CreateAsync(Product product)
    {
        try
        {
            var temp = new Product { ProductName = "abc1" };
            return await _productRepository.CreateAsync(temp);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IList<Product>> GetAsync()
    {
        try
        {
            return await _productRepository.GetAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
