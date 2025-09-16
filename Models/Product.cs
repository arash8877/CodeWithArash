using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWithArash.Models
{
    public class Product
    {

        public Product() // constructor, makes every new product have an empty list of categories
        {
            Categories = new List<Category>();
        }
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<Category> Categories { get; set; } // the product can be in multiple categories
    }
}