using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponController(
    ICouponService couponService) : ControllerBase
{

}
