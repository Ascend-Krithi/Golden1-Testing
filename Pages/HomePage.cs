using OpenQA.Selenium;
using Project1.Automation.Utilities;
using System;

namespace Project1.Automation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl;

        // Locators
        private By HomepageLogo => By.XPath("//img[@alt='Golden 1 Credit Union']");
        private By MainNavigationMenu => By.CssSelector("nav.main-navigation");
        private By ErrorMessage => By.XPath("//div[contains(@class, 'error')] | //div[contains(@class, 'alert-danger')]");
        private By PageLoadedIndicator => By.TagName("body");
        private By HeaderSection => By.CssSelector("header");

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _baseUrl = ConfigReader.GetValue("BaseUrl");
        }

        /// <summary>
        /// Navigates to the Golden 1 homepage
        /// </summary>
        public void NavigateToHomepage()
        {
            try
            {
                LogHelper.Info($"Navigating to URL: {_baseUrl}");
                _driver.Navigate().GoToUrl(_baseUrl);
                WaitHelper.WaitForPageLoad(_driver);
                WaitHelper.WaitVisible(_driver, PageLoadedIndicator, 30);
                LogHelper.Info("Homepage navigation completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "NavigationFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies if the homepage is loaded successfully
        /// </summary>
        /// <returns>True if homepage is loaded, false otherwise</returns>
        public bool IsHomepageLoaded()
        {
            try
            {
                LogHelper.Info("Checking if homepage is loaded");
                
                // Wait for page to be fully loaded
                WaitHelper.WaitForPageLoad(_driver);
                
                // Verify URL
                string currentUrl = _driver.Url;
                bool isCorrectUrl = currentUrl.Contains("golden1.com");
                LogHelper.Info($"Current URL: {currentUrl}");

                // Verify key elements are visible
                bool isHeaderVisible = WaitHelper.WaitVisible(_driver, HeaderSection, 10);
                
                // Verify no JavaScript errors (page loaded completely)
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                bool isPageReady = js.ExecuteScript("return document.readyState").ToString().Equals("complete");

                bool isLoaded = isCorrectUrl && isHeaderVisible && isPageReady;
                LogHelper.Info($"Homepage loaded status: {isLoaded}");
                
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking homepage load status: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "HomepageLoadCheckFailure");
                return false;
            }
        }

        /// <summary>
        /// Gets the current page title
        /// </summary>
        /// <returns>Page title as string</returns>
        public string GetPageTitle()
        {
            try
            {
                WaitHelper.WaitForPageLoad(_driver);
                string title = _driver.Title;
                LogHelper.Info($"Retrieved page title: {title}");
                return title;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get page title: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Checks if any error messages are displayed on the page
        /// </summary>
        /// <returns>True if errors are present, false otherwise</returns>
        public bool AreErrorMessagesDisplayed()
        {
            try
            {
                LogHelper.Info("Checking for error messages on page");
                var errorElements = _driver.FindElements(ErrorMessage);
                bool hasErrors = errorElements.Count > 0 && errorElements[0].Displayed;
                
                if (hasErrors)
                {
                    LogHelper.Warning($"Found {errorElements.Count} error message(s) on page");
                    ScreenshotHelper.TakeScreenshot(_driver, "ErrorMessagesFound");
                }
                
                return hasErrors;
            }
            catch (NoSuchElementException)
            {
                LogHelper.Info("No error messages found on page");
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error while checking for error messages: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies the homepage logo is visible
        /// </summary>
        /// <returns>True if logo is visible, false otherwise</returns>
        public bool IsLogoVisible()
        {
            try
            {
                LogHelper.Info("Verifying homepage logo visibility");
                bool isVisible = WaitHelper.WaitVisible(_driver, HomepageLogo, 10);
                LogHelper.Info($"Logo visibility status: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify logo visibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies the main navigation menu is visible
        /// </summary>
        /// <returns>True if navigation is visible, false otherwise</returns>
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Verifying navigation menu visibility");
                bool isVisible = WaitHelper.WaitVisible(_driver, MainNavigationMenu, 10);
                LogHelper.Info($"Navigation menu visibility status: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify navigation menu visibility: {ex.Message}");
                return false;
            }
        }
    }
}