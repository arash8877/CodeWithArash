using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeWithArash.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("User")] // explicitly tell EF this is the FK
        public int UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public bool IsClosed { get; set; }

        // Navigation property
        public Users User { get; set; }

        // One Order → Many OrderDetails
        public List<OrderDetailModel> OrderDetails { get; set; } = new List<OrderDetailModel>();
    }
}
