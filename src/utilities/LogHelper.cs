using System;
using System.IO;
using NLog;

namespace Golden1.Automation.Framework.Utilities
{
    public class LogHelper
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public LogHelper()
        {
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
            Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
            Console.WriteLine($"[DEBUG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);
            Console.WriteLine($"[WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogError(string message)
        {
            _logger.Error(message);
            Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogError(string message, Exception ex)
        {
            _logger.Error(ex, message);
            Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            Console.WriteLine($"Exception: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }

        public void LogFatal(string message)
        {
            _logger.Fatal(message);
            Console.WriteLine($"[FATAL] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogFatal(string message, Exception ex)
        {
            _logger.Fatal(ex, message);
            Console.WriteLine($"[FATAL] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            Console.WriteLine($"Exception: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }
    }
}