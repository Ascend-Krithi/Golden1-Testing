using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Golden1.AutomationFramework.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private const int DefaultTimeoutInSeconds = 30;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
        }

        public void WaitForElementToBeVisible(By locator)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToBeClickable(By locator)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitForElementToExist(By locator)
        {
            _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public void WaitForPageLoad()
        {
            _wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForTextToBePresentInElement(By locator, string text)
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public bool WaitForElementToBeInvisible(By locator, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}