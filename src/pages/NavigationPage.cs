using OpenQA.Selenium;
using AutomationFramework.Utilities;
using System.Collections.Generic;

namespace AutomationFramework.Pages
{
    public class NavigationPage
    {
        private readonly IWebDriver _driver;
        private readonly Dictionary<string, By> _locators;

        public NavigationPage(IWebDriver driver)
        {
            _driver = driver;
            _locators = new Dictionary<string, By>
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
                if (!_locators.ContainsKey(menuOption))
                {
                    return false;
                }
                WaitHelper.WaitForElementVisible(_driver, _locators[menuOption]);
                return _driver.FindElement(_locators[menuOption]).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void ClickMenuOption(string menuOption)
        {
            if (_locators.ContainsKey(menuOption))
            {
                WaitHelper.WaitForElementClickable(_driver, _locators[menuOption]);
                _driver.FindElement(_locators[menuOption]).Click();
            }
        }

        public void ClickLogo()
        {
            WaitHelper.WaitForElementClickable(_driver, _locators["Logo"]);
            _driver.FindElement(_locators["Logo"]).Click();
        }
    }
}