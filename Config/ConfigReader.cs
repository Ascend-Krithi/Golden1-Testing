using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Golden1.Automation.Config
{
    public static class ConfigReader
    {
        private static readonly IConfigurationRoot _config;
        private static readonly string _environment;

        static ConfigReader()
        {
            _environment = System.Environment.GetEnvironmentVariable("TEST_ENV") ?? "QA";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"Config/appsettings.{_environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        public static string TestEnvironment => _environment;
        public static string BaseUrl => _config["BaseUrl"] ?? throw new InvalidOperationException("BaseUrl not configured");
        public static string Browser => _config["Browser"] ?? "Chrome";
        public static bool Headless => bool.TryParse(_config["Headless"], out var v) && v;
        public static int TimeoutSeconds => int.TryParse(_config["TimeoutSeconds"], out var v) ? v : 20;
        public static int ImplicitWaitSeconds => int.TryParse(_config["ImplicitWaitSeconds"], out var v) ? v : 0;
        public static int PageLoadTimeoutSeconds => int.TryParse(_config["PageLoadTimeoutSeconds"], out var v) ? v : 60;

        public static bool TakeScreenshotOnFailure => bool.TryParse(_config["TakeScreenshotOnFailure"], out var v) ? v : true;
        public static string ScreenshotPath => _config["ScreenshotPath"] ?? "Screenshots";
        public static string ReportPath => _config["ReportPath"] ?? "TestResults";
        public static int MaxRetryCount => int.TryParse(_config["MaxRetryCount"], out var v) ? v : 0;

        public static bool UseRemoteDriver => bool.TryParse(_config["UseRemoteDriver"], out var v) && v;
        public static string RemoteDriverUrl => _config["RemoteDriverUrl"] ?? "http://localhost:4444/wd/hub";
    }
}
