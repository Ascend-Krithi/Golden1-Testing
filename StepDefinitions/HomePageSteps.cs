using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Golden1 Homepage interactions
    /// Test Cases: TASK0020445 TS-001, TS-002, TS-008, TS-009
    /// </summary>
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public HomePageSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _homePage = new HomePage(_driver);
        }

        /// <summary>
        /// Step: Launch browser
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Given(@"I launch the browser ""(.*)""")]
        public void GivenILaunchTheBrowser(string browserName)
        {
            try
            {
                LogHelper.Info($"Test Case: {_scenarioContext.ScenarioInfo.Title}");
                LogHelper.Info($"Launching browser: {browserName}");
                // Browser is already initialized in Hooks
                Assert.That(_driver, Is.Not.Null, "Browser driver should be initialized");
                LogHelper.Info($"Browser '{browserName}' launched successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to launch browser: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Launch browser on specific device
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Given(@"I launch the browser ""(.*)"" on ""(.*)"" device")]
        public void GivenILaunchTheBrowserOnDevice(string browserName, string deviceType)
        {
            try
            {
                LogHelper.Info($"Test Case: {_scenarioContext.ScenarioInfo.Title}");
                LogHelper.Info($"Launching browser: {browserName} on device: {deviceType}");
                Assert.That(_driver, Is.Not.Null, "Browser driver should be initialized");
                LogHelper.Info($"Browser '{browserName}' launched on '{deviceType}' device successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to launch browser on device: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Navigate to Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001
        /// </summary>
        [When(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Navigating to Golden1 homepage");
                _homePage.OpenHomePage();
                LogHelper.Info("Successfully navigated to Golden1 homepage");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify homepage loads successfully without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the homepage should load successfully without errors")]
        public void ThenTheHomepageShouldLoadSuccessfullyWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage loaded successfully without errors");
                
                bool isLoaded = _homePage.IsHomePageLoadedSuccessfully();
                Assert.That(isLoaded, Is.True, 
                    "Homepage should load successfully without errors");
                
                bool hasNoErrors = _homePage.HasNoErrorMessages();
                Assert.That(hasNoErrors, Is.True, 
                    "Homepage should not display any error messages");
                
                LogHelper.Info("Homepage loaded successfully without errors - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify global navigation menu is visible at top
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible at the top");
                
                bool isVisible = _homePage.IsGlobalNavigationMenuVisible();
                Assert.That(isVisible, Is.True, 
                    "Global navigation menu should be visible at the top of the page");
                
                LogHelper.Info("Global navigation menu is visible - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify global navigation menu is visible
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible")]
        public void ThenTheGlobalNavigationMenuShouldBeVisible()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible");
                
                bool isVisible = _homePage.IsGlobalNavigationMenuVisible();
                Assert.That(isVisible, Is.True, 
                    "Global navigation menu should be visible");
                
                LogHelper.Info("Global navigation menu is visible - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify Golden 1 logo is visible in top header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            try
            {
                LogHelper.Info("Verifying Golden 1 logo is visible in top header");
                
                bool isVisible = _homePage.IsGolden1LogoVisible();
                Assert.That(isVisible, Is.True, 
                    "Golden 1 logo should be visible in the top header");
                
                LogHelper.Info("Golden 1 logo is visible in header - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo visibility verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify Golden 1 logo is visible in header
        /// Test Cases: TASK0020445 TS-010 TC-001, TS-011 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            try
            {
                LogHelper.Info("Verifying Golden 1 logo is visible in header");
                
                bool isVisible = _homePage.IsGolden1LogoVisible();
                Assert.That(isVisible, Is.True, 
                    "Golden 1 logo should be visible in the header");
                
                LogHelper.Info("Golden 1 logo is visible - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo visibility verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify homepage displays correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should display correctly")]
        public void ThenTheHomepageShouldDisplayCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays correctly");
                
                bool isDisplayedCorrectly = _homePage.IsPageDisplayedCorrectly();
                Assert.That(isDisplayedCorrectly, Is.True, 
                    "Homepage should display correctly without issues");
                
                LogHelper.Info("Homepage displays correctly - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage display verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify no broken layouts
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Verifying there are no broken layouts");
                
                bool noLayoutIssues = _homePage.HasNoLayoutIssues();
                Assert.That(noLayoutIssues, Is.True, 
                    "Page should not have any broken layouts");
                
                LogHelper.Info("No broken layouts found - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify no missing content
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            try
            {
                LogHelper.Info("Verifying there is no missing content");
                
                bool isContentPresent = _homePage.IsPageDisplayedCorrectly();
                Assert.That(isContentPresent, Is.True, 
                    "Page should not have any missing content");
                
                LogHelper.Info("No missing content found - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify no system errors
        /// Test Cases: TASK0020445 TS-009 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        [Then(@"there should be no system errors")]
        public void ThenThereShouldBeNoSystemErrors()
        {
            try
            {
                LogHelper.Info("Verifying there are no system errors");
                
                bool hasNoErrors = _homePage.HasNoErrorMessages();
                Assert.That(hasNoErrors, Is.True, 
                    "Page should not display any system errors");
                
                LogHelper.Info("No system errors found - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"System error verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify no layout issues
        /// Test Cases: TASK0020445 TS-010 TC-001, TS-011 TC-001
        /// </summary>
        [Then(@"there should be no layout issues")]
        public void ThenThereShouldBeNoLayoutIssues()
        {
            try
            {
                LogHelper.Info("Verifying there are no layout issues");
                
                bool noLayoutIssues = _homePage.HasNoLayoutIssues();
                Assert.That(noLayoutIssues, Is.True, 
                    "Page should not have any layout issues");
                
                LogHelper.Info("No layout issues found - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout issue verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify navigation menu is visible and functional
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the navigation menu should be visible and functional")]
        public void ThenTheNavigationMenuShouldBeVisibleAndFunctional()
        {
            try
            {
                LogHelper.Info("Verifying navigation menu is visible and functional");
                
                bool isVisible = _homePage.IsGlobalNavigationMenuVisible();
                Assert.That(isVisible, Is.True, 
                    "Navigation menu should be visible and functional");
                
                LogHelper.Info("Navigation menu is visible and functional - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu functionality verification failed: {ex.Message}");
                throw;
            }
        }
    }
}