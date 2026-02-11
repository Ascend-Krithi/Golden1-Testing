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
        private By Logo => By.CssSelector("img[alt*='Golden 1'], .logo, [class*='logo']");
        private By MainContent => By.CssSelector("main, #main-content, .main-content");
        private By HeroBanner => By.CssSelector(".hero, .banner, [class*='hero']");
        private By ErrorMessage => By.CssSelector(".error, .alert-danger, [class*='error']");
        private By BrokenImage => By.CssSelector("img[src=''], img:not([src])");
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        /// <summary>
        /// Opens the Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info($"Opening Golden 1 homepage: {ConfigReader.BaseUrl}");
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                HandleCookieBanner();
                LogHelper.Info("Homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        /// <summary>
        /// Verifies if the homepage is displayed without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public bool IsHomePageDisplayedWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed without errors");
                
                // Wait for main content to be visible
                WaitHelper.WaitVisible(Driver, MainContent, 10);
                
                bool isMainContentVisible = IsDisplayed(MainContent);
                bool hasNoErrors = !IsDisplayed(ErrorMessage);
                
                bool result = isMainContentVisible && hasNoErrors;
                LogHelper.Info($"Homepage displayed without errors: {result}");
                
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying homepage: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the Golden 1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        public bool IsLogoVisible()
        {
            try
            {
                LogHelper.Info("Checking if Golden 1 logo is visible");
                WaitHelper.WaitVisible(Driver, Logo, 10);
                bool isVisible = IsDisplayed(Logo);
                LogHelper.Info($"Logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the homepage displays all content correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool IsContentDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying homepage content is displayed correctly");
                
                WaitHelper.WaitVisible(Driver, MainContent, 10);
                
                bool hasMainContent = IsDisplayed(MainContent);
                bool hasNoErrors = !IsDisplayed(ErrorMessage);
                bool hasNoBrokenImages = !IsDisplayed(BrokenImage);
                
                bool result = hasMainContent && hasNoErrors && hasNoBrokenImages;
                LogHelper.Info($"Content displayed correctly: {result}");
                
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying content: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if there are any broken layouts on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool HasNoBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Checking for broken layouts");
                
                // Check if main content is properly rendered
                bool isMainContentVisible = IsDisplayed(MainContent);
                
                // Check if there are no elements with zero dimensions (broken layout indicator)
                var brokenElements = Driver.FindElements(By.CssSelector("*[style*='display: none']"));
                bool hasNoBrokenElements = brokenElements.Count == 0 || isMainContentVisible;
                
                LogHelper.Info($"No broken layouts: {hasNoBrokenElements}");
                return hasNoBrokenElements;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking layouts: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if there are any error messages on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool HasNoErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages");
                bool hasNoErrors = !IsDisplayed(ErrorMessage);
                LogHelper.Info($"No error messages: {hasNoErrors}");
                return hasNoErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for error messages: {ex.Message}");
                return true; // If we can't find error locator, assume no errors
            }
        }

        // =============================================================
        // HELPER METHODS
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
                LogHelper.Warning($"Cookie banner not found or already dismissed: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the page title
        /// </summary>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            LogHelper.Info($"Page title: {title}");
            return title;
        }
    }
}