using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWithArash.Data;
using CodeWithArash.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodeWithArash.Pages.Admin
{
  public class IndexModel : PageModel
  {
    private CodeWithArashContext _context;

    public IndexModel(CodeWithArashContext context)
    {
      _context = context;
    }

    public IEnumerable<Product> Products { get; set; }

    public void OnGet()
    {
      Products = _context.Products.Include(p => p.BasketItem);
    }

    public void OnPost()
    {

    }

  }
}
