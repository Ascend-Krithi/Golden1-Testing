using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Golden1.Tests.Utilities
{
    public static class WaitHelper
    {
        private const int DefaultTimeoutSeconds = 30;

        public static void WaitForPageLoad(IWebDriver driver, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void WaitForElementVisible(IWebDriver driver, IWebElement element, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d => element.Displayed);
        }

        public static void WaitForElementClickable(IWebDriver driver, By locator, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitForElementPresent(IWebDriver driver, By locator, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }
    }
}