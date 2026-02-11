using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Golden1.Automation.Utilities;
using Golden1.Automation.Drivers;
using Golden1.Automation.Config;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for Browser-related actions
    /// Test Cases: TASK0020445 TS-010, TS-011
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

        // =============================================================
        // GIVEN STEPS - Browser Launch
        // =============================================================
        [Given(@"user launches ""(.*)"" browser")]
        public void GivenUserLaunchesBrowser(string browserName)
        {
            try
            {
                LogHelper.Info($"Step: User launches '{browserName}' browser");
                
                // Store original browser config
                string originalBrowser = ConfigReader.Browser;
                _scenarioContext["OriginalBrowser"] = originalBrowser;
                
                // Set browser for this scenario
                ConfigReader.SetBrowser(browserName.ToLower());
                
                // Create driver for specified browser
                _driver = DriverManager.CreateDriver();
                _scenarioContext.Set(_driver, "WebDriver");
                
                LogHelper.Info($"{browserName} browser launched successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to launch {browserName} browser: {ex.Message}");
                throw;
            }
        }

        [Given(@"user opens browser on ""(.*)"" device")]
        public void GivenUserOpensBrowserOnDevice(string deviceType)
        {
            try
            {
                LogHelper.Info($"Step: User opens browser on '{deviceType}' device");
                
                _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
                
                // Set viewport size based on device type
                switch (deviceType.ToLower())
                {
                    case "desktop":
                        _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
                        LogHelper.Info("Browser set to Desktop resolution: 1920x1080");
                        break;
                    case "tablet":
                        _driver.Manage().Window.Size = new System.Drawing.Size(768, 1024);
                        LogHelper.Info("Browser set to Tablet resolution: 768x1024");
                        break;
                    case "mobile":
                        _driver.Manage().Window.Size = new System.Drawing.Size(375, 667);
                        LogHelper.Info("Browser set to Mobile resolution: 375x667");
                        break;
                    default:
                        LogHelper.Warning($"Unknown device type: {deviceType}, using default");
                        _driver.Manage().Window.Maximize();
                        break;
                }
                
                _scenarioContext["DeviceType"] = deviceType;
                LogHelper.Info($"Browser opened on {deviceType} device");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open browser on {deviceType} device: {ex.Message}");
                throw;
            }
        }
    }
}