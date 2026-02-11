using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Golden1.Automation.Config
{
    /// <summary>
    /// Configuration Reader utility
    /// DO NOT MODIFY - Framework Core File
    /// </summary>
    public static class ConfigReader
    {
        private static IConfiguration _configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"Config/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "QA"}.json", optional: true);

            _configuration = builder.Build();
        }

        public static string BaseUrl => _configuration["BaseUrl"] ?? "https://www.golden1.com/";
        public static string Browser => _configuration["Browser"] ?? "chrome";
        public static bool Headless => bool.Parse(_configuration["Headless"] ?? "false");
        public static int ImplicitWait => int.Parse(_configuration["ImplicitWait"] ?? "10");
        public static int ExplicitWait => int.Parse(_configuration["ExplicitWait"] ?? "30");
        public static int PageLoadTimeout => int.Parse(_configuration["PageLoadTimeout"] ?? "60");
        public static string Environment => _configuration["Environment"] ?? "QA";
        public static string ScreenshotPath => _configuration["ScreenshotPath"] ?? "./Screenshots/";
        public static string LogPath => _configuration["LogPath"] ?? "./Logs/";
    }
}