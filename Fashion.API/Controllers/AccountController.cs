using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(string email, string password)
    {
        var result = await accountService.RegisterAsync(email, password);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(string email, string password)
    {
        var result = await accountService.LoginAsync(email, password);

        return Ok(result);
    }

    [HttpPost("role/create")]
    public async Task<IActionResult> CreateRoleAsync(string roleName)
    {
        var result = await accountService.CreateRoleAsync(roleName);

        return Ok(result);
    }
}
