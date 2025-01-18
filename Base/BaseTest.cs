using Luma_UI_Automation.Pages;
using Microsoft.Playwright;
using NUnit.Framework;


namespace Luma_UI_Automation.Base
{
    // Base class for all tests, providing setup and teardown functionality
    public abstract class BaseTest
    {
        // Playwright instance for browser automation
        protected IPlaywright _playwright;
        protected IBrowser _browser;
        protected IPage _page;
        protected LoginPage _loginPage;
        protected HomePage _homePage;
        
                
        [SetUp]
        public async Task SetUp() {
            try {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {Headless = false});
            _page = await _browser.NewPageAsync();
            _loginPage = new LoginPage(_page);
            _homePage = new HomePage(_page);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error during setup: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            try
            {
                if (_browser != null)
                {
                    await _browser.CloseAsync();
                }
                _playwright.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during teardown: {ex.Message}");
                throw;
            }

        }
    }
}
