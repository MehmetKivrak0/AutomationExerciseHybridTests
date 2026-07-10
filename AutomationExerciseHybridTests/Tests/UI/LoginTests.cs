using NUnit.Framework;
using AutomationExerciseHybridTests.Pages;

namespace AutomationExerciseHybridTests.Tests.UI
{
    public class LoginTests : BaseTest
    {
        [Test]
        public async Task InvalidLogin_ShouldShowErrorMessage()
        {
            var homePage = new HomePage(Page);
            var signupLoginPage = await homePage.GoToSignupLoginAsync();

            var resultPage = await signupLoginPage.LoginAsync("gecersiz@test.com", "yanlisSifre123");

            string error = await signupLoginPage.GetLoginErrorAsync();

            Assert.That(error, Does.Contain("incorrect"));
        }
    }
}