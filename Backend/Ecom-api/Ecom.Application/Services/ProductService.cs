using Ecom.Application.Interfaces.Repositories;
using Ecom.Application.Interfaces.Services;
using Ecom.Domain.Shared;

namespace Ecom.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
   
}
