using AutoMapper;
using BrainboxApi.DTOs;
using BrainboxApi.DTOs.Carts;
using BrainboxApi.Entity;

namespace BrainboxApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductDto, Product>();
            CreateMap<AddToCartDto, Cart>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<UpdateCartDto, Cart>();
            CreateMap<CreateCartDto, Cart>();
        }
    }
}
