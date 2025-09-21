using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CodeWithArash.Data;
using CodeWithArash.Models;

namespace CodeWithArash.Pages.Admin
{
    public class AddModel : PageModel
    {
        private CodeWithArashContext _context;

        public AddModel(CodeWithArashContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            var item = new BasketItem()
            {
                Price = Product.Price,
                QuantityInStock = Product.QuantityInStock
            };
            _context.Add(item);
            _context.SaveChanges();

            var pro = new Product()
            {
                Name = Product.Name,
                BasketItem = item,
                Description = Product.Description,
                
            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.BasketItemId = pro.Id;
            _context.SaveChanges();

            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    pro.Id + Path.GetExtension(Product.Picture.FileName));
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }


            return RedirectToPage("Index");
        }
    }
}
