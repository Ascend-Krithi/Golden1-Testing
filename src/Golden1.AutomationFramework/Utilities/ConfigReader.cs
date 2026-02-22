using Microsoft.Extensions.Configuration;
using System.IO;

namespace Golden1.AutomationFramework.Utilities
{
    public static class ConfigReader
    {
        private static IConfiguration _configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public static string GetBaseUrl()
        {
            return _configuration["AppSettings:BaseUrl"];
        }

        public static string GetBrowser()
        {
            return _configuration["AppSettings:Browser"];
        }

        public static int GetImplicitWait()
        {
            return int.Parse(_configuration["AppSettings:ImplicitWait"]);
        }

        public static int GetExplicitWait()
        {
            return int.Parse(_configuration["AppSettings:ExplicitWait"]);
        }

        public static string GetEnvironment()
        {
            return _configuration["AppSettings:Environment"];
        }

        public static string GetValue(string key)
        {
            return _configuration[key];
        }
    }
}