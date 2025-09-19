using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeWithArash.Models;
using Microsoft.EntityFrameworkCore;
using CodeWithArash.Data;

namespace CodeWithArash.Controllers;

public class ProductController : Controller
{
  private CodeWithArashContext _context;

  public ProductController(CodeWithArashContext context) // constructor with dependency injection
  {
    _context = context; // dependency injection of the database context
  }

  [Route("Group/{id}/{name}")]
  public IActionResult ShowProductByGroupId(int id, string name)
  {
    ViewData["GroupName"] = name; // pass the group name to the view using ViewData
    var products = _context.ProductInCategories
        .Where(pc => pc.CategoryId == id)
        .Include(pc => pc.Product)
        // .ThenInclude(p => p.BasketItem) // eager loading of BasketItem
        .Select(pc => pc.Product)
        .ToList(); // fetch products by category id from the database
    return View(products);
  }



}
