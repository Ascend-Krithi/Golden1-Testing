using NLog;
using System;

namespace Golden1.AutomationFramework.Utilities
{
    public class LogHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        public void LogDebug(string message)
        {
            Logger.Debug(message);
        }

        public void LogWarning(string message)
        {
            Logger.Warn(message);
        }

        public void LogError(string message)
        {
            Logger.Error(message);
        }

        public void LogError(string message, Exception ex)
        {
            Logger.Error(ex, message);
        }

        public void LogFatal(string message)
        {
            Logger.Fatal(message);
        }

        public void LogFatal(string message, Exception ex)
        {
            Logger.Fatal(ex, message);
        }
    }
}