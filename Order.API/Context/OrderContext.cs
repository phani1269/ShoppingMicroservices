using Microsoft.EntityFrameworkCore;
using Order.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        {
                
        }

        public OrderContext( DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<OrderedItems> OrderedItems { get; set; }
    }
}
