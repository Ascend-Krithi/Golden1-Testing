using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Golden1.Automation.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            System.Threading.Thread.Sleep(4000);
        }

        public void WaitForPageLoad(int timeout = 20)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout))
                .Until(d => ((IJavaScriptExecutor)d)
                .ExecuteScript("return document.readyState").ToString() != "loading");
        }

        // 🔥 JS Click avoids overlay issues
        public void Click(By locator)
        {
            var element = Driver.FindElement(locator);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }

        public void ScrollToElement(By locator)
        {
            var element = Driver.FindElement(locator);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public List<IWebElement> GetElements(By locator) =>
            new List<IWebElement>(Driver.FindElements(locator));

        public string GetCurrentUrl() => Driver.Url;

        public bool IsDisplayed(By locator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(d => d.FindElement(locator).Displayed);
            }
            catch
            {
                return false;
            }
        }
    }
}
