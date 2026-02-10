using OpenQA.Selenium;
using Project1.Automation.Utilities;
using System;

namespace Project1.Automation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver Driver;
        
        // Constructor
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }
        
        // Locators
        private By PageHeader => By.XPath("//header");
        private By NavigationMenu => By.XPath("//nav");
        private By CompanyLogo => By.XPath("//img[contains(@alt,'Golden 1')]");
        private By PageBody => By.XPath("//body");
        
        // Page Methods
        public void NavigateToHomePage(string url)
        {
            try
            {
                LogHelper.Info($"Navigating to URL: {url}");
                Driver.Navigate().GoToUrl(url);
                WaitHelper.WaitForPageLoad(Driver);
                LogHelper.Info("Successfully navigated to homepage");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                throw;
            }
        }
        
        public bool IsHomePageDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed");
                WaitHelper.WaitVisible(Driver, PageBody, 10);
                bool isDisplayed = Driver.FindElement(PageBody).Displayed;
                LogHelper.Info($"Homepage displayed status: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify homepage display: {ex.Message}");
                return false;
            }
        }
        
        public bool IsHomePageLoadedWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage loaded without errors");
                WaitHelper.WaitForPageLoad(Driver);
                
                // Check if essential elements are present
                bool headerPresent = WaitHelper.WaitVisible(Driver, PageHeader, 10);
                bool bodyPresent = WaitHelper.WaitVisible(Driver, PageBody, 10);
                
                bool noErrors = headerPresent && bodyPresent;
                LogHelper.Info($"Homepage loaded without errors: {noErrors}");
                return noErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage loaded with errors: {ex.Message}");
                return false;
            }
        }
        
        public bool VerifyExpectedElements()
        {
            try
            {
                LogHelper.Info("Verifying expected homepage elements");
                
                bool headerVisible = WaitHelper.WaitVisible(Driver, PageHeader, 10);
                bool navVisible = WaitHelper.WaitVisible(Driver, NavigationMenu, 10);
                bool logoVisible = WaitHelper.WaitVisible(Driver, CompanyLogo, 10);
                
                bool allElementsPresent = headerVisible && navVisible && logoVisible;
                LogHelper.Info($"All expected elements present: {allElementsPresent}");
                return allElementsPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify expected elements: {ex.Message}");
                return false;
            }
        }
        
        public string GetCurrentUrl()
        {
            try
            {
                string currentUrl = Driver.Url;
                LogHelper.Info($"Current URL: {currentUrl}");
                return currentUrl;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get current URL: {ex.Message}");
                throw;
            }
        }
        
        public bool IsPageFullyLoaded()
        {
            try
            {
                LogHelper.Info("Checking if page is fully loaded");
                WaitHelper.WaitForPageLoad(Driver);
                
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                string readyState = js.ExecuteScript("return document.readyState").ToString();
                
                bool isComplete = readyState.Equals("complete", StringComparison.OrdinalIgnoreCase);
                LogHelper.Info($"Page ready state: {readyState}, Fully loaded: {isComplete}");
                return isComplete;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to check page load status: {ex.Message}");
                return false;
            }
        }
    }
}