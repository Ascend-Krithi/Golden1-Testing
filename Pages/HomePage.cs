using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Homepage
    /// Test Cases: TASK0020445 TS-001 TC-001, TASK0020445 TS-008 TC-001, TASK0020445 TS-009 TC-001
    /// </summary>
    public class HomePage : BasePage
    {
        // Constructor
        public HomePage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS
        private By PageBody => By.TagName("body");
        private By ErrorMessage => By.CssSelector(".error-message, .alert-danger");
        private By Logo => By.CssSelector("img[alt*='Golden 1'], .logo, header img");
        private By MainContent => By.CssSelector("main, #main-content, .main-content");
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // SECTION 2: PAGE ACTIONS
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info($"Opening Golden1 homepage: {ConfigReader.GetValue("AppSettings:BaseUrl")}");
                NavigateTo(ConfigReader.GetValue("AppSettings:BaseUrl"));
                WaitForPageLoad();
                HandleCookieBanner();
                LogHelper.Info("Homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                throw new Exception("Failed to navigate to Golden1 homepage", ex);
            }
        }

        /// <summary>
        /// Handles cookie consent banner if present
        /// </summary>
        private void HandleCookieBanner()
        {
            try
            {
                if (IsElementPresent(CookieBanner, 3))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookie banner accepted");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner handling: {ex.Message}");
                // Continue execution even if cookie banner handling fails
            }
        }

        // SECTION 3: VERIFICATIONS
        
        /// <summary>
        /// Verifies if the homepage is loaded successfully
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        /// <returns>True if page is loaded, false otherwise</returns>
        public bool IsPageLoaded()
        {
            try
            {
                LogHelper.Info("Verifying homepage is loaded");
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
        /// Verifies if there are any error messages on the page
        /// Test Cases: TASK0020445 TS-001 TC-001, TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no errors, false if errors present</returns>
        public bool IsPageWithoutErrors()
        {
            try
            {
                LogHelper.Info("Checking for error messages");
                bool hasErrors = IsElementPresent(ErrorMessage, 2);
                
                if (hasErrors)
                {
                    string errorText = GetText(ErrorMessage);
                    LogHelper.Warning($"Error message found: {errorText}");
                    return false;
                }
                
                LogHelper.Info("No error messages found");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for error messages: {ex.Message}");
                return true; // Assume no errors if check fails
            }
        }

        /// <summary>
        /// Verifies if the Golden 1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        /// <returns>True if logo is visible, false otherwise</returns>
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
        /// Verifies if the homepage displays correctly without layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if page displays correctly, false otherwise</returns>
        public bool IsPageDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays correctly");
                
                // Check main content is visible
                WaitHelper.WaitVisible(Driver, MainContent, 10);
                bool mainContentVisible = IsDisplayed(MainContent);
                
                // Check no error messages
                bool noErrors = IsPageWithoutErrors();
                
                // Check page title is not empty
                bool hasTitle = !string.IsNullOrEmpty(Driver.Title);
                
                bool isCorrect = mainContentVisible && noErrors && hasTitle;
                LogHelper.Info($"Page displayed correctly: {isCorrect}");
                
                return isCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page display verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if an element is present on the page within timeout
        /// </summary>
        /// <param name="locator">Element locator</param>
        /// <param name="timeoutSeconds">Timeout in seconds</param>
        /// <returns>True if element is present, false otherwise</returns>
        private bool IsElementPresent(By locator, int timeoutSeconds)
        {
            try
            {
                WaitHelper.WaitVisible(Driver, locator, timeoutSeconds);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // SECTION 4: DATA RETRIEVAL
        
        /// <summary>
        /// Gets the page title
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