using Microsoft.EntityFrameworkCore;
using Product.GrpcService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.GrpcService.Context
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
