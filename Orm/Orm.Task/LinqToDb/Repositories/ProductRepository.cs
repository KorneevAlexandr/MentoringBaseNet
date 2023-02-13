using LinqToDB;
using Orm.Task.Interfaces.Repositories;
using Orm.Task.Models;
using System.Linq;

namespace Orm.Task.LinqToDb.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository, IRepository<Product>
    {
        public ProductRepository(LinqToDbDataContext context) 
            : base(context)
        { }

        public void Update(Product product)
        {
            GetAll().Where(x => x.Id == product.Id)
                .Set(x => x.Name, product.Name)
                .Set(x => x.Description, product.Description)
                .Set(x => x.Width, product.Width)
                .Set(x => x.Length, product.Length)
                .Set(x => x.Height, product.Height)
                .Set(x => x.Weight, product.Weight)
                .Update();
        }
    }
}
