using Identity_api.Attributes;
using Identity_api.Common;
using Identity_api.Dtos;
using Identity_api.Interfaces.Service;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity_api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ModelValidation]
[Authorize]
public class AuthController(IAuthService authService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<BaseResponse<TokenDto>> LoginAsync([FromForm] LoginRequest request)
    {
        return await authService.LoginAsync(request);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    [Consumes("application/x-www-form-urlencoded")]
    [ModelValidation]
    public async Task<BaseResponse<bool>> RegisterAsync([FromForm] RegisterRequest request)
    {
        return await authService.RegisterAsync(request);
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<BaseResponse<TokenDto>> RefreshTokenAsync([FromBody] string refreshToken)
    {
        return await authService.RefreshTokenAsync(refreshToken);
    }

    [HttpPut("revoke-token")]
    public async Task<BaseResponse<bool>> RevokeTokenAsync([FromBody] string token)
    {
        return await authService.RevokeTokenAsync(token);
    }

    [HttpGet("{email}")]
    public async Task<BaseResponse<UserInfoDto>> GetUserInfoByEmailAsync([FromRoute] string email)
    {
        return await authService.GetUserInfoByEmailAsync(email);
    }

    [HttpDelete("{id}")]
    public async Task<BaseResponse<bool>> DeleteAsync(string id)
    {
        return await authService.DeleteAsync(id);
    }
}
