using OpenQA.Selenium;
using Golden1.Automation.Framework.Core;

namespace Golden1.Automation.Framework.Utilities
{
    public class NavigationHelper
    {
        private readonly IWebDriver _driver;
        private readonly LogHelper _logHelper;
        private readonly WaitHelper _waitHelper;

        public NavigationHelper()
        {
            _driver = DriverManager.GetDriver();
            _logHelper = new LogHelper();
            _waitHelper = new WaitHelper();
        }

        public void NavigateToUrl(string url)
        {
            try
            {
                _logHelper.LogInfo($"Navigating to URL: {url}");
                _driver.Navigate().GoToUrl(url);
                _waitHelper.WaitForPageLoad();
                _logHelper.LogInfo($"Successfully navigated to: {url}");
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to navigate to URL: {url}", ex);
                throw;
            }
        }

        public string GetCurrentUrl()
        {
            try
            {
                string currentUrl = _driver.Url;
                _logHelper.LogInfo($"Current URL: {currentUrl}");
                return currentUrl;
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to get current URL", ex);
                throw;
            }
        }

        public string GetPageTitle()
        {
            try
            {
                string title = _driver.Title;
                _logHelper.LogInfo($"Page Title: {title}");
                return title;
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to get page title", ex);
                throw;
            }
        }

        public void RefreshPage()
        {
            try
            {
                _logHelper.LogInfo("Refreshing page");
                _driver.Navigate().Refresh();
                _waitHelper.WaitForPageLoad();
                _logHelper.LogInfo("Page refreshed successfully");
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to refresh page", ex);
                throw;
            }
        }

        public void NavigateBack()
        {
            try
            {
                _logHelper.LogInfo("Navigating back");
                _driver.Navigate().Back();
                _waitHelper.WaitForPageLoad();
                _logHelper.LogInfo("Navigated back successfully");
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to navigate back", ex);
                throw;
            }
        }

        public void NavigateForward()
        {
            try
            {
                _logHelper.LogInfo("Navigating forward");
                _driver.Navigate().Forward();
                _waitHelper.WaitForPageLoad();
                _logHelper.LogInfo("Navigated forward successfully");
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to navigate forward", ex);
                throw;
            }
        }
    }
}