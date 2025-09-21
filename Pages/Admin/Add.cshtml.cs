using System.IO;
using CodeWithArash.Data;
using CodeWithArash.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeWithArash.Pages.Admin
{
    public class AddModel : PageModel
    {
        private readonly CodeWithArashContext _context;

        public AddModel(CodeWithArashContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // Save BasketItem first
            var item = new BasketItem
            {
                Price = Product.Price,
                QuantityInStock = Product.QuantityInStock
            };
            _context.BasketItems.Add(item);
            _context.SaveChanges();

            // Save Product
            var pro = new Product
            {
                Name = Product.Name,
                Description = Product.Description,
                BasketItem = item
            };
            _context.Products.Add(pro);
            _context.SaveChanges();

            // Fix relationship
            pro.BasketItemId = item.Id;
            _context.SaveChanges();

            // Save picture
            if (Product.Picture?.Length > 0)
            {
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    pro.Id + Path.GetExtension(Product.Picture.FileName)
                );
                using var stream = new FileStream(filePath, FileMode.Create);
                Product.Picture.CopyTo(stream);
            }

            return RedirectToPage("Index");
        }
    }
}
