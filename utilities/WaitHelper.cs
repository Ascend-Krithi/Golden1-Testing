using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Golden1.Automation.Utilities
{
    public static class WaitHelper
    {
        private const int DefaultTimeoutInSeconds = 30;

        public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void WaitForElementVisible(IWebDriver driver, IWebElement element, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => element.Displayed);
        }

        public static void WaitForElementClickable(IWebDriver driver, IWebElement element, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => element.Displayed && element.Enabled);
        }

        public static void WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => d.FindElement(locator).Displayed);
        }

        public static void WaitForElementClickable(IWebDriver driver, By locator, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return element.Displayed && element.Enabled;
            });
        }
    }
}