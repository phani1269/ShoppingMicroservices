using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Models
{
    public class OrderedItems
    {
        [Key]
        public int ItemsId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }

    }
}
