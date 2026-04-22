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
            catch (System.Exception ex)
            {
                _logHelper.LogError($"Failed to navigate to URL: {url}", ex);
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
                _logHelper.LogInfo("Successfully navigated back");
            }
            catch (System.Exception ex)
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
                _logHelper.LogInfo("Successfully navigated forward");
            }
            catch (System.Exception ex)
            {
                _logHelper.LogError("Failed to navigate forward", ex);
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
                _logHelper.LogInfo("Successfully refreshed page");
            }
            catch (System.Exception ex)
            {
                _logHelper.LogError("Failed to refresh page", ex);
                throw;
            }
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }
    }
}