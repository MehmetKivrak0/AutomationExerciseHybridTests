using NUnit.Framework;
using AutomationExerciseHybridTests.Api;
using Allure.NUnit;

namespace AutomationExerciseHybridTests.Tests.Api
{
    [AllureNUnit]
    public class UsersApiTests
    {
        private UsersApiService _usersApiService = null!;

        [SetUp]
        public void Setup()
        {
            _usersApiService = new UsersApiService();
        }

        [Test]
        public async Task VerifyLogin_WithInvalidCredentials_ShouldReturnUserNotFound()
        {
            var result = await _usersApiService.VerifyLoginAsync("olmayan@kullanici.com", "yanlissifre");

            TestContext.WriteLine($"Response Code: {result.ResponseCode}");
            TestContext.WriteLine($"Message: {result.Message}");

            Assert.Multiple(() =>
            {
                Assert.That(result.ResponseCode, Is.EqualTo(404));
                Assert.That(result.Message, Does.Contain("not found"));
            });
        }
    }
}