using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWithArash.Models
{
  public class ProductDetailsViewModel
  {
    public Product Product { get; set; }
    public List<Category> Categories { get; set; }

  }
}
