using OpenQA.Selenium;
using [ProjectNamespace].Utilities;

namespace [ProjectNamespace].Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver _driver;
        
        // Locators - These should match Golden1 Locators.Json
        private By CheckingMenuLocator => By.XPath("//a[text()='Checking']");
        
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
        
        public void ClickCheckingMenu()
        {
            LogHelper.Info("Waiting for Checking menu to be clickable");
            WaitHelper.WaitForElementToBeClickable(_driver, CheckingMenuLocator);
            IWebElement checkingMenu = _driver.FindElement(CheckingMenuLocator);
            checkingMenu.Click();
            LogHelper.Info("Checking menu clicked successfully");
        }
    }
}