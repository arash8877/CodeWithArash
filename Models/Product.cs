using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWithArash.Models
{
    public class Product
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        // Foreign key for BasketItem
        public int BasketItemId { get; set; }

        // Navigation properties ( create relationship between Product and other tables)
        public ICollection<ProductInCategories>? ProductInCategories { get; set; } // many to many relationship between product and category
        public BasketItem? BasketItem { get; set; } // each product can be linked to one basket item
    }
}
