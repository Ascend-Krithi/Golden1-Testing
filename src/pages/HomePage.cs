using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Golden1.Automation.Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Golden1.Automation.Framework.Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver _driver;

        // Locators
        private By _golden1Logo = By.XPath("//a[@class='logo']//img[@alt='Golden 1 Credit Union']");
        private By _homePageLoadedIndicator = By.XPath("//div[@class='hero-banner'] | //main[@id='main-content']");
        private By _errorMessage = By.XPath("//div[contains(@class, 'error')] | //div[contains(@class, 'alert-danger')]");
        private By _loadingSpinner = By.XPath("//div[contains(@class, 'loading')] | //div[contains(@class, 'spinner')]");
        private By _mainContent = By.XPath("//main[@id='main-content']");
        private By _headerSection = By.XPath("//header");
        private By _footerSection = By.XPath("//footer");
        private By _navigationMenu = By.XPath("//nav[@class='main-navigation'] | //div[@class='navigation']");

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void NavigateToHomePage(string url)
        {
            try
            {
                LogHelper.Info($"Navigating to URL: {url}");
                _driver.Navigate().GoToUrl(url);
                WaitHelper.WaitForPageLoad(_driver);
                LogHelper.Info("Successfully navigated to homepage");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                throw;
            }
        }

        public bool IsHomePageLoaded()
        {
            try
            {
                WaitHelper.WaitForElementToBeVisible(_driver, _homePageLoadedIndicator, 30);
                bool isLoaded = IsElementDisplayed(_homePageLoadedIndicator);
                LogHelper.Info($"Homepage loaded status: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking if homepage is loaded: {ex.Message}");
                return false;
            }
        }

        public By GetHomePageLoadedIndicator()
        {
            return _homePageLoadedIndicator;
        }

        public bool HasErrorMessages()
        {
            try
            {
                var errorElements = _driver.FindElements(_errorMessage);
                bool hasErrors = errorElements.Any(e => e.Displayed);
                
                if (hasErrors)
                {
                    LogHelper.Warning("Error messages found on page");
                }
                
                return hasErrors;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for error messages: {ex.Message}");
                return false;
            }
        }

        public bool HasLoadingIssues()
        {
            try
            {
                // Check if loading spinner is still visible after page load
                var loadingElements = _driver.FindElements(_loadingSpinner);
                bool hasLoadingIssues = loadingElements.Any(e => e.Displayed);
                
                if (hasLoadingIssues)
                {
                    LogHelper.Warning("Loading issues detected on page");
                }
                
                return hasLoadingIssues;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for loading issues: {ex.Message}");
                return false;
            }
        }

        public bool IsGolden1LogoVisible()
        {
            try
            {
                WaitHelper.WaitForElementToBeVisible(_driver, _golden1Logo, 10);
                bool isVisible = IsElementDisplayed(_golden1Logo);
                LogHelper.Info($"Golden1 logo visibility: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking Golden1 logo visibility: {ex.Message}");
                return false;
            }
        }

        public By GetGolden1Logo()
        {
            return _golden1Logo;
        }

        public bool HasBrokenLayout()
        {
            try
            {
                // Check if main structural elements are present
                bool hasHeader = IsElementDisplayed(_headerSection);
                bool hasMainContent = IsElementDisplayed(_mainContent);
                bool hasFooter = IsElementDisplayed(_footerSection);
                
                bool layoutIsBroken = !hasHeader || !hasMainContent || !hasFooter;
                
                if (layoutIsBroken)
                {
                    LogHelper.Warning($"Broken layout detected - Header: {hasHeader}, Content: {hasMainContent}, Footer: {hasFooter}");
                }
                
                return layoutIsBroken;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for broken layout: {ex.Message}");
                return true;
            }
        }

        public bool AreKeyElementsDisplayed()
        {
            try
            {
                bool logoDisplayed = IsElementDisplayed(_golden1Logo);
                bool navigationDisplayed = IsElementDisplayed(_navigationMenu);
                bool mainContentDisplayed = IsElementDisplayed(_mainContent);
                
                bool allDisplayed = logoDisplayed && navigationDisplayed && mainContentDisplayed;
                
                LogHelper.Info($"Key elements display status - Logo: {logoDisplayed}, Navigation: {navigationDisplayed}, Content: {mainContentDisplayed}");
                
                return allDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking key elements display: {ex.Message}");
                return false;
            }
        }
    }
}