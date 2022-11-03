using Product.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategory(int id);
        List<ProductList> GetProducts(string category, string subcategory);
        ProductList GetProduct(int id);
    }
}
