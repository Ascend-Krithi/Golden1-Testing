using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Golden1.Automation.Config;

namespace Golden1.Automation.Utilities
{
    public static class WaitHelper
    {
        public static IWebElement WaitClickable(IWebDriver driver, By locator, int timeoutSeconds = 0)
        {
            try
            {
                int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(500)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
                
                LogHelper.Debug($"Waiting for element to be clickable: {locator}");
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Element not clickable after {timeoutSeconds}s: {locator}", ex);
                throw;
            }
        }

        public static IWebElement WaitVisible(IWebDriver driver, By locator, int timeoutSeconds = 0)
        {
            try
            {
                int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(500)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
                
                LogHelper.Debug($"Waiting for element to be visible: {locator}");
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Element not visible after {timeoutSeconds}s: {locator}", ex);
                throw;
            }
        }

        public static bool WaitForElementToDisappear(IWebDriver driver, By locator, int timeoutSeconds = 0)
        {
            try
            {
                int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                
                LogHelper.Debug($"Waiting for element to disappear: {locator}");
                return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Element still visible after {timeoutSeconds}s: {locator}", ex);
                return false;
            }
        }

        public static IReadOnlyCollection<IWebElement> WaitForElements(IWebDriver driver, By locator, int timeoutSeconds = 0)
        {
            try
            {
                int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                
                LogHelper.Debug($"Waiting for elements to be present: {locator}");
                return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Elements not found after {timeoutSeconds}s: {locator}", ex);
                throw;
            }
        }

        public static bool WaitForUrlContains(IWebDriver driver, string urlPart, int timeoutSeconds = 0)
        {
            try
            {
                int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                
                LogHelper.Debug($"Waiting for URL to contain: {urlPart}");
                return wait.Until(ExpectedConditions.UrlContains(urlPart));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"URL does not contain '{urlPart}' after {timeoutSeconds}s. Current URL: {driver.Url}", ex);
                return false;
            }
        }

        public static bool WaitForTextPresent(IWebDriver driver, By locator, string text, int timeoutSeconds = 0)
        {
            try
            {
                int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                
                LogHelper.Debug($"Waiting for text '{text}' in element: {locator}");
                return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Text '{text}' not present after {timeoutSeconds}s in {locator}", ex);
                return false;
            }
        }

        public static IAlert WaitForAlert(IWebDriver driver, int timeoutSeconds = 0)
        {
            try
            {
                int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                
                LogHelper.Debug("Waiting for alert to be present");
                return wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Alert not present after {timeoutSeconds}s", ex);
                throw;
            }
        }

        public static IWebElement WaitUntilElementExists(IWebDriver driver, By locator, int timeoutSeconds = 0)
        {
            try
            {
                int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                
                LogHelper.Debug($"Waiting for element to exist: {locator}");
                return wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Element does not exist after {timeoutSeconds}s: {locator}", ex);
                throw;
            }
        }

        public static bool WaitForAttributeContains(IWebDriver driver, By locator, string attribute, string value, int timeoutSeconds = 0)
        {
            try
            {
                int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                
                LogHelper.Debug($"Waiting for attribute '{attribute}' to contain '{value}' in {locator}");
                return wait.Until(d =>
                {
                    var element = d.FindElement(locator);
                    var attrValue = element.GetAttribute(attribute);
                    return attrValue != null && attrValue.Contains(value);
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                LogHelper.Error($"Attribute '{attribute}' does not contain '{value}' after {timeoutSeconds}s", ex);
                return false;
            }
        }

        /// <summary>
        /// Fluent wait with custom conditions and polling
        /// </summary>
        public static T FluentWait<T>(IWebDriver driver, Func<IWebDriver, T> condition, 
            int timeoutSeconds = 0, int pollingIntervalMs = 500)
        {
            int timeout = timeoutSeconds > 0 ? timeoutSeconds : ConfigReader.TimeoutSeconds;
            
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(timeout),
                PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalMs)
            };
            
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            
            return wait.Until(condition);
        }
    }
}
