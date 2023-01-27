using AdoNetTask.Models;
using AdoNetTask.Repositories;
using AdoNetTask.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace AdoNetTask.Tests.Repositories
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

        [Test]
        public void Create_WhenCreateCollection_ShouldReturnCreatedProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Description = "P1", Name = "Pa", Height = 1, Lenght = 1, Weight = 1, Width = 1 },
                new Product { Description = "P2", Name = "Pb", Height = 2, Lenght = 2, Weight = 2, Width = 2 }
            };

            var repository = new ProductRepository(DatabaseHelper.ConnectionProvider);

            // Act
            foreach (var product in products)
            {
                repository.Create(product);
            }

            // Assert
            var actual = repository.GetAll();

            products.Should().BeEquivalentTo(actual, c => c.Excluding(x => x.Id));
        }

        [Test]
        public void Update_WhenUpdateSeveralProperties_ShouldReturnUpdatedProduct()
        {
            // Arrange
            var product = new Product { Description = "P1", Name = "P2", Height = 1, Lenght = 1, Weight = 1, Width = 1 };
            var updatedProduct = new Product { Description = "A", Name = "B", Height = 2, Lenght = 2, Weight = 2, Width = 2 };

            var repository = new ProductRepository(DatabaseHelper.ConnectionProvider);

            repository.Create(product);
            updatedProduct.Id = repository.GetAll().Last().Id;

            // Act
            repository.Update(updatedProduct);

            // Assert
            var actual = repository.GetById(updatedProduct.Id);

            updatedProduct.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void Delete_WhenExistProduct_ShouldDeletedProduct()
        {
            // Arrange
            var product = new Product { Description = "P1", Name = "P2", Height = 1, Lenght = 1, Weight = 1, Width = 1 };
            var repository = new ProductRepository(DatabaseHelper.ConnectionProvider);

            repository.Create(product);
            product.Id = repository.GetAll().Last().Id;

            // Act
            repository.Delete(product.Id);

            // Assert
            var actual = repository.GetAll();

            actual.Should().BeEmpty();
        }
    }
}
