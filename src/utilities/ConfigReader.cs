using System;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Golden1.Automation.Framework.Utilities
{
    public static class ConfigReader
    {
        private static IConfiguration _configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{GetEnvironment()}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public static string GetValue(string key)
        {
            try
            {
                return _configuration[key];
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to read configuration key: {key}", ex);
            }
        }

        public static string GetConnectionString(string name)
        {
            try
            {
                return _configuration.GetConnectionString(name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to read connection string: {name}", ex);
            }
        }

        private static string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        }

        public static T GetSection<T>(string sectionName) where T : class, new()
        {
            try
            {
                var section = _configuration.GetSection(sectionName);
                return section.Get<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to read configuration section: {sectionName}", ex);
            }
        }
    }
}