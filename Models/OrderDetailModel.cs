using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeWithArash.Models
{
  public class OrderDetailModel
  {
    [Key]
    public int OrderDetailId { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public decimal Price { get; set; }


    public OrderModel Order { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
  

        



  }
}
