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
        public async Task<HomePage> LogoutAsync()
        {
            await _page.ClickAsync("a[href='/logout']");
            return this;
        }
        public async Task<SignupLoginPage> GoToSignupLoginAsync()
        {
            await _page.ClickAsync("a[href='/login']");
            return new SignupLoginPage(_page);
        }
        public async Task<bool> SearchProductAndCheckResultsAsync(string productName)
        {
            await _page.ClickAsync("a[href='/products']");
            await _page.FillAsync("#search_product", productName);
            await _page.ClickAsync("#submit_search");

            var resultsCount = await _page.Locator(".productinfo.text-center").CountAsync();
            return resultsCount > 0;
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