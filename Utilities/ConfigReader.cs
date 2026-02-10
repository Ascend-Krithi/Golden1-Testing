using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Project1.Automation.Utilities
{
    public static class ConfigReader
    {
        private static IConfiguration _configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true);
            
            _configuration = builder.Build();
        }

        /// <summary>
        /// Gets application setting value by key
        /// </summary>
        /// <param name="key">Setting key</param>
        /// <returns>Setting value</returns>
        public static string GetAppSetting(string key)
        {
            try
            {
                string value = _configuration[$"AppSettings:{key}"];
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception($"Configuration key '{key}' not found in appsettings.json");
                }
                return value;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error reading configuration key '{key}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets base URL from configuration
        /// </summary>
        /// <returns>Base URL</returns>
        public static string GetBaseUrl()
        {
            return GetAppSetting("BaseUrl");
        }

        /// <summary>
        /// Gets browser type from configuration
        /// </summary>
        /// <returns>Browser name</returns>
        public static string GetBrowser()
        {
            return GetAppSetting("Browser");
        }

        /// <summary>
        /// Gets implicit wait timeout
        /// </summary>
        /// <returns>Timeout in seconds</returns>
        public static int GetImplicitWait()
        {
            return int.Parse(GetAppSetting("ImplicitWait"));
        }

        /// <summary>
        /// Gets explicit wait timeout
        /// </summary>
        /// <returns>Timeout in seconds</returns>
        public static int GetExplicitWait()
        {
            return int.Parse(GetAppSetting("ExplicitWait"));
        }
    }
}