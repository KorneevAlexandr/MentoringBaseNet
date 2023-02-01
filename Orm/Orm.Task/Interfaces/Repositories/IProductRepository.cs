using Orm.Task.Models;

namespace Orm.Task.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
