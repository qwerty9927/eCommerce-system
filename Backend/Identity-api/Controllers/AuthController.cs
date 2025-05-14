using Identity_api.Attributes;
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
    [Consumes("application/x-www-form-urlencoded")]
    [ModelValidation]
    public async Task<BaseResponse<bool>> RegisterAsync([FromForm] RegisterRequest request)
    {
        return await authService.RegisterAsync(request);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<BaseResponse<bool>> DeleteAsync(string id)
    {
        return await authService.DeleteAsync(id);
    }
}
