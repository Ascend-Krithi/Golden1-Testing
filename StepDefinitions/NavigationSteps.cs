using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for Golden1 Navigation Tests
    /// Test Cases: TASK0020445 TS-001 to TS-009
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _navigationPage = new NavigationPage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================

        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001 through TS-009 TC-001
        /// </summary>
        [Given(@"I launch the Golden 1 homepage")]
        public void GivenILaunchTheGolden1Homepage()
        {
            LogHelper.Info("Step: Launch the Golden 1 homepage");
            _navigationPage.OpenHomePage();
            Assert.That(_navigationPage.IsHomepageLoaded(), Is.True, 
                "Golden 1 homepage failed to load");
            LogHelper.Info("Golden 1 homepage launched successfully");
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        /// <summary>
        /// Enters the website URL in the address bar
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [When(@"I enter the website URL in the address bar")]
        public void WhenIEnterTheWebsiteURLInTheAddressBar()
        {
            LogHelper.Info("Step: Enter the website URL in the address bar");
            // URL is already entered in the Given step
            LogHelper.Info("Website URL entered successfully");
        }

        /// <summary>
        /// Locates the global navigation menu
        /// Test Cases: TASK0020445 TS-003 TC-001, TS-004 TC-001
        /// </summary>
        [When(@"I locate the global navigation menu")]
        public void WhenILocateTheGlobalNavigationMenu()
        {
            LogHelper.Info("Step: Locate the global navigation menu");
            Assert.That(_navigationPage.IsGlobalNavigationMenuVisible(), Is.True,
                "Global navigation menu is not visible");
            LogHelper.Info("Global navigation menu located successfully");
        }

        /// <summary>
        /// Expands a main product category menu
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to expand</param>
        [When(@"I expand the 