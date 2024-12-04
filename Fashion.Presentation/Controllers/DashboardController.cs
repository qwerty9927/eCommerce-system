using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fashion.Presentation.Models;

namespace Fashion.Presentation.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("dashboard/order")]
    public IActionResult Order()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
