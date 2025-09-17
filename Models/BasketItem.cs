using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWithArash.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; } 

        // Navigation properties ( create relationship between BasketItem and Product)
        public Product? Product { get; set; } // each basket item is linked to a product

    
    }
}
