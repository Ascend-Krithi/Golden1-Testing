using OpenQA.Selenium;
using System;
using System.IO;

namespace Project1.Automation.Utilities
{
    public static class ScreenshotHelper
    {
        private static readonly string ScreenshotDirectory = "Screenshots";

        static ScreenshotHelper()
        {
            if (!Directory.Exists(ScreenshotDirectory))
            {
                Directory.CreateDirectory(ScreenshotDirectory);
            }
        }

        /// <summary>
        /// Takes screenshot and saves to file
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="screenshotName">Name for the screenshot file</param>
        /// <returns>Path to saved screenshot</returns>
        public static string TakeScreenshot(IWebDriver driver, string screenshotName)
        {
            try
            {
                // Clean filename
                string fileName = screenshotName.Replace(" ", "_");
                fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
                
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string screenshotPath = Path.Combine(ScreenshotDirectory, $"{fileName}_{timestamp}.png");

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath);

                LogHelper.Info($"Screenshot saved: {screenshotPath}");
                return screenshotPath;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to take screenshot: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Takes screenshot with default naming
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <returns>Path to saved screenshot</returns>
        public static string TakeScreenshot(IWebDriver driver)
        {
            return TakeScreenshot(driver, "Screenshot");
        }
    }
}