using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Golden1.Automation.Utilities;
using Golden1.Automation.Drivers;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for browser-related actions
    /// Test Cases: TASK0020445 TS-010 TC-001, TS-011 TC-001
    /// </summary>
    [Binding]
    public class BrowserSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public BrowserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Step: Given I launch browser
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Given(@"I launch ""(.*)"" browser")]
        public void GivenILaunchBrowser(string browserType)
        {
            try
            {
                LogHelper.Info($"Step: Launching '{browserType}' browser");
                
                // This would typically be handled in Hooks, but for cross-browser testing
                // we need to override the default browser
                _scenarioContext["BrowserType"] = browserType;
                
                // Get driver from scenario context (initialized in Hooks)
                _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
                
                Assert.That(_driver, Is.Not.Null, $"'{browserType}' browser should be launched successfully");
                LogHelper.Info($"'{browserType}' browser launched successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to launch '{browserType}' browser: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Given I set the browser viewport to device size
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Given(@"I set the browser viewport to ""(.*)"" size")]
        public void GivenISetTheBrowserViewportToSize(string deviceType)
        {
            try
            {
                LogHelper.Info($"Step: Setting browser viewport to '{deviceType}' size");
                _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
                
                // Set viewport size based on device type
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
                        LogHelper.Warning($"Unknown device type '{deviceType}', using default desktop size");
                        _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
                        break;
                }
                
                _scenarioContext["DeviceType"] = deviceType;
                LogHelper.Info($"Browser viewport set to '{deviceType}' size successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to set viewport to '{deviceType}' size: {ex.Message}");
                throw;
            }
        }
    }
}