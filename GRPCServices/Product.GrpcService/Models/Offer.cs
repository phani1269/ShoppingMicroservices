using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.GrpcService.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        public string Title { get; set; }
        public int Discount { get; set; }
    }
}
