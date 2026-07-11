using Microsoft.Playwright;

namespace AutomationExerciseHybridTests.Pages
{
    public class SignupLoginPage
    {
        private readonly IPage _page;

        public SignupLoginPage(IPage page)
        {
            _page = page;
        }

        public async Task<HomePage> LoginAsync(string email, string password)
        {
            await _page.FillAsync("input[data-qa='login-email']", email);
            await _page.FillAsync("input[data-qa='login-password']", password);
            await _page.ClickAsync("button[data-qa='login-button']");
            return new HomePage(_page);
        }

        public async Task<string> GetLoginErrorAsync()
        {
            return await _page.InnerTextAsync("p[style*='color: red']");
        }

        public async Task<SignupPage> GoToSignupFormAsync(string name, string email)
        {
            await _page.FillAsync("input[data-qa='signup-name']", name);
            await _page.FillAsync("input[data-qa='signup-email']", email);
            return new SignupPage(_page);
        }
    }
}