using Ecom.Application.Dtos.Product;
using Ecom.Application.Interfaces.Services;
using Ecom.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
	[HttpGet]
	public async Task<BaseResponse<ProductDto>> GetById([FromQuery] string id)
	{
		return await productService.GetByIdAsync(id);
	}
}
