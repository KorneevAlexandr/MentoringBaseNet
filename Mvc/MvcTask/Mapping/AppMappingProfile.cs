using AutoMapper;
using MvcTask.Models.DbModels;
using MvcTask.Models.DtoModels;

namespace MvcTask.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
