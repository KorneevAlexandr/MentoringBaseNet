using AdoNetTask.Connection;
using AdoNetTask.Models;
using AdoNetTask.Repositories;
using Moq;

namespace AdoNetTask.Tests
{
    public class Tests
    {
        private const string ConnectionString = "Data Source=localhost; Initial Catalog = Database1; Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

        private IConnectionStringProvider _connectionStringProvider;

        [SetUp]
        public void Setup()
        {
            var connectionProviderMock = new Mock<IConnectionStringProvider>();
            connectionProviderMock.Setup(a => a.ConnectionString).Returns(ConnectionString);
            _connectionStringProvider = connectionProviderMock.Object;
        }

        [Test]
        public void CreateTest()
        {
            var order = new Order
            {
                CreatedDate= DateTime.Now,
                UpdatedDate= DateTime.Now,
                Status = OrderStatus.Arrived,
                ProductId = 1,
            };

            var repo = new OrderRepository(_connectionStringProvider);

            repo.Create(order);

            var newOrder = repo.GetAll().Last();

            Assert.That(newOrder.Status == order.Status);
        }
    }
}