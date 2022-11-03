using Microsoft.EntityFrameworkCore;
using ShoppingCart.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Context
{
    public class CartContext : DbContext
    {
        public CartContext()
        {

        }

        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {
        }
        public DbSet<CartList> cartLists { get; set; }
        public DbSet<CartItems> cartItems { get; set; }
    }
}
