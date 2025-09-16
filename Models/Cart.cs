using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWithArash.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>(); // constructor, makes every new cart/basket have an empty list of CartItems
        }

        public int OrderId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public void AddItem(CartItem item)
        {
            if (CartItems.Any(i => i.BasketItem.Id == item.BasketItem.Id))
            {
                var existingItem = CartItems.First(i => i.BasketItem.Id == item.BasketItem.Id);
                existingItem.Quantity += 1;
            }
            else
            {
                CartItems.Add(item);
            }
        }
        public void RemoveItem(CartItem item)
        {
          if (CartItems.Any(i => i.BasketItem.Id == item.BasketItem.Id))
            {
                var existingItem = CartItems.First(i => i.BasketItem.Id == item.BasketItem.Id);
                if (existingItem.Quantity > 1)
                {
                    existingItem.Quantity -= 1;
                }
                else
                {
                    CartItems.Remove(existingItem);
                }
            }
        }


    
    }
}