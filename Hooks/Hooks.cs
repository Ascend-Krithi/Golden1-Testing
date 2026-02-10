using TechTalk.SpecFlow;
using Project1.Automation.Utilities;
using BoDi;

namespace Project1.Automation.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            LogHelper.Info("========================================");
            LogHelper.Info($"Starting Scenario: {scenarioContext.ScenarioInfo.Title}");
            LogHelper.Info("========================================");
            
            // Initialize WebDriver
            DriverManager.InitializeDriver();
            
            LogHelper.Info("Browser initialized for scenario");
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            LogHelper.Info("========================================");
            LogHelper.Info($"Scenario Status: {scenarioContext.ScenarioExecutionStatus}");
            
            if (scenarioContext.TestError != null)
            {
                LogHelper.Error($"Scenario failed with error: {scenarioContext.TestError.Message}");
                
                // Take screenshot on failure
                try
                {
                    ScreenshotHelper.TakeScreenshot(DriverManager.Driver, scenarioContext.ScenarioInfo.Title);
                }
                catch (Exception ex)
                {
                    LogHelper.Error($"Failed to capture screenshot: {ex.Message}");
                }
            }
            
            // Quit browser
            DriverManager.QuitDriver();
            
            LogHelper.Info($"Completed Scenario: {scenarioContext.ScenarioInfo.Title}");
            LogHelper.Info("========================================\n");
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            LogHelper.Info("******************************************");
            LogHelper.Info("Starting Test Execution");
            LogHelper.Info("******************************************");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            LogHelper.Info("******************************************");
            LogHelper.Info("Test Execution Completed");
            LogHelper.Info("******************************************");
        }
    }
}