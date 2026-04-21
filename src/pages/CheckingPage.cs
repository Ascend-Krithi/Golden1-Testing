using OpenQA.Selenium;
using [ProjectNamespace].Utilities;

namespace [ProjectNamespace].Pages
{
    public class CheckingPage : BasePage
    {
        private readonly IWebDriver _driver;
        
        // Locators - These should match Golden1 Locators.Json
        private By FreeCheckingLinkLocator => By.XPath("//a[text()='Free Checking']");
        
        public CheckingPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
        
        public void ClickFreeCheckingLink()
        {
            LogHelper.Info("Waiting for Free Checking link to be clickable");
            WaitHelper.WaitForElementToBeClickable(_driver, FreeCheckingLinkLocator);
            IWebElement freeCheckingLink = _driver.FindElement(FreeCheckingLinkLocator);
            freeCheckingLink.Click();
            LogHelper.Info("Free Checking link clicked successfully");
        }
    }
}