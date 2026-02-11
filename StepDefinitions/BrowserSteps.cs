using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Golden1.Automation.Drivers;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for browser and device configuration
    /// Test Cases: TASK0020445 TS-001, TS-010, TS-011
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

        /// <summary>
        /// Step: Given the browser is launched
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("Step: Launching browser");
            _driver = DriverManager.CreateDriver();
            _scenarioContext.Set(_driver, "WebDriver");
            LogHelper.Info("Browser launched successfully");
        }

        /// <summary>
        /// Step: Given the browser is launched with specific type
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Given(@"the browser ""(.*)"" is launched")]
        public void GivenTheSpecificBrowserIsLaunched(string browserType)
        {
            LogHelper.Info($"Step: Launching {browserType} browser");
            
            switch (browserType.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddArgument("--disable-gpu");
                    chromeOptions.AddArgument("--no-sandbox");
                    _driver = new ChromeDriver(chromeOptions);
                    break;
                    
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    _driver = new FirefoxDriver(firefoxOptions);
                    _driver.Manage().Window.Maximize();
                    break;
                    
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    _driver = new EdgeDriver(edgeOptions);
                    _driver.Manage().Window.Maximize();
                    break;
                    
                default:
                    throw new ArgumentException($"Browser type '{browserType}' is not supported");
            }
            
            _scenarioContext.Set(_driver, "WebDriver");
            LogHelper.Info($"{browserType} browser launched successfully");
        }

        /// <summary>
        /// Step: Given the device is configured
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Given(@"the device ""(.*)"" is configured")]
        public void GivenTheDeviceIsConfigured(string deviceType)
        {
            LogHelper.Info($"Step: Configuring device: {deviceType}");
            
            var chromeOptions = new ChromeOptions();
            
            switch (deviceType.ToLower())
            {
                case "desktop":
                    chromeOptions.AddArgument("--start-maximized");
                    break;
                    
                case "tablet":
                    chromeOptions.AddArgument("--window-size=768,1024");
                    chromeOptions.EnableMobileEmulation("iPad");
                    break;
                    
                case "mobile":
                    chromeOptions.AddArgument("--window-size=375,667");
                    chromeOptions.EnableMobileEmulation("iPhone X");
                    break;
                    
                default:
                    throw new ArgumentException($"Device type '{deviceType}' is not supported");
            }
            
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--no-sandbox");
            
            _driver = new ChromeDriver(chromeOptions);
            _scenarioContext.Set(_driver, "WebDriver");
            _scenarioContext.Set(deviceType, "DeviceType");
            LogHelper.Info($"Device '{deviceType}' configured successfully");
        }
    }
}