using AdoNetTask.Connection;
using AdoNetTask.Models;
using AdoNetTask.Repositories;
using AdoNetTask.Tests.Helpers;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AdoNetTask.Tests.Repositories
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

        [Test]
        public void Create_WhenCreateCollection_ShouldReturnCreatedOrders()
        {
            // Arrange
            var productId = SetupProducts().First();
            var orders = new List<Order>
            {
                new Order { CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, Status = OrderStatus.Done, ProductId = productId },
                new Order { CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, Status = OrderStatus.Done, ProductId = productId },
                new Order { CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, Status = OrderStatus.Done, ProductId = productId },
            };

            var repository = new OrderRepository(DatabaseHelper.ConnectionProvider);

            // Act
            foreach (var order in orders)
            {
                repository.Create(order);
            }

            // Assert
            var actual = repository.GetAll();

            orders.Should().BeEquivalentTo(actual, c => c.Excluding(x => x.Id));
        }

        [Test]
        public void Update_WhenUpdateSeveralProperties_ShouldReturnUpdatedOrder()
        {
            // Arrange
            var productIds = SetupProducts(2);
            var order = new Order { CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Status = OrderStatus.Done, ProductId = productIds.First() };
            var updatedOrder = new Order { CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, Status = OrderStatus.Loading, ProductId = productIds.Last() };

            var repository = new OrderRepository(DatabaseHelper.ConnectionProvider);

            repository.Create(order);
            updatedOrder.Id = repository.GetAll().Last().Id;

            // Act
            repository.Update(updatedOrder);

            // Assert
            var actual = repository.GetById(updatedOrder.Id);

            updatedOrder.Should().BeEquivalentTo(actual);
        }

        private static IEnumerable<int> SetupProducts(int count = 1)
        {
            var productRepository = new ProductRepository(DatabaseHelper.ConnectionProvider);

            for (int i = 0; i < count; i++)
            {
                productRepository.Create(new Product { Name = "Test", Description = "Test2" });
            }

            var products = productRepository.GetAll();

            return products.Select(x => x.Id);
        }
    }
}
