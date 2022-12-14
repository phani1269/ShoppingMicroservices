using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Models
{
    public class joinclass
    {
        [Key]
        public int CartId { get; set; }
        public string UserName { get; set; }
        public bool Ordered { get; set; } = false;
        public string CreatedOn { get; set; } = string.Empty;
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
