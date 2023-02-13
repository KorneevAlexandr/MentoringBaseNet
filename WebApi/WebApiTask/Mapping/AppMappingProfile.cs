using AutoMapper;
using WebApiTask.Models.DbModels;
using WebApiTask.Models.DtoModels;

namespace WebApiTask.Mapping
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
