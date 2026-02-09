using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Golden1.Pages
{
    public class NavigationPage
    {
        private readonly IWebDriver _driver;
        private readonly Dictionary<string, By> _locators;

        public NavigationPage(IWebDriver driver)
        {
            _driver = driver;
            _locators = LoadLocators();
        }

        private Dictionary<string, By> LoadLocators()
        {
            return new Dictionary<string, By>
            {
                { "TopNavBar", By.CssSelector("header nav") },
                { "Logo", By.CssSelector("header .logo img") },
                { "Personal", By.XPath("//nav//a[normalize-space()='Personal']") },
                { "Business", By.XPath("//nav//a[normalize-space()='Business']") },
                { "Financial Wellness", By.XPath("//nav//a[normalize-space()='Financial Wellness']") },
                { "Appointments", By.XPath("//nav//a[normalize-space()='Appointments']") },
                { "Locations", By.XPath("//nav//a[normalize-space()='Locations']") },
                { "Membership", By.XPath("//nav//a[normalize-space()='Membership']") },
                { "Help Center", By.XPath("//nav//a[normalize-space()='Help Center']") }
            };
        }

        public bool IsTopNavBarVisible()
        {
            try
            {
                WaitHelper.WaitForElementVisible(_driver, _locators["TopNavBar"]);
                return _driver.FindElement(_locators["TopNavBar"]).Displayed;
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
                WaitHelper.WaitForElementVisible(_driver, _locators["Logo"]);
                return _driver.FindElement(_locators["Logo"]).Displayed;
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
                if (_locators.ContainsKey(menuOption))
                {
                    WaitHelper.WaitForElementVisible(_driver, _locators[menuOption]);
                    return _driver.FindElement(_locators[menuOption]).Displayed;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool IsPageLoadedSuccessfully()
        {
            try
            {
                WaitHelper.WaitForPageLoad(_driver);
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                string readyState = js.ExecuteScript("return document.readyState").ToString();
                return readyState.Equals("complete", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public bool HasErrorMessages()
        {
            try
            {
                var errorElements = _driver.FindElements(By.XPath("//*[contains(@class, 'error') or contains(@class, 'alert')]"));
                return errorElements.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}