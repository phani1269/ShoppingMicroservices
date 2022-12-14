using Product.GrpcService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.GrpcService.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductCategory> GetProductCategories();
        Task<ProductCategory> GetProductCategory(int id);
        List<ProductList> GetProducts(string category, string subcategory);
        ProductList GetProduct(int id);
        List<ProductList> GetProductsByOfferId(int offerId);
        List<int> GetOffersByProductName(string productName);
        List<ProductList> UpdateProductQuantity(int productId, int orderedQuantity);
        List<ProductList> AddProductQuantity(int productId, int orderedQuantity);
    }
}
