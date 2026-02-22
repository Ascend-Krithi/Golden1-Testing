using OpenQA.Selenium;
using Golden1.AutomationFramework.Utilities;

namespace Golden1.AutomationFramework.Pages
{
    public class HomePage : BasePage
    {
        // Locators - These should be loaded from locators.json
        private readonly By _checkingMenuLocator = By.XPath("//a[text()='Checking']");
        private readonly By _savingsMenuLocator = By.XPath("//a[text()='Savings']");
        private readonly By _loansMenuLocator = By.XPath("//a[text()='Loans']");

        public HomePage(IWebDriver driver) : base(driver)
        {
            LogHelper.LogInfo("HomePage initialized");
        }

        public void NavigateToHomePage()
        {
            string homeUrl = ConfigReader.GetBaseUrl();
            NavigateToUrl(homeUrl);
            LogHelper.LogInfo("Navigated to Home Page");
        }

        public void ClickCheckingMenu()
        {
            ClickElement(_checkingMenuLocator, "Checking Menu");
            LogHelper.LogInfo("Clicked on Checking Menu");
        }

        public void ClickSavingsMenu()
        {
            ClickElement(_savingsMenuLocator, "Savings Menu");
            LogHelper.LogInfo("Clicked on Savings Menu");
        }

        public void ClickLoansMenu()
        {
            ClickElement(_loansMenuLocator, "Loans Menu");
            LogHelper.LogInfo("Clicked on Loans Menu");
        }

        public bool IsCheckingMenuDisplayed()
        {
            return IsElementDisplayed(_checkingMenuLocator, "Checking Menu");
        }
    }
}