using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Product.GrpcService.Protos;
using Product.GrpcService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.GrpcService.Services
{
    public class ProductService : ProductProtoService.ProductProtoServiceBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICouponRepository couponRepository, ILogger<ProductService> logger, IMapper mapper)
        {
            _productRepository = productRepository;
            _couponRepository = couponRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CategoryResponse> GetProductCategories(GetCategoryRequest request, ServerCallContext context)
        {
            var category = await _productRepository.GetProductCategory(request.CategoryId);
            if (category == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"category with categoryid ={request.CategoryId} is not found."));
            }
            _logger.LogInformation("category is retrieved for  categoryId : {categoryId}," +
                " category : {category}, subCategory:{subCategory}",
                category.CategoryId,category.Category,category.SubCategory );

            var categoryResponse = _mapper.Map<CategoryResponse>(category);

            return categoryResponse;
        }
        public override async Task<OfferResponse> GetProductOffer(GetOfferRequest request, ServerCallContext context)
        {
            var offer = await _couponRepository.GetOfferDetails(request.OfferId);
            if (offer == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with offerId ={request.OfferId} is not found."));
            }
            _logger.LogInformation("Discount is retrieved for  offerId : {offerId}," +
               " Title  : {Title}, Discount :{Discount}", offer.OfferId,offer.Title,offer.Discount);

            return _mapper.Map<OfferResponse>(offer);
        }
    }
}
