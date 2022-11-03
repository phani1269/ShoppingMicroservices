using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Models
{
    public class CartItems
    {
        [Key]
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }

        public virtual CartList CartListobj { get; set; }


    }
}
