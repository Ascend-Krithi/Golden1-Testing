using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Homepage verification scenarios
    /// Test Case: TASK0020445 TS-009 TC-001
    /// </summary>
    [Binding]
    public class HomepageSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public HomepageSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _homePage = new HomePage(_driver);
        }

        /// <summary>
        /// Step: User launches the Golden 1 homepage
        /// Test Case: TASK0020445 TS-009 TC-001 - Step 1
        /// </summary>
        [Given(@"User launches the Golden 1 homepage")]
        public void GivenUserLaunchesTheGolden1Homepage()
        {
            try
            {
                LogHelper.Info("[TASK0020445 TS-009 TC-001] Step 1: Launching the Golden 1 homepage");
                _homePage.OpenHomePage();
                LogHelper.Info("Homepage launched successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to launch homepage: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Launch_Failed");
                throw;
            }
        }

        /// <summary>
        /// Step: User should see the homepage loaded successfully
        /// Test Case: TASK0020445 TS-009 TC-001 - Step 2 Verification
        /// </summary>
        [Then(@"User should see the homepage loaded successfully")]
        public void ThenUserShouldSeeTheHomepageLoadedSuccessfully()
        {
            try
            {
                LogHelper.Info("[TASK0020445 TS-009 TC-001] Step 2: Verifying homepage loads successfully");
                
                // Verify page title
                string pageTitle = _homePage.GetPageTitle();
                LogHelper.Info($"Page title: {pageTitle}");
                Assert.That(pageTitle, Is.Not.Null.And.Not.Empty, 
                    "Homepage title should not be null or empty");
                
                // Verify URL
                string currentUrl = _homePage.GetCurrentUrl();
                LogHelper.Info($"Current URL: {currentUrl}");
                Assert.That(currentUrl, Does.Contain("golden1.com"), 
                    "URL should contain 'golden1.com'");
                
                // Verify navigation menu is visible
                bool isMenuVisible = _homePage.IsNavigationMenuVisible();
                LogHelper.Info($"Navigation menu visible: {isMenuVisible}");
                Assert.That(isMenuVisible, Is.True, 
                    "Navigation menu should be visible on homepage");
                
                LogHelper.Info("Homepage loaded successfully - All verifications passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Load_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Step: User should verify no broken layouts or error messages are displayed
        /// Test Case: TASK0020445 TS-009 TC-001 - Step 2 Final Verification
        /// </summary>
        [Then(@"User should verify no broken layouts or error messages are displayed")]
        public void ThenUserShouldVerifyNoBrokenLayoutsOrErrorMessagesAreDisplayed()
        {
            try
            {
                LogHelper.Info("[TASK0020445 TS-009 TC-001] Verifying no broken layouts or error messages");
                
                // Verify no error messages
                bool hasErrorMessages = _homePage.HasErrorMessages();
                LogHelper.Info($"Error messages present: {hasErrorMessages}");
                Assert.That(hasErrorMessages, Is.False, 
                    "Homepage should not display any error messages");
                
                // Verify top tabs are visible
                bool areTopTabsVisible = _homePage.AreTopTabsVisible();
                LogHelper.Info($"Top tabs visible: {areTopTabsVisible}");
                Assert.That(areTopTabsVisible, Is.True, 
                    "Top tabs should be visible indicating proper layout");
                
                // Verify main menu items are visible
                bool areMainMenuItemsVisible = _homePage.AreMainMenuItemsVisible();
                LogHelper.Info($"Main menu items visible: {areMainMenuItemsVisible}");
                Assert.That(areMainMenuItemsVisible, Is.True, 
                    "Main menu items should be visible indicating proper layout");
                
                // Handle cookie banner if present
                _homePage.HandleCookieBannerIfPresent();
                
                LogHelper.Info("No broken layouts or error messages found - Verification passed");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Verification_Success");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout/Error verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Layout_Verification_Failed");
                throw;
            }
        }
    }
}