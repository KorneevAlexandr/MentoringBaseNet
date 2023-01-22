using WebApiTask.Models.DbModels;

namespace WebApiTask.Services
{
    public interface IProductService : IBaseService<Product>
    {
        Task<IEnumerable<Product>> GetByAsync(int pageNumber, int pageSize, int? categoryId);
    }
}
