using OpenQA.Selenium;
using System;

namespace Golden1.Automation.Pages
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
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "TopNavBar"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
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
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "Logo"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsMenuOptionVisible(string menuOption)
        {
            try
            {
                string locatorKey = menuOption.Replace(" ", "") + "Menu";
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", locatorKey));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void ClickMenuOption(string menuOption)
        {
            string locatorKey = menuOption.Replace(" ", "") + "Menu";
            var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", locatorKey));
            WaitHelper.WaitForElementClickable(_driver, element);
            element.Click();
        }

        public bool IsPageLoadedWithoutErrors()
        {
            try
            {
                var pageSource = _driver.PageSource.ToLower();
                bool hasErrors = pageSource.Contains("error") || pageSource.Contains("404") || pageSource.Contains("500");
                return !hasErrors && _driver.FindElements(By.CssSelector("body")).Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}