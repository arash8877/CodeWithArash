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
            return View(_context.Categories); 
        }
        

    }
}
