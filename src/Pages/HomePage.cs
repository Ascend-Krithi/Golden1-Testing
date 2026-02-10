using OpenQA.Selenium;
using Project1.Automation.Utilities;
using System;

namespace Project1.Automation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver Driver;

        // Locators
        private By HomePageLogo => By.XPath("//img[@alt='Golden 1 Credit Union']");
        private By PageTitle => By.TagName("title");
        private By MainContent => By.XPath("//main");

        // Constructor
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Navigates to the Golden 1 homepage
        /// </summary>
        /// <param name="url">The URL to navigate to</param>
        public void NavigateToHomePage(string url)
        {
            try
            {
                LogHelper.Info($"Navigating to URL: {url}");
                Driver.Navigate().GoToUrl(url);
                WaitHelper.WaitForPageLoad(Driver);
                LogHelper.Info("Successfully navigated to homepage");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies that the homepage is displayed successfully
        /// </summary>
        /// <returns>True if homepage is displayed, false otherwise</returns>
        public bool IsHomePageDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed");
                WaitHelper.WaitVisible(Driver, MainContent, 10);
                bool isDisplayed = Driver.FindElement(MainContent).Displayed;
                LogHelper.Info($"Homepage displayed status: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies that the homepage loaded without errors
        /// </summary>
        /// <returns>True if no errors found, false otherwise</returns>
        public bool IsHomePageLoadedWithoutErrors()
        {
            try
            {
                LogHelper.Info("Checking for page load errors");
                WaitHelper.WaitForPageLoad(Driver);
                
                // Check if main content is visible
                bool mainContentVisible = WaitHelper.WaitVisible(Driver, MainContent, 10);
                
                // Check if page title is present
                string pageTitle = Driver.Title;
                bool hasTitleContent = !string.IsNullOrEmpty(pageTitle);
                
                // Check for common error indicators
                bool noErrorPage = !pageTitle.ToLower().Contains("error") && 
                                   !pageTitle.ToLower().Contains("404") && 
                                   !pageTitle.ToLower().Contains("not found");
                
                bool isLoadedSuccessfully = mainContentVisible && hasTitleContent && noErrorPage;
                
                LogHelper.Info($"Homepage loaded without errors: {isLoadedSuccessfully}");
                return isLoadedSuccessfully;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking page load status: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        /// <returns>Current URL as string</returns>
        public string GetCurrentUrl()
        {
            try
            {
                string currentUrl = Driver.Url;
                LogHelper.Info($"Current URL: {currentUrl}");
                return currentUrl;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get current URL: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies the homepage URL is correct
        /// </summary>
        /// <param name="expectedUrl">Expected URL</param>
        /// <returns>True if URL matches, false otherwise</returns>
        public bool VerifyHomePageUrl(string expectedUrl)
        {
            try
            {
                LogHelper.Info($"Verifying homepage URL matches: {expectedUrl}");
                string currentUrl = GetCurrentUrl();
                bool urlMatches = currentUrl.Equals(expectedUrl, StringComparison.OrdinalIgnoreCase) || 
                                  currentUrl.TrimEnd('/').Equals(expectedUrl.TrimEnd('/'), StringComparison.OrdinalIgnoreCase);
                LogHelper.Info($"URL verification result: {urlMatches}");
                return urlMatches;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                return false;
            }
        }
    }
}