using System;
using System.Configuration;

namespace Golden1.Utilities
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