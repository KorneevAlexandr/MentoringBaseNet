using Orm.Task.Models;
using System.Linq;

namespace Orm.Task.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetBy(OrderStatus? status = null, int? month = null, int? year = null, int? productId = null);

        void BulkDelete(OrderStatus? status = null, int? month = null, int? year = null, int? productId = null);

        void Update(Order order);
    }
}
