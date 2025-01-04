using Microsoft.Playwright;

class Program
{
    public static async Task Main(string[] args)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://example.com");
        Console.WriteLine(await page.TitleAsync());
        await browser.CloseAsync();
    }
}
