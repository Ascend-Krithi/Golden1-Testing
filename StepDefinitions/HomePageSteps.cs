using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;
using Golden1.Automation.Drivers;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for Golden 1 Homepage interactions
    /// Test Cases: TASK0020445 TS-001, TS-008, TS-009
    /// </summary>
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public HomePageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _homePage = new HomePage(_driver);
        }

        /// <summary>
        /// Step: Given I launch a supported browser
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Given(@"I launch a supported browser")]
        public void GivenILaunchASupportedBrowser()
        {
            try
            {
                LogHelper.Info("Step: Launching a supported browser");
                // Browser is already initialized in Hooks
                Assert.That(_driver, Is.Not.Null, "Browser should be launched successfully");
                LogHelper.Info("Browser launched successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to launch browser: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: When I navigate to the Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001
        /// </summary>
        [When(@"I navigate to the Golden 1 homepage")]
        [Given(@"I navigate to the Golden 1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Step: Navigating to Golden 1 homepage");
                _homePage.OpenHomePage();
                LogHelper.Info("Successfully navigated to homepage");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "NavigationFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: Then the homepage should be displayed without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            try
            {
                LogHelper.Info("Step: Verifying homepage is displayed without errors");
                bool isDisplayed = _homePage.IsHomePageDisplayedWithoutErrors();
                
                Assert.That(isDisplayed, Is.True, 
                    "Homepage should be displayed without errors");
                
                LogHelper.Info("Homepage verified successfully - no errors found");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "HomepageVerificationFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: Then the Golden 1 logo should be visible in the top header area
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the top header area")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeaderArea()
        {
            try
            {
                LogHelper.Info("Step: Verifying Golden 1 logo is visible");
                bool isLogoVisible = _homePage.IsLogoVisible();
                
                Assert.That(isLogoVisible, Is.True, 
                    "Golden 1 logo should be visible in the top header area");
                
                LogHelper.Info("Golden 1 logo verified successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "LogoVerificationFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: Then the homepage should display all content correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should display all content correctly")]
        public void ThenTheHomepageShouldDisplayAllContentCorrectly()
        {
            try
            {
                LogHelper.Info("Step: Verifying homepage displays all content correctly");
                bool isContentCorrect = _homePage.IsContentDisplayedCorrectly();
                
                Assert.That(isContentCorrect, Is.True, 
                    "Homepage should display all content correctly");
                
                LogHelper.Info("Homepage content verified successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "ContentVerificationFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: And there should be no broken layouts
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Step: Checking for broken layouts");
                bool noBrokenLayouts = _homePage.HasNoBrokenLayouts();
                
                Assert.That(noBrokenLayouts, Is.True, 
                    "Homepage should have no broken layouts");
                
                LogHelper.Info("No broken layouts found");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Broken layout check failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "BrokenLayoutCheck");
                throw;
            }
        }

        /// <summary>
        /// Step: And there should be no error messages
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no error messages")]
        public void ThenThereShouldBeNoErrorMessages()
        {
            try
            {
                LogHelper.Info("Step: Checking for error messages");
                bool noErrors = _homePage.HasNoErrorMessages();
                
                Assert.That(noErrors, Is.True, 
                    "Homepage should have no error messages");
                
                LogHelper.Info("No error messages found");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error message check failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "ErrorMessageCheck");
                throw;
            }
        }
    }
}