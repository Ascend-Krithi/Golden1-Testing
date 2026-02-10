using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Golden1.Automation.Drivers;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = DriverManager.CreateDriver();
            _scenarioContext["Driver"] = driver;

            LogHelper.Info($"Starting Scenario: {_scenarioContext.ScenarioInfo.Title}");
        }

        [AfterStep]
        public void AfterStep()
        {
            if (_scenarioContext.TestError != null &&
                _scenarioContext.TryGetValue("Driver", out IWebDriver driver))
            {
                ScreenshotHelper.CaptureScreenshot(driver, _scenarioContext.ScenarioInfo.Title);
                LogHelper.Error($"Step Failed: {_scenarioContext.TestError.Message}");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TryGetValue("Driver", out IWebDriver driver))
            {
                driver.Quit();
            }

            LogHelper.Info($"Completed Scenario: {_scenarioContext.ScenarioInfo.Title}");
        }
    }
}
