using OpenQA.Selenium;
using G1AutomationFramework.Utilities;
using System.Collections.Generic;

namespace G1AutomationFramework.Pages
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
                { "PersonalMenu", By.XPath("//nav//a[normalize-space()='Personal']") },
                { "BusinessMenu", By.XPath("//nav//a[normalize-space()='Business']") },
                { "FinancialWellnessMenu", By.XPath("//nav//a[normalize-space()='Financial Wellness']") },
                { "AppointmentsMenu", By.XPath("//nav//a[normalize-space()='Appointments']") },
                { "LocationsMenu", By.XPath("//nav//a[normalize-space()='Locations']") },
                { "HelpCenterMenu", By.XPath("//nav//a[normalize-space()='Help Center']") }
            };
        }

        public bool IsTopNavBarVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, _locators["TopNavBar"]);
            return _driver.FindElement(_locators["TopNavBar"]).Displayed;
        }

        public bool IsLogoVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, _locators["Logo"]);
            return _driver.FindElement(_locators["Logo"]).Displayed;
        }

        public bool IsPersonalMenuVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, _locators["PersonalMenu"]);
            return _driver.FindElement(_locators["PersonalMenu"]).Displayed;
        }

        public bool IsBusinessMenuVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, _locators["BusinessMenu"]);
            return _driver.FindElement(_locators["BusinessMenu"]).Displayed;
        }

        public bool IsFinancialWellnessMenuVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, _locators["FinancialWellnessMenu"]);
            return _driver.FindElement(_locators["FinancialWellnessMenu"]).Displayed;
        }

        public bool IsAppointmentsMenuVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, _locators["AppointmentsMenu"]);
            return _driver.FindElement(_locators["AppointmentsMenu"]).Displayed;
        }

        public bool IsLocationsMenuVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, _locators["LocationsMenu"]);
            return _driver.FindElement(_locators["LocationsMenu"]).Displayed;
        }

        public bool IsHelpCenterMenuVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, _locators["HelpCenterMenu"]);
            return _driver.FindElement(_locators["HelpCenterMenu"]).Displayed;
        }
    }
}