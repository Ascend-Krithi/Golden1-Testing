using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Golden1.Automation.Config
{
    /// <summary>
    /// Configuration reader for application settings
    /// Reads from appsettings.json and environment-specific config files
    /// </summary>
    public static class ConfigReader
    {
        private static IConfiguration _configuration;

        static ConfigReader()
        {
            try
            {
                var environment = Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") ?? "QA";

                _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"Config/appsettings.{environment}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load configuration: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets the base URL for the application
        /// </summary>
        public static string BaseUrl => GetConfigValue("BaseUrl", "https://www.golden1.com/");

        /// <summary>
        /// Gets the browser type (chrome, firefox, edge)
        /// </summary>
        public static string Browser => GetConfigValue("Browser", "chrome");

        /// <summary>
        /// Gets whether to run browser in headless mode
        /// </summary>
        public static bool Headless => bool.Parse(GetConfigValue("Headless", "false"));

        /// <summary>
        /// Gets the implicit wait timeout in seconds
        /// </summary>
        public static int ImplicitWait => int.Parse(GetConfigValue("ImplicitWait", "10"));

        /// <summary>
        /// Gets the explicit wait timeout in seconds
        /// </summary>
        public static int ExplicitWait => int.Parse(GetConfigValue("ExplicitWait", "30"));

        /// <summary>
        /// Gets the page load timeout in seconds
        /// </summary>
        public static int PageLoadTimeout => int.Parse(GetConfigValue("PageLoadTimeout", "60"));

        /// <summary>
        /// Gets the test environment (QA, UAT, Prod)
        /// </summary>
        public static string Environment => GetConfigValue("Environment", "QA");

        /// <summary>
        /// Gets the screenshot save path
        /// </summary>
        public static string ScreenshotPath => GetConfigValue("ScreenshotPath", "./Screenshots/");

        /// <summary>
        /// Gets the log file path
        /// </summary>
        public static string LogPath => GetConfigValue("LogPath", "./Logs/");

        /// <summary>
        /// Helper method to get configuration value with default fallback
        /// </summary>
        private static string GetConfigValue(string key, string defaultValue)
        {
            try
            {
                return _configuration[key] ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}