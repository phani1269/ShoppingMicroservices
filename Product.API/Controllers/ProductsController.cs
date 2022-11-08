using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.GRPCService;
using Product.API.Models;
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
        private readonly ProductGRPCService _productGRPCService;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, ProductGRPCService productGRPCService, IMapper mapper)
        {
            _productRepository = productRepository;
            _productGRPCService = productGRPCService;
            _mapper = mapper;
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
        [Route("GetProducts/{category}/{subcategory}")]
        public IActionResult GetProducts(string category, string subcategory)
        {
            var products = _productRepository.GetProducts(category, subcategory);

            var productList = new List<ProductClass>();

            foreach (var item in products)
            {
                var cat = _productGRPCService.GetCategories(item.CategoryId);
                var offerDetails = _productGRPCService.GetOffers(item.OfferId);
                var discount = _mapper.Map<Offer>(offerDetails);
                var data = new ProductClass
                {
                    ProductId = item.ProductId,
                    Description= item.Description,
                    ImageName = item.ImageName,
                    Price = item.Price- (Convert.ToDouble(offerDetails.Discount)/100)*item.Price,
                    Quantity = item.Quantity,
                    Title = item.Title,
                    productCategory = _mapper.Map<ProductCategory>(cat),
                    productOffer = discount
                };


                productList.Add(data);
               
            }
            return Ok(productList);
        }

        [HttpPost]
        [Route("UpdateProductQuantity/{productId}/{orderedQuantity}")]
        public IActionResult UpdateProductQuantity(int productId, int orderedQuantity)
        {
            return Ok(_productRepository.UpdateProductQuantity(productId,orderedQuantity));
        }
        [HttpPost]
        [Route("AddProductQuantity/{productId}/{orderedQuantity}")]
        public IActionResult AddProductQuantity(int productId, int orderedQuantity)
        {
            return Ok(_productRepository.AddProductQuantity(productId, orderedQuantity));
        }
        [HttpGet]
        [Route("GetProductsByOfferId")]
        public IActionResult GetOffersByProductName(int offerId)
        {
            return Ok(_productRepository.GetProductsByOfferId(offerId));
        }
        [HttpGet]
        [Route("GetOffersByProductName/{productName}")]
        public IActionResult GetOffersByProductName(string productName)
        {
            return Ok(_productRepository.GetOffersByProductName(productName));
        }
    }
}
