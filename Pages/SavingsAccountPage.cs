using System;
using OpenQA.Selenium;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.Pages
{
    public class SavingsAccountPage : BasePage
    {
        // Constructor
        public SavingsAccountPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS (Private, Read-only Properties)
        private By PageHeading => By.XPath("//h1[contains(text(),'Savings') or contains(text(),'Account')]");
        private By PageContent => By.CssSelector(".page-content, .main-content");

        // SECTION 2: VERIFICATIONS (Public Methods returning bool)
        public bool IsSavingsAccountPageDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying Savings Account page is displayed");
                WaitHelper.WaitVisible(Driver, PageHeading, 10);
                bool isDisplayed = IsDisplayed(PageHeading) || Driver.Url.Contains("savings");
                LogHelper.Info($"Savings Account page displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Savings Account page not displayed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "SavingsAccountPage_NotDisplayed");
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