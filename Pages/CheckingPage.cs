using System;
using OpenQA.Selenium;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Checking Page
    /// Test Cases: TASK0020445 TS-003, TS-004
    /// </summary>
    public class CheckingPage : BasePage
    {
        // CONSTRUCTOR
        public CheckingPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS (Private, Read-only Properties)
        private By PageHeading => By.XPath("//h1[contains(text(),'Checking')]");
        private By FreeCheckingLink => By.XPath("//a[normalize-space()='Free Checking']");

        // SECTION 2: PAGE ACTIONS (Public Methods)
        
        /// <summary>
        /// Clicks on the Free Checking link
        /// </summary>
        public void ClickFreeCheckingLink()
        {
            LogHelper.Info("Clicking on Free Checking link");
            WaitHelper.WaitClickable(Driver, FreeCheckingLink, 10);
            Click(FreeCheckingLink);
            LogHelper.Info("Free Checking link clicked successfully");
        }

        // SECTION 3: VERIFICATIONS (Public Methods returning bool)
        
        /// <summary>
        /// Verifies if the Checking page is displayed
        /// </summary>
        /// <returns>True if Checking page is displayed, false otherwise</returns>
        public bool IsCheckingPageDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageHeading, 10);
                bool isDisplayed = IsDisplayed(PageHeading);
                LogHelper.Info($"Checking page displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Checking page not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the Free Checking link is visible
        /// </summary>
        /// <returns>True if Free Checking link is visible, false otherwise</returns>
        public bool IsFreeCheckingLinkVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, FreeCheckingLink, 10);
                bool isVisible = IsDisplayed(FreeCheckingLink);
                LogHelper.Info($"Free Checking link visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Free Checking link not visible: {ex.Message}");
                return false;
            }
        }

        // SECTION 4: DATA RETRIEVAL
        
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