using System;
using BoDi;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Golden1.Automation.Drivers;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Hooks
{
    /// <summary>
    /// SpecFlow Hooks for test lifecycle management
    /// DO NOT MODIFY - Framework Core File
    /// </summary>
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private IWebDriver _driver;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            try
            {
                LogHelper.Info("========================================");
                LogHelper.Info($"Starting Scenario: {scenarioContext.ScenarioInfo.Title}");
                LogHelper.Info($"Tags: {string.Join(", ", scenarioContext.ScenarioInfo.Tags)}");
                LogHelper.Info("========================================");

                _driver = DriverManager.CreateDriver();
                _driver.Manage().Window.Maximize();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigReader.ImplicitWait);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigReader.PageLoadTimeout);

                _container.RegisterInstanceAs(_driver);
                LogHelper.Info("WebDriver initialized successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to initialize WebDriver: {ex.Message}");
                throw;
            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext.TestError != null)
                {
                    LogHelper.Error($"Scenario Failed: {scenarioContext.TestError.Message}");
                    LogHelper.Error($"Stack Trace: {scenarioContext.TestError.StackTrace}");
                    
                    // Capture screenshot on failure
                    ScreenshotHelper.CaptureScreenshot(_driver, scenarioContext.ScenarioInfo.Title);
                }
                else
                {
                    LogHelper.Info($"Scenario Passed: {scenarioContext.ScenarioInfo.Title}");
                }

                LogHelper.Info("========================================");
                LogHelper.Info($"Completed Scenario: {scenarioContext.ScenarioInfo.Title}");
                LogHelper.Info("========================================");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error in AfterScenario: {ex.Message}");
            }
            finally
            {
                if (_driver != null)
                {
                    _driver.Quit();
                    _driver.Dispose();
                    LogHelper.Info("WebDriver closed successfully");
                }
            }
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            LogHelper.Info("========================================");
            LogHelper.Info("TEST RUN STARTED");
            LogHelper.Info($"Environment: {ConfigReader.Environment}");
            LogHelper.Info($"Base URL: {ConfigReader.BaseUrl}");
            LogHelper.Info($"Browser: {ConfigReader.Browser}");
            LogHelper.Info("========================================");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            LogHelper.Info("========================================");
            LogHelper.Info("TEST RUN COMPLETED");
            LogHelper.Info("========================================");
        }
    }
}