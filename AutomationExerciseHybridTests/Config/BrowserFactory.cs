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

            var page = await context.NewPageAsync();

            // Reklam/tracking kaynaklarını engelle
            await page.RouteAsync("**/*", async route =>
            {
                var url = route.Request.Url;
                string[] blockedDomains = { "doubleclick.net", "googlesyndication", "google-analytics",
                                             "googletagmanager", "tod.com.tr", "facebook.net", "adservice" };

                if (blockedDomains.Any(domain => url.Contains(domain)))
                {
                    await route.AbortAsync();
                }
                else
                {
                    await route.ContinueAsync();
                }
            });

            return page;
        }

        public async Task CloseBrowserAsync()
        {
            if (_browser != null)
                await _browser.CloseAsync();

            _playwright?.Dispose();
        }
    }
}

/*  
    Selenium'dan en büyük fark buradaDikkat ettiysen her şey async/await ile yazıldı. 
    Playwright, C#'ın modern asenkron programlama yapısını native kullanıyor — 
    yani "bu işlem bitene kadar bekle ama bu sırada programın diğer kısımları donmasın" mantığı. 
    Selenium'da senkron (sıralı, bekleyerek) çalışıyorduk, Playwright'ta daha esnek bir mantık bulunmakta.        
    */
// Reklam/tracking kaynaklarını engelle