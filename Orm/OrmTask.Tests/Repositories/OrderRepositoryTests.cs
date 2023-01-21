using FluentAssertions;
using NUnit.Framework;
using Orm.Task.Interfaces.Repositories;
using Orm.Task.Models;
using OrmTask.Tests.Helpers;

namespace OrmTask.Tests.Repositories
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            DatabaseHelper.FullCleanup();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            DatabaseHelper.FullCleanup();
        }

        public static IEnumerable<object> Repositories => new List<object>
        {
            DatabaseHelper.OrderRepository,
            DatabaseHelper.EfOrderRepository
        };

        private static readonly List<Order> Orders = new()
        {
            new Order { CreatedDate = new DateTime(2000, 1, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.Arrived },
            new Order { CreatedDate = new DateTime(2000, 1, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.NotStarted },
            new Order { CreatedDate = new DateTime(2000, 2, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.Loading },
            new Order { CreatedDate = new DateTime(2000, 2, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.Cancelled },
            new Order { CreatedDate = new DateTime(2000, 3, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.Done },
            new Order { CreatedDate = new DateTime(2000, 3, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.InProgress },
            new Order { CreatedDate = new DateTime(2001, 1, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.Arrived },
            new Order { CreatedDate = new DateTime(2001, 1, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.NotStarted },
            new Order { CreatedDate = new DateTime(2001, 2, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.Loading },
            new Order { CreatedDate = new DateTime(2001, 2, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.Cancelled },
            new Order { CreatedDate = new DateTime(2001, 3, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.Done },
            new Order { CreatedDate = new DateTime(2001, 3, 1), UpdatedDate = DateTime.Today, Status = OrderStatus.InProgress }
        };

        private static IEnumerable<object> GetByParameters => new List<object>
        {
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[0], Orders[6] }, OrderStatus.Arrived, null, 1, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[1] }, OrderStatus.NotStarted, 2000, null, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[2] }, OrderStatus.Loading, 2000, 2, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[3], Orders[9] }, OrderStatus.Cancelled, null, null, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { }, OrderStatus.Done, 1999, 10, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[5], Orders[11] }, OrderStatus.InProgress, null, 3, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { }, null, 1999, null, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[0], Orders[1], Orders[2], Orders[3], Orders[4], Orders[5] }, null, 2000, null, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[6], Orders[7], Orders[8], Orders[9], Orders[10], Orders[11] }, null, 2001, null, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[0], Orders[1] }, null, 2000, 1, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[8], Orders[9] }, null, 2001, 2, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { Orders[4], Orders[5], Orders[10], Orders[11] }, null, null, 3, null },
            new object[] { DatabaseHelper.OrderRepository, new List<Order> { }, null, null, null, -1 },
            new object[] { DatabaseHelper.OrderRepository, Orders, null, null, null, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[0], Orders[6] }, OrderStatus.Arrived, null, 1, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[1] }, OrderStatus.NotStarted, 2000, null, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[2] }, OrderStatus.Loading, 2000, 2, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[3], Orders[9] }, OrderStatus.Cancelled, null, null, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { }, OrderStatus.Done, 1999, 10, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[5], Orders[11] }, OrderStatus.InProgress, null, 3, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { }, null, 1999, null, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[0], Orders[1], Orders[2], Orders[3], Orders[4], Orders[5] }, null, 2000, null, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[6], Orders[7], Orders[8], Orders[9], Orders[10], Orders[11] }, null, 2001, null, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[0], Orders[1] }, null, 2000, 1, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[8], Orders[9] }, null, 2001, 2, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { Orders[4], Orders[5], Orders[10], Orders[11] }, null, null, 3, null },
            new object[] { DatabaseHelper.EfOrderRepository, new List<Order> { }, null, null, null, -1 },
            new object[] { DatabaseHelper.EfOrderRepository, Orders, null, null, null, null }
        };

        [TestCaseSource(nameof(GetByParameters))]
        public void GetBy_WhenFilteringByProperties_ShouldReturnValues(IOrderRepository repository,
            IEnumerable<Order> expected, OrderStatus? status, int? year, int? month, int? productId)
        {
            // Arrange
            var setupedProductId = SetupProducts().First();

            foreach (var order in Orders)
            {
                order.ProductId = setupedProductId;
                repository.Create(order);
            }

            // Act
            var actual = repository.GetBy(status, month, year, productId);

            // Assert
            expected.Should().BeEquivalentTo(actual, x => x.Excluding(o => o.Id));
        }

        [TestCaseSource(nameof(GetByParameters))]
        public void BulkDelete_WhenFilteringByProperties_ShouldDeleted(IOrderRepository repository,
            IEnumerable<Order> deleted, OrderStatus? status, int? year, int? month, int? productId)
        {
            // Arrange
            var setupedProductId = SetupProducts().First();

            foreach (var order in Orders)
            {
                order.ProductId = setupedProductId;
                repository.Create(order);
            }

            // Act
            repository.BulkDelete(status, month, year, productId);

            // Assert
            var allOrders = repository.GetAll();
            var actual = Orders.Except(allOrders, new OrderTestComparer());

            deleted.Should().BeEquivalentTo(actual, x => x.Excluding(o => o.Id));
        }

        [TestCaseSource(nameof(Repositories))]
        public void Create_WhenCreateCollection_ShouldReturnCreatedOrders(IOrderRepository repository)
        {
            // Arrange
            var productId = SetupProducts().First();
            var orders = new List<Order>
            {
                new Order { CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, Status = OrderStatus.Done, ProductId = productId },
                new Order { CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, Status = OrderStatus.Done, ProductId = productId },
                new Order { CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, Status = OrderStatus.Done, ProductId = productId },
            };

            // Act
            foreach (var order in orders)
            {
                repository.Create(order);
            }

            // Assert
            var actual = repository.GetAll();

            orders.Should().BeEquivalentTo(actual, c => c.Excluding(x => x.Id));
        }

        [TestCaseSource(nameof(Repositories))]
        public void Update_WhenUpdateSeveralProperties_ShouldReturnUpdatedOrder(IOrderRepository repository)
        {
            // Arrange
            var productIds = SetupProducts(2);
            var order = new Order { CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Status = OrderStatus.Done, ProductId = productIds.First() };
            var updatedOrder = new Order { CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, Status = OrderStatus.Loading, ProductId = productIds.Last() };

            repository.Create(order);
            updatedOrder.Id = repository.GetAll().ToList().Last().Id;

            // Act
            repository.Update(updatedOrder);

            // Assert
            var actual = repository.GetById(updatedOrder.Id);

            updatedOrder.Should().BeEquivalentTo(actual);
        }

        [TestCaseSource(nameof(Repositories))]
        public void Delete_WhenExistOrder_ShouldDeleteOrder(IOrderRepository repository)
        {
            // Arrange
            var productId = SetupProducts().First();
            var order = new Order { CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, Status = OrderStatus.Loading, ProductId = productId };

            repository.Create(order);
            order.Id = repository.GetAll().ToList().Last().Id;

            // Act
            repository.Delete(order.Id);

            // Assert
            var actual = repository.GetAll();

            actual.Should().BeEmpty();
        }

        private static IEnumerable<int> SetupProducts(int count = 1)
        {
            var productRepository = DatabaseHelper.ProductRepository;

            for (int i = 0; i < count; i++)
            {
                productRepository.Create(new Product { Name = "Test", Description = "Test2" });
            }

            var products = productRepository.GetAll();

            return products.Select(x => x.Id);
        }
    }
}
