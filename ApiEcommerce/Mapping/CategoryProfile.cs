using ApiEcommerce.Models;
using ApiEcommerce.Models.DTOs;
using AutoMapper;

namespace ApiEcommerce.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
