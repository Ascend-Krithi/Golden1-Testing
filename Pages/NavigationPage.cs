using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    public class NavigationPage : BasePage
    {
        public NavigationPage(IWebDriver driver) : base(driver) { }

        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");

        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        public void OpenHome()
        {
            LogHelper.Info($"Opening Golden1 homepage: {ConfigReader.BaseUrl}");
            NavigateTo(ConfigReader.BaseUrl);
            HandleCookieBanner();
        }

        private void HandleCookieBanner()
        {
            try
            {
                if (IsDisplayed(CookieBanner, 5))
                {
                    Click(AcceptCookiesButton);
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch { }
        }

        public bool IsTopNavigationVisible() =>
            IsDisplayed(MenuContainer) && IsDisplayed(TopTabsContainer);

        // 🔥 FINAL NAVIGATION FLOW (page-based navigation, not hover)
        public void NavigateToSubMenu(string mainMenu, string subMenu)
        {
            LogHelper.Info($"Navigating to main menu page: {mainMenu}");

            var mainLocator = By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{mainMenu}']");
            WaitHelper.WaitVisible(Driver, mainLocator, 10);
            Click(mainLocator);

            WaitForPageLoad();

            LogHelper.Info($"Selecting page link: {subMenu}");

            var subLocator = By.XPath($"//a[normalize-space()='{subMenu}']");
            WaitHelper.WaitVisible(Driver, subLocator, 15);
            Click(subLocator);

            WaitForPageLoad();
        }

        public bool VerifyUrlContains(string expectedUrlPart)
        {
            var currentUrl = GetCurrentUrl();
            bool contains = currentUrl.Contains(expectedUrlPart);

            if (contains)
                LogHelper.Info($"URL contains expected value: {expectedUrlPart}");
            else
                LogHelper.Error($"URL mismatch. Expected: {expectedUrlPart}, Actual: {currentUrl}");

            return contains;
        }

        // ✅ ADD THIS METHOD (required by your Step file)
        public List<string> GetMainMenuItems()
        {
            LogHelper.Info("Reading main menu items from navigation");

            var menuElements = Driver.FindElements(By.XPath("//a[contains(@class,'nav-item-link')]"));

            var menus = menuElements
                .Where(e => e.Displayed && !string.IsNullOrWhiteSpace(e.Text))
                .Select(e => e.Text.Trim())
                .Distinct()
                .ToList();

            LogHelper.Info($"Main menus detected: {string.Join(", ", menus)}");

            return menus;
        }
    }
}
