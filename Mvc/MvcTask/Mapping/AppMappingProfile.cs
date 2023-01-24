using AutoMapper;
using MvcTask.Models.DbModels;
using MvcTask.Models.DtoModels;
using MvcTask.ViewModels;

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
            CreateMap<Supplier, SupplierDto>().ReverseMap();

            CreateMap<ProductDto, ProductCreateUpdateViewModel>().ReverseMap();
        }
    }
}
