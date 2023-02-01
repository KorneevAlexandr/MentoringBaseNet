using Microsoft.EntityFrameworkCore;
using Orm.Task.Interfaces.Repositories;
using Orm.Task.Models;
using System.Linq;

namespace Orm.Task.EfCore.Repositories
{
    public class EfRepository<T> : IRepository<T>
        where T : class, IDbModel
    {
        protected readonly EfCoreDataContext _context;
        protected readonly DbSet<T> _dbSet;

        public EfRepository(EfCoreDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(T entity)
        {
            entity.Id = 0;
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
