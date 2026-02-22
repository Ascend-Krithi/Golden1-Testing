using OpenQA.Selenium;
using Golden1.AutomationFramework.Utilities;

namespace Golden1.AutomationFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WaitHelper WaitHelper;
        protected LogHelper LogHelper;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            WaitHelper = new WaitHelper(driver);
            LogHelper = new LogHelper();
        }

        protected void NavigateToUrl(string url)
        {
            LogHelper.LogInfo($"Navigating to URL: {url}");
            Driver.Navigate().GoToUrl(url);
            WaitHelper.WaitForPageLoad();
        }

        protected void ClickElement(By locator, string elementName)
        {
            LogHelper.LogInfo($"Clicking on element: {elementName}");
            WaitHelper.WaitForElementToBeClickable(locator);
            Driver.FindElement(locator).Click();
        }

        protected void EnterText(By locator, string text, string fieldName)
        {
            LogHelper.LogInfo($"Entering text '{text}' in field: {fieldName}");
            WaitHelper.WaitForElementToBeVisible(locator);
            var element = Driver.FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetElementText(By locator, string elementName)
        {
            LogHelper.LogInfo($"Getting text from element: {elementName}");
            WaitHelper.WaitForElementToBeVisible(locator);
            return Driver.FindElement(locator).Text;
        }

        protected bool IsElementDisplayed(By locator, string elementName)
        {
            try
            {
                WaitHelper.WaitForElementToBeVisible(locator);
                bool isDisplayed = Driver.FindElement(locator).Displayed;
                LogHelper.LogInfo($"Element '{elementName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (NoSuchElementException)
            {
                LogHelper.LogWarning($"Element '{elementName}' not found");
                return false;
            }
        }
    }
}