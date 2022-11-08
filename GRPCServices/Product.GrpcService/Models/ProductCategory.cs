using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.GrpcService.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }

        public string Category { get; set; } 
        public string SubCategory { get; set; }
       // public virtual ICollection<ProductList> Products { get; set; }

    }
}
