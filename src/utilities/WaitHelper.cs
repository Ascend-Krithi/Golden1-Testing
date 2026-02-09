using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Golden1.Utilities
{
    public static class WaitHelper
    {
        private const int DefaultTimeoutInSeconds = 30;

        public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitForElementClickable(IWebDriver driver, By locator, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}