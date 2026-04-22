using TechTalk.SpecFlow;
using Golden1.Automation.Framework.Utilities;
using NUnit.Framework;

namespace Golden1.Automation.Framework.Core
{
    [Binding]
    public class Hooks
    {
        private readonly LogHelper _logHelper;

        public Hooks()
        {
            _logHelper = new LogHelper();
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            LogHelper logHelper = new LogHelper();
            logHelper.LogInfo("========== Test Run Started ==========");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            LogHelper logHelper = new LogHelper();
            logHelper.LogInfo("========== Test Run Completed ==========");
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _logHelper.LogInfo($"========== Scenario Started: {scenarioContext.ScenarioInfo.Title} ==========");
            _logHelper.LogInfo($"Tags: {string.Join(", ", scenarioContext.ScenarioInfo.Tags)}");
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            _logHelper.LogInfo($"========== Scenario Completed: {scenarioContext.ScenarioInfo.Title} ==========");
            _logHelper.LogInfo($"Scenario Status: {scenarioContext.ScenarioExecutionStatus}");
            
            if (scenarioContext.TestError != null)
            {
                _logHelper.LogError($"Scenario failed with error: {scenarioContext.TestError.Message}", scenarioContext.TestError);
            }

            DriverManager.QuitDriver();
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            _logHelper.LogInfo($"Executing Step: {scenarioContext.StepContext.StepInfo.Text}");
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null)
            {
                _logHelper.LogError($"Step failed: {scenarioContext.StepContext.StepInfo.Text}", scenarioContext.TestError);
            }
            else
            {
                _logHelper.LogInfo($"Step completed: {scenarioContext.StepContext.StepInfo.Text}");
            }
        }
    }
}