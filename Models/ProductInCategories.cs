using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWithArash.Models
{
    public class ProductInCategories
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        // Navigation properties ( create relationship between Product and Category)
        public required Product Product { get; set; }
        public required Category Category { get; set; }
    }
}