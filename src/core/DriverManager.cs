using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Golden1.Automation.Framework.Utilities;
using System;

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
            try
            {
                string browser = ConfigReader.GetValue("Browser") ?? "Chrome";
                _logHelper.LogInfo($"Initializing {browser} driver");

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
                        throw new ArgumentException($"Browser '{browser}' is not supported");
                }

                int implicitWait = int.Parse(ConfigReader.GetValue("ImplicitWait") ?? "10");
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
                _logHelper.LogInfo($"{browser} driver initialized successfully");
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to initialize driver", ex);
                throw;
            }
        }

        public static void QuitDriver()
        {
            try
            {
                if (_driver != null)
                {
                    _logHelper.LogInfo("Quitting driver");
                    _driver.Quit();
                    _driver.Dispose();
                    _driver = null;
                    _logHelper.LogInfo("Driver quit successfully");
                }
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to quit driver", ex);
                throw;
            }
        }
    }
}