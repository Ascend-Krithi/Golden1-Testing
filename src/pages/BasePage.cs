using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Golden1.Automation.Framework.Helpers;
using System;

namespace Golden1.Automation.Framework.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking element display: {ex.Message}");
                return false;
            }
        }

        protected void ClickElement(By locator)
        {
            try
            {
                WaitHelper.WaitForElementToBeClickable(Driver, locator, 10);
                Driver.FindElement(locator).Click();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error clicking element: {ex.Message}");
                throw;
            }
        }

        protected void EnterText(By locator, string text)
        {
            try
            {
                WaitHelper.WaitForElementToBeVisible(Driver, locator, 10);
                IWebElement element = Driver.FindElement(locator);
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error entering text: {ex.Message}");
                throw;
            }
        }

        protected string GetElementText(By locator)
        {
            try
            {
                WaitHelper.WaitForElementToBeVisible(Driver, locator, 10);
                return Driver.FindElement(locator).Text;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error getting element text: {ex.Message}");
                throw;
            }
        }
    }
}