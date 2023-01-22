using Microsoft.EntityFrameworkCore;
using WebApiTask.Infrastructure;
using WebApiTask.Models.DbModels;

namespace WebApiTask.Services
{
    public class ProductService : BaseService<Product>, IProductService, IBaseService<Product>
    {
        public ProductService(NorthwindDataContext context) 
            : base(context)
        { }

        public async Task<IEnumerable<Product>> GetByAsync(int pageNumber = 0, int pageSize = 10, int? categoryId = null)
        {
            var query = categoryId is null ? _dbSet : _dbSet.Where(x => x.CategoryId == categoryId);
            var products = await _dbSet.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();

            return products;
        }
    }
}
