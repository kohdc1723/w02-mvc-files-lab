using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using filewebapp.Models;

namespace filewebapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["name"] = "Dongchan Koh";
        ViewData["studentNum"] = "A01261746";
        ViewData["description"] = "Desire to be a software developer";

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
