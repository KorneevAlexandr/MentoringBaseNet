using AdoNetTask.Connection;
using AdoNetTask.Models;
using Microsoft.Data.SqlClient;

namespace AdoNetTask.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConnectionStringProvider connectionStringProvider)
        {
            _connectionString = connectionStringProvider.ConnectionString ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public IEnumerable<Product> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT * FROM Products", connection);

            connection.Open();
            var reader = command.ExecuteReader();
            var products = new List<Product>();

            while (reader.Read())
            {
                products.Add(MapProduct(reader));
            }

            reader.Close();

            return products;
        }

        public Product GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT * FROM Products WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using var reader = command.ExecuteReader();

            Product product = null;

            while (reader.Read())
            {
                product = MapProduct(reader);
            }

            return product;
        }

        public void Create(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "INSERT INTO Products VALUES (@name, @description, @weight, @height, @width, @length)"
            };

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@weight", product.Weight);
            command.Parameters.AddWithValue("@height", product.Height);
            command.Parameters.AddWithValue("@width", product.Width);
            command.Parameters.AddWithValue("@length", product.Lenght);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Update(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "UPDATE Products " +
                              "SET Name = (@name), Description = (@description), Weight = (@weight), Height = (@height), Width = (@width), Length = (@length) " +
                              "WHERE Id = (@id)"
            };

            command.Parameters.AddWithValue("@id", product.Id);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@weight", product.Weight);
            command.Parameters.AddWithValue("@height", product.Height);
            command.Parameters.AddWithValue("@width", product.Width);
            command.Parameters.AddWithValue("@length", product.Lenght);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "DELETE FROM Products WHERE Id = (@id)"
            };

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }

        private static Product MapProduct(SqlDataReader reader) =>
            new Product
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                Weight = reader.GetDouble(3),
                Height = reader.GetDouble(4),
                Width = reader.GetDouble(5),
                Lenght = reader.GetDouble(6)
            };
    }
}
