using System;
using System.Configuration;

namespace Golden1.WebAutomation.Helpers
{
    public static class ConfigReader
    {
        public static string GetApplicationUrl()
        {
            string url = GetConfigValue("ApplicationUrl");
            if (string.IsNullOrEmpty(url))
            {
                url = "https://www.golden1.com/";
                LogHelper.Warning($"ApplicationUrl not found in config, using default: {url}");
            }
            return url;
        }

        public static string GetBrowser()
        {
            string browser = GetConfigValue("Browser");
            if (string.IsNullOrEmpty(browser))
            {
                browser = "Chrome";
                LogHelper.Warning($"Browser not found in config, using default: {browser}");
            }
            return browser;
        }

        public static int GetImplicitWait()
        {
            string wait = GetConfigValue("ImplicitWait");
            if (int.TryParse(wait, out int waitTime))
            {
                return waitTime;
            }
            LogHelper.Warning("ImplicitWait not found in config, using default: 10 seconds");
            return 10;
        }

        public static int GetExplicitWait()
        {
            string wait = GetConfigValue("ExplicitWait");
            if (int.TryParse(wait, out int waitTime))
            {
                return waitTime;
            }
            LogHelper.Warning("ExplicitWait not found in config, using default: 20 seconds");
            return 20;
        }

        public static int GetPageLoadTimeout()
        {
            string timeout = GetConfigValue("PageLoadTimeout");
            if (int.TryParse(timeout, out int timeoutValue))
            {
                return timeoutValue;
            }
            LogHelper.Warning("PageLoadTimeout not found in config, using default: 30 seconds");
            return 30;
        }

        public static bool IsHeadlessMode()
        {
            string headless = GetConfigValue("HeadlessMode");
            if (bool.TryParse(headless, out bool isHeadless))
            {
                return isHeadless;
            }
            return false;
        }

        public static string GetScreenshotPath()
        {
            string path = GetConfigValue("ScreenshotPath");
            if (string.IsNullOrEmpty(path))
            {
                path = "Screenshots";
                LogHelper.Warning($"ScreenshotPath not found in config, using default: {path}");
            }
            return path;
        }

        private static string GetConfigValue(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error reading config key '{key}': {ex.Message}");
                return null;
            }
        }
    }
}