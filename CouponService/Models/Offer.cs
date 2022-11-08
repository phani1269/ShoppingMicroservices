using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CouponService.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        public string Title { get; set; }
        public decimal Discount { get; set; }
    }
}
