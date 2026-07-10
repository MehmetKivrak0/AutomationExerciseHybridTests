using Microsoft.Playwright;
using NUnit.Framework;
using AutomationExerciseHybridTests.Config;
using Allure.NUnit;

namespace AutomationExerciseHybridTests.Tests.UI
{
    [AllureNUnit]
    public class BaseTest
    {
        protected IPage Page { get; private set; } = null!;
        private BrowserFactory _browserFactory = null!;

        [SetUp]
        public async Task BaseSetUp()
        {
            _browserFactory = new BrowserFactory();
            Page = await _browserFactory.InitBrowserAsync();
            await Page.GotoAsync(ConfigReader.BaseUrl);
        }

        [TearDown]
        public async Task BaseTearDown()
        {
            await _browserFactory.CloseBrowserAsync();
        }
    }
}