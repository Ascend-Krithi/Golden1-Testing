using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using Golden1.Automation.Config;

namespace Golden1.Automation.Drivers
{
    /// <summary>
    /// WebDriver Manager for browser initialization
    /// DO NOT MODIFY - Framework Core File
    /// </summary>
    public static class DriverManager
    {
        public static IWebDriver CreateDriver()
        {
            string browser = ConfigReader.Browser.ToLower();
            return browser switch
            {
                "chrome" => CreateChromeDriver(),
                "firefox" => CreateFirefoxDriver(),
                "edge" => CreateEdgeDriver(),
                _ => throw new ArgumentException($"Browser '{browser}' is not supported")
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            if (ConfigReader.Headless)
            {
                options.AddArgument("--headless");
            }
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            var options = new FirefoxOptions();
            if (ConfigReader.Headless)
            {
                options.AddArgument("--headless");
            }
            return new FirefoxDriver(options);
        }

        private static IWebDriver CreateEdgeDriver()
        {
            var options = new EdgeOptions();
            if (ConfigReader.Headless)
            {
                options.AddArgument("headless");
            }
            return new EdgeDriver(options);
        }
    }
}