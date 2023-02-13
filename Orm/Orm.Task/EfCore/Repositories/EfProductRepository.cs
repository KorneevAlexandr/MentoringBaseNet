using Microsoft.EntityFrameworkCore;
using Orm.Task.Interfaces.Repositories;
using Orm.Task.Models;

namespace Orm.Task.EfCore.Repositories
{
    public class EfProductRepository : EfRepository<Product>, IProductRepository, IRepository<Product>
    {
        public EfProductRepository(EfCoreDataContext context) 
            : base(context)
        { }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
