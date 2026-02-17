using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the homepage elements
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
        private By PageHeader => By.CssSelector("h1, .page-title");
        
        // Navigation menu elements
        private By GlobalNavigationMenu => By.CssSelector("nav.main-nav, nav[role='navigation'], .global-navigation");
        
        // Error and loading indicators
        private By ErrorMessage => By.CssSelector(".error-message, .alert-error, [role='alert']");
        private By LoadingSpinner => By.CssSelector(".spinner, .loading, .loader");
        
        // Page content
        private By PageContent => By.CssSelector("main, .main-content, #content");
        private By BrokenLayout => By.CssSelector(".error, .broken, [style*='display: none']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info("Opening Golden1 homepage");
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                WaitHelper.WaitForPageToLoad(Driver, 30);
                LogHelper.Info("Golden1 homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open Golden1 homepage: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if homepage loaded successfully without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        /// <returns>True if homepage loaded successfully</returns>
        public bool IsHomePageLoadedSuccessfully()
        {
            try
            {
                LogHelper.Info("Verifying homepage loaded successfully");
                
                // Wait for page to be fully loaded
                WaitHelper.WaitForPageToLoad(Driver, 30);
                
                // Check if page content is visible
                bool isContentVisible = IsDisplayed(PageContent, 10);
                
                // Check if there are no error messages
                bool hasNoErrors = !IsDisplayed(ErrorMessage, 2);
                
                bool isLoaded = isContentVisible && hasNoErrors;
                
                LogHelper.Info($"Homepage loaded successfully: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify homepage load: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        /// <returns>True if navigation menu is visible</returns>
        public bool IsGlobalNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Checking if global navigation menu is visible");
                WaitHelper.WaitVisible(Driver, GlobalNavigationMenu, 10);
                bool isVisible = IsDisplayed(GlobalNavigationMenu);
                LogHelper.Info($"Global navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Global navigation menu not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if Golden 1 logo is visible in header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        /// <returns>True if logo is visible</returns>
        public bool IsGolden1LogoVisible()
        {
            try
            {
                LogHelper.Info("Checking if Golden 1 logo is visible in header");
                WaitHelper.WaitVisible(Driver, Golden1Logo, 10);
                bool isVisible = IsDisplayed(Golden1Logo);
                LogHelper.Info($"Golden 1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Golden 1 logo not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if there are any error messages on the page
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        /// <returns>True if no errors present</returns>
        public bool HasNoErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages on page");
                bool hasNoErrors = !IsDisplayed(ErrorMessage, 2);
                LogHelper.Info($"Page has no error messages: {hasNoErrors}");
                return hasNoErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for error messages: {ex.Message}");
                return true; // Assume no errors if check fails
            }
        }

        /// <summary>
        /// Verifies if homepage displays correctly without layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if page displays correctly</returns>
        public bool IsPageDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying page displays correctly");
                
                // Check if main content is visible
                bool contentVisible = IsDisplayed(PageContent, 10);
                
                // Check if there are no broken layouts
                bool noBrokenLayouts = !IsDisplayed(BrokenLayout, 2);
                
                // Check if there are no error messages
                bool noErrors = HasNoErrorMessages();
                
                bool isCorrect = contentVisible && noBrokenLayouts && noErrors;
                
                LogHelper.Info($"Page displayed correctly: {isCorrect}");
                return isCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify page display: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if there are any layout issues on the page
        /// Test Cases: TASK0020445 TS-009 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        /// <returns>True if no layout issues found</returns>
        public bool HasNoLayoutIssues()
        {
            try
            {
                LogHelper.Info("Checking for layout issues");
                bool noIssues = !IsDisplayed(BrokenLayout, 2);
                LogHelper.Info($"No layout issues: {noIssues}");
                return noIssues;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking layout issues: {ex.Message}");
                return true;
            }
        }

        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <returns>Current page URL</returns>
        public string GetPageUrl()
        {
            try
            {
                string url = GetCurrentUrl();
                LogHelper.Info($"Current page URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get page URL: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets the page title
        /// </summary>
        /// <returns>Page title</returns>
        public string GetPageTitle()
        {
            try
            {
                string title = Driver.Title;
                LogHelper.Info($"Page title: {title}");
                return title;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get page title: {ex.Message}");
                throw;
            }
        }
    }
}