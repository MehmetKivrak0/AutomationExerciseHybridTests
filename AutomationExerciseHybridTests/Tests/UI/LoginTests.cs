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

        [Test]
        public async Task ValidLogin_ShouldShowLoggedInUsername()
        {
            string uniqueEmail = $"testuser{DateTime.Now.Ticks}@test.com";
            string name = "TestKullanici";
            string password = "Test1234!";

            var homePage = new HomePage(Page);
            var signupLoginPage = await homePage.GoToSignupLoginAsync();

            var signupPage = await signupLoginPage.GoToSignupFormAsync(name, uniqueEmail);
            homePage = await signupPage.CreateAccountAsync(name, uniqueEmail, password);

            // Kayıt sonrası otomatik login oluyor, önce çıkış yapalım
            homePage = await homePage.LogoutAsync();

            // Şimdi az önce oluşturduğumuz hesapla gerçek login akışını test edelim
            signupLoginPage = await homePage.GoToSignupLoginAsync();
            homePage = await signupLoginPage.LoginAsync(uniqueEmail, password);

            bool isLoggedIn = await homePage.IsLoggedInAsUserAsync(name);

            Assert.That(isLoggedIn, Is.True);
        }
    }
}