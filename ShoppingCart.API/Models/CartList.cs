using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Models
{
    public class CartList
    {
        [Key]
        public int CartId { get; set; }
        public string UserName { get; set; }
        public bool Ordered { get; set; } = false;
        public string OrderedOn { get; set; } = DateTime.UtcNow.ToString("dd MMMM yyyy hh mm ss");
        public virtual ICollection<CartItems> CartItems { get; set; }

    }
}
