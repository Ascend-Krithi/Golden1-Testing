using OpenQA.Selenium;
using Project1.Automation.Utilities;

namespace Project1.Automation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver Driver;

        // Locators - TO BE POPULATED FROM LOCATOR DEFINITIONS FILE
        private By Logo => By.XPath("[LOCATOR_NEEDED]");
        private By PersonalMenu => By.XPath("[LOCATOR_NEEDED]");
        private By BusinessMenu => By.XPath("[LOCATOR_NEEDED]");
        private By FinancialWellnessMenu => By.XPath("[LOCATOR_NEEDED]");
        private By AppointmentsMenu => By.XPath("[LOCATOR_NEEDED]");
        private By LocationsMenu => By.XPath("[LOCATOR_NEEDED]");
        private By HelpCenterMenu => By.XPath("[LOCATOR_NEEDED]");
        private By LoginButton => By.XPath("[LOCATOR_NEEDED]");
        private By OpenAccountButton => By.XPath("[LOCATOR_NEEDED]");
        private By HeroBanner => By.XPath("[LOCATOR_NEEDED]");

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToHomePage()
        {
            LogHelper.Info("Navigating to Golden 1 Home Page");
            Driver.Navigate().GoToUrl(ConfigReader.GetValue("BaseUrl"));
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Home Page loaded successfully");
        }

        public void VerifyHomePageLoaded()
        {
            LogHelper.Info("Verifying Home Page elements are visible");
            WaitHelper.WaitVisible(Driver, Logo, 10);
            Assert.That(Driver.FindElement(Logo).Displayed, Is.True, "Logo is not visible");
            LogHelper.Info("Home Page verification completed");
        }

        public void ClickPersonalMenu()
        {
            LogHelper.Info("Clicking Personal menu");
            WaitHelper.WaitVisible(Driver, PersonalMenu, 10);
            WaitHelper.WaitClickable(Driver, PersonalMenu, 10);
            Driver.FindElement(PersonalMenu).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Personal menu clicked successfully");
        }

        public void ClickBusinessMenu()
        {
            LogHelper.Info("Clicking Business menu");
            WaitHelper.WaitVisible(Driver, BusinessMenu, 10);
            WaitHelper.WaitClickable(Driver, BusinessMenu, 10);
            Driver.FindElement(BusinessMenu).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Business menu clicked successfully");
        }

        public void ClickFinancialWellnessMenu()
        {
            LogHelper.Info("Clicking Financial Wellness menu");
            WaitHelper.WaitVisible(Driver, FinancialWellnessMenu, 10);
            WaitHelper.WaitClickable(Driver, FinancialWellnessMenu, 10);
            Driver.FindElement(FinancialWellnessMenu).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Financial Wellness menu clicked successfully");
        }

        public void ClickLoginButton()
        {
            LogHelper.Info("Clicking Login button");
            WaitHelper.WaitVisible(Driver, LoginButton, 10);
            WaitHelper.WaitClickable(Driver, LoginButton, 10);
            Driver.FindElement(LoginButton).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Login button clicked successfully");
        }

        public void ClickOpenAccountButton()
        {
            LogHelper.Info("Clicking Open Account button");
            WaitHelper.WaitVisible(Driver, OpenAccountButton, 10);
            WaitHelper.WaitClickable(Driver, OpenAccountButton, 10);
            Driver.FindElement(OpenAccountButton).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Open Account button clicked successfully");
        }

        public bool IsTopNavigationMenuVisible()
        {
            LogHelper.Info("Checking if top navigation menu is visible");
            WaitHelper.WaitVisible(Driver, PersonalMenu, 10);
            return Driver.FindElement(PersonalMenu).Displayed &&
                   Driver.FindElement(BusinessMenu).Displayed &&
                   Driver.FindElement(FinancialWellnessMenu).Displayed;
        }
    }
}