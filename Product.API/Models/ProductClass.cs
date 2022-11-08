using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Models
{
    public class ProductClass
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ProductCategory productCategory { get; set; } 

        public Offer productOffer { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageName { get; set; } = string.Empty;
    }
}
