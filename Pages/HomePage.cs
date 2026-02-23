using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Credit Union Homepage
    /// </summary>
    public class HomePage : BasePage
    {
        // Constructor
        public HomePage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS
        private By LogoImage => By.CssSelector("img[alt*='Golden 1'], .logo img, header img");
        private By PageBody => By.TagName("body");
        private By ErrorMessageContainer => By.CssSelector(".error, .alert-danger, [class*='error']");
        private By MainContent => By.CssSelector("main, #main-content, .main-content");
        private By HeroBanner => By.CssSelector(".hero, .banner, [class*='hero']");
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // SECTION 2: PAGE ACTIONS

        /// <summary>
        /// Opens the Golden1 homepage
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info("Opening Golden1 homepage");
                string baseUrl = ConfigReader.BaseUrl;
                NavigateTo(baseUrl);
                WaitForPageLoad();
                HandleCookieBanner();
                LogHelper.Info($"Successfully navigated to: {baseUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomePage_OpenFailed");
                throw;
            }
        }

        /// <summary>
        /// Handles cookie consent banner if present
        /// </summary>
        private void HandleCookieBanner()
        {
            try
            {
                if (IsDisplayed(CookieBanner))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookie banner accepted and closed");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner handling: {ex.Message}");
                // Non-critical, continue execution
            }
        }

        // SECTION 3: VERIFICATIONS

        /// <summary>
        /// Verifies if browser is open and responsive
        /// </summary>
        /// <returns>True if browser is open, false otherwise</returns>
        public bool IsBrowserOpen()
        {
            try
            {
                LogHelper.Info("Verifying browser is open");
                string currentUrl = Driver.Url;
                bool isOpen = !string.IsNullOrEmpty(currentUrl);
                LogHelper.Info($"Browser open status: {isOpen}, Current URL: {currentUrl}");
                return isOpen;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify browser status: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if homepage loaded successfully
        /// </summary>
        /// <returns>True if homepage loaded, false otherwise</returns>
        public bool IsHomePageLoaded()
        {
            try
            {
                LogHelper.Info("Verifying homepage loaded successfully");
                WaitHelper.WaitVisible(Driver, PageBody, 10);
                
                bool urlCorrect = Driver.Url.Contains("golden1.com");
                bool bodyVisible = IsDisplayed(PageBody);
                bool isLoaded = urlCorrect && bodyVisible;
                
                LogHelper.Info($"Homepage loaded: {isLoaded} (URL correct: {urlCorrect}, Body visible: {bodyVisible})");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify homepage load: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomePage_LoadVerificationFailed");
                return false;
            }
        }

        /// <summary>
        /// Checks if there are any error messages on the page
        /// </summary>
        /// <returns>True if errors found, false otherwise</returns>
        public bool HasErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages");
                bool hasErrors = IsDisplayed(ErrorMessageContainer);
                
                if (hasErrors)
                {
                    string errorText = GetText(ErrorMessageContainer);
                    LogHelper.Warning($"Error message detected: {errorText}");
                    ScreenshotHelper.TakeScreenshot(Driver, "HomePage_ErrorDetected");
                }
                else
                {
                    LogHelper.Info("No error messages found");
                }
                
                return hasErrors;
            }
            catch (NoSuchElementException)
            {
                LogHelper.Info("No error messages found (element not present)");
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Error checking for error messages: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if Golden 1 logo is visible
        /// </summary>
        /// <returns>True if logo is visible, false otherwise</returns>
        public bool IsLogoVisible()
        {
            try
            {
                LogHelper.Info("Verifying Golden 1 logo visibility");
                WaitHelper.WaitVisible(Driver, LogoImage, 10);
                bool isVisible = IsDisplayed(LogoImage);
                LogHelper.Info($"Logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify logo visibility: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomePage_LogoNotVisible");
                return false;
            }
        }

        /// <summary>
        /// Verifies if homepage displays correctly without layout issues
        /// </summary>
        /// <returns>True if displays correctly, false otherwise</returns>
        public bool IsHomePageDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays correctly");
                
                bool mainContentVisible = IsDisplayed(MainContent);
                bool logoVisible = IsDisplayed(LogoImage);
                bool pageBodyVisible = IsDisplayed(PageBody);
                
                bool displaysCorrectly = mainContentVisible && logoVisible && pageBodyVisible;
                
                LogHelper.Info($"Homepage display status: {displaysCorrectly} (Main: {mainContentVisible}, Logo: {logoVisible}, Body: {pageBodyVisible})");
                return displaysCorrectly;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify homepage display: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomePage_DisplayVerificationFailed");
                return false;
            }
        }

        /// <summary>
        /// Checks for broken layouts on the homepage
        /// </summary>
        /// <returns>True if broken layouts detected, false otherwise</returns>
        public bool HasBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Checking for broken layouts");
                
                // Check if main content area has proper dimensions
                IWebElement mainElement = FindElement(MainContent);
                int width = mainElement.Size.Width;
                int height = mainElement.Size.Height;
                
                bool hasBrokenLayout = (width < 100 || height < 100);
                
                if (hasBrokenLayout)
                {
                    LogHelper.Warning($"Broken layout detected - Width: {width}, Height: {height}");
                    ScreenshotHelper.TakeScreenshot(Driver, "HomePage_BrokenLayout");
                }
                else
                {
                    LogHelper.Info($"Layout appears correct - Width: {width}, Height: {height}");
                }
                
                return hasBrokenLayout;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Could not verify layout: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks for missing content on the homepage
        /// </summary>
        /// <returns>True if missing content detected, false otherwise</returns>
        public bool HasMissingContent()
        {
            try
            {
                LogHelper.Info("Checking for missing content");
                
                bool mainContentMissing = !IsDisplayed(MainContent);
                bool logoMissing = !IsDisplayed(LogoImage);
                
                bool hasMissingContent = mainContentMissing || logoMissing;
                
                if (hasMissingContent)
                {
                    LogHelper.Warning($"Missing content detected - Main: {mainContentMissing}, Logo: {logoMissing}");
                    ScreenshotHelper.TakeScreenshot(Driver, "HomePage_MissingContent");
                }
                else
                {
                    LogHelper.Info("All expected content is present");
                }
                
                return hasMissingContent;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Could not verify content: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks for system errors on the homepage
        /// </summary>
        /// <returns>True if system errors detected, false otherwise</returns>
        public bool HasSystemErrors()
        {
            try
            {
                LogHelper.Info("Checking for system errors");
                
                // Check for common error indicators
                By systemErrorLocators = By.CssSelector(".system-error, .server-error, [class*='500'], [class*='error-page']");
                bool hasSystemError = IsDisplayed(systemErrorLocators);
                
                // Also check page title for error indicators
                string pageTitle = Driver.Title.ToLower();
                bool titleHasError = pageTitle.Contains("error") || pageTitle.Contains("404") || pageTitle.Contains("500");
                
                bool hasErrors = hasSystemError || titleHasError;
                
                if (hasErrors)
                {
                    LogHelper.Warning($"System error detected - Element: {hasSystemError}, Title: {titleHasError}");
                    ScreenshotHelper.TakeScreenshot(Driver, "HomePage_SystemError");
                }
                else
                {
                    LogHelper.Info("No system errors detected");
                }
                
                return hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Could not verify system errors: {ex.Message}");
                return false;
            }
        }

        // SECTION 4: DATA RETRIEVAL

        /// <summary>
        /// Gets the current page title
        /// </summary>
        /// <returns>Page title as string</returns>
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
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        /// <returns>Current URL as string</returns>
        public string GetCurrentUrl()
        {
            try
            {
                string url = Driver.Url;
                LogHelper.Info($"Current URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get current URL: {ex.Message}");
                return string.Empty;
            }
        }
    }
}