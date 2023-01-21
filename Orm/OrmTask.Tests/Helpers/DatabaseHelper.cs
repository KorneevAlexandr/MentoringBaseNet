using LinqToDB;
using Microsoft.Data.SqlClient;
using Orm.Task.Interfaces.Repositories;
using Orm.Task.LinqToDb;
using Orm.Task.LinqToDb.Repositories;
using System.Transactions;

namespace OrmTask.Tests.Helpers
{
    public static class DatabaseHelper
    {
        private static readonly LinqToDbDataContext LinqToDbContext = 
            new LinqToDbDataContext(Contstants.ProviderName, Contstants.ConnectionString);

        public static IOrderRepository OrderRepository => new OrderRepository(LinqToDbContext);

        public static IProductRepository ProductRepository => new ProductRepository(LinqToDbContext);

        public static void FullCleanup()
        {
            using var transactionScope = new TransactionScope();
            using var connection = new SqlConnection(Contstants.ConnectionString);
            using var command = new SqlCommand("DELETE FROM Orders; DELETE FROM Products", connection);

            connection.Open();
            command.ExecuteNonQuery();
            transactionScope.Complete();
        }
    }
}