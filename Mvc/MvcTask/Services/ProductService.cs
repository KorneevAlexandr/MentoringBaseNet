using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MvcTask.Infrastructure;
using MvcTask.Models.DbModels;
using MvcTask.Models.DtoModels;

namespace MvcTask.Services
{
    public class ProductService : BaseService<Product, ProductDto>, IProductService, IBaseService<ProductDto>
    {
        public ProductService(NorthwindDataContext context, IMapper mapper) 
            : base(context, mapper)
        { }

        public async Task<IEnumerable<ProductDto>> GetByAsync(int count)
        {
            if (count == 0)
            {
                return await GetAllAsync();
            }

            var products = await _dbSet.Take(count).Include(x => x.Category).Include(x => x.Supplier).ToListAsync();
            var mapProducts = products.Select(x => _mapper.Map<ProductDto>(x)).ToList();

            return mapProducts;
        }

        public override async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _dbSet.Include(x => x.Category).Include(x => x.Supplier).ToListAsync();
            var mapProducts = products.Select(x => _mapper.Map<ProductDto>(x)).ToList();

            return mapProducts;
        }
    }
}
