using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomationExerciseHybridTests.Pages
{
    public class SignupPage
    {
        private readonly IPage _page;

        public SignupPage(IPage page)
        {
            _page = page;
        }

        public async Task<HomePage> CreateAccountAsync(string name, string email, string password)
        {
            await _page.FillAsync("input[data-qa='signup-name']", name);
            await _page.FillAsync("input[data-qa='signup-email']", email);
            await _page.ClickAsync("button[data-qa='signup-button']");

            await _page.CheckAsync("#id_gender1");
            await _page.FillAsync("#password", password);
            await _page.SelectOptionAsync("#days", "10");
            await _page.SelectOptionAsync("#months", "5");
            await _page.SelectOptionAsync("#years", "1995");

            await _page.FillAsync("#first_name", name);
            await _page.FillAsync("#last_name", "TestUser");
            await _page.FillAsync("#address1", "Test Mahallesi 1");

            // JS ile garanti seçim: option metninde "Turkey" geçeni bul, seç, change event'ini tetikle
            await _page.EvalOnSelectorAsync("#country", @"
        (select) => {
            const option = Array.from(select.options).find(o => o.text.trim().toLowerCase().includes('turkey'));
            if (option) {
                select.value = option.value;
                select.dispatchEvent(new Event('change', { bubbles: true }));
            }
        }
    ");

            await _page.FillAsync("#state", "Istanbul");
            await _page.FillAsync("#city", "Istanbul");
            await _page.FillAsync("#zipcode", "34000");
            await _page.FillAsync("#mobile_number", "5551234567");

            await _page.ClickAsync("button[data-qa='create-account']");
            await _page.ClickAsync("a[data-qa='continue-button']");

            return new HomePage(_page);
        }

    }
}
