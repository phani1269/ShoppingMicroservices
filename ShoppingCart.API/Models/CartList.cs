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
        public string CreatedOn { get; set; } 
        public List<CartItems> Items { get; set; } = new List<CartItems>();

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }
    }
}
