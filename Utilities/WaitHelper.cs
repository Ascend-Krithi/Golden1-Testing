using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Golden1.Automation.Utilities
{
    /// <summary>
    /// Wait Helper utility for explicit waits
    /// DO NOT MODIFY - Framework Core File
    /// </summary>
    public static class WaitHelper
    {
        /// <summary>
        /// Waits for element to be visible
        /// </summary>
        public static IWebElement WaitVisible(IWebDriver driver, By locator, int timeoutSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Element not visible after {timeoutSeconds} seconds: {locator}");
            }
        }

        /// <summary>
        /// Waits for element to be clickable
        /// </summary>
        public static IWebElement WaitClickable(IWebDriver driver, By locator, int timeoutSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Element not clickable after {timeoutSeconds} seconds: {locator}");
            }
        }

        /// <summary>
        /// Waits for element to exist in DOM
        /// </summary>
        public static IWebElement WaitExists(IWebDriver driver, By locator, int timeoutSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                return wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Element does not exist after {timeoutSeconds} seconds: {locator}");
            }
        }

        /// <summary>
        /// Waits for element to be invisible
        /// </summary>
        public static bool WaitInvisible(IWebDriver driver, By locator, int timeoutSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for text to be present in element
        /// </summary>
        public static bool WaitTextPresent(IWebDriver driver, By locator, string text, int timeoutSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Text '{text}' not present in element after {timeoutSeconds} seconds: {locator}");
            }
        }
    }
}