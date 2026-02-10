using Microsoft.Extensions.Configuration;
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
        /// Gets configuration value by key
        /// </summary>
        /// <param name="key">Configuration key</param>
        /// <returns>Configuration value</returns>
        public static string GetValue(string key)
        {
            return _configuration[key];
        }

        /// <summary>
        /// Gets configuration section
        /// </summary>
        /// <param name="sectionName">Section name</param>
        /// <returns>Configuration section</returns>
        public static IConfigurationSection GetSection(string sectionName)
        {
            return _configuration.GetSection(sectionName);
        }
    }
}