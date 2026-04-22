using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using Golden1.Automation.Framework.Utilities;

namespace Golden1.Automation.Framework.Core
{
    public static class DriverManager
    {
        private static IWebDriver _driver;
        private static readonly LogHelper _logHelper = new LogHelper();

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                InitializeDriver();
            }
            return _driver;
        }

        private static void InitializeDriver()
        {
            ConfigReader configReader = new ConfigReader();
            string browser = configReader.GetBrowser();

            _logHelper.LogInfo($"Initializing WebDriver for browser: {browser}");

            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddArgument("--disable-notifications");
                    chromeOptions.AddArgument("--disable-popup-blocking");
                    _driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--start-maximized");
                    _driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--start-maximized");
                    _driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    _logHelper.LogWarning($"Browser '{browser}' not recognized. Defaulting to Chrome.");
                    ChromeOptions defaultOptions = new ChromeOptions();
                    defaultOptions.AddArgument("--start-maximized");
                    _driver = new ChromeDriver(defaultOptions);
                    break;
            }

            int implicitWait = configReader.GetImplicitWait();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
            _logHelper.LogInfo($"WebDriver initialized successfully with implicit wait: {implicitWait} seconds");
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _logHelper.LogInfo("Quitting WebDriver");
                _driver.Quit();
                _driver = null;
                _logHelper.LogInfo("WebDriver quit successfully");
            }
        }
    }
}