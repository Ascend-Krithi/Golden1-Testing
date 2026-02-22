using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;

namespace Golden1.AutomationFramework.Utilities
{
    public class DriverFactory
    {
        private static IWebDriver _driver;
        private static readonly LogHelper LogHelper = new LogHelper();

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                string browser = ConfigReader.GetBrowser();
                _driver = InitializeDriver(browser);
            }
            return _driver;
        }

        private static IWebDriver InitializeDriver(string browser)
        {
            IWebDriver driver;
            LogHelper.LogInfo($"Initializing {browser} driver");

            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddArgument("--disable-notifications");
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    driver = new FirefoxDriver(firefoxOptions);
                    driver.Manage().Window.Maximize();
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    driver = new EdgeDriver(edgeOptions);
                    driver.Manage().Window.Maximize();
                    break;

                default:
                    throw new ArgumentException($"Browser '{browser}' is not supported");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigReader.GetImplicitWait());
            LogHelper.LogInfo($"{browser} driver initialized successfully");
            return driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                LogHelper.LogInfo("Quitting driver");
                _driver.Quit();
                _driver = null;
            }
        }
    }
}