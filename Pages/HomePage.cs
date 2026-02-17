using System;
using OpenQA.Selenium;
using ProjectName.Automation.Config;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the Golden1 homepage
    /// Test Cases: TASK0020445 TS-001 through TS-011
    /// </summary>
    public class HomePage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public HomePage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators from Golden1 Locators.Json
        // =============================================================
        
        // Cookie Banner Locators
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Logo Locator
        private By Golden1Logo => By.CssSelector("a.logo, img[alt*='Golden 1'], .header-logo");
        
        // Page Container
        private By PageContainer => By.TagName("body");
        private By ErrorMessage => By.CssSelector(".error, .alert-error, [role='alert']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info($"Opening Golden1 homepage: {ConfigReader.BaseUrl}");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            HandleCookieBanner();
            LogHelper.Info("Golden1 homepage loaded successfully");
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Handles cookie consent banner if present
        /// </summary>
        private void HandleCookieBanner()
        {
            try
            {
                if (IsDisplayed(CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookie banner accepted and dismissed");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner not found or already dismissed: {ex.Message}");
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies homepage loaded successfully
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        /// <returns>True if homepage loaded successfully</returns>
        public bool IsHomePageLoaded()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageContainer, 10);
                bool isLoaded = IsDisplayed(PageContainer);
                LogHelper.Info($"Homepage loaded status: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage failed to load: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies no error messages are displayed
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        /// <returns>True if no errors are displayed</returns>
        public bool IsPageWithoutErrors()
        {
            try
            {
                bool hasErrors = IsDisplayed(ErrorMessage, 2);
                LogHelper.Info($"Page has errors: {hasErrors}");
                return !hasErrors;
            }
            catch (Exception)
            {
                LogHelper.Info("No error messages found on page");
                return true;
            }
        }

        /// <summary>
        /// Verifies Golden1 logo is visible in header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        /// <returns>True if logo is visible</returns>
        public bool IsGolden1LogoVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, Golden1Logo, 10);
                bool isVisible = IsDisplayed(Golden1Logo);
                LogHelper.Info($"Golden1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Golden1 logo not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies page displays correctly without layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if page displays correctly</returns>
        public bool IsPageDisplayedCorrectly()
        {
            try
            {
                // Check if page body is rendered
                bool bodyRendered = IsDisplayed(PageContainer);
                
                // Check if no error messages
                bool noErrors = IsPageWithoutErrors();
                
                // Check page title is not empty
                string pageTitle = GetPageTitle();
                bool hasTitle = !string.IsNullOrEmpty(pageTitle);
                
                bool isCorrect = bodyRendered && noErrors && hasTitle;
                LogHelper.Info($"Page displayed correctly: {isCorrect}");
                return isCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page display verification failed: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================
        
        /// <summary>
        /// Gets the current page title
        /// </summary>
        /// <returns>Page title</returns>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            LogHelper.Info($"Page title: {title}");
            return title;
        }

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        /// <returns>Current URL</returns>
        public string GetCurrentPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current URL: {url}");
            return url;
        }
    }
}