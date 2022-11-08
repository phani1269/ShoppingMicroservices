using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Models
{
    public class joinClass
    {
        [Key]
        public int PaymentId { get; set; }
        public string UserName { get; set; }
        public int TotalAmount { get; set; }
        public int orderId { get; set; }

        public int ShipingCharges { get; set; }
        public int AmountReduced { get; set; }
        public int AmountPaid { get; set; }
        public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("dd MMMM yyyy hh mm ss");
        public int PaymentMethodId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public bool Available { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
