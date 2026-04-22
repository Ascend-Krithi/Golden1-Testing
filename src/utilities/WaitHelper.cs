using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Golden1.Automation.Framework.Core;

namespace Golden1.Automation.Framework.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly int _defaultTimeout;
        private readonly LogHelper _logHelper;

        public WaitHelper()
        {
            _driver = DriverManager.GetDriver();
            _defaultTimeout = int.Parse(ConfigReader.GetValue("DefaultTimeout") ?? "30");
            _logHelper = new LogHelper();
        }

        public void WaitForElementVisible(By locator, int timeoutInSeconds = 0)
        {
            try
            {
                int timeout = timeoutInSeconds > 0 ? timeoutInSeconds : _defaultTimeout;
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                _logHelper.LogInfo($"Element visible: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                _logHelper.LogError($"Timeout waiting for element to be visible: {locator}. Exception: {ex.Message}");
                throw;
            }
        }

        public void WaitForElementClickable(By locator, int timeoutInSeconds = 0)
        {
            try
            {
                int timeout = timeoutInSeconds > 0 ? timeoutInSeconds : _defaultTimeout;
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                _logHelper.LogInfo($"Element clickable: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                _logHelper.LogError($"Timeout waiting for element to be clickable: {locator}. Exception: {ex.Message}");
                throw;
            }
        }

        public void WaitForElementPresent(By locator, int timeoutInSeconds = 0)
        {
            try
            {
                int timeout = timeoutInSeconds > 0 ? timeoutInSeconds : _defaultTimeout;
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementExists(locator));
                _logHelper.LogInfo($"Element present: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                _logHelper.LogError($"Timeout waiting for element to be present: {locator}. Exception: {ex.Message}");
                throw;
            }
        }

        public void WaitForPageLoad(int timeoutInSeconds = 0)
        {
            try
            {
                int timeout = timeoutInSeconds > 0 ? timeoutInSeconds : _defaultTimeout;
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                _logHelper.LogInfo("Page loaded successfully");
            }
            catch (WebDriverTimeoutException ex)
            {
                _logHelper.LogError($"Timeout waiting for page to load. Exception: {ex.Message}");
                throw;
            }
        }

        public void WaitForElementInvisible(By locator, int timeoutInSeconds = 0)
        {
            try
            {
                int timeout = timeoutInSeconds > 0 ? timeoutInSeconds : _defaultTimeout;
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                _logHelper.LogInfo($"Element invisible: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                _logHelper.LogError($"Timeout waiting for element to be invisible: {locator}. Exception: {ex.Message}");
                throw;
            }
        }

        public bool WaitForUrlContains(string urlFragment, int timeoutInSeconds = 0)
        {
            try
            {
                int timeout = timeoutInSeconds > 0 ? timeoutInSeconds : _defaultTimeout;
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                bool result = wait.Until(ExpectedConditions.UrlContains(urlFragment));
                _logHelper.LogInfo($"URL contains: {urlFragment}");
                return result;
            }
            catch (WebDriverTimeoutException ex)
            {
                _logHelper.LogError($"Timeout waiting for URL to contain: {urlFragment}. Exception: {ex.Message}");
                return false;
            }
        }
    }
}