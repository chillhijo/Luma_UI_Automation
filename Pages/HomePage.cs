﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luma_UI_Automation.Base;
using Microsoft.Playwright;

namespace Luma_UI_Automation.Pages
{
    public class HomePage(IPage page) : BasePage(page)
    {
        protected ILocator HomePageTitle => Page.Locator("//span[@class='base']");
        protected ILocator NavigationBar => Page.Locator(".navigation");
        protected ILocator NavigationBarUl => Page.GetByRole(AriaRole.Menu);
        protected ILocator WhatsNewNavBar => Page.GetByRole(AriaRole.Presentation).GetByText("What`s New");
        protected ILocator WomenMenu => Page.GetByRole(AriaRole.Presentation).GetByText("Women");
        protected ILocator MenMenu => Page.GetByRole(AriaRole.Presentation).GetByText("Men");
        protected ILocator GearMenu => Page.GetByRole(AriaRole.Presentation).GetByText($"Gear");
        protected ILocator TrainingMenu => Page.GetByRole(AriaRole.Presentation).GetByText($"Training");
        protected ILocator SaleMenu => Page.GetByRole(AriaRole.Presentation).GetByText($"Sale");

        public async Task VerifyHomePageTitleAsync() {
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await WaitForElementAsync(HomePageTitle);
            Console.WriteLine("Home page input title: " + HomePageTitle.InputValueAsync());
            Console.WriteLine("Homepage title: " + HomePageTitle.TextContentAsync());
            await IsVisibleAsync(HomePageTitle);
            Console.WriteLine("Homepage is visible");
            await GetAndAssertTextFromElementAsync(HomePageTitle, "Home Page");
        }

        public async Task VerifyNavigationBarMenuAsync() {
            await IsVisibleAsync(WhatsNewNavBar);
            await IsVisibleAsync(WomenMenu);
            await IsVisibleAsync(MenMenu);
            await IsVisibleAsync(GearMenu);
            await IsVisibleAsync(TrainingMenu);
            await IsVisibleAsync(SaleMenu);
        }
    }
}
