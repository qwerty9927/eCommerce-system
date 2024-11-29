using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fashion.Presentation.Models;

namespace Fashion.Presentation.Controllers;

public class ShopController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ShopController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("shop/{id}")]
    public IActionResult Detail(int id)
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
