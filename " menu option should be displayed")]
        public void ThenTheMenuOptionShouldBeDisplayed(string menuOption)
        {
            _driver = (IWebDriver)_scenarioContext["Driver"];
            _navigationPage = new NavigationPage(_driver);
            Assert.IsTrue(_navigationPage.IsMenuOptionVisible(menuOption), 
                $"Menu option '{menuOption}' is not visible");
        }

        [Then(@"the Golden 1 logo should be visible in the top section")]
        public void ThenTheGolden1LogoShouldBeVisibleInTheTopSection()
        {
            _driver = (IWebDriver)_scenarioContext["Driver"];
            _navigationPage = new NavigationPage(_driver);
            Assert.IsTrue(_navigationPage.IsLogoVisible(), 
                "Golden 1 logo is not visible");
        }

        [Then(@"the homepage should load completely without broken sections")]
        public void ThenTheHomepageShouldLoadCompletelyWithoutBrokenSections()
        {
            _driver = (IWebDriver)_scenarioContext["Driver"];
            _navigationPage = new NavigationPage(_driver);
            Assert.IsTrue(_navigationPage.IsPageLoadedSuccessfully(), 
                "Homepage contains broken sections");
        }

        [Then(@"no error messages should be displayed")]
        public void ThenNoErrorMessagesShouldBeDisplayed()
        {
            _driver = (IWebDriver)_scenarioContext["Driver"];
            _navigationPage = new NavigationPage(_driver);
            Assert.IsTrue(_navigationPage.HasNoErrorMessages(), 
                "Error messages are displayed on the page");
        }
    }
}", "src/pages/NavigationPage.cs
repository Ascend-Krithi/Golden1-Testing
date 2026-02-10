using OpenQA.Selenium;
using AutomationFramework.Utilities;
using System;
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

        public bool IsNavigationMenuVisible()
        {
            try
            {
                WaitHelper.WaitForElementVisible(_driver, _locators["TopNavBar"]);
                IWebElement navMenu = _driver.FindElement(_locators["TopNavBar"]);
                return navMenu.Displayed;
            }
            catch (Exception)
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
                IWebElement menuElement = _driver.FindElement(_locators[menuOption]);
                return menuElement.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsLogoVisible()
        {
            try
            {
                WaitHelper.WaitForElementVisible(_driver, _locators["Logo"]);
                IWebElement logo = _driver.FindElement(_locators["Logo"]);
                return logo.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsPageLoadedSuccessfully()
        {
            try
            {
                WaitHelper.WaitForPageLoad(_driver);
                return _driver.FindElements(By.CssSelector("body")).Count > 0 &&
                       !_driver.PageSource.Contains("404") &&
                       !_driver.PageSource.Contains("500") &&
                       !_driver.PageSource.Contains("Error");
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool HasNoErrorMessages()
        {
            try
            {
                string pageSource = _driver.PageSource.ToLower();
                return !pageSource.Contains("error") &&
                       !pageSource.Contains("404") &&
                       !pageSource.Contains("500") &&
                       !pageSource.Contains("exception");
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClickMenuOption(string menuOption)
        {
            if (_locators.ContainsKey(menuOption))
            {
                WaitHelper.WaitForElementClickable(_driver, _locators[menuOption]);
                IWebElement menuElement = _driver.FindElement(_locators[menuOption]);
                menuElement.Click();
            }
        }
    }
}