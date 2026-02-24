using OpenQA.Selenium;
using System;

namespace Golden1.Automation.Pages
{
    public class HomePage : BasePage
    {
        // Locators
        private By LogoLocator => By.CssSelector("a.logo, .header__logo, img[alt*='Golden 1']");
        private By ErrorMessageLocator => By.CssSelector(".error, .alert-danger, .error-message");
        private By SystemErrorLocator => By.XPath("//div[contains(text(),'Error') or contains(text(),'error') or contains(text(),'Exception')]");
        private By PageContentLocator => By.CssSelector("main, .main-content, #main");
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // Constructor
        public HomePage() : base()
        {
            LogHelper.Info("HomePage object created");
        }

        // Navigation Methods
        public void NavigateToHomepage()
        {
            try
            {
                LogHelper.Info("Navigating to Golden1 homepage");
                string baseUrl = ConfigReader.GetValue("BaseUrl");
                NavigateTo(baseUrl);
                WaitForPageLoad();
                LogHelper.Info($"Successfully navigated to: {baseUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, "NavigateToHomepage_Failed");
                throw;
            }
        }

        // Action Methods
        public void HandleCookieBanner()
        {
            try
            {
                LogHelper.Info("Checking for cookie banner");
                if (IsDisplayed(CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner detected, clicking accept button");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 10);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 10);
                    LogHelper.Info("Cookie banner accepted and closed");
                }
                else
                {
                    LogHelper.Info("No cookie banner found");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Cookie banner handling skipped: {ex.Message}");
                // Don't fail test if cookie banner handling fails
            }
        }

        // Verification Methods
        public bool IsLogoVisible()
        {
            try
            {
                LogHelper.Info("Checking if Golden 1 logo is visible");
                WaitHelper.WaitVisible(Driver, LogoLocator, 10);
                bool isVisible = IsDisplayed(LogoLocator);
                LogHelper.Info($"Logo visibility status: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to check logo visibility: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, "IsLogoVisible_Failed");
                return false;
            }
        }

        public bool HasErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages on page");
                bool hasErrors = IsDisplayed(ErrorMessageLocator, 3);
                LogHelper.Info($"Error messages present: {hasErrors}");
                return hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No error messages found: {ex.Message}");
                return false;
            }
        }

        public bool HasSystemErrors()
        {
            try
            {
                LogHelper.Info("Checking for system errors on page");
                bool hasSystemErrors = IsDisplayed(SystemErrorLocator, 3);
                LogHelper.Info($"System errors present: {hasSystemErrors}");
                return hasSystemErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No system errors found: {ex.Message}");
                return false;
            }
        }

        public bool IsPageLayoutCorrect()
        {
            try
            {
                LogHelper.Info("Verifying page layout is correct");
                WaitHelper.WaitVisible(Driver, PageContentLocator, 10);
                bool isLogoVisible = IsDisplayed(LogoLocator);
                bool hasContent = IsDisplayed(PageContentLocator);
                bool layoutCorrect = isLogoVisible && hasContent;
                LogHelper.Info($"Page layout correct: {layoutCorrect}");
                return layoutCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify page layout: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, "IsPageLayoutCorrect_Failed");
                return false;
            }
        }

        public bool HasMissingContent()
        {
            try
            {
                LogHelper.Info("Checking for missing content");
                bool hasContent = IsDisplayed(PageContentLocator, 5);
                bool hasMissingContent = !hasContent;
                LogHelper.Info($"Missing content detected: {hasMissingContent}");
                return hasMissingContent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to check for missing content: {ex.Message}");
                return true; // Assume missing content if check fails
            }
        }

        // Data Retrieval Methods
        public string GetCurrentUrl()
        {
            try
            {
                string currentUrl = Driver.Url;
                LogHelper.Info($"Current URL: {currentUrl}");
                return currentUrl;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get current URL: {ex.Message}");
                throw;
            }
        }
    }
}