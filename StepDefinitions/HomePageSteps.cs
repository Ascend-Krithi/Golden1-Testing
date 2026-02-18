using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for Golden1 Homepage interactions
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
        /// Step: User launches the browser
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Given(@"User launches the browser")]
        public void GivenUserLaunchesTheBrowser()
        {
            LogHelper.Info("Step: User launches the browser");
            // Browser is already launched in Hooks.cs
            Assert.That(_driver, Is.Not.Null, "Browser should be launched successfully");
            LogHelper.Info("Browser launched successfully");
        }

        /// <summary>
        /// Step: User navigates to Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001, etc.
        /// </summary>
        [When(@"User navigates to Golden1 homepage")]
        public void WhenUserNavigatesToGolden1Homepage()
        {
            LogHelper.Info("Step: User navigates to Golden1 homepage");
            _homePage.OpenHomePage();
            LogHelper.Info("Navigated to Golden1 homepage");
        }

        /// <summary>
        /// Step: Homepage should load successfully without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"Homepage should load successfully without errors")]
        public void ThenHomepageShouldLoadSuccessfullyWithoutErrors()
        {
            LogHelper.Info("Step: Verifying homepage loads successfully without errors");
            
            bool isLoaded = _homePage.IsHomePageLoaded();
            Assert.That(isLoaded, Is.True, "Homepage should load successfully");
            
            bool hasNoErrors = _homePage.HasNoErrors();
            Assert.That(hasNoErrors, Is.True, "Homepage should not display any errors");
            
            LogHelper.Info("Homepage loaded successfully without errors");
        }

        /// <summary>
        /// Step: Golden1 logo should be visible in the header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"Golden1 logo should be visible in the header")]
        public void ThenGolden1LogoShouldBeVisibleInTheHeader()
        {
            LogHelper.Info("Step: Verifying Golden1 logo is visible in header");
            
            bool isLogoVisible = _homePage.IsLogoVisible();
            Assert.That(isLogoVisible, Is.True, "Golden1 logo should be visible in the header");
            
            LogHelper.Info("Golden1 logo is visible in header");
        }

        /// <summary>
        /// Step: Homepage should display correctly without layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"Homepage should display correctly without layout issues")]
        public void ThenHomepageShouldDisplayCorrectlyWithoutLayoutIssues()
        {
            LogHelper.Info("Step: Verifying homepage displays correctly without layout issues");
            
            bool isDisplayedCorrectly = _homePage.IsPageDisplayedCorrectly();
            Assert.That(isDisplayedCorrectly, Is.True, "Homepage should display correctly without layout issues");
            
            LogHelper.Info("Homepage displays correctly without layout issues");
        }

        /// <summary>
        /// Step: No error messages should be displayed
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"No error messages should be displayed")]
        public void ThenNoErrorMessagesShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying no error messages are displayed");
            
            bool hasNoErrors = _homePage.HasNoErrors();
            Assert.That(hasNoErrors, Is.True, "No error messages should be displayed on the page");
            
            LogHelper.Info("No error messages displayed");
        }

        /// <summary>
        /// Step: No missing content should be present
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"No missing content should be present")]
        public void ThenNoMissingContentShouldBePresent()
        {
            LogHelper.Info("Step: Verifying no missing content");
            
            bool isPageLoaded = _homePage.IsHomePageLoaded();
            Assert.That(isPageLoaded, Is.True, "Page content should be fully loaded without missing elements");
            
            LogHelper.Info("No missing content detected");
        }
    }
}