using Microsoft.Playwright;
using NUnit.Framework;

namespace Luma_UI_Automation.Base
{
    public class BasePage(IPage page)
    {
        protected IPage Page = page;

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

        public async Task GetAndAssertTextFromElementAsync(ILocator element, string text)
        {
            var ElementText = await element.TextContentAsync();
            Assert.That(ElementText, Is.EqualTo(text));
        }

        public async Task WaitForElementAsync(ILocator element, int timeout = 10000)
        {
            await element.WaitForAsync(new LocatorWaitForOptions { Timeout = timeout });
        }
    }
}
