using LinqToDB;
using Orm.Task.Interfaces.Repositories;
using Orm.Task.Models;
using System.Linq;
using System.Transactions;

namespace Orm.Task.LinqToDb.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository, IRepository<Order>
    {
        public OrderRepository(LinqToDbDataContext context) 
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
            using var transactionScope = new TransactionScope();

            try
            {
                GetBy(status, month, year, productId).Delete();
                transactionScope.Complete();
            }
            catch
            { }
        }

        public void Update(Order order)
        {
            GetAll().Where(x => x.Id == order.Id)
                .Set(x => x.CreatedDate, order.CreatedDate)
                .Set(x => x.UpdatedDate, order.UpdatedDate)
                .Set(x => x.Status, order.Status)
                .Set(x => x.ProductId, order.ProductId)
                .Update();
        }
    }
}
