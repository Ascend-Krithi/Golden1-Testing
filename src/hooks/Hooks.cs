using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using System;
using System.IO;
using Golden1.WebAutomation.Helpers;

namespace Golden1.WebAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            LogHelper.Info("========================================");
            LogHelper.Info($"Starting Scenario: {_scenarioContext.ScenarioInfo.Title}");
            LogHelper.Info("========================================");

            string browser = ConfigReader.GetBrowser();
            _driver = InitializeDriver(browser);

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigReader.GetImplicitWait());
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigReader.GetPageLoadTimeout());

            _container.RegisterInstanceAs(_driver);
            _scenarioContext.Add("WebDriver", _driver);

            LogHelper.Info($"Browser '{browser}' initialized successfully");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                LogHelper.Error($"Scenario failed: {_scenarioContext.ScenarioInfo.Title}");
                LogHelper.Error($"Error: {_scenarioContext.TestError.Message}");
                LogHelper.Error($"Stack Trace: {_scenarioContext.TestError.StackTrace}");
                TakeScreenshot();
            }
            else
            {
                LogHelper.Info($"Scenario passed: {_scenarioContext.ScenarioInfo.Title}");
            }

            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                LogHelper.Info("Browser closed successfully");
            }

            LogHelper.Info("========================================");
            LogHelper.Info($"Finished Scenario: {_scenarioContext.ScenarioInfo.Title}");
            LogHelper.Info("========================================\n");
        }

        [AfterStep]
        public void AfterStep()
        {
            if (_scenarioContext.TestError != null)
            {
                LogHelper.Error($"Step failed: {_scenarioContext.StepContext.StepInfo.Text}");
            }
        }

        private IWebDriver InitializeDriver(string browser)
        {
            LogHelper.Info($"Initializing {browser} driver");

            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    if (ConfigReader.IsHeadlessMode())
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddArgument("--disable-notifications");
                    chromeOptions.AddArgument("--disable-popup-blocking");
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    if (ConfigReader.IsHeadlessMode())
                    {
                        firefoxOptions.AddArgument("--headless");
                    }
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    if (ConfigReader.IsHeadlessMode())
                    {
                        edgeOptions.AddArgument("--headless");
                    }
                    return new EdgeDriver(edgeOptions);

                default:
                    LogHelper.Warning($"Browser '{browser}' not recognized. Using Chrome as default.");
                    return new ChromeDriver();
            }
        }

        private void TakeScreenshot()
        {
            try
            {
                string screenshotPath = ConfigReader.GetScreenshotPath();
                if (!Directory.Exists(screenshotPath))
                {
                    Directory.CreateDirectory(screenshotPath);
                }

                string fileName = $"{_scenarioContext.ScenarioInfo.Title.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string fullPath = Path.Combine(screenshotPath, fileName);

                Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(fullPath);

                LogHelper.Info($"Screenshot saved: {fullPath}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to take screenshot: {ex.Message}");
            }
        }
    }
}