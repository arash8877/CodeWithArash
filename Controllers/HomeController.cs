using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeWithArash.Models;

namespace CodeWithArash.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ContactUs()
    {
        return View();
    }

    [Route("contact-us")] // this attribute decorates the action method, so that it can be accessed via /contact-us URL
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
