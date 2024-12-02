using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderController(
    IOrderService orderService) : ControllerBase
{
    [HttpPost("create-customer")]
    public async Task<IActionResult> CreateCustomerAsync()
    {
        var result = await orderService.CreateCustomerAsync();

        return Ok(result);
    }

    [HttpPost("add-card")]
    public async Task<IActionResult> AddCardAsync([FromBody] string source)
    {
        var result = await orderService.AddCardAsync(source);

        return Ok(result);
    }

    [HttpPost("create-payment")]
    public async Task<IActionResult> CreatePaymentAsync([FromBody] int amount)
    {
        var result = await orderService.CreatePaymentAsync(amount);

        return Ok(result);
    }

    [HttpPost("confirm-payment")]
    public async Task<IActionResult> ConfirmPaymentAsync([FromBody] string paymentId)
    {
        var result = await orderService.ConfirmPaymentAsync(paymentId);

        return Ok(result);
    }

    [HttpPost("convert-to-order")]
    public async Task<IActionResult> PlaceOrderAsync()
    {
        var result = await orderService.PlaceOrderAsync();

        return Ok(result);
    }
}
