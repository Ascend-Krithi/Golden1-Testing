using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ProjectName.Automation.Pages;
using ProjectName.Automation.Utilities;
using ProjectName.Automation.Drivers;

namespace ProjectName.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Golden1 Homepage Navigation and Verification
    /// Test Cases: TASK0020445 TS-001 to TS-011
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            
            // Get driver from scenario context if exists, otherwise create new
            if (_scenarioContext.ContainsKey("WebDriver"))
            {
                _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            }
            else
            {
                _driver = DriverManager.CreateDriver();
                _scenarioContext.Set(_driver, "WebDriver");
            }
            
            _homePage = new HomePage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================

        /// <summary>
        /// Launches Chrome browser
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Given(@"I launch Chrome browser")]
        public void GivenILaunchChromeBrowser()
        {
            LogHelper.Info("Step: Launching Chrome browser");
            // Browser is already launched in constructor via DriverManager
            Assert.That(_driver, Is.Not.Null, "Chrome browser should be launched successfully");
            LogHelper.Info("Chrome browser launched successfully");
        }

        /// <summary>
        /// Launches specified browser
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Given(@"I launch (.*) browser")]
        public void GivenILaunchBrowser(string browserName)
        {
            LogHelper.Info($"Step: Launching {browserName} browser");
            // Browser is already launched in constructor
            Assert.That(_driver, Is.Not.Null, $"{browserName} browser should be launched successfully");
            LogHelper.Info($"{browserName} browser launched successfully");
        }

        /// <summary>
        /// Navigates to Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 to TS-011
        /// </summary>
        [Given(@"I navigate to Golden1 homepage")]
        [When(@"I navigate to Golden1 homepage")]
        public void GivenINavigateToGolden1Homepage()
        {
            LogHelper.Info("Step: Navigating to Golden1 homepage");
            _homePage.OpenHomepage();
            LogHelper.Info("Successfully navigated to Golden1 homepage");
        }

        /// <summary>
        /// Sets browser viewport to specified device size
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Given(@"I set the browser viewport to (.*) size")]
        public void GivenISetBrowserViewportToDeviceSize(string deviceType)
        {
            LogHelper.Info($"Step: Setting browser viewport to {deviceType} size");
            
            switch (deviceType.ToLower())
            {
                case "desktop":
                    _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
                    LogHelper.Info("Viewport set to Desktop size: 1920x1080");
                    break;
                case "tablet":
                    _driver.Manage().Window.Size = new System.Drawing.Size(768, 1024);
                    LogHelper.Info("Viewport set to Tablet size: 768x1024");
                    break;
                case "mobile":
                    _driver.Manage().Window.Size = new System.Drawing.Size(375, 667);
                    LogHelper.Info("Viewport set to Mobile size: 375x667");
                    break;
                default:
                    throw new ArgumentException($"Unsupported device type: {deviceType}");
            }
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        /// <summary>
        /// Observes the top section of the homepage
        /// Test Cases: TASK0020445 TS-002 TC-001, TS-008 TC-001
        /// </summary>
        [When(@"I observe the top section of the homepage")]
        [When(@"I observe the top header area")]
        public void WhenIObserveTheTopSectionOfHomepage()
        {
            LogHelper.Info("Step: Observing the top section of the homepage");
            // Wait for header to be visible
            System.Threading.Thread.Sleep(1000); // Brief pause to allow observation
            LogHelper.Info("Top section observation completed");
        }

        /// <summary>
        /// Locates the global navigation menu
        /// Test Cases: TASK0020445 TS-003 TC-001, TS-004 TC-001
        /// </summary>
        [When(@"I locate the global navigation menu")]
        public void WhenILocateTheGlobalNavigationMenu()
        {
            LogHelper.Info("Step: Locating the global navigation menu");
            bool isVisible = _homePage.IsGlobalNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Global navigation menu should be visible");
            LogHelper.Info("Global navigation menu located successfully");
        }

        /// <summary>
        /// Expands a product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I expand the 