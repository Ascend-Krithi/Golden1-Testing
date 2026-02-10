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
        /// Gets a configuration value by key
        /// </summary>
        /// <param name="key">Configuration key</param>
        /// <returns>Configuration value</returns>
        public static string GetValue(string key)
        {
            try
            {
                return _configuration[key];
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error reading configuration key '{key}': {ex.Message}");
                return null;
            }
        }
    }
}