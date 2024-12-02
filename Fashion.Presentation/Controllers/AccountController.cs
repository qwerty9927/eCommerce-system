using Fashion.Application.Dtos.Account;
using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.Presentation.Controllers;

public class AccountController(
    IAccountService accountService
) : Controller
{
    [HttpGet("account/login")]
    public IActionResult Login()
    {
        return View();
    }

    // [Consumes("application/json")]
    // [HttpPost("account/login")]
    // public async Task<IActionResult> LoginAction(LoginAccount request)
    // {
    //     var result = await accountService.LoginAsync(request);

    //     return Ok(result);
    // }

    [HttpGet("account/register")]
    public IActionResult Register()
    {
        return View();
    }
}
