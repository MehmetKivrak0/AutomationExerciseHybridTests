using NUnit.Framework;
using AutomationExerciseHybridTests.Api;
using Allure.NUnit;

namespace AutomationExerciseHybridTests.Tests.Api
{
    [AllureNUnit]
    public class ProductsApiTests
    {
        private ProductsApiService _productsApiService = null!;

        [SetUp]
        public void Setup()
        {
            _productsApiService = new ProductsApiService();
        }

        [Test]
        public async Task GetProductsList_ShouldReturnSuccessAndProducts()
        {
            var result = await _productsApiService.GetProductsListAsync();

            // Geçici: konsola yazdırıp gözle kontrol edelim
            TestContext.WriteLine($"Response Code: {result.ResponseCode}");
            TestContext.WriteLine($"Toplam ürün sayısı: {result.Products.Count}");
            TestContext.WriteLine($"İlk ürün: {result.Products[0].Name} - {result.Products[0].Price}");

            Assert.Multiple(() =>
            {
                Assert.That(result.ResponseCode, Is.EqualTo(200));
                Assert.That(result.Products, Is.Not.Empty);
            });
        }
        [Test]
        public async Task PostToProductsList_ShouldReturnMethodNotAllowed()
        {
            var response = await _productsApiService.PostToProductsListAsync();

            TestContext.WriteLine($"Status Code: {response.StatusCode}");
            TestContext.WriteLine($"Content: {response.Content}");

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            // Not: automationexercise.com kendi responseCode'unu 200 status ile 405 olarak body içinde döndürüyor, 
            // bu yüzden body içeriğini de kontrol edelim
            Assert.That(response.Content, Does.Contain("405"));
        }

    }
}