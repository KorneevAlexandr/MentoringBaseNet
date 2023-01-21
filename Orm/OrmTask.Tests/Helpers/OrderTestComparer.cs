using Orm.Task.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmTask.Tests.Helpers
{
    public class OrderTestComparer : IEqualityComparer<Order>
    {
        public bool Equals(Order? x, Order? y)
        {
            return x.UpdatedDate.Equals(y.UpdatedDate) && x.CreatedDate.Equals(y.CreatedDate) && x.ProductId == y.ProductId && x.Status == y.Status;
        }

        public int GetHashCode([DisallowNull] Order obj)
        {
            return (int)obj.Status;
        }
    }
}
