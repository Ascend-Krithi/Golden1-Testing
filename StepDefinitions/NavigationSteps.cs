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
    /// Step Definitions for Golden 1 Navigation Tests
    /// Test Cases: TASK0020445 TS-001 through TS-012
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _homePage = new HomePage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================

        /// <summary>
        /// Step: Given the browser is launched
        /// Test Cases: All test scenarios
        /// </summary>
        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("Browser is already launched via Hooks");
            Assert.That(_driver, Is.Not.Null, "Driver should be initialized");
        }

        /// <summary>
        /// Step: Given the browser type is "<Browser>"
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Given(@"the browser type is 