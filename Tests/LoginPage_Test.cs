using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luma_UI_Automation.Pages;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Luma_UI_Automation.Tests
{
    [TestFixture]
    public class LoginPage_Test
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;
        private LoginPage _loginPage;
        
        [SetUp]
        public async Task SetUp() {
            try {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {Headless = false});
            _page = await _browser.NewPageAsync();
            _loginPage = new LoginPage(_page);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error during setup: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public async void TearDown() {
            if (_browser != null) {
                await _browser.CloseAsync();
            }
            _playwright.Dispose();
        }

        [Test]
        public async Task ValidCredentialsLoginAsync() {
            await _loginPage.GoToLoginPageAsync();
            await _loginPage.EnterCredentialsAsync("pralicadusko93@gmail.com", "Samorejv1312!");
            await _loginPage.ClickOnLoginButtonAsync();
        }
    }
}
