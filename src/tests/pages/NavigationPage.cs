using OpenQA.Selenium;
using System;

namespace Golden1.Tests.Pages
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
            catch (NoSuchElementException)
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
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsOpenAccountButtonVisible()
        {
            try
            {
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "OpenAccountButton"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsLoginButtonVisible()
        {
            try
            {
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "LoginButton"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsPersonalMenuVisible()
        {
            try
            {
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "PersonalMenu"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsBusinessMenuVisible()
        {
            try
            {
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "BusinessMenu"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsFinancialWellnessMenuVisible()
        {
            try
            {
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "FinancialWellnessMenu"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsAppointmentsMenuVisible()
        {
            try
            {
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "AppointmentsMenu"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsLocationsMenuVisible()
        {
            try
            {
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "LocationsMenu"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsMembershipMenuVisible()
        {
            try
            {
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "MembershipMenu"));
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsHelpCenterMenuVisible()
        {
            try
            {
                var element = _driver.FindElement(_locators.GetLocator("NavigationLocators", "HelpCenterMenu"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
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
                var element = _driver.FindElement(_locators.GetLocator("HomePageLocators", "HeroBanner"));
                WaitHelper.WaitForElementVisible(_driver, element);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}