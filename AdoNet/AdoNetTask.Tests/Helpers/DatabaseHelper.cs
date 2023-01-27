using AdoNetTask.Connection;
using Microsoft.Data.SqlClient;
using System.Transactions;
using static AdoNetTask.Tests.Constants;

namespace AdoNetTask.Tests.Helpers
{
    public static class DatabaseHelper
    {
        public static IConnectionStringProvider ConnectionProvider => new ConnectionStringProvider(ConnectionString);

        public static void FullCleanup()
        {
            using var transactionScope = new TransactionScope();
            using var connection = new SqlConnection(ConnectionString);
            using var command = new SqlCommand("DELETE FROM Orders; DELETE FROM Products", connection);

            connection.Open();
            command.ExecuteNonQuery();
            transactionScope.Complete();
        }
    }
}
