using Microsoft.EntityFrameworkCore;
using Product.API.Models;


namespace Product.API.Context
{
    public class ProductContext :DbContext
    {
        public ProductContext()
        {

        }

        public ProductContext( DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<ProductList> products { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }

    }
}
