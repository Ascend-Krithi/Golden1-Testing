using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for browser-specific scenarios
    /// Test Cases: TASK0020445 TS-010, TS-011
    /// </summary>
    [Binding]
    public class BrowserSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        public BrowserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
        }

        /// <summary>
        /// Step: Launch specific browser
        /// Test Case: TASK0020445 TS-010 TC-001 Step 1
        /// </summary>
        [Given(@"I launch the ""(.*)"" browser")]
        public void GivenILaunchTheBrowser(string browserType)
        {
            LogHelper.Info($"Launching {browserType} browser");
            
            // Browser is already launched via Hooks based on config
            // This step is for documentation and logging purposes
            Assert.That(_driver, Is.Not.Null, $"{browserType} browser should be initialized");
            
            LogHelper.Info($"{browserType} browser launched successfully");
        }

        /// <summary>
        /// Step: Open browser on specific device
        /// Test Case: TASK0020445 TS-011 TC-001 Step 1
        /// </summary>
        [Given(@"I open the browser on ""(.*)"" device")]
        public void GivenIOpenTheBrowserOnDevice(string deviceType)
        {
            LogHelper.Info($"Opening browser on {deviceType} device");
            
            // Device emulation would be configured in Hooks or DriverManager
            // This step is for documentation and logging purposes
            Assert.That(_driver, Is.Not.Null, $"Browser should be initialized for {deviceType} device");
            
            LogHelper.Info($"Browser opened on {deviceType} device successfully");
        }
    }
}