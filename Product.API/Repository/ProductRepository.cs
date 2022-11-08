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

        public ProductList GetProduct(int id)
        {
            var products = _productContext.products.Where(x => x.ProductId == id).FirstOrDefault();
            if (products == null)
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
            var productList = _productContext.products.FromSqlRaw("exec GetProductsByCategoryAndSubCategory {0},{1}", category, subcategory).ToList();
            return productList;
        }

        public List<ProductList> UpdateProductQuantity(int productId, int orderedQuantity)
        {
            var productList = _productContext.products.Where(x => x.ProductId == productId).ToList();

         
            foreach (var item in productList)
            {
                item.Quantity = item.Quantity - orderedQuantity;
            }
            
            _productContext.SaveChanges();
            return productList;
        }

        public List<ProductList> AddProductQuantity(int productId, int orderedQuantity)
        {
            var productList = _productContext.products.Where(x => x.ProductId == productId).ToList();


            foreach (var item in productList)
            {
                item.Quantity = item.Quantity + orderedQuantity;
            }

            _productContext.SaveChanges();
            return productList;
        }

        public  List<ProductList> GetProductsByOfferId(int offerId)
        {
            var couponList =  _productContext.products.Where(x => x.OfferId == offerId).ToList();
            return couponList;
        }

        public List<int> GetOffersByProductName(string productName)
        {
            var couponList = _productContext.products.Where(x => x.Title == productName).Select(x=>x.OfferId).ToList();
            return couponList;
        }

    }
}
