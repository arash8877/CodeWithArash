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
    public Product? Product { get; set; }
    public Category? Category { get; set; }
  }
}
