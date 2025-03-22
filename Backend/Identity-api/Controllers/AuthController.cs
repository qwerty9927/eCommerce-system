using Identity_api.Common;
using Identity_api.Dtos;
using Identity_api.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<BaseResponse<bool>> RegisterAsync([FromBody] RegisterRequest request)
    {
        return await authService.RegisterAsync(request);
    }

    [Authorize]
    [HttpDelete]
    public async Task<BaseResponse<bool>> DeleteAsync([FromQuery] string id)
    {
        return await authService.DeleteAsync(id);
    }
}