using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Golden1.Automation.Framework.Core;

namespace Golden1.Automation.Framework.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly LogHelper _logHelper;

        public WaitHelper()
        {
            _driver = DriverManager.GetDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            _logHelper = new LogHelper();
        }

        public void WaitForElementVisible(By locator, int timeoutInSeconds = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                _logHelper.LogInfo($"Element visible: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                _logHelper.LogError($"Element not visible within {timeoutInSeconds} seconds: {locator}", ex);
                throw;
            }
        }

        public void WaitForElementClickable(By locator, int timeoutInSeconds = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                _logHelper.LogInfo($"Element clickable: {locator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                _logHelper.LogError($"Element not clickable within {timeoutInSeconds} seconds: {locator}", ex);
                throw;
            }
        }

        public void WaitForPageLoad()
        {
            try
            {
                _wait.Until(driver => ((IJavaScriptExecutor)driver)
                    .ExecuteScript("return document.readyState").Equals("complete"));
                _logHelper.LogInfo("Page loaded successfully");
            }
            catch (WebDriverTimeoutException ex)
            {
                _logHelper.LogError("Page did not load within timeout period", ex);
                throw;
            }
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                _driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return _driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void HoverOverElement(By locator)
        {
            try
            {
                var element = _driver.FindElement(locator);
                var actions = new OpenQA.Selenium.Interactions.Actions(_driver);
                actions.MoveToElement(element).Perform();
                _logHelper.LogInfo($"Hovered over element: {locator}");
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to hover over element: {locator}", ex);
                throw;
            }
        }

        public void ClickElement(By locator)
        {
            try
            {
                var element = _driver.FindElement(locator);
                element.Click();
                _logHelper.LogInfo($"Clicked element: {locator}");
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to click element: {locator}", ex);
                throw;
            }
        }

        public string GetElementText(By locator)
        {
            try
            {
                return _driver.FindElement(locator).Text;
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to get text from element: {locator}", ex);
                throw;
            }
        }

        public ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            try
            {
                return _driver.FindElements(locator);
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to find elements: {locator}", ex);
                throw;
            }
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }
    }
}