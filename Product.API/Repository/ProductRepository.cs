using Product.API.Context;
using Product.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;
        
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public  ProductList GetProduct(int id)
        {
            var products = _productContext.products.Where(x => x.Id == id).FirstOrDefault();
            if (products==null)
            {
                return null;
            }
            return products;
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            var categories = _productContext.productCategories.ToList();
            return categories;
        }

        public ProductCategory GetProductCategory(int id)
        {
            var productCategory = _productContext.productCategories.Where(x => x.CategoryId == id).FirstOrDefault();
           
            return productCategory;
        }

        public List<ProductList> GetProducts(string category, string subcategory)
        {
            var productList = _productContext.products.FromSqlRaw("exec GetProducts {0},{1}", category, subcategory).ToList();
            return productList;
        }
    }
}
