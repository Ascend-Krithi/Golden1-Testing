using System;
using OpenQA.Selenium;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.Pages
{
    public class FreeCheckingPage : BasePage
    {
        // Constructor
        public FreeCheckingPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS (Private, Read-only Properties)
        private By PageHeading => By.XPath("//h1[contains(text(),'Free Checking') or contains(text(),'Checking')]");
        private By PageContent => By.CssSelector(".page-content, .main-content");

        // SECTION 2: VERIFICATIONS (Public Methods returning bool)
        public bool IsFreeCheckingPageDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying Free Checking page is displayed");
                WaitHelper.WaitVisible(Driver, PageHeading, 10);
                bool isDisplayed = IsDisplayed(PageHeading) || Driver.Url.Contains("checking");
                LogHelper.Info($"Free Checking page displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Free Checking page not displayed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "FreeCheckingPage_NotDisplayed");
                return false;
            }
        }

        // SECTION 3: DATA RETRIEVAL (Public Methods returning data)
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
    }
}