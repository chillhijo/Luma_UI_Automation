using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luma_UI_Automation.Base;
using Microsoft.Playwright;

namespace Luma_UI_Automation.Pages
{
    public class LoginPage(IPage page) : BasePage(page)
    {
        protected ILocator CustomerLoginTitle => Page.Locator(".base");
        protected ILocator EmailInputField => Page.GetByTitle("Email");
        protected ILocator PasswordInputField => Page.GetByTitle("Password");
        protected ILocator LoginButton => Page.GetByRole(AriaRole.Button, new() { Name = "Sign in" });

        public async Task GoToLoginPageAsync() {
            await Page.GotoAsync("https://magento.softwaretestingboard.com/customer/account/login");
            await Page.WaitForLoadStateAsync(LoadState.Load);
            Console.WriteLine("Login page is open!");
        }

        public async Task EnterCredentialsAsync(string username, string password) {
            await EnterTextAsync(EmailInputField, username);
            await EnterTextAsync(PasswordInputField, password);
            Console.WriteLine("Login credentials entered successfully!");
        }

        public async Task ClickOnLoginButtonAsync() {
            await ClickOnElementAsync(LoginButton);
            Console.WriteLine("Clicked on login button.");
        }
    }
}
