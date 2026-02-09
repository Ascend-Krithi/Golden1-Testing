using System;
using System.Configuration;

namespace Golden1.Automation.Utilities
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

        public static int ImplicitWait
        {
            get
            {
                string wait = ConfigurationManager.AppSettings["ImplicitWait"];
                if (string.IsNullOrEmpty(wait))
                {
                    return 10;
                }
                return int.Parse(wait);
            }
        }
    }
}