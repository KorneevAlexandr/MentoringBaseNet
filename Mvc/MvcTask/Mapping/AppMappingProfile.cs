using AutoMapper;
using MvcTask.Models.DbModels;
using MvcTask.Models.DtoModels;

namespace MvcTask.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.SupplierName, c => c.MapFrom(src => src.Supplier.CompanyName))
                .ForMember(x => x.CategoryName, c => c.MapFrom(src => src.Category.CategoryName))
                .ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
