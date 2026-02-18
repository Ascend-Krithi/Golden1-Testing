using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the homepage
    /// Test Cases: TASK0020445 TS-001 through TS-009
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
        private By Golden1Logo => By.CssSelector("a.logo, .header-logo, img[alt*='Golden 1']");
        
        // Cookie Banner
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Page Elements
        private By PageBody => By.TagName("body");
        private By ErrorMessage => By.CssSelector(".error, .alert-danger, [class*='error']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info($"Opening Golden1 homepage: {ConfigReader.BaseUrl}");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            HandleCookieBanner();
            LogHelper.Info("Homepage loaded successfully");
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
                    LogHelper.Info("Cookies accepted");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner not found or already handled: {ex.Message}");
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies homepage loaded successfully
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public bool IsHomePageLoaded()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageBody, 10);
                bool isLoaded = IsDisplayed(PageBody);
                LogHelper.Info($"Homepage loaded: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage not loaded: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies no error messages are displayed
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        public bool HasNoErrors()
        {
            try
            {
                bool noErrors = !IsDisplayed(ErrorMessage, 2);
                LogHelper.Info($"No errors displayed: {noErrors}");
                return noErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Info("No error messages found on page");
                return true;
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
        /// Verifies page displays correctly without layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool IsPageDisplayedCorrectly()
        {
            try
            {
                WaitForPageLoad();
                bool bodyVisible = IsDisplayed(PageBody);
                bool noErrors = HasNoErrors();
                bool pageCorrect = bodyVisible && noErrors;
                LogHelper.Info($"Page displayed correctly: {pageCorrect}");
                return pageCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page display issue: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets current page URL
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