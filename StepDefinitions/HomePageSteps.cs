using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Golden 1 Homepage scenarios
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
        /// Step: When I navigate to the Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
        /// </summary>
        [When(@"I navigate to the Golden 1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Step: Navigating to Golden 1 homepage");
            _homePage.OpenHomePage();
            _scenarioContext.Set(_homePage, "HomePage");
        }

        /// <summary>
        /// Step: Then the homepage should be displayed without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            LogHelper.Info("Step: Verifying homepage is displayed without errors");
            bool isDisplayed = _homePage.IsHomepageDisplayedWithoutErrors();
            Assert.That(isDisplayed, Is.True, "Homepage should be displayed without errors");
            LogHelper.Info("Assertion passed: Homepage displayed successfully");
        }

        /// <summary>
        /// Step: Then the Golden 1 logo should be visible in the header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            LogHelper.Info("Step: Verifying Golden 1 logo is visible");
            bool isLogoVisible = _homePage.IsLogoVisible();
            Assert.That(isLogoVisible, Is.True, "Golden 1 logo should be visible in the header");
            LogHelper.Info("Assertion passed: Logo is visible");
        }

        /// <summary>
        /// Step: Then the homepage should display all content correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should display all content correctly")]
        public void ThenTheHomepageShouldDisplayAllContentCorrectly()
        {
            LogHelper.Info("Step: Verifying homepage displays all content correctly");
            bool isContentCorrect = _homePage.IsContentDisplayedCorrectly();
            Assert.That(isContentCorrect, Is.True, "Homepage should display all content correctly");
            LogHelper.Info("Assertion passed: Content displayed correctly");
        }

        /// <summary>
        /// Step: And there should be no broken layouts
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            LogHelper.Info("Step: Verifying no broken layouts");
            bool noBrokenLayouts = _homePage.HasNoBrokenLayouts();
            Assert.That(noBrokenLayouts, Is.True, "There should be no broken layouts on the homepage");
            LogHelper.Info("Assertion passed: No broken layouts found");
        }

        /// <summary>
        /// Step: And there should be no error messages
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no error messages")]
        public void ThenThereShouldBeNoErrorMessages()
        {
            LogHelper.Info("Step: Verifying no error messages");
            bool noErrors = _homePage.HasNoErrorMessages();
            Assert.That(noErrors, Is.True, "There should be no error messages on the homepage");
            LogHelper.Info("Assertion passed: No error messages found");
        }
    }
}