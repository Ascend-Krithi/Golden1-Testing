using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the main homepage
    /// Test Cases: TASK0020445 TS-001 through TS-012
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
        
        // Logo
        private By Golden1Logo => By.CssSelector("a.logo");
        
        // Cookie Banner
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Page Elements
        private By PageContent => By.CssSelector("main, .main-content");
        private By ErrorMessages => By.CssSelector(".error, .alert-error, [role='alert']");
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
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 10);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 10);
                    LogHelper.Info("Cookies accepted");
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
        /// Verifies homepage is displayed without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public bool IsHomePageDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed");
                WaitHelper.WaitVisible(Driver, PageContent, 15);
                bool isDisplayed = IsDisplayed(PageContent);
                LogHelper.Info($"Homepage displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage not displayed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies Golden1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        public bool IsLogoVisible()
        {
            try
            {
                LogHelper.Info("Checking if Golden1 logo is visible");
                WaitHelper.WaitVisible(Driver, Golden1Logo, 10);
                bool isVisible = IsDisplayed(Golden1Logo);
                LogHelper.Info($"Golden1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies homepage content displays correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool IsContentDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying homepage content displays correctly");
                WaitHelper.WaitVisible(Driver, PageContent, 15);
                bool contentVisible = IsDisplayed(PageContent);
                LogHelper.Info($"Homepage content displayed correctly: {contentVisible}");
                return contentVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content not displayed correctly: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Checks for broken layouts on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool HasBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Checking for broken layouts");
                bool hasBroken = IsDisplayed(BrokenLayouts, 5);
                LogHelper.Info($"Broken layouts found: {hasBroken}");
                return hasBroken;
            }
            catch
            {
                LogHelper.Info("No broken layouts detected");
                return false;
            }
        }
        
        /// <summary>
        /// Checks for error messages on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool HasErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages");
                bool hasErrors = IsDisplayed(ErrorMessages, 5);
                LogHelper.Info($"Error messages found: {hasErrors}");
                return hasErrors;
            }
            catch
            {
                LogHelper.Info("No error messages detected");
                return false;
            }
        }
        
        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public string GetPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }
    }
}