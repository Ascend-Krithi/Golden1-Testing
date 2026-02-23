using System;
using OpenQA.Selenium;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Savings Account Page
    /// Test Cases: TASK0020445 TS-005
    /// </summary>
    public class SavingsAccountPage : BasePage
    {
        // CONSTRUCTOR
        public SavingsAccountPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS (Private, Read-only Properties)
        private By PageHeading => By.XPath("//h1[contains(text(),'Savings')]");
        private By PageContent => By.CssSelector(".page-content");

        // SECTION 2: VERIFICATIONS (Public Methods returning bool)
        
        /// <summary>
        /// Verifies if the Savings Account page is displayed
        /// </summary>
        /// <returns>True if Savings Account page is displayed, false otherwise</returns>
        public bool IsSavingsAccountPageDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageHeading, 10);
                bool isDisplayed = IsDisplayed(PageHeading);
                LogHelper.Info($"Savings Account page displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Savings Account page not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the page content is visible
        /// </summary>
        /// <returns>True if page content is visible, false otherwise</returns>
        public bool IsPageContentVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageContent, 10);
                bool isVisible = IsDisplayed(PageContent);
                LogHelper.Info($"Page content visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page content not visible: {ex.Message}");
                return false;
            }
        }

        // SECTION 3: DATA RETRIEVAL
        
        /// <summary>
        /// Gets the page heading text
        /// </summary>
        /// <returns>Page heading text as string</returns>
        public string GetPageHeading()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageHeading, 10);
                string heading = GetText(PageHeading);
                LogHelper.Info($"Page heading: {heading}");
                return heading;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Could not get page heading: {ex.Message}");
                return string.Empty;
            }
        }
    }
}