using TechTalk.SpecFlow;
using Golden1.AutomationFramework.Utilities;
using OpenQA.Selenium;
using System;

namespace Golden1.AutomationTests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private static IWebDriver _driver;
        private static LogHelper _logHelper;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _logHelper = new LogHelper();
            _logHelper.LogInfo("=== Test Run Started ===");
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _logHelper.LogInfo($"=== Scenario Started: {scenarioContext.ScenarioInfo.Title} ===");
            _driver = DriverFactory.GetDriver();
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext.TestError != null)
                {
                    _logHelper.LogError($"Scenario Failed: {scenarioContext.ScenarioInfo.Title}", scenarioContext.TestError);
                    
                    // Take screenshot on failure
                    var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                    string screenshotPath = $"Screenshots/{scenarioContext.ScenarioInfo.Title}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    screenshot.SaveAsFile(screenshotPath);
                    _logHelper.LogInfo($"Screenshot saved: {screenshotPath}");
                }
                else
                {
                    _logHelper.LogInfo($"Scenario Passed: {scenarioContext.ScenarioInfo.Title}");
                }
            }
            finally
            {
                _logHelper.LogInfo($"=== Scenario Ended: {scenarioContext.ScenarioInfo.Title} ===");
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _logHelper.LogInfo("=== Test Run Ended ===");
            DriverFactory.QuitDriver();
        }
    }
}