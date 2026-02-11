using System;
using System.IO;
using OpenQA.Selenium;
using Golden1.Automation.Config;

namespace Golden1.Automation.Utilities
{
    /// <summary>
    /// Screenshot Helper utility
    /// DO NOT MODIFY - Framework Core File
    /// </summary>
    public static class ScreenshotHelper
    {
        /// <summary>
        /// Captures a screenshot and saves it to the configured path
        /// </summary>
        public static void CaptureScreenshot(IWebDriver driver, string scenarioName)
        {
            try
            {
                var screenshotDriver = driver as ITakesScreenshot;
                if (screenshotDriver == null)
                {
                    LogHelper.Warning("Driver does not support screenshots");
                    return;
                }

                var screenshot = screenshotDriver.GetScreenshot();
                var screenshotDirectory = ConfigReader.ScreenshotPath;

                if (!Directory.Exists(screenshotDirectory))
                {
                    Directory.CreateDirectory(screenshotDirectory);
                }

                var fileName = $"{scenarioName.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                var filePath = Path.Combine(screenshotDirectory, fileName);

                screenshot.SaveAsFile(filePath);
                LogHelper.Info($"Screenshot saved: {filePath}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to capture screenshot: {ex.Message}");
            }
        }
    }
}