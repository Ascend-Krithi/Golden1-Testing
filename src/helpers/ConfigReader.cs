using System;
using System.Configuration;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Golden1.Automation.Framework.Helpers
{
    public static class ConfigReader
    {
        private static JObject _configData;

        static ConfigReader()
        {
            LoadConfiguration();
        }

        private static void LoadConfiguration()
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "config.json");
                
                if (File.Exists(configPath))
                {
                    string jsonContent = File.ReadAllText(configPath);
                    _configData = JObject.Parse(jsonContent);
                    LogHelper.Info("Configuration loaded successfully from config.json");
                }
                else
                {
                    LogHelper.Warning($"Configuration file not found at: {configPath}. Using default values.");
                    _configData = new JObject();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error loading configuration: {ex.Message}");
                _configData = new JObject();
            }
        }

        public static string GetValue(string key)
        {
            try
            {
                // Try to get from JSON config first
                if (_configData != null && _configData[key] != null)
                {
                    return _configData[key].ToString();
                }

                // Fallback to app.config
                string value = ConfigurationManager.AppSettings[key];
                
                if (string.IsNullOrEmpty(value))
                {
                    // Return default values for common keys
                    switch (key)
                    {
                        case "BaseUrl":
                            return "https://www.golden1.com/";
                        case "Browser":
                            return "Chrome";
                        case "ImplicitWait":
                            return "10";
                        case "ExplicitWait":
                            return "30";
                        default:
                            LogHelper.Warning($"Configuration key '{key}' not found. Returning empty string.");
                            return string.Empty;
                    }
                }

                return value;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error reading configuration value for key '{key}': {ex.Message}");
                return string.Empty;
            }
        }

        public static int GetIntValue(string key, int defaultValue = 0)
        {
            try
            {
                string value = GetValue(key);
                return int.TryParse(value, out int result) ? result : defaultValue;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error parsing integer value for key '{key}': {ex.Message}");
                return defaultValue;
            }
        }

        public static bool GetBoolValue(string key, bool defaultValue = false)
        {
            try
            {
                string value = GetValue(key);
                return bool.TryParse(value, out bool result) ? result : defaultValue;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error parsing boolean value for key '{key}': {ex.Message}");
                return defaultValue;
            }
        }
    }
}