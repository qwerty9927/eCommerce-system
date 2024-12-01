using Fashion.Application.Dtos.Product;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Constants;
using Fashion.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost("search")]
    public async Task<IActionResult> SearchAsync(SearchRequest request)
    {
        var result = await productService.SearchAsync(request);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var result = await productService.GetByIdAsync(id);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateProduct request)
    {
        var result = await productService.CreateAsync(request);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateProduct request)
    {
        var result = await productService.UpdateAsync(request);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var result = await productService.DeleteAsync(id);

        return Ok(result);
    }
}
