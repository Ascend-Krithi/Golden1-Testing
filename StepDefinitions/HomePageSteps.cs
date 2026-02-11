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

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================
        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            try
            {
                LogHelper.Info("Browser is already launched in hooks");
                Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Browser launch verification failed: {ex.Message}");
                throw;
            }
        }

        [Given(@"user navigates to Golden 1 homepage")]
        public void GivenUserNavigatesToGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Step: User navigates to Golden 1 homepage");
                _homePage.OpenHomepage();
                Assert.That(_homePage.IsHomepageDisplayed(), Is.True, 
                    "Homepage should be displayed after navigation");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage navigation failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Navigation_Failed");
                throw;
            }
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================
        [When(@"user navigates to Golden 1 homepage")]
        public void WhenUserNavigatesToGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Step: User navigates to Golden 1 homepage");
                _homePage.OpenHomepage();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage navigation action failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Navigation_Action_Failed");
                throw;
            }
        }

        [When(@"user checks the top section of the homepage")]
        public void WhenUserChecksTheTopSectionOfTheHomepage()
        {
            try
            {
                LogHelper.Info("Step: User checks the top section of the homepage");
                // Verification will be done in Then step
                _scenarioContext["TopSectionChecked"] = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top section check failed: {ex.Message}");
                throw;
            }
        }

        [When(@"user checks the top header area")]
        public void WhenUserChecksTheTopHeaderArea()
        {
            try
            {
                LogHelper.Info("Step: User checks the top header area");
                _scenarioContext["HeaderAreaChecked"] = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Header area check failed: {ex.Message}");
                throw;
            }
        }

        [When(@"user inspects the homepage")]
        public void WhenUserInspectsTheHomepage()
        {
            try
            {
                LogHelper.Info("Step: User inspects the homepage");
                _scenarioContext["HomepageInspected"] = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage inspection failed: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================
        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            try
            {
                LogHelper.Info("Step: Verifying homepage is displayed without errors");
                
                bool isDisplayed = _homePage.IsHomepageDisplayed();
                Assert.That(isDisplayed, Is.True, 
                    "TASK0020445 TS-001 TC-001: Homepage should be displayed");
                
                bool hasNoErrors = _homePage.HasNoErrorMessages();
                Assert.That(hasNoErrors, Is.True, 
                    "TASK0020445 TS-001 TC-001: Homepage should have no error messages");
                
                LogHelper.Info("Homepage displayed successfully without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Verification_Failed");
                throw;
            }
        }

        [Then(@"the Golden 1 logo should be visible")]
        public void ThenTheGolden1LogoShouldBeVisible()
        {
            try
            {
                LogHelper.Info("Step: Verifying Golden 1 logo is visible");
                
                bool isLogoVisible = _homePage.IsLogoVisible();
                Assert.That(isLogoVisible, Is.True, 
                    "TASK0020445 TS-008 TC-001: Golden 1 logo should be visible in header");
                
                LogHelper.Info("Golden 1 logo is visible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Logo_Verification_Failed");
                throw;
            }
        }

        [Then(@"the homepage should display all content correctly")]
        public void ThenTheHomepageShouldDisplayAllContentCorrectly()
        {
            try
            {
                LogHelper.Info("Step: Verifying homepage displays all content correctly");
                
                bool contentDisplayed = _homePage.IsContentDisplayedCorrectly();
                Assert.That(contentDisplayed, Is.True, 
                    "TASK0020445 TS-009 TC-001: Homepage should display all content correctly");
                
                LogHelper.Info("Homepage content displays correctly");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content display verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Content_Display_Failed");
                throw;
            }
        }

        [Then(@"there should be no broken layouts or error messages")]
        public void ThenThereShouldBeNoBrokenLayoutsOrErrorMessages()
        {
            try
            {
                LogHelper.Info("Step: Verifying no broken layouts or error messages");
                
                bool hasNoErrors = _homePage.HasNoErrorMessages();
                Assert.That(hasNoErrors, Is.True, 
                    "TASK0020445 TS-009 TC-001: Homepage should have no error messages or broken layouts");
                
                LogHelper.Info("No broken layouts or error messages found");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Layout_Verification_Failed");
                throw;
            }
        }
    }
}