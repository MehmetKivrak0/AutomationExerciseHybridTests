using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomationExerciseHybridTests.Config
{
    public class BrowserFactory
    {
        private IPlaywright? _playwright;
        private IBrowser? _browser;

        public async Task<IPage> InitBrowserAsync()
        {
            _playwright = await Playwright.CreateAsync();
            bool isCI = Environment.GetEnvironmentVariable("CI") == "true";
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = isCI,
                Args = new[] { "--start-maximized" }
            });

            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });



            return await context.NewPageAsync();
        }
        /* 
         Selenium'dan en büyük fark buradaDikkat ettiysen her şey async/await ile yazıldı. 
         Playwright, C#'ın modern asenkron programlama yapısını native kullanıyor — 
         yani "bu işlem bitene kadar bekle ama bu sırada programın diğer kısımları donmasın" mantığı. 
         Selenium'da senkron (sıralı, bekleyerek) çalışıyorduk, Playwright'ta daha esnek bir mantık bulunmakta.        
         */
        public async Task CloseBrowserAsync()
        {
            if (_browser != null)
                await _browser.CloseAsync();

            _playwright?.Dispose();
        }
    }
}