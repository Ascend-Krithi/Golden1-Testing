using OpenQA.Selenium;
using System;

namespace Golden1.Automation.Pages
{
    public class CheckingPage : BasePage
    {
        // Locators
        private By PageHeading => By.CssSelector("h1, .page-title, .heading");
        private By ErrorMessageLocator => By.CssSelector(".error, .alert-danger, .error-message");
        private By PageContentLocator => By.CssSelector("main, .main-content, #main");

        // Constructor
        public CheckingPage() : base()
        {
            LogHelper.Info("CheckingPage object created");
        }

        // Verification Methods
        public bool IsPageLoaded()
        {
            try
            {
                LogHelper.Info("Checking if Checking page is loaded");
                WaitForPageLoad();
                WaitHelper.WaitVisible(Driver, PageContentLocator, 10);
                bool isLoaded = IsDisplayed(PageContentLocator);
                LogHelper.Info($"Checking page loaded: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify Checking page loaded: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, "IsPageLoaded_Failed");
                return false;
            }
        }

        public bool HasErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages on Checking page");
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

        // Data Retrieval Methods
        public string GetPageHeading()
        {
            try
            {
                LogHelper.Info("Getting page heading text");
                WaitHelper.WaitVisible(Driver, PageHeading, 10);
                string headingText = GetText(PageHeading);
                LogHelper.Info($"Page heading: {headingText}");
                return headingText;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get page heading: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, "GetPageHeading_Failed");
                throw;
            }
        }
    }
}