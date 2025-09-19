using System.Diagnostics;
using System.Security.Claims;
using CodeWithArash.Data;
using CodeWithArash.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeWithArash.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private CodeWithArashContext _context;
  private static Cart _cart = new Cart(); // static cart instance to hold items added to the cart

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

  [Authorize] // only authenticated users can access this action
  public IActionResult AddToBasket(int productId)
  {
    var product = _context.Products
        .Include(p => p.BasketItem)
        .SingleOrDefault(p => p.Id == productId);

    if (product != null && product.BasketItem != null)
    {
      // -------------------------------
      // 1️⃣ Add to in-memory cart (_cart)
      // -------------------------------
      var cartItem = _cart.CartItems.FirstOrDefault(ci => ci.BasketItem.Id == product.BasketItem.Id);
      if (cartItem != null)
      {
        cartItem.Quantity += 1;
      }
      else
      {
        _cart.CartItems.Add(new CartItem
        {
          BasketItem = product.BasketItem,
          Quantity = 1
        });
      }

      // -------------------------------
      // 2️⃣ Persist to database (optional)
      // -------------------------------
      int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
      var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsClosed);

      if (order != null)
      {
        var orderDetail = _context.OrderDetails
            .FirstOrDefault(od => od.OrderId == order.OrderId && od.ProductId == product.Id);

        if (orderDetail != null)
        {
          orderDetail.Count += 1;
          _context.OrderDetails.Update(orderDetail);
        }
        else
        {
          _context.OrderDetails.Add(new OrderDetailModel
          {
            OrderId = order.OrderId,
            ProductId = product.Id,
            Price = product.BasketItem.Price,
            Count = 1
          });
        }
      }
      else
      {
        order = new OrderModel
        {
          UserId = userId,
          OrderDate = DateTime.Now,
          IsClosed = false
        };
        _context.Orders.Add(order);
        _context.SaveChanges(); // Save to generate OrderId

        _context.OrderDetails.Add(new OrderDetailModel
        {
          OrderId = order.OrderId,
          ProductId = product.Id,
          Price = product.BasketItem.Price,
          Count = 1
        });
      }

      _context.SaveChanges();
    }

    return RedirectToAction("ShowBasket");
  }


  public IActionResult ShowBasket()
  {
    var cartViewModel = new CartViewModel
    {
      CartItems = _cart.CartItems,
      OrderTotal = _cart.CartItems.Sum(i => i.GetTotalPrice())
    };
    return View(cartViewModel);
  }

  public IActionResult RemoveFromBasket(int productId)
  {
    var product = _context.Products
    .Include(p => p.BasketItem)
    .SingleOrDefault(p => p.Id == productId);
    if (product != null)
    {
      var cartItem = new CartItem
      {
        BasketItem = product.BasketItem,
        Quantity = 1
      };
      _cart.RemoveItem(cartItem);
    }
    return RedirectToAction("ShowBasket");
  }


  [Route("contact-us")] // this attribute decorates the action method, so that it can be accessed via /contact-us URL
  public IActionResult ContactUs()
  {
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
