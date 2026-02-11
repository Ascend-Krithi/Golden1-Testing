using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Golden1 Homepage scenarios
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
        /// Step: Launch the browser
        /// Test Case: TASK0020445 TS-001 TC-001 Step 1
        /// </summary>
        [Given(@"I launch the browser")]
        public void GivenILaunchTheBrowser()
        {
            LogHelper.Info("Browser launched via Hooks - verifying driver is ready");
            Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
            LogHelper.Info("Browser is ready for testing");
        }

        /// <summary>
        /// Step: Navigate to Golden1 homepage
        /// Test Case: TASK0020445 TS-001 TC-001 Step 2, TS-002 TC-001 Step 1
        /// </summary>
        [When(@"I navigate to the Golden1 homepage")]
        [Given(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden1 homepage");
            _homePage.OpenHomePage();
            LogHelper.Info("Navigation to homepage completed");
        }

        /// <summary>
        /// Step: Verify homepage is displayed without errors
        /// Test Case: TASK0020445 TS-001 TC-001 Step 3
        /// </summary>
        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            LogHelper.Info("Verifying homepage is displayed without errors");
            
            bool isDisplayed = _homePage.IsHomePageDisplayed();
            Assert.That(isDisplayed, Is.True, 
                "Homepage should be displayed without errors");
            
            LogHelper.Info("Homepage verification completed successfully");
        }

        /// <summary>
        /// Step: Verify Golden1 logo is visible
        /// Test Case: TASK0020445 TS-008 TC-001 Step 2
        /// </summary>
        [Then(@"the Golden1 logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            LogHelper.Info("Verifying Golden1 logo is visible");
            
            bool isLogoVisible = _homePage.IsLogoVisible();
            Assert.That(isLogoVisible, Is.True, 
                "Golden1 logo should be visible in the header area");
            
            LogHelper.Info("Logo visibility verification completed");
        }

        /// <summary>
        /// Step: Verify homepage displays all content correctly
        /// Test Case: TASK0020445 TS-009 TC-001 Step 2
        /// </summary>
        [Then(@"the homepage should display all content correctly")]
        public void ThenTheHomepageShouldDisplayAllContentCorrectly()
        {
            LogHelper.Info("Verifying homepage content displays correctly");
            
            bool contentDisplayed = _homePage.IsContentDisplayedCorrectly();
            Assert.That(contentDisplayed, Is.True, 
                "Homepage content should be displayed correctly");
            
            LogHelper.Info("Content display verification completed");
        }

        /// <summary>
        /// Step: Verify no broken layouts
        /// Test Case: TASK0020445 TS-009 TC-001 Step 2
        /// </summary>
        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            LogHelper.Info("Checking for broken layouts");
            
            bool hasBrokenLayouts = _homePage.HasBrokenLayouts();
            Assert.That(hasBrokenLayouts, Is.False, 
                "Homepage should not have any broken layouts");
            
            LogHelper.Info("Broken layout check completed");
        }

        /// <summary>
        /// Step: Verify no error messages
        /// Test Case: TASK0020445 TS-009 TC-001 Step 2
        /// </summary>
        [Then(@"there should be no error messages")]
        public void ThenThereShouldBeNoErrorMessages()
        {
            LogHelper.Info("Checking for error messages");
            
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.That(hasErrors, Is.False, 
                "Homepage should not display any error messages");
            
            LogHelper.Info("Error message check completed");
        }
    }
}