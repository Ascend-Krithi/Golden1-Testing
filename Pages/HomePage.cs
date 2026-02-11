using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Home Page
    /// Handles all interactions with the homepage
    /// Test Cases: TASK0020445 TS-001, TS-008, TS-009, TS-010, TS-011
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
        
        // Cookie Banner
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Header elements
        private By Logo => By.CssSelector("a.logo, .header__logo, img[alt*='Golden 1'], img[alt*='logo']");
        private By HeaderContainer => By.CssSelector("header, .header, .site-header");
        
        // Page elements
        private By PageBody => By.TagName("body");
        private By MainContent => By.CssSelector("main, .main-content, #main");
        private By HeroBanner => By.CssSelector(".hero, .banner, .hero-banner");
        
        // Error indicators
        private By ErrorMessage => By.CssSelector(".error, .alert-error, .error-message, [class*='error']");
        private By ErrorPage => By.XPath("//h1[contains(text(),'Error')] | //h1[contains(text(),'404')] | //h1[contains(text(),'Not Found')]");
        
        // Layout elements
        private By NavigationContainer => By.CssSelector("nav, .navigation, .nav");
        private By FooterContainer => By.CssSelector("footer, .footer");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info($"Opening Golden 1 homepage: {ConfigReader.BaseUrl}");
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                LogHelper.Info("Homepage opened successfully");
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
        /// Test Cases: All scenarios
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
                    LogHelper.Info("Cookie banner accepted and closed");
                }
                else
                {
                    LogHelper.Info("No cookie banner present");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner handling failed (non-critical): {ex.Message}");
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if homepage is displayed
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public bool IsHomePageDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed");
                WaitHelper.WaitVisible(Driver, PageBody, 10);
                
                bool isBodyDisplayed = IsDisplayed(PageBody);
                bool isMainContentDisplayed = IsDisplayed(MainContent, 5);
                string currentUrl = GetCurrentUrl();
                bool isCorrectUrl = currentUrl.Contains(ConfigReader.BaseUrl) || 
                                   currentUrl.Contains("golden1.com");
                
                bool isDisplayed = isBodyDisplayed && isMainContentDisplayed && isCorrectUrl;
                LogHelper.Info($"Homepage displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify homepage display: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if logo is visible
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
                LogHelper.Error($"Failed to verify logo visibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if page has error messages
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        public bool HasErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages on page");
                
                bool hasErrorMessage = IsDisplayed(ErrorMessage, 2);
                bool hasErrorPage = IsDisplayed(ErrorPage, 2);
                
                bool hasErrors = hasErrorMessage || hasErrorPage;
                LogHelper.Info($"Page has errors: {hasErrors}");
                return hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Error check failed (assuming no errors): {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all content is displayed correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool IsAllContentDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying all homepage content is displayed");
                
                bool hasHeader = IsDisplayed(HeaderContainer, 5);
                bool hasMainContent = IsDisplayed(MainContent, 5);
                bool hasNavigation = IsDisplayed(NavigationContainer, 5);
                bool hasFooter = IsDisplayed(FooterContainer, 5);
                
                bool allDisplayed = hasHeader && hasMainContent && hasNavigation && hasFooter;
                LogHelper.Info($"All content displayed: {allDisplayed}");
                return allDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify content display: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if page has broken layout
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool HasBrokenLayout()
        {
            try
            {
                LogHelper.Info("Checking for broken layout");
                
                // Check if main structural elements are present
                bool hasStructure = IsDisplayed(HeaderContainer, 3) && 
                                   IsDisplayed(MainContent, 3);
                
                // Check page dimensions
                var bodyElement = Driver.FindElement(PageBody);
                var bodySize = bodyElement.Size;
                bool hasValidDimensions = bodySize.Width > 0 && bodySize.Height > 0;
                
                bool hasBrokenLayout = !hasStructure || !hasValidDimensions;
                LogHelper.Info($"Page has broken layout: {hasBrokenLayout}");
                return hasBrokenLayout;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Layout check failed: {ex.Message}");
                return true; // Assume broken if check fails
            }
        }

        /// <summary>
        /// Verifies elements are consistent (for cross-browser testing)
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        public bool AreElementsConsistent()
        {
            try
            {
                LogHelper.Info("Verifying homepage elements are consistent");
                
                bool hasLogo = IsDisplayed(Logo, 5);
                bool hasNavigation = IsDisplayed(NavigationContainer, 5);
                bool hasMainContent = IsDisplayed(MainContent, 5);
                bool hasFooter = IsDisplayed(FooterContainer, 5);
                
                bool areConsistent = hasLogo && hasNavigation && hasMainContent && hasFooter;
                LogHelper.Info($"Elements are consistent: {areConsistent}");
                return areConsistent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify element consistency: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies elements are responsive (for cross-device testing)
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        public bool AreElementsResponsive(string deviceType)
        {
            try
            {
                LogHelper.Info($"Verifying homepage elements are responsive on {deviceType}");
                
                // Check if main elements are visible and properly sized
                bool hasLogo = IsDisplayed(Logo, 5);
                bool hasNavigation = IsDisplayed(NavigationContainer, 5);
                bool hasMainContent = IsDisplayed(MainContent, 5);
                
                // Get viewport dimensions
                var bodyElement = Driver.FindElement(PageBody);
                var viewportWidth = bodyElement.Size.Width;
                
                bool isResponsive = hasLogo && hasNavigation && hasMainContent && viewportWidth > 0;
                LogHelper.Info($"Elements are responsive on {deviceType}: {isResponsive}");
                return isResponsive;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify element responsiveness: {ex.Message}");
                return false;
            }
        }
    }
}