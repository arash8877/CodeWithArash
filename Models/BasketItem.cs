using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWithArash.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public required Product Product { get; set; } // each basket item is linked to a product
        public decimal Price { get; set; }
        public int Quantity { get; set; } 
    
    }
}