using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Homepage
    /// Handles all interactions with the homepage
    /// Test Cases: TASK0020445 TS-001, TS-002, TS-008, TS-009
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
        private By Golden1Logo => By.CssSelector("a.logo, .header__logo, img[alt*='Golden 1']");
        private By PageContent => By.CssSelector("body");
        private By ErrorMessages => By.CssSelector(".error, .alert-danger, [class*='error']");
        private By LoadingSpinner => By.CssSelector(".spinner, .loading");
        
        // Cookie Banner Locators
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        /// <summary>
        /// Opens the Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public void OpenHomepage()
        {
            try
            {
                LogHelper.Info("Opening Golden 1 homepage");
                string baseUrl = ConfigReader.BaseUrl;
                NavigateTo(baseUrl);
                WaitForPageLoad();
                HandleCookieBanner();
                LogHelper.Info($"Successfully navigated to: {baseUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                throw;
            }
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
                // Continue execution even if cookie banner handling fails
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        /// <summary>
        /// Verifies if homepage is displayed without errors
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        /// <returns>True if homepage is displayed correctly</returns>
        public bool IsHomepageDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed");
                WaitHelper.WaitVisible(Driver, PageContent, 10);
                bool isDisplayed = IsDisplayed(PageContent);
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
        /// Verifies if Golden 1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        /// <returns>True if logo is visible</returns>
        public bool IsLogoVisible()
        {
            try
            {
                LogHelper.Info("Verifying Golden 1 logo visibility");
                WaitHelper.WaitVisible(Driver, Golden1Logo, 10);
                bool isVisible = IsDisplayed(Golden1Logo);
                LogHelper.Info($"Golden 1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if there are any error messages on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no error messages found</returns>
        public bool HasNoErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages on homepage");
                bool hasErrors = IsDisplayed(ErrorMessages, 2);
                LogHelper.Info($"Error messages present: {hasErrors}");
                return !hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Info("No error messages found on page");
                return true;
            }
        }

        /// <summary>
        /// Verifies if page content is displayed correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if content displays correctly</returns>
        public bool IsContentDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying page content displays correctly");
                WaitForPageLoad();
                bool contentVisible = IsDisplayed(PageContent);
                bool noErrors = HasNoErrorMessages();
                bool result = contentVisible && noErrors;
                LogHelper.Info($"Content displayed correctly: {result}");
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content verification failed: {ex.Message}");
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
        public string GetPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }

        /// <summary>
        /// Gets the page title
        /// </summary>
        /// <returns>Page title</returns>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            LogHelper.Info($"Page title: {title}");
            return title;
        }
    }
}