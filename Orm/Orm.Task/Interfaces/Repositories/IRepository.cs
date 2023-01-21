using Orm.Task.Models;
using System.Linq;

namespace Orm.Task.Interfaces.Repositories
{
    public interface IRepository<T>
        where T : class, IDbModel
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        void Create(T entity);

        void Delete(int id);
    }
}
