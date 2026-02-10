using OpenQA.Selenium;
using Project1.Automation.Utilities;

namespace Project1.Automation.Pages
{
    public class PersonalPage
    {
        private readonly IWebDriver Driver;

        // Locators - TO BE POPULATED FROM LOCATOR DEFINITIONS FILE
        private By PageHeading => By.XPath("[LOCATOR_NEEDED]");
        private By CheckingSubmenu => By.XPath("[LOCATOR_NEEDED]");
        private By SavingsSubmenu => By.XPath("[LOCATOR_NEEDED]");
        private By LoansSubmenu => By.XPath("[LOCATOR_NEEDED]");
        private By CreditCardsSubmenu => By.XPath("[LOCATOR_NEEDED]");

        public PersonalPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void VerifyPersonalPageLoaded()
        {
            LogHelper.Info("Verifying Personal Page is loaded");
            WaitHelper.WaitVisible(Driver, PageHeading, 10);
            Assert.That(Driver.FindElement(PageHeading).Displayed, Is.True, "Personal Page heading is not visible");
            LogHelper.Info("Personal Page loaded successfully");
        }

        public void ClickCheckingSubmenu()
        {
            LogHelper.Info("Clicking Checking submenu");
            WaitHelper.WaitVisible(Driver, CheckingSubmenu, 10);
            WaitHelper.WaitClickable(Driver, CheckingSubmenu, 10);
            Driver.FindElement(CheckingSubmenu).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Checking submenu clicked successfully");
        }

        public void ClickSavingsSubmenu()
        {
            LogHelper.Info("Clicking Savings submenu");
            WaitHelper.WaitVisible(Driver, SavingsSubmenu, 10);
            WaitHelper.WaitClickable(Driver, SavingsSubmenu, 10);
            Driver.FindElement(SavingsSubmenu).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Savings submenu clicked successfully");
        }

        public void ClickLoansSubmenu()
        {
            LogHelper.Info("Clicking Loans submenu");
            WaitHelper.WaitVisible(Driver, LoansSubmenu, 10);
            WaitHelper.WaitClickable(Driver, LoansSubmenu, 10);
            Driver.FindElement(LoansSubmenu).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Loans submenu clicked successfully");
        }

        public bool AreSubmenuOptionsVisible()
        {
            LogHelper.Info("Verifying submenu options are visible");
            WaitHelper.WaitVisible(Driver, CheckingSubmenu, 10);
            return Driver.FindElement(CheckingSubmenu).Displayed &&
                   Driver.FindElement(SavingsSubmenu).Displayed;
        }
    }
}