using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CartController(
    ICartService cartService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetByUserIdAsync()
    {
        var result = await cartService.GetByUserIdAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        var result = await cartService.CreateAsync();

        return Ok(result);
    }

    [HttpPut("add")]
    public async Task<IActionResult> AddItemAsync(string productId, int quantity)
    {
        var result = await cartService.AddItemAsync(productId, quantity);

        return Ok(result);
    }

    [HttpPut("remove")]
    public async Task<IActionResult> RemoveItemAsync(string cartDetailId)
    {
        var result = await cartService.RemoveItemAsync(cartDetailId);

        return Ok(result);
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummaryAsync()
    {
        var result = await cartService.GetSummaryAsync();

        return Ok(result);
    }
}
