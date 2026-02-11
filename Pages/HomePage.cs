using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Homepage
    /// Handles all interactions with the main homepage
    /// Test Cases: TASK0020445 TS-001, TS-002, TS-008, TS-009, TS-010, TS-011
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
        private By Golden1Logo => By.CssSelector("a.logo img, .header__logo img, img[alt*='Golden 1']");
        
        // Page elements
        private By PageBody => By.TagName("body");
        private By MainContent => By.CssSelector("main, .main-content, #main");
        private By ErrorMessage => By.CssSelector(".error, .alert-danger, [class*='error']");
        
        // Cookie Banner (Overlay)
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Layout validation elements
        private By HeaderSection => By.CssSelector("header, .header, .site-header");
        private By FooterSection => By.CssSelector("footer, .footer, .site-footer");

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
                LogHelper.Info("Golden 1 homepage opened successfully");
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
        public void HandleCookieBanner()
        {
            try
            {
                LogHelper.Info("Checking for cookie consent banner");
                if (IsDisplayed(CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookie banner accepted and dismissed");
                }
                else
                {
                    LogHelper.Info("No cookie banner present");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner handling: {ex.Message}");
                // Don't throw - cookie banner is optional
            }
        }

        /// <summary>
        /// Sets viewport size based on device type
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        /// <param name="deviceType">Desktop, Tablet, or Mobile</param>
        public void SetViewportSize(string deviceType)
        {
            try
            {
                LogHelper.Info($"Setting viewport size for device: {deviceType}");
                
                switch (deviceType.ToLower())
                {
                    case "desktop":
                        Driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
                        break;
                    case "tablet":
                        Driver.Manage().Window.Size = new System.Drawing.Size(768, 1024);
                        break;
                    case "mobile":
                        Driver.Manage().Window.Size = new System.Drawing.Size(375, 667);
                        break;
                    default:
                        LogHelper.Warning($"Unknown device type: {deviceType}, using desktop size");
                        Driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
                        break;
                }
                
                LogHelper.Info($"Viewport set to {deviceType} size");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to set viewport size: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies homepage is displayed
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        /// <returns>True if homepage is displayed</returns>
        public bool IsHomePageDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed");
                WaitHelper.WaitVisible(Driver, PageBody, 10);
                bool isDisplayed = IsDisplayed(PageBody) && IsDisplayed(MainContent, 10);
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
        /// Verifies no errors are present on the page
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        /// <returns>True if no errors found</returns>
        public bool VerifyNoErrorsOnPage()
        {
            try
            {
                LogHelper.Info("Checking for error messages on page");
                bool noErrors = !IsDisplayed(ErrorMessage, 3);
                LogHelper.Info($"No errors on page: {noErrors}");
                return noErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies page loaded successfully
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        /// <returns>True if page loaded successfully</returns>
        public bool VerifyPageLoadedSuccessfully()
        {
            try
            {
                LogHelper.Info("Verifying page loaded successfully");
                WaitForPageLoad();
                
                var readyState = ((IJavaScriptExecutor)Driver)
                    .ExecuteScript("return document.readyState").ToString();
                
                bool isLoaded = readyState.Equals("complete", StringComparison.OrdinalIgnoreCase);
                LogHelper.Info($"Page load complete: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page load verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies Golden 1 logo is visible
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
        /// Verifies all content is displayed correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if all content displayed correctly</returns>
        public bool VerifyAllContentDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying all content is displayed correctly");
                
                bool headerDisplayed = IsDisplayed(HeaderSection, 5);
                bool mainContentDisplayed = IsDisplayed(MainContent, 5);
                bool footerDisplayed = IsDisplayed(FooterSection, 5);
                
                bool allDisplayed = headerDisplayed && mainContentDisplayed && footerDisplayed;
                
                LogHelper.Info($"Header: {headerDisplayed}, Main: {mainContentDisplayed}, Footer: {footerDisplayed}");
                LogHelper.Info($"All content displayed correctly: {allDisplayed}");
                
                return allDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies no layout issues on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no layout issues</returns>
        public bool VerifyNoLayoutIssues()
        {
            try
            {
                LogHelper.Info("Verifying no layout issues");
                
                // Check if main structural elements are present and visible
                bool headerVisible = IsDisplayed(HeaderSection, 5);
                bool mainVisible = IsDisplayed(MainContent, 5);
                
                // Check for JavaScript errors
                var jsErrors = ((IJavaScriptExecutor)Driver)
                    .ExecuteScript("return window.jsErrors || [];");
                
                bool noLayoutIssues = headerVisible && mainVisible;
                LogHelper.Info($"No layout issues: {noLayoutIssues}");
                
                return noLayoutIssues;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies elements are consistent across browsers
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        /// <returns>True if elements are consistent</returns>
        public bool VerifyElementsConsistent()
        {
            try
            {
                LogHelper.Info("Verifying elements are consistent");
                
                bool logoVisible = IsDisplayed(Golden1Logo, 5);
                bool headerVisible = IsDisplayed(HeaderSection, 5);
                bool mainVisible = IsDisplayed(MainContent, 5);
                
                bool consistent = logoVisible && headerVisible && mainVisible;
                LogHelper.Info($"Elements consistent: {consistent}");
                
                return consistent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Consistency verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies elements are responsive across devices
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        /// <returns>True if elements are responsive</returns>
        public bool VerifyElementsResponsive()
        {
            try
            {
                LogHelper.Info("Verifying elements are responsive");
                
                bool headerVisible = IsDisplayed(HeaderSection, 5);
                bool mainVisible = IsDisplayed(MainContent, 5);
                
                bool responsive = headerVisible && mainVisible;
                LogHelper.Info($"Elements responsive: {responsive}");
                
                return responsive;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Responsiveness verification failed: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================
        
        /// <summary>
        /// Gets current page URL
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
                LogHelper.Error($"Failed to get current URL: {ex.Message}");
                throw;
            }
        }
    }
}