using System.Configuration;

namespace G1AutomationFramework.Utilities
{
    public static class ConfigReader
    {
        public static string BaseUrl
        {
            get
            {
                string url = ConfigurationManager.AppSettings["BaseUrl"];
                if (string.IsNullOrEmpty(url))
                {
                    url = "https://www.golden1.com/";
                }
                return url;
            }
        }

        public static string Browser
        {
            get
            {
                string browser = ConfigurationManager.AppSettings["Browser"];
                if (string.IsNullOrEmpty(browser))
                {
                    browser = "Chrome";
                }
                return browser;
            }
        }
    }
}