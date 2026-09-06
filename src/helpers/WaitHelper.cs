using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Golden1.WebAutomation.Helpers
{
    public static class WaitHelper
    {
        public static void WaitForElementToBeVisible(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                LogHelper.Info($"Element visible: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Timeout waiting for element to be visible: {locator}. Error: {ex.Message}");
                throw;
            }
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                LogHelper.Info($"Element clickable: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Timeout waiting for element to be clickable: {locator}. Error: {ex.Message}");
                throw;
            }
        }

        public static void WaitForElementToBeInvisible(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                LogHelper.Info($"Element invisible: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Warning($"Timeout waiting for element to be invisible: {locator}. Error: {ex.Message}");
            }
        }

        public static void WaitForElementToExist(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementExists(locator));
                LogHelper.Info($"Element exists: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Timeout waiting for element to exist: {locator}. Error: {ex.Message}");
                throw;
            }
        }

        public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                LogHelper.Info("Page loaded successfully");
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Timeout waiting for page to load. Error: {ex.Message}");
                throw;
            }
        }

        public static bool WaitForUrlToContain(IWebDriver driver, string urlPart, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                bool result = wait.Until(ExpectedConditions.UrlContains(urlPart));
                LogHelper.Info($"URL contains: {urlPart}");
                return result;
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Timeout waiting for URL to contain: {urlPart}. Error: {ex.Message}");
                return false;
            }
        }

        public static bool WaitForTitleToContain(IWebDriver driver, string title, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                bool result = wait.Until(ExpectedConditions.TitleContains(title));
                LogHelper.Info($"Title contains: {title}");
                return result;
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Timeout waiting for title to contain: {title}. Error: {ex.Message}");
                return false;
            }
        }

        public static void ImplicitWait(IWebDriver driver, int timeoutInSeconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSeconds);
            LogHelper.Info($"Implicit wait set to {timeoutInSeconds} seconds");
        }
    }
}