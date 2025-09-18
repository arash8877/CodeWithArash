using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWithArash.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public  BasketItem BasketItem { get; set; }
        public int Quantity { get; set; }
        public decimal GetTotalPrice ()
        {
            return BasketItem.Price * Quantity;
        }
    
    }
}
