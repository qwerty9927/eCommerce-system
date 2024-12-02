using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(
    ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await categoryService.GetAllAsync();

        return Ok(result);
    }

    // [HttpGet("")]
    // public async Task<IActionResult> GetByNameAsync(string categoryName)
    // {
    //     var result = await categoryService.GetByNameAsync(categoryName);

    //     return Ok(result);
    // }
}
