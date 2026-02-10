using OpenQA.Selenium;
using Project1.Automation.Utilities;
using System;

namespace Project1.Automation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver Driver;

        // Locators
        private By PageLogo => By.XPath("//img[@alt='Golden 1 Credit Union']");
        private By NavigationMenu => By.XPath("//nav[@role='navigation']");
        private By HeaderSection => By.XPath("//header");
        private By MainContent => By.XPath("//main");
        private By ErrorMessage => By.XPath("//*[contains(text(), 'error') or contains(text(), 'Error')]");

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Navigates to the Golden1 homepage
        /// </summary>
        public void NavigateToHomepage()
        {
            LogHelper.Info("Navigating to Golden1 homepage");
            string url = ConfigReader.GetAppSetting("BaseUrl");
            Driver.Navigate().GoToUrl(url);
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Successfully navigated to Golden1 homepage");
        }

        /// <summary>
        /// Verifies if the homepage is displayed
        /// </summary>
        /// <returns>True if homepage is displayed</returns>
        public bool IsHomepageDisplayed()
        {
            LogHelper.Info("Verifying if homepage is displayed");
            try
            {
                WaitHelper.WaitVisible(Driver, PageLogo, 10);
                bool isDisplayed = Driver.FindElement(PageLogo).Displayed;
                LogHelper.Info($"Homepage displayed status: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the page is fully loaded
        /// </summary>
        /// <returns>True if page is fully loaded</returns>
        public bool IsPageFullyLoaded()
        {
            LogHelper.Info("Verifying if page is fully loaded");
            try
            {
                WaitHelper.WaitForPageLoad(Driver);
                WaitHelper.WaitVisible(Driver, HeaderSection, 10);
                WaitHelper.WaitVisible(Driver, MainContent, 10);
                
                bool headerVisible = Driver.FindElement(HeaderSection).Displayed;
                bool contentVisible = Driver.FindElement(MainContent).Displayed;
                
                bool isFullyLoaded = headerVisible && contentVisible;
                LogHelper.Info($"Page fully loaded status: {isFullyLoaded}");
                return isFullyLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page not fully loaded: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if any error messages are displayed on the page
        /// </summary>
        /// <returns>True if error messages are present</returns>
        public bool AreErrorMessagesDisplayed()
        {
            LogHelper.Info("Checking for error messages on page");
            try
            {
                var errorElements = Driver.FindElements(ErrorMessage);
                bool hasErrors = errorElements.Count > 0;
                
                if (hasErrors)
                {
                    LogHelper.Warning($"Found {errorElements.Count} error message(s) on page");
                }
                else
                {
                    LogHelper.Info("No error messages found on page");
                }
                
                return hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error while checking for error messages: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all expected elements are present on homepage
        /// </summary>
        /// <returns>True if all expected elements are present</returns>
        public bool AreAllExpectedElementsPresent()
        {
            LogHelper.Info("Verifying all expected elements are present");
            try
            {
                WaitHelper.WaitVisible(Driver, PageLogo, 10);
                WaitHelper.WaitVisible(Driver, NavigationMenu, 10);
                WaitHelper.WaitVisible(Driver, HeaderSection, 10);
                
                bool logoPresent = Driver.FindElement(PageLogo).Displayed;
                bool navPresent = Driver.FindElement(NavigationMenu).Displayed;
                bool headerPresent = Driver.FindElement(HeaderSection).Displayed;
                
                bool allPresent = logoPresent && navPresent && headerPresent;
                
                LogHelper.Info($"Logo present: {logoPresent}, Navigation present: {navPresent}, Header present: {headerPresent}");
                LogHelper.Info($"All expected elements present: {allPresent}");
                
                return allPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Not all expected elements are present: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        /// <returns>Current URL</returns>
        public string GetCurrentUrl()
        {
            string currentUrl = Driver.Url;
            LogHelper.Info($"Current URL: {currentUrl}");
            return currentUrl;
        }

        /// <summary>
        /// Verifies the page title
        /// </summary>
        /// <returns>True if title contains expected text</returns>
        public bool IsPageTitleCorrect()
        {
            LogHelper.Info("Verifying page title");
            try
            {
                WaitHelper.WaitForPageLoad(Driver);
                string pageTitle = Driver.Title;
                bool titleCorrect = !string.IsNullOrEmpty(pageTitle) && pageTitle.Contains("Golden 1");
                LogHelper.Info($"Page title: {pageTitle}, Title correct: {titleCorrect}");
                return titleCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying page title: {ex.Message}");
                return false;
            }
        }
    }
}