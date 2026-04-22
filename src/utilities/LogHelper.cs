using System;
using System.IO;
using NLog;

namespace Golden1.Automation.Framework.Utilities
{
    public class LogHelper
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            logger.Info(message);
            Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogError(string message, Exception ex = null)
        {
            if (ex != null)
            {
                logger.Error(ex, message);
                Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message} - Exception: {ex.Message}");
            }
            else
            {
                logger.Error(message);
                Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            }
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
            Console.WriteLine($"[WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
            Console.WriteLine($"[DEBUG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
    }
}