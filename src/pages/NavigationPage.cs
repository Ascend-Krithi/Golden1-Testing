using OpenQA.Selenium;
using System;

namespace Golden1.Pages
{
    public class NavigationPage
    {
        private readonly IWebDriver _driver;
        private readonly LocatorLibrary _locators;

        public NavigationPage(IWebDriver driver)
        {
            _driver = driver;
            _locators = new LocatorLibrary();
        }

        public bool IsTopNavBarVisible()
        {
            try
            {
                var navElement = WaitHelper.WaitForElementVisible(_driver, _locators.GetLocator("NavigationLocators", "TopNavBar"));
                return navElement != null && navElement.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsLogoVisible()
        {
            try
            {
                var logoElement = WaitHelper.WaitForElementVisible(_driver, _locators.GetLocator("NavigationLocators", "Logo"));
                return logoElement != null && logoElement.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsMenuItemVisible(string menuName)
        {
            try
            {
                string locatorKey = menuName.Replace(" ", "") + "Menu";
                var menuElement = WaitHelper.WaitForElementVisible(_driver, _locators.GetLocator("NavigationLocators", locatorKey));
                return menuElement != null && menuElement.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool HasPageErrors()
        {
            try
            {
                var errorElements = _driver.FindElements(By.XPath("//div[contains(@class, 'error')] | //div[contains(@class, 'broken')]"));
                return errorElements.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}