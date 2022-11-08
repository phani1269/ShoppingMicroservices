using Product.GrpcService.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.GRPCService
{
    public class ProductGRPCService
    {
        private readonly ProductProtoService.ProductProtoServiceClient _productProtoServiceClient;

        public ProductGRPCService(ProductProtoService.ProductProtoServiceClient productProtoServiceClient)
        {
            _productProtoServiceClient = productProtoServiceClient;
        }

        public CategoryResponse GetCategories(int categoryId)
        {
            var productRequest = new GetCategoryRequest { CategoryId = categoryId };

            return  _productProtoServiceClient.GetProductCategories(productRequest);
        }

        public OfferResponse GetOffers(int offerId)
        {
            var offerRequest = new GetOfferRequest { OfferId = offerId };
            return _productProtoServiceClient.GetProductOffer(offerRequest);
        }
    }
}
