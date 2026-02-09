using OpenQA.Selenium;
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
                { "PersonalMenu", By.XPath("//nav//a[normalize-space()='Personal']") },
                { "BusinessMenu", By.XPath("//nav//a[normalize-space()='Business']") },
                { "FinancialWellnessMenu", By.XPath("//nav//a[normalize-space()='Financial Wellness']") },
                { "AppointmentsMenu", By.XPath("//nav//a[normalize-space()='Appointments']") },
                { "LocationsMenu", By.XPath("//nav//a[normalize-space()='Locations']") },
                { "MembershipMenu", By.XPath("//nav//a[normalize-space()='Membership']") },
                { "HelpCenterMenu", By.XPath("//nav//a[normalize-space()='Help Center']") },
                { "HeroBanner", By.CssSelector("section.hero") }
            };
        }

        public bool IsTopNavBarVisible()
        {
            try
            {
                WaitHelper.WaitForElementVisible(_driver, _locators["TopNavBar"]);
                return _driver.FindElement(_locators["TopNavBar"]).Displayed;
            }
            catch (NoSuchElementException)
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
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsHeroBannerVisible()
        {
            try
            {
                WaitHelper.WaitForElementVisible(_driver, _locators["HeroBanner"]);
                return _driver.FindElement(_locators["HeroBanner"]).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsMenuOptionPresent(string menuOption)
        {
            try
            {
                string locatorKey = menuOption.Replace(" ", "") + "Menu";
                if (!_locators.ContainsKey(locatorKey))
                {
                    return false;
                }
                WaitHelper.WaitForElementVisible(_driver, _locators[locatorKey]);
                return _driver.FindElement(_locators[locatorKey]).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickMenuOption(string menuOption)
        {
            string locatorKey = menuOption.Replace(" ", "") + "Menu";
            if (!_locators.ContainsKey(locatorKey))
            {
                throw new Exception($"Menu option '{menuOption}' not found in locator library");
            }
            WaitHelper.WaitForElementClickable(_driver, _locators[locatorKey]);
            _driver.FindElement(_locators[locatorKey]).Click();
        }
    }
}