using Luma_UI_Automation.Base;
using NUnit.Framework;

namespace Luma_UI_Automation.Tests
{
    [TestFixture]
    public class LoginPage_Test :BaseTest
    {
        [Test]
        public async Task ValidCredentialsLoginAsync() {
            await _loginPage.GoToHomePageAsync();
            await _loginPage.EnterCredentialsAsync("brobro@gmail.com", "Pass123!");
            await _loginPage.ClickOnLoginButtonAsync();
            await _homePage.VerifyHomePageTitleAsync();
            await _homePage.VerifyNavigationBarMenuAsync();
        }
    }
}
