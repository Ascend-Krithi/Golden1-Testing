using System;
using System.Linq;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Credit Union Homepage
    /// Handles all interactions with the homepage
    /// Test Cases: TASK0020445 TS-001 through TS-011
    /// </summary>
    public class HomePage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public HomePage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators
        // =============================================================
        
        // Header elements
        private By Golden1Logo => By.CssSelector("a.logo, img[alt*='Golden 1'], .header-logo");
        private By HeaderContainer => By.CssSelector("header, .header, .site-header");
        
        // Page elements
        private By PageBody => By.TagName("body");
        private By MainContent => By.CssSelector("main, #main-content, .main-content");
        
        // Error indicators
        private By ErrorMessage => By.CssSelector(".error, .error-message, .alert-error, .alert-danger");
        private By SystemError => By.XPath("//div[contains(text(), 'error') or contains(text(), 'Error')]");
        
        // Loading indicators
        private By LoadingSpinner => By.CssSelector(".spinner, .loading, .loader");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001, TS-004 TC-001, TS-005 TC-001, TS-006 TC-001, TS-007 TC-001, TS-008 TC-001, TS-009 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info($"Opening Golden 1 homepage: {ConfigReader.BaseUrl}");
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                WaitForLoadingToComplete();
                LogHelper.Info("Golden 1 homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open Golden 1 homepage: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // VERIFICATION METHODS - Page Load
        // =============================================================
        
        /// <summary>
        /// Verifies if the homepage is loaded successfully
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        /// <returns>True if homepage is loaded, false otherwise</returns>
        public bool IsHomePageLoaded()
        {
            try
            {
                LogHelper.Info("Verifying homepage is loaded");
                
                // Wait for page body to be visible
                WaitHelper.WaitVisible(Driver, PageBody, 10);
                
                // Check if main content is present
                bool isMainContentPresent = IsDisplayed(MainContent, 5);
                
                // Check if URL is correct
                string currentUrl = GetCurrentUrl();
                bool isCorrectUrl = currentUrl.Contains("golden1.com");
                
                bool isLoaded = isMainContentPresent && isCorrectUrl;
                LogHelper.Info($"Homepage loaded status: {isLoaded}");
                
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying homepage load: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the page is loaded (generic check)
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        /// <returns>True if page is loaded, false otherwise</returns>
        public bool IsPageLoaded()
        {
            try
            {
                LogHelper.Info("Verifying page is loaded");
                WaitForPageLoad();
                bool isLoaded = IsDisplayed(PageBody, 10);
                LogHelper.Info($"Page loaded status: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying page load: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // VERIFICATION METHODS - Display and Layout
        // =============================================================
        
        /// <summary>
        /// Verifies if the page is displayed correctly
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        /// <returns>True if page displays correctly, false otherwise</returns>
        public bool IsPageDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying page displays correctly");
                
                // Check if main content is visible
                bool isMainContentVisible = IsDisplayed(MainContent, 5);
                
                // Check if header is visible
                bool isHeaderVisible = IsDisplayed(HeaderContainer, 5);
                
                // Check for no errors
                bool hasNoErrors = !IsDisplayed(ErrorMessage, 2);
                
                bool isDisplayedCorrectly = isMainContentVisible && isHeaderVisible && hasNoErrors;
                LogHelper.Info($"Page displayed correctly: {isDisplayedCorrectly}");
                
                return isDisplayedCorrectly;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying page display: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the page has no layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        /// <returns>True if no layout issues, false otherwise</returns>
        public bool HasNoLayoutIssues()
        {
            try
            {
                LogHelper.Info("Checking for layout issues");
                
                // Check if main content is visible and properly sized
                bool isMainContentVisible = IsDisplayed(MainContent, 5);
                
                // Check if header is visible
                bool isHeaderVisible = IsDisplayed(HeaderContainer, 5);
                
                // Check if body has proper dimensions
                var bodyElement = Driver.FindElement(PageBody);
                var bodySize = bodyElement.Size;
                bool hasProperSize = bodySize.Width > 0 && bodySize.Height > 0;
                
                bool hasNoLayoutIssues = isMainContentVisible && isHeaderVisible && hasProperSize;
                LogHelper.Info($"No layout issues: {hasNoLayoutIssues}");
                
                return hasNoLayoutIssues;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking layout issues: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the page has no missing content
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no missing content, false otherwise</returns>
        public bool HasNoMissingContent()
        {
            try
            {
                LogHelper.Info("Checking for missing content");
                
                // Check if main content is present
                bool isMainContentPresent = IsDisplayed(MainContent, 5);
                
                // Check if header is present
                bool isHeaderPresent = IsDisplayed(HeaderContainer, 5);
                
                // Check if logo is present
                bool isLogoPresent = IsDisplayed(Golden1Logo, 5);
                
                bool hasNoMissingContent = isMainContentPresent && isHeaderPresent && isLogoPresent;
                LogHelper.Info($"No missing content: {hasNoMissingContent}");
                
                return hasNoMissingContent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking missing content: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // VERIFICATION METHODS - Errors
        // =============================================================
        
        /// <summary>
        /// Verifies if the page has no system errors
        /// Test Cases: TASK0020445 TS-009 TC-001, TS-006 TC-001
        /// </summary>
        /// <returns>True if no system errors, false otherwise</returns>
        public bool HasNoSystemErrors()
        {
            try
            {
                LogHelper.Info("Checking for system errors");
                
                // Check for error messages
                bool hasErrorMessage = IsDisplayed(ErrorMessage, 2);
                
                // Check for system error text
                bool hasSystemError = IsDisplayed(SystemError, 2);
                
                bool hasNoErrors = !hasErrorMessage && !hasSystemError;
                LogHelper.Info($"No system errors: {hasNoErrors}");
                
                return hasNoErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking system errors: {ex.Message}");
                return true; // If we can't find error elements, assume no errors
            }
        }

        // =============================================================
        // VERIFICATION METHODS - Header Elements
        // =============================================================
        
        /// <summary>
        /// Verifies if the Golden 1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001, TS-010 TC-001
        /// </summary>
        /// <returns>True if logo is visible, false otherwise</returns>
        public bool IsGolden1LogoVisible()
        {
            try
            {
                LogHelper.Info("Verifying Golden 1 logo is visible");
                WaitHelper.WaitVisible(Driver, Golden1Logo, 10);
                bool isVisible = IsDisplayed(Golden1Logo);
                LogHelper.Info($"Golden 1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying Golden 1 logo visibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all header elements are visible
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        /// <returns>True if header elements are visible, false otherwise</returns>
        public bool AreHeaderElementsVisible()
        {
            try
            {
                LogHelper.Info("Verifying header elements are visible");
                
                // Check if header container is visible
                bool isHeaderVisible = IsDisplayed(HeaderContainer, 5);
                
                // Check if logo is visible
                bool isLogoVisible = IsDisplayed(Golden1Logo, 5);
                
                bool areVisible = isHeaderVisible && isLogoVisible;
                LogHelper.Info($"Header elements visible: {areVisible}");
                
                return areVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying header elements visibility: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================
        
        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <returns>Current page URL</returns>
        public string GetCurrentPageUrl()
        {
            try
            {
                string url = GetCurrentUrl();
                LogHelper.Info($"Current page URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error getting current page URL: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // HELPER METHODS
        // =============================================================
        
        /// <summary>
        /// Waits for loading spinner to disappear
        /// </summary>
        private void WaitForLoadingToComplete()
        {
            try
            {
                LogHelper.Info("Waiting for loading to complete");
                WaitHelper.WaitInvisible(Driver, LoadingSpinner, 10);
                LogHelper.Info("Loading completed");
            }
            catch (Exception)
            {
                // Loading spinner might not be present, which is fine
                LogHelper.Info("No loading spinner found or already completed");
            }
        }
    }
}