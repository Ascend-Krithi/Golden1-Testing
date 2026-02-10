using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Project1.Automation.Utilities;
using System;

namespace Project1.Automation
{
    public static class DriverManager
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    throw new NullReferenceException("WebDriver is not initialized. Call InitializeDriver() first.");
                }
                return _driver;
            }
        }

        /// <summary>
        /// Initializes WebDriver based on browser configuration
        /// </summary>
        /// <param name="browserName">Browser name (Chrome, Firefox, Edge)</param>
        public static void InitializeDriver(string browserName = null)
        {
            if (browserName == null)
            {
                browserName = ConfigReader.GetValue("Browser") ?? "Chrome";
            }

            LogHelper.Info($"Initializing {browserName} browser");

            switch (browserName.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddArgument("--disable-notifications");
                    _driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    _driver = new FirefoxDriver(firefoxOptions);
                    _driver.Manage().Window.Maximize();
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--start-maximized");
                    _driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException($"Browser '{browserName}' is not supported");
            }

            // Set timeouts
            int implicitWait = int.Parse(ConfigReader.GetValue("ImplicitWait") ?? "10");
            int pageLoadTimeout = int.Parse(ConfigReader.GetValue("PageLoadTimeout") ?? "30");
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);

            LogHelper.Info($"{browserName} browser initialized successfully");
        }

        /// <summary>
        /// Quits and disposes the WebDriver
        /// </summary>
        public static void QuitDriver()
        {
            if (_driver != null)
            {
                LogHelper.Info("Closing browser");
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
                LogHelper.Info("Browser closed successfully");
            }
        }
    }
}