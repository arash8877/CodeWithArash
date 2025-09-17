using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeWithArash.Models;
using Microsoft.EntityFrameworkCore; 
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
        var product = _context.Products
           .Include(p => p.BasketItem)
           .SingleOrDefault(p => p.Id == id); // fetch product by id from the database
        if (product == null)
        {
            return NotFound(); // return 404 if product not found
        }

        var categories = _context.Products
            .Where(p => p.Id == id)
            .SelectMany(c => c.ProductInCategories)
            .Select(c => c.Category)
            .ToList(); // fetch categories associated with the product

        var viewModel = new ProductDetailsViewModel()
        {
            Product = product,
            Categories = categories
        };

        return View(viewModel);
    }

    public IActionResult AddToBasket(int productId)
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
