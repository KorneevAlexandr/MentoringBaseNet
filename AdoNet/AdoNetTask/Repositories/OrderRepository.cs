using AdoNetTask.Connection;
using AdoNetTask.Models;
using Microsoft.Data.SqlClient;

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
            var command = new SqlCommand("SELECT * FROM Orders", connection);

            connection.Open();
            var reader = command.ExecuteReader();
            var orders = new List<Order>();

            while (reader.Read())
            {
                orders.Add(MapOrder(reader));
            }

            reader.Close();
            command.Dispose();

            return orders;
        }

        public Order GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("SELECT * FROM Orders WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            var reader = command.ExecuteReader();
            Order order = null;

            while (reader.Read())
            {
                order = MapOrder(reader);
            }

            reader.Close();
            command.Dispose();

            return order;
        }

        public void Create(Order order)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand
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
            command.Dispose();
        }

        public void Update(Order order)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand
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
            command.Dispose();
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "DELETE FROM Orders WHERE Id = (@id)"
            };

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
        }

        private static Order MapOrder(SqlDataReader reader) =>
            new Order()
            {
                Id = reader.GetInt32(0),
                Status = (OrderStatus)reader.GetInt32(1),
                CreatedDate = reader.GetDateTime(2),
                UpdatedDate = reader.GetDateTime(3),
                ProductId = reader.GetInt32(4),
            };
    }
}
