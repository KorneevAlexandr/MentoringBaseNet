using FluentAssertions;
using NUnit.Framework;
using Orm.Task.Interfaces.Repositories;
using Orm.Task.Models;
using OrmTask.Tests.Helpers;

namespace OrmTask.Tests.Repositories
{
    [TestFixture]
    public class ProductRepositoryTests
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
            DatabaseHelper.ProductRepository,
            DatabaseHelper.EfProductRepository
        };

        [TestCaseSource(nameof(Repositories))]
        public void Create_WhenCreateCollection_ShouldReturnCreatedProducts(IProductRepository repository)
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Description = "P1", Name = "Pa", Height = 1, Length = 1, Weight = 1, Width = 1 },
                new Product { Description = "P2", Name = "Pb", Height = 2, Length = 2, Weight = 2, Width = 2 }
            };

            // Act
            foreach (var product in products)
            {
                repository.Create(product);
            }

            // Assert
            var actual = repository.GetAll();

            products.Should().BeEquivalentTo(actual, c => c.Excluding(x => x.Id));
        }

        [TestCaseSource(nameof(Repositories))]
        public void Update_WhenUpdateSeveralProperties_ShouldReturnUpdatedProduct(IProductRepository repository)
        {
            // Arrange
            var product = new Product { Description = "P1", Name = "P2", Height = 1, Length = 1, Weight = 1, Width = 1 };
            var updatedProduct = new Product { Description = "A", Name = "B", Height = 2, Length = 2, Weight = 2, Width = 2 };

            repository.Create(product);
            updatedProduct.Id = repository.GetAll().ToList().Last().Id;

            // Act
            repository.Update(updatedProduct);

            // Assert
            var actual = repository.GetById(updatedProduct.Id);

            updatedProduct.Should().BeEquivalentTo(actual);
        }

        [TestCaseSource(nameof(Repositories))]
        public void Delete_WhenExistProduct_ShouldDeletedProduct(IProductRepository repository)
        {
            // Arrange
            var product = new Product { Description = "P1", Name = "P2", Height = 1, Length = 1, Weight = 1, Width = 1 };

            repository.Create(product);
            product.Id = repository.GetAll().ToList().Last().Id;

            // Act
            repository.Delete(product.Id);

            // Assert
            var actual = repository.GetAll();

            actual.Should().BeEmpty();
        }
    }
}
