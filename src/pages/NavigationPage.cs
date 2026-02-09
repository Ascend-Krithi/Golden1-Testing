using OpenQA.Selenium;
using AutomationFramework.Utilities;

namespace AutomationFramework.Pages
{
    public class NavigationPage
    {
        private readonly IWebDriver _driver;

        // Locators from Locator Library
        private By TopNavBar => By.CssSelector("header nav");
        private By Logo => By.CssSelector("header .logo img");
        private By PersonalMenu => By.XPath("//nav//a[normalize-space()='Personal']");
        private By BusinessMenu => By.XPath("//nav//a[normalize-space()='Business']");
        private By FinancialWellnessMenu => By.XPath("//nav//a[normalize-space()='Financial Wellness']");
        private By AppointmentsMenu => By.XPath("//nav//a[normalize-space()='Appointments']");
        private By LocationsMenu => By.XPath("//nav//a[normalize-space()='Locations']");
        private By MembershipMenu => By.XPath("//nav//a[normalize-space()='Membership']");
        private By HelpCenterMenu => By.XPath("//nav//a[normalize-space()='Help Center']");

        public NavigationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsTopNavBarVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, TopNavBar);
            return _driver.FindElement(TopNavBar).Displayed;
        }

        public bool IsLogoVisible()
        {
            WaitHelper.WaitForElementVisible(_driver, Logo);
            return _driver.FindElement(Logo).Displayed;
        }

        public bool IsMenuOptionVisible(string menuOption)
        {
            By menuLocator = menuOption switch
            {
                "Personal" => PersonalMenu,
                "Business" => BusinessMenu,
                "Financial Wellness" => FinancialWellnessMenu,
                "Appointments" => AppointmentsMenu,
                "Locations" => LocationsMenu,
                "Membership" => MembershipMenu,
                "Help Center" => HelpCenterMenu,
                _ => throw new System.ArgumentException($"Unknown menu option: {menuOption}")
            };

            WaitHelper.WaitForElementVisible(_driver, menuLocator);
            return _driver.FindElement(menuLocator).Displayed;
        }

        public void ClickMenuOption(string menuOption)
        {
            By menuLocator = menuOption switch
            {
                "Personal" => PersonalMenu,
                "Business" => BusinessMenu,
                "Financial Wellness" => FinancialWellnessMenu,
                "Appointments" => AppointmentsMenu,
                "Locations" => LocationsMenu,
                "Membership" => MembershipMenu,
                "Help Center" => HelpCenterMenu,
                _ => throw new System.ArgumentException($"Unknown menu option: {menuOption}")
            };

            WaitHelper.WaitForElementClickable(_driver, menuLocator);
            _driver.FindElement(menuLocator).Click();
        }
    }
}