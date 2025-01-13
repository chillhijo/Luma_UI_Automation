using Microsoft.Playwright;
using NUnit.Framework;

namespace Luma_UI_Automation.Base
{
    public class BasePage
    {
        protected IPage Page;
        public BasePage(IPage page) {
            Page = page;
        }
        public static async Task ClickOnElementAsync(ILocator element)
        {
            await element.ClickAsync();
        }

        public static async Task IsVisibleAsync(ILocator element)
        {
            var isVisible = await element.IsVisibleAsync();
            Assert.That(isVisible, Is.True);
        }

        public static async Task EnterTextAsync(ILocator element, string text)
        {
            await element.FillAsync(text);
        }
    }
}
