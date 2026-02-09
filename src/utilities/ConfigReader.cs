using System.Configuration;

namespace AutomationFramework.Utilities
{
    public static class ConfigReader
    {
        public static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"] ?? "https://www.golden1.com/";
        public static string Browser => ConfigurationManager.AppSettings["Browser"] ?? "Chrome";
        public static int ImplicitWait => int.Parse(ConfigurationManager.AppSettings["ImplicitWait"] ?? "10");
        public static int ExplicitWait => int.Parse(ConfigurationManager.AppSettings["ExplicitWait"] ?? "30");
    }
}