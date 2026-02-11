using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Base Page class containing common methods for all page objects
    /// DO NOT MODIFY - Framework Core File
    /// </summary>
    public class BasePage
    {
        protected IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        protected void Click(By locator)
        {
            Driver.FindElement(locator).Click();
        }

        protected void SendKeys(By locator, string text)
        {
            Driver.FindElement(locator).Clear();
            Driver.FindElement(locator).SendKeys(text);
        }

        protected string GetText(By locator)
        {
            return Driver.FindElement(locator).Text;
        }

        protected bool IsDisplayed(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsDisplayed(By locator, int timeoutSeconds)
        {
            try
            {
                WaitHelper.WaitVisible(Driver, locator, timeoutSeconds);
                return Driver.FindElement(locator).Displayed;
            }
            catch
            {
                return false;
            }
        }

        protected void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        protected string GetCurrentUrl()
        {
            return Driver.Url;
        }

        protected void WaitForPageLoad()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => ((IJavaScriptExecutor)driver)
                .ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}