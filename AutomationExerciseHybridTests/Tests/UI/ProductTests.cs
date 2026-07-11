using NUnit.Framework;
using AutomationExerciseHybridTests.Pages;

namespace AutomationExerciseHybridTests.Tests.UI
{
    public class ProductTests : BaseTest
    {
        [TestCase("Dress")]
        [TestCase("Jeans")]
        [TestCase("Top")]
        [TestCase("Saree")]
        public async Task SearchProduct_ShouldReturnResults(string productName)
        {
            var homePage = new HomePage(Page);

            bool hasResults = await homePage.SearchProductAndCheckResultsAsync(productName);

            Assert.That(hasResults, Is.True, $"'{productName}' araması için sonuç bulunamadı");
        }
    }
}