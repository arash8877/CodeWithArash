using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWithArash.Data;
using Microsoft.AspNetCore.Mvc;

namespace CodeWithArash.Models
{
    public class ProductGroupsViewComponent : ViewComponent
    {
        private CodeWithArashContext _context;
        public ProductGroupsViewComponent(CodeWithArashContext context) // constructor with dependency injection
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _context.Categories
                .Select(c => new ShowGroupViewModel
                {
                    GroupId = c.Id,
                    GroupName = c.Name,
                    ProductCount = c.ProductInCategories.Count(g => g.CategoryId == c.Id)
                }).ToList();
                
            return View(categories);
        }


    }
}
