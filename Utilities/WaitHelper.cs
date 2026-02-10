using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Project1.Automation.Utilities
{
    public static class WaitHelper
    {
        /// <summary>
        /// Waits for element to be visible
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="locator">Element locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>WebElement when visible</returns>
        public static IWebElement WaitVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                LogHelper.Error($"Element not visible within {timeoutInSeconds} seconds: {locator}");
                throw;
            }
        }

        /// <summary>
        /// Waits for element to be clickable
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="locator">Element locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>WebElement when clickable</returns>
        public static IWebElement WaitClickable(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException)
            {
                LogHelper.Error($"Element not clickable within {timeoutInSeconds} seconds: {locator}");
                throw;
            }
        }

        /// <summary>
        /// Waits for page to load completely
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                LogHelper.Info("Page loaded completely");
            }
            catch (WebDriverTimeoutException)
            {
                LogHelper.Error($"Page did not load within {timeoutInSeconds} seconds");
                throw;
            }
        }

        /// <summary>
        /// Waits for element to exist in DOM
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="locator">Element locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>WebElement when exists</returns>
        public static IWebElement WaitExists(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (WebDriverTimeoutException)
            {
                LogHelper.Error($"Element does not exist within {timeoutInSeconds} seconds: {locator}");
                throw;
            }
        }
    }
}