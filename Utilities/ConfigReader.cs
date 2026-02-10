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

        public static string GetValue(string key)
        {
            try
            {
                return _configuration[$"AppSettings:{key}"];
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to read configuration key '{key}': {ex.Message}");
            }
        }

        public static int GetIntValue(string key)
        {
            string value = GetValue(key);
            return int.Parse(value);
        }

        public static bool GetBoolValue(string key)
        {
            string value = GetValue(key);
            return bool.Parse(value);
        }
    }
}