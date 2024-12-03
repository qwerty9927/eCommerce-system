using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fashion.Presentation.Models;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Shared;
using Mapster;

namespace Fashion.Presentation.Controllers;

public class ShopController(
    ICategoryService categoryService,
    IProductService productService
) : Controller
{
    public async Task<IActionResult> Index()
    {
        var productPaging = await productService.SearchAsync(new SearchRequest
        {
            PageSize = 10
        });

        var categories = await categoryService.GetAllAsync();

        ViewBag.ProductPaging = productPaging.Data.Adapt<PagingResponseModel<ProductModel>>();
        ViewBag.Categories = categories.Data.Adapt<List<CategoryModel>>();

        return View();
    }

    [HttpGet("shop/{id}")]
    public async Task<IActionResult> Detail(string id)
    {
        var product = await productService.GetByIdAsync(id);

        ViewBag.Product = product.Data.Adapt<ProductModel>();

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
