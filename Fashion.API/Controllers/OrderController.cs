using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderController(
    IOrderService OrderService) : ControllerBase
{

}
