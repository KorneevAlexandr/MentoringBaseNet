using NUnit.Framework;
using System.Net.Http.Json;
using WebApiTask.TestClient.Models;

namespace WebApiTask.TestClient.ApiTests
{
    [TestFixture]
    public class CategoryApiTests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Constants.ApiUrl) };
        }

        [Test]
        public async Task GetAll_WhenCategoriesExists_ShouldReturnCategories()
        {
            // Arrange, Act
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("Category/getAll");

            // Assert
            Assert.IsNotEmpty(categories);
        }

        [Test]
        public async Task GetById_WhenIdExist_ShouldReturnCategory()
        {
            // Arrange
            var categoryId = 1;

            // Act
            var category = await _httpClient.GetFromJsonAsync<Category>($"Category?id={categoryId}");

            // Assert
            Assert.IsNotNull(category);
            Assert.That(categoryId, Is.EqualTo(category.CategoryId));
        }
    }
}
