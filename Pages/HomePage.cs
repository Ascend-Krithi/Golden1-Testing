using OpenQA.Selenium;
using Project1.Automation.Utilities;
using SeleniumExtras.WaitHelpers;

namespace Project1.Automation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly string _homePageUrl;

        // Locators
        private By PageLogo => By.XPath("//img[contains(@alt, 'Golden 1') or contains(@class, 'logo')]");
        private By NavigationMenu => By.XPath("//nav | //div[contains(@class, 'navigation') or contains(@class, 'menu')]");
        private By PageHeader => By.XPath("//header | //div[contains(@class, 'header')]");
        private By ErrorMessage => By.XPath("//div[contains(@class, 'error') or contains(text(), 'error') or contains(text(), 'Error')]");
        private By PageBody => By.TagName("body");

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _homePageUrl = ConfigReader.GetValue("BaseUrl") ?? "https://www.golden1.com/";
        }

        /// <summary>
        /// Navigates to the Golden 1 homepage
        /// </summary>
        public void NavigateToHomePage()
        {
            LogHelper.Info($"Navigating to URL: {_homePageUrl}");
            _driver.Navigate().GoToUrl(_homePageUrl);
            WaitHelper.WaitForPageLoad(_driver);
            LogHelper.Info("Page load completed");
        }

        /// <summary>
        /// Verifies if the homepage is loaded successfully
        /// </summary>
        /// <returns>True if homepage is loaded, false otherwise</returns>
        public bool IsHomePageLoaded()
        {
            try
            {
                LogHelper.Info("Checking if homepage is loaded");
                
                // Wait for page body to be visible
                WaitHelper.WaitVisible(_driver, PageBody, 10);
                
                // Verify URL contains golden1.com
                string currentUrl = _driver.Url;
                bool urlCorrect = currentUrl.Contains("golden1.com");
                
                if (!urlCorrect)
                {
                    LogHelper.Error($"URL verification failed. Current URL: {currentUrl}");
                    return false;
                }
                
                // Check if page title is not empty
                bool titleExists = !string.IsNullOrEmpty(_driver.Title);
                
                LogHelper.Info($"Homepage loaded - URL: {currentUrl}, Title: {_driver.Title}");
                return urlCorrect && titleExists;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying homepage load: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies that no error messages are displayed on the page
        /// </summary>
        /// <returns>True if no errors displayed, false otherwise</returns>
        public bool VerifyNoErrorsDisplayed()
        {
            try
            {
                LogHelper.Info("Checking for error messages on page");
                
                // Check if any error elements are present
                var errorElements = _driver.FindElements(ErrorMessage);
                
                if (errorElements.Count > 0)
                {
                    LogHelper.Error($"Found {errorElements.Count} error message(s) on page");
                    return false;
                }
                
                // Verify page loaded successfully by checking for key elements
                bool pageBodyVisible = _driver.FindElements(PageBody).Count > 0;
                
                if (!pageBodyVisible)
                {
                    LogHelper.Error("Page body not visible");
                    return false;
                }
                
                LogHelper.Info("No errors found on homepage");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for page errors: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the current URL
        /// </summary>
        /// <returns>Current page URL</returns>
        public string GetCurrentUrl()
        {
            string url = _driver.Url;
            LogHelper.Info($"Current URL: {url}");
            return url;
        }

        /// <summary>
        /// Verifies if the page logo is displayed
        /// </summary>
        /// <returns>True if logo is visible, false otherwise</returns>
        public bool IsLogoDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(_driver, PageLogo, 5);
                bool isDisplayed = _driver.FindElement(PageLogo).Displayed;
                LogHelper.Info($"Logo displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Logo not found or not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the navigation menu is displayed
        /// </summary>
        /// <returns>True if navigation menu is visible, false otherwise</returns>
        public bool IsNavigationMenuDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(_driver, NavigationMenu, 5);
                bool isDisplayed = _driver.FindElement(NavigationMenu).Displayed;
                LogHelper.Info($"Navigation menu displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Navigation menu not found or not visible: {ex.Message}");
                return false;
            }
        }
    }
}