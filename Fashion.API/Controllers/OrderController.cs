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
    public async Task<IActionResult> CreatePaymentAsync(int amount, string orderId)
    {
        var result = await orderService.CreatePaymentAsync(amount, orderId);

        return Ok(result);
    }

    [HttpPost("confirm-payment")]
    public async Task<IActionResult> ConfirmPaymentAsync([FromBody] string orderId)
    {
        var result = await orderService.ConfirmPaymentAsync(orderId);

        return Ok(result);
    }

    [HttpPost("convert-to-order")]
    public async Task<IActionResult> PlaceOrderAsync()
    {
        var result = await orderService.PlaceOrderAsync();

        return Ok(result);
    }

    [HttpPost("mock-up")]
    public async Task<IActionResult> PaymentMockupAsync([FromBody] string sourceId)
    {
        var result = await orderService.PaymentMockupAsync(sourceId);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await orderService.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("my-order")]
    public async Task<IActionResult> GetMyOrderAsync()
    {
        var result = await orderService.GetMyOrderAsync();

        return Ok(result);
    }
}
