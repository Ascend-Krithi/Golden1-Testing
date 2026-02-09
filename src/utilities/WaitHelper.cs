using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Golden1.Utilities
{
    public static class WaitHelper
    {
        private static readonly int DefaultTimeout = 30;

        public static void WaitForPageLoad(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void WaitForElementVisible(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeout));
            wait.Until(d => d.FindElement(locator).Displayed);
        }

        public static void WaitForElementClickable(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitForUrlToContain(IWebDriver driver, string urlPart)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeout));
            wait.Until(d => d.Url.ToLower().Contains(urlPart.ToLower()));
        }
    }
}