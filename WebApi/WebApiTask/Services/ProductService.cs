using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Infrastructure;
using WebApiTask.Models.DbModels;
using WebApiTask.Models.DtoModels;

namespace WebApiTask.Services
{
    public class ProductService : BaseService<Product, ProductDto>, IProductService, IBaseService<ProductDto>
    {
        public ProductService(NorthwindDataContext context, IMapper mapper) 
            : base(context, mapper)
        { }

        public async Task<IEnumerable<ProductDto>> GetByAsync(int pageNumber = 0, int pageSize = 10, int? categoryId = null)
        {
            var query = categoryId is null ? _dbSet : _dbSet.Where(x => x.CategoryId == categoryId.Value);
            var products = await query.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
            var mapProducts = products.Select(x => _mapper.Map<ProductDto>(x)).ToList();

            return mapProducts;
        }
    }
}
