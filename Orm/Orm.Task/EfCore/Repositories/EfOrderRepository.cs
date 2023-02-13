using Orm.Task.Interfaces.Repositories;
using Orm.Task.Models;
using System.Linq;

namespace Orm.Task.EfCore.Repositories
{
    public class EfOrderRepository : EfRepository<Order>, IOrderRepository, IRepository<Order>
    {
        public EfOrderRepository(EfCoreDataContext context) 
            : base(context)
        { }

        public IQueryable<Order> GetBy(OrderStatus? status = null, int? month = null, int? year = null, int? productId = null)
        {
            var query = GetAll();

            if (status.HasValue)
            {
                query = query.Where(x => x.Status.Equals(status.Value));
            }
            if (month.HasValue)
            {
                query = query.Where(x => x.CreatedDate.Month.Equals(month.Value));
            }
            if (year.HasValue)
            {
                query = query.Where(x => x.CreatedDate.Year.Equals(year.Value));
            }
            if (productId.HasValue)
            {
                query = query.Where(x => x.ProductId.Equals(productId));
            }

            return query;
        }

        public void BulkDelete(OrderStatus? status = null, int? month = null, int? year = null, int? productId = null)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var orders = GetBy(status, month, year, productId);
                _dbSet.RemoveRange(orders);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch
            { }
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
