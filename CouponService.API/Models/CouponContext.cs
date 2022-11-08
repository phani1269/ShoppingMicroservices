using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponService.API.Models
{
    public class CouponContext : DbContext
    {
        public CouponContext()
        {

        }
        public CouponContext(DbContextOptions<CouponContext> options) : base(options)
        {
        }
        public DbSet<Coupon> coupons { get; set; }
        public DbSet<Offer> offers { get; set; }

    }
}
