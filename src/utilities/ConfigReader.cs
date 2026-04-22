using System;
using System.Configuration;

namespace Golden1.Automation.Framework.Utilities
{
    public class ConfigReader
    {
        private readonly LogHelper _logHelper;

        public ConfigReader()
        {
            _logHelper = new LogHelper();
        }

        public string GetApplicationUrl()
        {
            try
            {
                string url = ConfigurationManager.AppSettings["ApplicationUrl"] ?? "https://www.golden1.com";
                _logHelper.LogInfo($"Retrieved Application URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to retrieve Application URL from config", ex);
                return "https://www.golden1.com";
            }
        }

        public string GetBrowser()
        {
            try
            {
                string browser = ConfigurationManager.AppSettings["Browser"] ?? "Chrome";
                _logHelper.LogInfo($"Retrieved Browser: {browser}");
                return browser;
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to retrieve Browser from config", ex);
                return "Chrome";
            }
        }

        public int GetImplicitWait()
        {
            try
            {
                string wait = ConfigurationManager.AppSettings["ImplicitWait"] ?? "30";
                int waitTime = int.Parse(wait);
                _logHelper.LogInfo($"Retrieved Implicit Wait: {waitTime}");
                return waitTime;
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to retrieve Implicit Wait from config", ex);
                return 30;
            }
        }

        public int GetExplicitWait()
        {
            try
            {
                string wait = ConfigurationManager.AppSettings["ExplicitWait"] ?? "30";
                int waitTime = int.Parse(wait);
                _logHelper.LogInfo($"Retrieved Explicit Wait: {waitTime}");
                return waitTime;
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to retrieve Explicit Wait from config", ex);
                return 30;
            }
        }

        public string GetEnvironment()
        {
            try
            {
                string environment = ConfigurationManager.AppSettings["Environment"] ?? "QA";
                _logHelper.LogInfo($"Retrieved Environment: {environment}");
                return environment;
            }
            catch (Exception ex)
            {
                _logHelper.LogError("Failed to retrieve Environment from config", ex);
                return "QA";
            }
        }
    }
}