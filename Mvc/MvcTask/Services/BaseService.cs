using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MvcTask.Infrastructure;

namespace MvcTask.Services
{
    public class BaseService<TDbModel, TDtoModel> : IBaseService<TDtoModel>
        where TDbModel : class
        where TDtoModel : class
    {
        protected readonly NorthwindDataContext _context;
        protected readonly DbSet<TDbModel> _dbSet;
        protected readonly IMapper _mapper;

        public BaseService(NorthwindDataContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TDbModel>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDtoModel>> GetAllAsync()
        {
            var items = await _dbSet.ToListAsync();
            var mapItems = items.Select(x => _mapper.Map<TDbModel, TDtoModel>(x));

            return mapItems;
        }

        public async Task<TDtoModel> GetAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);
            var mapItem = _mapper.Map<TDbModel, TDtoModel>(item);

            return mapItem;
        }

        public async Task CreateAsync(TDtoModel entity)
        {
            var dbItem = _mapper.Map<TDtoModel, TDbModel>(entity);
            await _dbSet.AddAsync(dbItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TDtoModel entity)
        {
            var dbItem = _mapper.Map<TDtoModel, TDbModel>(entity);
            _dbSet.Update(dbItem);
            await _context.SaveChangesAsync();
        }
    }
}
