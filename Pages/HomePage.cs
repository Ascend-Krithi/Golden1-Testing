using OpenQA.Selenium;
using Project1.Automation.Utilities;
using System;

namespace Project1.Automation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private const int DefaultTimeout = 30;

        // Locators
        private By PageLogo => By.XPath("//img[@alt='Golden 1 Credit Union']");
        private By MainContent => By.TagName("body");
        private By ErrorMessage => By.XPath("//div[contains(@class, 'error')] | //div[contains(@class, 'alert-danger')] | //*[contains(text(), 'error')] | //*[contains(text(), 'Error')]");
        private By PageLoadIndicator => By.XPath("//header | //nav | //main");

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Navigates to the Golden 1 homepage
        /// </summary>
        public void NavigateToHomepage()
        {
            try
            {
                string homeUrl = ConfigReader.GetValue("BaseUrl");
                if (string.IsNullOrEmpty(homeUrl))
                {
                    homeUrl = "https://www.golden1.com/";
                }
                
                LogHelper.Info($"Navigating to URL: {homeUrl}");
                _driver.Navigate().GoToUrl(homeUrl);
                
                // Wait for page to load
                WaitHelper.WaitForPageLoad(_driver, DefaultTimeout);
                WaitHelper.WaitVisible(_driver, MainContent, DefaultTimeout);
                
                LogHelper.Info("Homepage navigation completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies if the homepage is displayed
        /// </summary>
        /// <returns>True if homepage is displayed, false otherwise</returns>
        public bool IsHomepageDisplayed()
        {
            try
            {
                LogHelper.Info("Checking if homepage is displayed");
                
                // Wait for page load indicator
                WaitHelper.WaitVisible(_driver, PageLoadIndicator, DefaultTimeout);
                
                // Verify main content is visible
                bool isMainContentVisible = WaitHelper.IsElementVisible(_driver, MainContent, 10);
                
                // Verify URL contains golden1.com
                bool isCorrectUrl = _driver.Url.Contains("golden1.com");
                
                LogHelper.Info($"Homepage displayed status - Content visible: {isMainContentVisible}, Correct URL: {isCorrectUrl}");
                
                return isMainContentVisible && isCorrectUrl;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking if homepage is displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if there are any error messages on the page
        /// </summary>
        /// <returns>True if error messages exist, false otherwise</returns>
        public bool HasErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages on homepage");
                
                // Check for common error elements
                bool hasErrors = WaitHelper.IsElementVisible(_driver, ErrorMessage, 5);
                
                // Check page title for error indicators
                string pageTitle = _driver.Title.ToLower();
                bool titleHasError = pageTitle.Contains("error") || pageTitle.Contains("404") || pageTitle.Contains("not found");
                
                LogHelper.Info($"Error check result - Error elements: {hasErrors}, Title has error: {titleHasError}");
                
                return hasErrors || titleHasError;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error while checking for error messages: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies the page title
        /// </summary>
        /// <returns>Page title</returns>
        public string GetPageTitle()
        {
            try
            {
                string title = _driver.Title;
                LogHelper.Info($"Page title: {title}");
                return title;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error getting page title: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the current URL
        /// </summary>
        /// <returns>Current URL</returns>
        public string GetCurrentUrl()
        {
            try
            {
                string url = _driver.Url;
                LogHelper.Info($"Current URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error getting current URL: {ex.Message}");
                return string.Empty;
            }
        }
    }
}