using System;
using System.IO;

namespace Golden1.Automation.Utilities
{
    /// <summary>
    /// Log Helper utility for logging
    /// DO NOT MODIFY - Framework Core File
    /// </summary>
    public static class LogHelper
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", $"TestLog_{DateTime.Now:yyyyMMdd_HHmmss}.log");

        static LogHelper()
        {
            var logDirectory = Path.GetDirectoryName(LogFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        /// <summary>
        /// Logs an informational message
        /// </summary>
        public static void Info(string message)
        {
            Log("INFO", message);
        }

        /// <summary>
        /// Logs a warning message
        /// </summary>
        public static void Warning(string message)
        {
            Log("WARNING", message);
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        public static void Error(string message)
        {
            Log("ERROR", message);
        }

        /// <summary>
        /// Logs a debug message
        /// </summary>
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