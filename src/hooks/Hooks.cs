using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using Golden1.Automation.Framework.Helpers;
using System;

namespace Golden1.Automation.Framework.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                LogHelper.Info("========================================");
                LogHelper.Info($"Starting Scenario: {_scenarioContext.ScenarioInfo.Title}");
                LogHelper.Info("========================================");

                string browser = ConfigReader.GetValue("Browser");
                _driver = InitializeDriver(browser);

                int implicitWait = ConfigReader.GetIntValue("ImplicitWait", 10);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
                _driver.Manage().Window.Maximize();

                _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                _scenarioContext["WebDriver"] = _driver;

                LogHelper.Info($"WebDriver initialized successfully with browser: {browser}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error in BeforeScenario: {ex.Message}");
                throw;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    LogHelper.Error($"Scenario failed with error: {_scenarioContext.TestError.Message}");
                    LogHelper.Error($"Stack trace: {_scenarioContext.TestError.StackTrace}");
                    
                    // Take screenshot on failure
                    TakeScreenshot(_scenarioContext.ScenarioInfo.Title);
                }
                else
                {
                    LogHelper.Pass($"Scenario passed: {_scenarioContext.ScenarioInfo.Title}");
                }

                LogHelper.Info("========================================");
                LogHelper.Info($"Completed Scenario: {_scenarioContext.ScenarioInfo.Title}");
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

        private IWebDriver InitializeDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddArgument("--disable-notifications");
                    chromeOptions.AddArgument("--disable-popup-blocking");
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    return new EdgeDriver(edgeOptions);

                default:
                    LogHelper.Warning($"Browser '{browser}' not recognized. Defaulting to Chrome.");
                    return new ChromeDriver();
            }
        }

        private void TakeScreenshot(string scenarioName)
        {
            try
            {
                string screenshotDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                if (!System.IO.Directory.Exists(screenshotDirectory))
                {
                    System.IO.Directory.CreateDirectory(screenshotDirectory);
                }

                string fileName = $"{scenarioName.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string filePath = System.IO.Path.Combine(screenshotDirectory, fileName);

                Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(filePath);

                LogHelper.Info($"Screenshot saved: {filePath}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error taking screenshot: {ex.Message}");
            }
        }
    }
}