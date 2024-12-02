using Fashion.Application.Dtos.Account;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterAccount request)
    {
        var result = await accountService.RegisterAsync(request);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginAccount request)
    {
        var result = await accountService.LoginAsync(request);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPost("role/create")]
    public async Task<IActionResult> CreateRoleAsync(string roleName)
    {
        var result = await accountService.CreateRoleAsync(roleName);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPost]
    public async Task<IActionResult> CreateAccountAsync(CreateAccount request)
    {
        var result = await accountService.CreateAccountAsync(request);

        return Ok(result);
    }

    [Authorize(Roles = $"{RoleConstant.Admin},{RoleConstant.User}")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateAccount request)
    {
        var result = await accountService.UpdateAsync(request);

        return Ok(result);
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var result = await accountService.DeleteAsync(id);

        return Ok(result);
    }
}
