using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Golden1.Automation.Framework.Helpers
{
    public static class WaitHelper
    {
        public static void WaitForElementToBeVisible(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Element not visible within {timeoutInSeconds} seconds: {locator}");
                throw new TimeoutException($"Element not visible: {locator}", ex);
            }
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Element not clickable within {timeoutInSeconds} seconds: {locator}");
                throw new TimeoutException($"Element not clickable: {locator}", ex);
            }
        }

        public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Page did not load within {timeoutInSeconds} seconds");
                throw new TimeoutException("Page load timeout", ex);
            }
        }

        public static bool WaitForElementToDisappear(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (WebDriverTimeoutException)
            {
                LogHelper.Warning($"Element still visible after {timeoutInSeconds} seconds: {locator}");
                return false;
            }
        }

        public static void WaitForElementToExist(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Element does not exist within {timeoutInSeconds} seconds: {locator}");
                throw new TimeoutException($"Element does not exist: {locator}", ex);
            }
        }
    }
}