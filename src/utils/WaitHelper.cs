using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Golden1.Utils
{
    public static class WaitHelper
    {
        private const int DefaultTimeoutInSeconds = 30;

        public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d =>
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)d;
                return js.ExecuteScript("return document.readyState").ToString().Equals("complete");
            });
        }

        public static void WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => d.FindElement(locator).Displayed);
        }

        public static void WaitForElementClickable(IWebDriver driver, By locator, int timeoutInSeconds = DefaultTimeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}