using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWithArash.Models
{
  public class Users
  {
    [Key]
    public int UserId { get; set; }
    [MaxLength(300)]
    public required string Email { get; set; }
    [MaxLength(50)]
    public required string Password { get; set; }
    public required DateTime RegisterTime { get; set; }
    public Boolean IsAdmin { get; set; }
  }
}
