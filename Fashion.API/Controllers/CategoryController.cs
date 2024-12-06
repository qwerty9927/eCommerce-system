using Fashion.Application.Dtos.Category;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(string categoryId)
    {
        var result = await categoryService.GetByIdAsync(categoryId);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCategoryDto request)
    {
        var result = await categoryService.CreateAsync(request);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateCategoryDto request)
    {
        var result = await categoryService.UpdateAsync(request);

        return Ok(result);
    }
}
