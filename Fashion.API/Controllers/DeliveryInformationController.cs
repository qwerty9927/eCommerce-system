using Fashion.Application.Dtos.DeliveryInformation;
using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeliveryInformationController(
    IDeliveryInformationService deliveryInformationService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(DeliveryInformationDto request)
    {
        var result = await deliveryInformationService.CreateAsync(request);

        return Ok(result);
    }
}
