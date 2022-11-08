using AutoMapper;
using Product.GrpcService.Models;
using Product.GrpcService.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.GrpcService.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCategory, CategoryResponse>().ReverseMap();
            CreateMap<Offer, OfferResponse>().ReverseMap();
        }

    }
}
