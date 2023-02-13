using NUnit.Framework;
using System.Net;
using System.Net.Http.Json;
using WebApiTask.TestClient.Models;

namespace WebApiTask.TestClient.ApiTests
{
    [TestFixture]
    public class ProductApiTests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Constants.ApiUrl) };
        }

        [Test]
        public async Task GetAll_WhenProductsExists_ShouldReturnProducts()
        {
            // Arrange, Act
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("Product/getAll");

            // Assert
            Assert.IsNotEmpty(products);
        }

        [TestCase(0, 10, 1)]
        [TestCase(1, 3, 5)]
        [TestCase(0, 0, 0)]
        public async Task PaginationGet_WhenExistProducts_ShouldReturnPaginationProducts(int pageNumber, int pageSize, int categoryId)
        {
            // Arrange, Act
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>(
                $"Product/getBy?pageNumber={pageNumber}&pageSize={pageSize}&CategoryId={categoryId}");

            // Assert
            Assert.That(products.Count(), Is.LessThanOrEqualTo(pageSize));
            Assert.That(products.All(x => x.CategoryId == categoryId));
        }

        [Test]
        public async Task GetById_WhenIdExist_ShouldReturnProduct()
        {
            // Arrange
            var productId = 10;

            // Act
            var product = await _httpClient.GetFromJsonAsync<Product>($"Product?id={productId}");

            // Assert
            Assert.IsNotNull(product);
            Assert.That(productId, Is.EqualTo(product.ProductId));
        }

        [Test]
        public async Task Create_WhenModelValid_ShouldReturnSuccessResult()
        {
            // Arrange 
            var product = new Product
            {
                CategoryId = 1,
                SupplierId = 1,
                ProductName = "Test",
                QuantityPerUnit = "Test1",
                UnitPrice = 12
            };

            // Act
            var response = await _httpClient.PostAsJsonAsync("Product", product);

            // Assert
            Assert.That(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
