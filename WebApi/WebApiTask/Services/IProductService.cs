using WebApiTask.Models.DtoModels;

namespace WebApiTask.Services
{
    public interface IProductService : IBaseService<ProductDto>
    {
        Task<IEnumerable<ProductDto>> GetByAsync(int pageNumber, int pageSize, int? categoryId);
    }
}
