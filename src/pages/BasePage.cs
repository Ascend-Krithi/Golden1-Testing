using OpenQA.Selenium;
using System;

namespace Golden1.WebAutomation.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public string GetCurrentUrl()
        {
            LogHelper.Info("Getting current URL");
            string url = Driver.Url;
            LogHelper.Info($"Current URL: {url}");
            return url;
        }

        public string GetPageTitle()
        {
            LogHelper.Info("Getting page title");
            string title = Driver.Title;
            LogHelper.Info($"Page Title: {title}");
            return title;
        }

        public void RefreshPage()
        {
            LogHelper.Info("Refreshing page");
            Driver.Navigate().Refresh();
            WaitHelper.WaitForPageLoad(Driver, 10);
            LogHelper.Info("Page refreshed successfully");
        }

        public void NavigateBack()
        {
            LogHelper.Info("Navigating back");
            Driver.Navigate().Back();
            WaitHelper.WaitForPageLoad(Driver, 10);
            LogHelper.Info("Navigated back successfully");
        }

        public void NavigateForward()
        {
            LogHelper.Info("Navigating forward");
            Driver.Navigate().Forward();
            WaitHelper.WaitForPageLoad(Driver, 10);
            LogHelper.Info("Navigated forward successfully");
        }

        public void ScrollToElement(By locator)
        {
            LogHelper.Info($"Scrolling to element: {locator}");
            IWebElement element = Driver.FindElement(locator);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            LogHelper.Info("Scrolled to element successfully");
        }

        public void ScrollToTop()
        {
            LogHelper.Info("Scrolling to top of page");
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, 0);");
            LogHelper.Info("Scrolled to top successfully");
        }

        public void ScrollToBottom()
        {
            LogHelper.Info("Scrolling to bottom of page");
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            LogHelper.Info("Scrolled to bottom successfully");
        }
    }
}