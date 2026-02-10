using System;
using System.IO;

namespace Project1.Automation.Utilities
{
    public static class LogHelper
    {
        private static readonly string LogDirectory = "Logs";
        private static readonly string LogFileName = $"TestLog_{DateTime.Now:yyyyMMdd_HHmmss}.log";
        private static readonly string LogFilePath = Path.Combine(LogDirectory, LogFileName);

        static LogHelper()
        {
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        /// <summary>
        /// Logs info message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Info(string message)
        {
            Log("INFO", message);
        }

        /// <summary>
        /// Logs error message
        /// </summary>
        /// <param name="message">Error message to log</param>
        public static void Error(string message)
        {
            Log("ERROR", message);
        }

        /// <summary>
        /// Logs warning message
        /// </summary>
        /// <param name="message">Warning message to log</param>
        public static void Warning(string message)
        {
            Log("WARNING", message);
        }

        /// <summary>
        /// Logs debug message
        /// </summary>
        /// <param name="message">Debug message to log</param>
        public static void Debug(string message)
        {
            Log("DEBUG", message);
        }

        private static void Log(string level, string message)
        {
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
            Console.WriteLine(logMessage);
            
            try
            {
                File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}