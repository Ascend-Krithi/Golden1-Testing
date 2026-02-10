using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using Golden1.Automation.Config;
using Wdm = WebDriverManager.DriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Golden1.Automation.Drivers
{
    public static class DriverManager
    {
        public static IWebDriver CreateDriver()
        {
            IWebDriver driver = ConfigReader.UseRemoteDriver
                ? CreateRemoteDriver()
                : CreateLocalDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigReader.ImplicitWaitSeconds);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigReader.PageLoadTimeoutSeconds);

            return driver;
        }

        private static IWebDriver CreateLocalDriver()
        {
            return ConfigReader.Browser.ToLower() switch
            {
                "chrome" => CreateChromeDriver(),
                "firefox" => CreateFirefoxDriver(),
                "edge" => CreateEdgeDriver(),
                _ => throw new ArgumentException($"Unsupported browser: {ConfigReader.Browser}")
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            new Wdm().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            var options = new ChromeOptions();

            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-background-networking");
            options.AddArgument("--disable-sync");
            options.AddArgument("--disable-features=NetworkService");

            if (ConfigReader.Headless)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
            }

            // 🔥 CRITICAL FIX — DO NOT WAIT FOR FULL PAGE LOAD
            options.PageLoadStrategy = PageLoadStrategy.None;

            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            new Wdm().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
            return new FirefoxDriver();
        }

        private static IWebDriver CreateEdgeDriver()
        {
            new Wdm().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
            return new EdgeDriver();
        }

        private static IWebDriver CreateRemoteDriver()
        {
            var capabilities = ConfigReader.Browser.ToLower() switch
            {
                "chrome" => new ChromeOptions().ToCapabilities(),
                "firefox" => new FirefoxOptions().ToCapabilities(),
                "edge" => new EdgeOptions().ToCapabilities(),
                _ => throw new ArgumentException($"Unsupported browser: {ConfigReader.Browser}")
            };

            return new RemoteWebDriver(new Uri(ConfigReader.RemoteDriverUrl), capabilities);
        }
    }
}
