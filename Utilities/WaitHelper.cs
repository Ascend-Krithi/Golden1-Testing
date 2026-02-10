using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Project1.Automation.Utilities
{
    public static class WaitHelper
    {
        /// <summary>
        /// Waits for an element to be visible
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="locator">Element locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>WebElement if found</returns>
        public static IWebElement WaitVisible(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => 
                {
                    var element = drv.FindElement(locator);
                    return element.Displayed ? element : null;
                });
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Element not visible within {timeoutInSeconds} seconds: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Checks if an element is visible without throwing exception
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="locator">Element locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>True if element is visible, false otherwise</returns>
        public static bool IsElementVisible(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(drv => drv.FindElement(locator).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for page to load completely
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page did not load within {timeoutInSeconds} seconds: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Waits for an element to be clickable
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="locator">Element locator</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>WebElement if clickable</returns>
        public static IWebElement WaitClickable(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Element not clickable within {timeoutInSeconds} seconds: {ex.Message}");
                throw;
            }
        }
    }
}