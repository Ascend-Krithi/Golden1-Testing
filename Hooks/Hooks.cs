using System;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.Automation.Drivers;
using Golden1.Automation.Utilities;
using Golden1.Automation.Config;

namespace Golden1.Automation.Hooks
{
    /// <summary>
    /// SpecFlow hooks for test lifecycle management
    /// Handles browser initialization, cleanup, and test context
    /// </summary>
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        /// <summary>
        /// Executes before each test scenario
        /// Initializes WebDriver and registers it in the DI container
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            try
            {
                LogHelper.Info("========================================");
                LogHelper.Info($"Starting Scenario: {scenarioContext.ScenarioInfo.Title}");
                LogHelper.Info($"Tags: {string.Join(", ", scenarioContext.ScenarioInfo.Tags)}");
                LogHelper.Info("========================================");

                // Initialize WebDriver
                _driver = DriverManager.CreateDriver();
                _driver.Manage().Window.Maximize();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigReader.ImplicitWait);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigReader.PageLoadTimeout);

                // Register driver in DI container
                _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);

                LogHelper.Info($"Browser initialized: {ConfigReader.Browser}");
                LogHelper.Info($"Base URL: {ConfigReader.BaseUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"BeforeScenario failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Executes after each test scenario
        /// Captures screenshots on failure and closes the browser
        /// </summary>
        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext.TestError != null)
                {
                    LogHelper.Error("========================================");
                    LogHelper.Error($"Scenario Failed: {scenarioContext.ScenarioInfo.Title}");
                    LogHelper.Error($"Error: {scenarioContext.TestError.Message}");
                    LogHelper.Error($"Stack Trace: {scenarioContext.TestError.StackTrace}");
                    LogHelper.Error("========================================");

                    // Capture screenshot on failure
                    if (_driver != null)
                    {
                        string screenshotName = $"{scenarioContext.ScenarioInfo.Title.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}";
                        ScreenshotHelper.CaptureScreenshot(_driver, screenshotName);
                    }
                }
                else
                {
                    LogHelper.Info("========================================");
                    LogHelper.Info($"Scenario Passed: {scenarioContext.ScenarioInfo.Title}");
                    LogHelper.Info("========================================");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"AfterScenario cleanup error: {ex.Message}");
            }
            finally
            {
                // Close browser
                if (_driver != null)
                {
                    try
                    {
                        _driver.Quit();
                        _driver.Dispose();
                        LogHelper.Info("Browser closed successfully");
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Warning($"Browser cleanup warning: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Executes before each step
        /// Logs step execution for traceability
        /// </summary>
        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            LogHelper.Info($"Executing Step: {scenarioContext.StepContext.StepInfo.Text}");
        }

        /// <summary>
        /// Executes after each step
        /// Logs step completion status
        /// </summary>
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null)
            {
                LogHelper.Error($"Step Failed: {scenarioContext.StepContext.StepInfo.Text}");
            }
            else
            {
                LogHelper.Info($"Step Completed: {scenarioContext.StepContext.StepInfo.Text}");
            }
        }
    }
}