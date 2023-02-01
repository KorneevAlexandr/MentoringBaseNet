using LinqToDB;
using Orm.Task.Interfaces.Repositories;
using Orm.Task.Models;
using System.Linq;

namespace Orm.Task.LinqToDb.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class, IDbModel
    {
        protected readonly LinqToDbDataContext _context;

        public Repository(LinqToDbDataContext context) 
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.GetTable<T>();
        }

        public T GetById(int id)
        {
            return _context.GetTable<T>().Where(item => item.Id.Equals(id)).FirstOrDefault();
        }

        public void Create(T item)
        {
            _context.InsertWithIdentity(item);
        }

        public void Delete(int id)
        {
            GetAll().Where(x => x.Id == id).Delete();
        }
    }
}
