using System;
using System.IO;
using Serilog;
using Golden1.Automation.Config;

namespace Golden1.Automation.Utilities
{
    public static class LogHelper
    {
        private static readonly ILogger _logger;

        static LogHelper()
        {
            var logPath = Path.Combine(ConfigReader.ReportPath, "Logs", 
                $"TestLog_{DateTime.Now:yyyyMMdd}.txt");
            
            Directory.CreateDirectory(Path.GetDirectoryName(logPath));

            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }

        public static void Info(string message)
        {
            _logger.Information(message);
        }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Warning(string message)
        {
            _logger.Warning(message);
        }

        public static void Error(string message, Exception ex = null)
        {
            if (ex != null)
                _logger.Error(ex, message);
            else
                _logger.Error(message);
        }
    }
}
