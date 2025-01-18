using Luma_UI_Automation.Base;
using NUnit.Framework;

namespace Luma_UI_Automation.Tests
{
    [TestFixture]
    public class LoginPage_Test :BaseTest
    {
        [Test]
        public async Task ValidCredentialsLoginAsync() {
            await _loginPage.GoToLoginPageAsync();
            await _loginPage.EnterCredentialsAsync("pralicadusko93@gmail.com", "Samorejv1312!");
            await _loginPage.ClickOnLoginButtonAsync();
        }
    }
}
