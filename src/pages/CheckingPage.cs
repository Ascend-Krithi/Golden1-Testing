using OpenQA.Selenium;
using Golden1.Automation.Framework.Utilities;

namespace Golden1.Automation.Framework.Pages
{
    public class CheckingPage : BasePage
    {
        private readonly WaitHelper _waitHelper;
        private readonly LogHelper _logHelper;

        // Locators
        private By _pageHeaderLocator = By.XPath("//h1[contains(text(), 'Checking')] | //div[@class='page-header']//h1");
        private By _pageContentLocator = By.XPath("//div[@class='page-content'] | //main[@class='main-content']");
        private By _errorMessageLocator = By.XPath("//div[contains(@class, 'error')] | //div[contains(@class, 'alert')]");

        public CheckingPage()
        {
            _waitHelper = new WaitHelper();
            _logHelper = new LogHelper();
        }

        public bool IsOnCheckingPage()
        {
            try
            {
                _waitHelper.WaitForElementVisible(_pageHeaderLocator);
                string currentUrl = Driver.Url;
                bool urlContainsChecking = currentUrl.ToLower().Contains("checking");
                bool headerDisplayed = Driver.FindElement(_pageHeaderLocator).Displayed;
                
                _logHelper.LogInfo($"Checking page verification - URL contains 'checking': {urlContainsChecking}, Header displayed: {headerDisplayed}");
                return urlContainsChecking || headerDisplayed;
            }
            catch (NoSuchElementException ex)
            {
                _logHelper.LogError($"Checking page header not found: {ex.Message}");
                return false;
            }
        }

        public bool HasErrorMessages()
        {
            try
            {
                var errorElements = Driver.FindElements(_errorMessageLocator);
                bool hasErrors = errorElements.Any(e => e.Displayed);
                if (hasErrors)
                {
                    _logHelper.LogWarning("Error messages detected on Checking page");
                }
                return hasErrors;
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to check for error messages: {ex.Message}");
                return false;
            }
        }

        public bool IsPageContentDisplayed()
        {
            try
            {
                _waitHelper.WaitForElementVisible(_pageContentLocator);
                bool isDisplayed = Driver.FindElement(_pageContentLocator).Displayed;
                _logHelper.LogInfo($"Checking page content displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (NoSuchElementException ex)
            {
                _logHelper.LogError($"Checking page content not found: {ex.Message}");
                return false;
            }
        }

        public string GetPageTitle()
        {
            try
            {
                _waitHelper.WaitForElementVisible(_pageHeaderLocator);
                return Driver.FindElement(_pageHeaderLocator).Text;
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to get page title: {ex.Message}");
                return string.Empty;
            }
        }
    }
}