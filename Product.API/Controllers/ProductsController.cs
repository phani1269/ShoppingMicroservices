using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetAllProductCategories")]
        public  IActionResult GetProductCategories()
        {
            return Ok(  _productRepository.GetProductCategories());
        }
        [HttpGet]
        [Route("GetProductCategoryByCategoryId/{id}")]
        public IActionResult GetProductCategoryByCategoryId(int id)
        {
            var res = _productRepository.GetProductCategory(id);
            return Ok(res);
        }
        [HttpGet]
        [Route("GetProductByProductId/{id}")]
        public IActionResult GetProductByProductId(int id)
        {
            return Ok(_productRepository.GetProduct(id));
        }
        [HttpGet]
        [Route("GetProductsByCategory")]
        public IActionResult GetProducts(string category, string subcategory)
        {
            return Ok(_productRepository.GetProducts(category,subcategory));
        }

    }
}
