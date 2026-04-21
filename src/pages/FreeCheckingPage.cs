using OpenQA.Selenium;
using [ProjectNamespace].Utilities;

namespace [ProjectNamespace].Pages
{
    public class FreeCheckingPage : BasePage
    {
        private readonly IWebDriver _driver;
        
        // Locators for Free Checking page verification
        private By PageHeaderLocator => By.XPath("//h1[contains(text(),'Free Checking')]");
        
        public FreeCheckingPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
        
        public bool IsFreeCheckingPageDisplayed()
        {
            LogHelper.Info("Checking if Free Checking page is displayed");
            WaitHelper.WaitForElementToBeVisible(_driver, PageHeaderLocator);
            IWebElement pageHeader = _driver.FindElement(PageHeaderLocator);
            bool isDisplayed = pageHeader.Displayed;
            LogHelper.Info($"Free Checking page displayed: {isDisplayed}");
            return isDisplayed;
        }
    }
}