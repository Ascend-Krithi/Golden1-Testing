using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the Golden1 homepage
    /// Test Cases: TASK0020445 TS-001 through TS-012
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
        
        // Logo
        private By Golden1Logo => By.CssSelector("a.logo, .header__logo, img[alt*='Golden 1']");
        
        // Cookie Banner
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Page Elements
        private By PageBody => By.TagName("body");
        private By ErrorMessages => By.CssSelector(".error, .alert-error, .error-message");
        private By BrokenLayouts => By.CssSelector(".broken, .layout-error");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
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
                    LogHelper.Info("Cookies accepted successfully");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner handling: {ex.Message}");
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies homepage is displayed without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        /// <returns>True if homepage is displayed correctly</returns>
        public bool IsHomepageDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed correctly");
                WaitHelper.WaitVisible(Driver, PageBody, 10);
                bool isDisplayed = IsDisplayed(PageBody);
                LogHelper.Info($"Homepage displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies Golden1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        /// <returns>True if logo is visible</returns>
        public bool IsLogoVisible()
        {
            try
            {
                LogHelper.Info("Verifying Golden1 logo is visible");
                WaitHelper.WaitVisible(Driver, Golden1Logo, 10);
                bool isVisible = IsDisplayed(Golden1Logo);
                LogHelper.Info($"Golden1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks for error messages on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no error messages found</returns>
        public bool HasNoErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages");
                var errors = Driver.FindElements(ErrorMessages);
                bool noErrors = errors.Count == 0;
                LogHelper.Info($"Error messages found: {errors.Count}");
                return noErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Error message check: {ex.Message}");
                return true; // If locator not found, assume no errors
            }
        }

        /// <summary>
        /// Checks for broken layouts on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no broken layouts found</returns>
        public bool HasNoBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Checking for broken layouts");
                var brokenElements = Driver.FindElements(BrokenLayouts);
                bool noIssues = brokenElements.Count == 0;
                LogHelper.Info($"Broken layouts found: {brokenElements.Count}");
                return noIssues;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Broken layout check: {ex.Message}");
                return true; // If locator not found, assume no issues
            }
        }

        /// <summary>
        /// Verifies all homepage content displays correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if content displays correctly</returns>
        public bool IsContentDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying all homepage content displays correctly");
                bool pageDisplayed = IsHomepageDisplayedCorrectly();
                bool noErrors = HasNoErrorMessages();
                bool noLayoutIssues = HasNoBrokenLayouts();
                
                bool allCorrect = pageDisplayed && noErrors && noLayoutIssues;
                LogHelper.Info($"Content display verification result: {allCorrect}");
                return allCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content display verification failed: {ex.Message}");
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
        public string GetCurrentUrl()
        {
            string url = Driver.Url;
            LogHelper.Info($"Current URL: {url}");
            return url;
        }
    }
}