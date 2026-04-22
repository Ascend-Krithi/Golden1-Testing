using System;
using System.IO;

namespace Golden1.Automation.Framework.Helpers
{
    public static class LogHelper
    {
        private static string _logFilePath;
        private static readonly object _lockObject = new object();

        static LogHelper()
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            _logFilePath = Path.Combine(logDirectory, $"TestLog_{DateTime.Now:yyyyMMdd_HHmmss}.log");
        }

        public static void Info(string message)
        {
            Log("INFO", message);
        }

        public static void Warning(string message)
        {
            Log("WARNING", message);
        }

        public static void Error(string message)
        {
            Log("ERROR", message);
        }

        public static void Pass(string message)
        {
            Log("PASS", message);
        }

        public static void Fail(string message)
        {
            Log("FAIL", message);
        }

        private static void Log(string level, string message)
        {
            lock (_lockObject)
            {
                try
                {
                    string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
                    Console.WriteLine(logMessage);
                    File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to log file: {ex.Message}");
                }
            }
        }
    }
}