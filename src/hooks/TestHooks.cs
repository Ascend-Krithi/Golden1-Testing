using TechTalk.SpecFlow;
using Golden1.Automation.Framework.Core;
using Golden1.Automation.Framework.Utilities;
using NUnit.Framework;
using System;

namespace Golden1.Automation.Framework.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly LogHelper _logHelper;

        public TestHooks()
        {
            _logHelper = new LogHelper();
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            LogHelper logHelper = new LogHelper();
            logHelper.LogInfo("========================================");
            logHelper.LogInfo("Test Execution Started");
            logHelper.LogInfo($"Start Time: {DateTime.Now}");
            logHelper.LogInfo("========================================");
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _logHelper.LogInfo("========================================");
            _logHelper.LogInfo($"Scenario Started: {scenarioContext.ScenarioInfo.Title}");
            _logHelper.LogInfo($"Tags: {string.Join(", ", scenarioContext.ScenarioInfo.Tags)}");
            _logHelper.LogInfo("========================================");
            
            // Initialize driver for each scenario
            var driver = DriverManager.GetDriver();
            _logHelper.LogInfo("Driver initialized for scenario");
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext.TestError != null)
                {
                    _logHelper.LogError($"Scenario Failed: {scenarioContext.ScenarioInfo.Title}");
                    _logHelper.LogError($"Error: {scenarioContext.TestError.Message}");
                    _logHelper.LogError($"Stack Trace: {scenarioContext.TestError.StackTrace}");
                    
                    // Take screenshot on failure
                    TakeScreenshot(scenarioContext.ScenarioInfo.Title);
                }
                else
                {
                    _logHelper.LogInfo($"Scenario Passed: {scenarioContext.ScenarioInfo.Title}");
                }
            }
            finally
            {
                _logHelper.LogInfo("========================================");
                _logHelper.LogInfo($"Scenario Ended: {scenarioContext.ScenarioInfo.Title}");
                _logHelper.LogInfo("========================================");
                
                // Quit driver after each scenario
                DriverManager.QuitDriver();
                _logHelper.LogInfo("Driver quit after scenario");
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            LogHelper logHelper = new LogHelper();
            logHelper.LogInfo("========================================");
            logHelper.LogInfo("Test Execution Completed");
            logHelper.LogInfo($"End Time: {DateTime.Now}");
            logHelper.LogInfo("========================================");
        }

        private void TakeScreenshot(string scenarioName)
        {
            try
            {
                var driver = DriverManager.GetDriver();
                if (driver != null)
                {
                    var screenshot = ((OpenQA.Selenium.ITakesScreenshot)driver).GetScreenshot();
                    string screenshotPath = ConfigReader.GetValue("ScreenshotPath") ?? "./Screenshots";
                    string fileName = $"{scenarioName.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    string fullPath = System.IO.Path.Combine(screenshotPath, fileName);
                    
                    if (!System.IO.Directory.Exists(screenshotPath))
                    {
                        System.IO.Directory.CreateDirectory(screenshotPath);
                    }
                    
                    screenshot.SaveAsFile(fullPath);
                    _logHelper.LogInfo($"Screenshot saved: {fullPath}");
                }
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to take screenshot: {ex.Message}");
            }
        }
    }
}