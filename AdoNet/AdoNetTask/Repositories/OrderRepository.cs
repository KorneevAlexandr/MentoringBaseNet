using AdoNetTask.Connection;
using AdoNetTask.Models;
using AdoNetTask.QueryBuilders;
using Microsoft.Data.SqlClient;
using System.Transactions;

namespace AdoNetTask.Repositories
{
    public class OrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(IConnectionStringProvider connectionStringProvider)
        {
            _connectionString = connectionStringProvider?.ConnectionString ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public IEnumerable<Order> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT * FROM Orders", connection);

            connection.Open();
            using var reader = command.ExecuteReader();
            var orders = new List<Order>();

            while (reader.Read())
            {
                orders.Add(MapOrder(reader));
            }

            return orders;
        }

        public Order GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT * FROM Orders WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using var reader = command.ExecuteReader();
            Order order = null;

            while (reader.Read())
            {
                order = MapOrder(reader);
            }

            return order;
        }

        public IEnumerable<Order> GetBy(OrderStatus? status = null, int? month = null, int? year = null, int? productId = null)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new QueryConditionBuilder("SELECT * FROM Orders")
                .SetConnection(connection)
                .AddCondition(nameof(status), status)
                .AddCondition(nameof(productId), productId)
                .AddSpecificCondition("MONTH(CreatedDate)", nameof(month), month)
                .AddSpecificCondition("YEAR(CreatedDate)", nameof(year), year)
                .Build();

            connection.Open();
            using var reader = command.ExecuteReader();
            var orders = new List<Order>();

            while (reader.Read())
            {
                orders.Add(MapOrder(reader));
            }

            return orders;
        }

        public void Create(Order order)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "INSERT INTO Orders VALUES (@status, @createdDate, @updatedDate, @productId)"
            };

            command.Parameters.AddWithValue("@status", (int)order.Status);
            command.Parameters.AddWithValue("@createdDate", order.CreatedDate);
            command.Parameters.AddWithValue("@updatedDate", order.UpdatedDate);
            command.Parameters.AddWithValue("@productId", order.ProductId);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Update(Order order)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "UPDATE Orders " +
                              "SET Status = (@status), CreatedDate = (@createdDate), UpdatedDate = (@updatedDate), ProductId = (@productId) " +
                              "WHERE Id = (@id)"
            };

            command.Parameters.AddWithValue("@id", order.Id);
            command.Parameters.AddWithValue("@status", (int)order.Status);
            command.Parameters.AddWithValue("@createdDate", order.CreatedDate);
            command.Parameters.AddWithValue("@updatedDate", order.UpdatedDate);
            command.Parameters.AddWithValue("@productId", order.ProductId);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "DELETE FROM Orders WHERE Id = (@id)"
            };

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void BulkDelete(OrderStatus? status = null, int? month = null, int? year = null, int? productId = null)
        {
            using var transactionScope = new TransactionScope();
            using var connection = new SqlConnection(_connectionString);

            using var command = new QueryConditionBuilder("DELETE FROM Orders")
                .SetConnection(connection)
                .AddCondition(nameof(status), status)
                .AddCondition(nameof(productId), productId)
                .AddSpecificCondition("MONTH(CreatedDate)", nameof(month), month)
                .AddSpecificCondition("YEAR(CreatedDate)", nameof(year), year)
                .Build();

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                transactionScope.Complete();
            }
            catch
            {
                transactionScope.Dispose();
            }
        }

        private static Order MapOrder(SqlDataReader reader) =>
            new()
            {
                Id = reader.GetInt32(0),
                Status = (OrderStatus)reader.GetInt32(1),
                CreatedDate = reader.GetDateTime(2),
                UpdatedDate = reader.GetDateTime(3),
                ProductId = reader.GetInt32(4),
            };
    }
}
