using AutoMapper;
using IBuy.API.DTOs;
using IBuy.API.Models;

namespace IBuy.API.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
