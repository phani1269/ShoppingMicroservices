using AutoMapper;
using Product.API.Models;
using Product.GrpcService.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.MappperProfile
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<ProductCategory, CategoryResponse>().ReverseMap();
            CreateMap<Offer, OfferResponse>().ReverseMap();
        }
    }
}
