using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodeWithArash.Models
{
  public class OrderModel
  {
    [Key]
    public int OrderId { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    public bool IsClosed { get; set; }


    public Users Users { get; set; }
  

        



  }
}
