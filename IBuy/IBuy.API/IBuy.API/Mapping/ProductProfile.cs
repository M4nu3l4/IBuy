using AutoMapper;
using IBuy.API.DTOs;
using IBuy.API.Models;

namespace IBuy.API.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Product -> ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : ""));

            // CreateProductDto -> Product
            CreateMap<CreateProductDto, Product>();

            // UpdateProductDto -> Product
            CreateMap<UpdateProductDto, Product>();

            // Product -> UpdateProductDto 
            CreateMap<Product, UpdateProductDto>();
        }
    }
}


