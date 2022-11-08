using Microsoft.EntityFrameworkCore;
using Product.GrpcService.Models;


namespace Product.GrpcService.Context
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
