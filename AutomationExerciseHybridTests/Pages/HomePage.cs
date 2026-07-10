using Microsoft.Playwright;

namespace AutomationExerciseHybridTests.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task<SignupLoginPage> GoToSignupLoginAsync()
        {
            await _page.ClickAsync("a[href='/login']");
            return new SignupLoginPage(_page);
        }

        public async Task<HomePage> GoToProductsAsync()
        {
            await _page.ClickAsync("a[href='/products']");
            return this;
        }

        public async Task<bool> IsLoggedInAsUserAsync(string username)
        {
            return await _page.IsVisibleAsync($"text=Logged in as {username}");
        }
    }
}