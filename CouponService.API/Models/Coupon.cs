using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CouponService.API.Models
{
    public class Coupon
    {
        [Key]
        public int couponId { get; set; }
        public string couponCode { get; set; }
        public decimal discountAmount { get; set; }
    }
}
