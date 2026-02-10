using OpenQA.Selenium;
using System;
using System.IO;

namespace Golden1.Automation.Utilities
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string name)
        {
            string folder = "Screenshots";
            Directory.CreateDirectory(folder);

            // 🔥 SANITIZE FILE NAME
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }

            string path = Path.Combine(folder, $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path);

            return path;
        }
    }
}
