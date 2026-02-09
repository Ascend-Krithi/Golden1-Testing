using System.Configuration;

namespace AutomationFramework.Utilities
{
    public static class ConfigReader
    {
        public static string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["BaseUrl"] ?? "https://www.golden1.com/";
            }
        }
    }
}