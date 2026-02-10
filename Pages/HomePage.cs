using OpenQA.Selenium;
using Project1.Automation.Utilities;
using System;

namespace Project1.Automation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver Driver;

        // Constructor
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        // Locators
        private By PageLogo => By.XPath("//img[@alt='Golden 1 Credit Union']");
        private By NavigationMenu => By.XPath("//nav[@role='navigation']");
        private By HeaderSection => By.XPath("//header");

        // Page Methods
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

        public bool IsHomePageDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed");
                WaitHelper.WaitVisible(Driver, HeaderSection, 10);
                bool isDisplayed = Driver.FindElement(HeaderSection).Displayed;
                LogHelper.Info($"Homepage displayed status: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify homepage display: {ex.Message}");
                return false;
            }
        }

        public bool IsHomePageLoadedWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage loaded without errors");
                WaitHelper.WaitForPageLoad(Driver);
                
                // Check for common error indicators
                bool noErrorPage = !Driver.PageSource.Contains("404") && 
                                   !Driver.PageSource.Contains("Error") && 
                                   !Driver.PageSource.Contains("Page Not Found");
                
                // Verify key elements are present
                bool headerPresent = Driver.FindElements(HeaderSection).Count > 0;
                bool navigationPresent = Driver.FindElements(NavigationMenu).Count > 0;
                
                bool isLoaded = noErrorPage && headerPresent && navigationPresent;
                LogHelper.Info($"Homepage loaded without errors: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error while verifying homepage load: {ex.Message}");
                return false;
            }
        }

        public bool VerifyHomePageElements()
        {
            try
            {
                LogHelper.Info("Verifying homepage elements are present");
                
                WaitHelper.WaitVisible(Driver, HeaderSection, 10);
                bool headerVisible = Driver.FindElement(HeaderSection).Displayed;
                LogHelper.Info($"Header visible: {headerVisible}");
                
                WaitHelper.WaitVisible(Driver, NavigationMenu, 10);
                bool navigationVisible = Driver.FindElement(NavigationMenu).Displayed;
                LogHelper.Info($"Navigation menu visible: {navigationVisible}");
                
                bool allElementsPresent = headerVisible && navigationVisible;
                LogHelper.Info($"All expected elements present: {allElementsPresent}");
                return allElementsPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify homepage elements: {ex.Message}");
                return false;
            }
        }

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

        public bool VerifyNoLoadingErrors()
        {
            try
            {
                LogHelper.Info("Verifying no loading errors are displayed");
                WaitHelper.WaitForPageLoad(Driver);
                
                // Check page source for error indicators
                string pageSource = Driver.PageSource.ToLower();
                bool hasErrors = pageSource.Contains("error") || 
                                pageSource.Contains("404") || 
                                pageSource.Contains("not found") ||
                                pageSource.Contains("exception");
                
                bool noErrors = !hasErrors;
                LogHelper.Info($"No loading errors: {noErrors}");
                return noErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error while checking for loading errors: {ex.Message}");
                return false;
            }
        }
    }
}