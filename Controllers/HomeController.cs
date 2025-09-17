using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeWithArash.Models;
using CodeWithArash.Data;

namespace CodeWithArash.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private CodeWithArashContext _context;

    public HomeController(ILogger<HomeController> logger, CodeWithArashContext context) // constructor with dependency injection
    {
        _logger = logger;
        _context = context; // dependency injection of the database context
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList(); // fetch all products from the database
        return View(products); // pass the list of products to the view
    }

    public IActionResult ProductDetails(int id)
    {
        return null;
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
