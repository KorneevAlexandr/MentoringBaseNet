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

		public override async Task CreateAsync(ProductDto entity)
		{
			var dbItem = _mapper.Map<ProductDto, Product>(entity);
            dbItem.Supplier = null;
            dbItem.Category = null;

			await _dbSet.AddAsync(dbItem);
			await _context.SaveChangesAsync();
		}

		public override async Task UpdateAsync(ProductDto entity)
		{
			var dbItem = _mapper.Map<ProductDto, Product>(entity);
			dbItem.Supplier = null;
			dbItem.Category = null;

			_dbSet.Update(dbItem);
			await _context.SaveChangesAsync();
		}
	}
}
