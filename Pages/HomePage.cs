using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Homepage
    /// Handles all interactions with the homepage
    /// Test Cases: TASK0020445 TS-009 TC-001
    /// </summary>
    public class HomePage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public HomePage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators from Golden1 Locators.Json
        // =============================================================
        
        // Navigation Menu Locators
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");
        
        // Top Tab Locators
        private By PersonalTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Personal']");
        private By BusinessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Business']");
        private By FinancialWellnessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Financial Wellness']");
        private By AppointmentsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Appointments']");
        private By LocationsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Locations']");
        private By MembershipTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Membership']");
        private By HelpCenterTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Help Center']");
        
        // Main Menu Locators
        private By CheckingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Checking']");
        private By SavingsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Savings']");
        private By HomeLoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Home Loans']");
        private By CreditCardsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Credit Cards']");
        private By LoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Loans']");
        private By InvestingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Investing']");
        private By CommunityMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Community']");
        
        // Cookie Banner Locators
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Error Message Locators
        private By ErrorMessage => By.CssSelector(".error-message, .alert-error, .error, [class*='error']");
        private By SystemErrorMessage => By.XPath("//div[contains(text(),'error') or contains(text(),'Error')]");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden 1 homepage
        /// Test Cases: TASK0020445 TS-009 TC-001 - Step 1
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info($"Opening Golden 1 homepage: {ConfigReader.BaseUrl}");
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                LogHelper.Info("Homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if navigation menu is visible
        /// Test Cases: TASK0020445 TS-009 TC-001 - Step 2
        /// </summary>
        /// <returns>True if navigation menu is visible, false otherwise</returns>
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Checking if navigation menu is visible");
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if top tabs container is visible
        /// Test Cases: TASK0020445 TS-009 TC-001 - Step 2
        /// </summary>
        /// <returns>True if top tabs are visible, false otherwise</returns>
        public bool AreTopTabsVisible()
        {
            try
            {
                LogHelper.Info("Checking if top tabs are visible");
                WaitHelper.WaitVisible(Driver, TopTabsContainer, 10);
                bool isVisible = IsDisplayed(TopTabsContainer);
                LogHelper.Info($"Top tabs visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tabs not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if main menu items are visible
        /// Test Cases: TASK0020445 TS-009 TC-001 - Step 2
        /// </summary>
        /// <returns>True if at least 3 main menu items are visible, false otherwise</returns>
        public bool AreMainMenuItemsVisible()
        {
            try
            {
                LogHelper.Info("Checking if main menu items are visible");
                int visibleCount = 0;
                
                var menuItems = new List<By> 
                { 
                    CheckingMenu, 
                    SavingsMenu, 
                    HomeLoansMenu, 
                    CreditCardsMenu 
                };
                
                foreach (var menuItem in menuItems)
                {
                    try
                    {
                        if (IsDisplayed(menuItem, 5))
                        {
                            visibleCount++;
                        }
                    }
                    catch
                    {
                        // Continue checking other items
                    }
                }
                
                bool areVisible = visibleCount >= 3;
                LogHelper.Info($"Main menu items visible count: {visibleCount}, Result: {areVisible}");
                return areVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to check main menu items: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Checks if any error messages are displayed on the page
        /// Test Cases: TASK0020445 TS-009 TC-001 - Step 2
        /// </summary>
        /// <returns>True if error messages are present, false otherwise</returns>
        public bool HasErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages on homepage");
                
                // Check for generic error messages
                bool hasError = false;
                try
                {
                    hasError = IsDisplayed(ErrorMessage, 3);
                }
                catch
                {
                    // No error found, which is good
                }
                
                // Check for system error messages
                bool hasSystemError = false;
                try
                {
                    hasSystemError = IsDisplayed(SystemErrorMessage, 3);
                }
                catch
                {
                    // No system error found, which is good
                }
                
                bool hasErrors = hasError || hasSystemError;
                LogHelper.Info($"Error messages present: {hasErrors}");
                return hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error while checking for error messages: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Handles cookie banner if present by accepting cookies
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public void HandleCookieBannerIfPresent()
        {
            try
            {
                LogHelper.Info("Checking for cookie banner");
                if (IsDisplayed(CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner found, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    LogHelper.Info("Cookies accepted successfully");
                }
                else
                {
                    LogHelper.Info("No cookie banner present");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Cookie banner handling: {ex.Message}");
                // Not critical, continue test execution
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================
        
        /// <summary>
        /// Gets the current page title
        /// Test Cases: TASK0020445 TS-009 TC-001 - Step 2
        /// </summary>
        /// <returns>Page title as string</returns>
        public string GetPageTitle()
        {
            try
            {
                string title = Driver.Title;
                LogHelper.Info($"Page title: {title}");
                return title;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get page title: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-009 TC-001 - Step 2
        /// </summary>
        /// <returns>Current URL as string</returns>
        public string GetCurrentUrl()
        {
            try
            {
                string url = Driver.Url;
                LogHelper.Info($"Current URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get current URL: {ex.Message}");
                throw;
            }
        }
    }
}