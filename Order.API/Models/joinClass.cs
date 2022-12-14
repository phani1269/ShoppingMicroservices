using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Models
{
    public class joinClass
    {
        [Key]
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
     //   public int PaymentId { get; set; }
        public bool PaymentConfirmation { get; set; }

        public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("dd MMMM yyyy hh mm ss");
        public int ItemsId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
