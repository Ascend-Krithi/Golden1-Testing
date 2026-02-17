using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Navigation Menu
    /// Handles all interactions with the global navigation menu and product menus
    /// Test Cases: TASK0020445 TS-002 through TS-007
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - From Golden1 Locators.Json
        // =============================================================
        
        // Menu Container
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");

        // Top Navigation Tabs
        private By PersonalTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Personal']");
        private By BusinessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Business']");
        private By FinancialWellnessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Financial Wellness']");
        private By AppointmentsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Appointments']");
        private By LocationsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Locations']");
        private By MembershipTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Membership']");
        private By HelpCenterTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Help Center']");

        // Main Product Category Menus
        private By CheckingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Checking']");
        private By SavingsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Savings']");
        private By HomeLoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Home Loans']");
        private By CreditCardsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Credit Cards']");
        private By LoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Loans']");
        private By InvestingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Investing']");
        private By CommunityMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Community']");

        // Submenu Items
        private By FreeCheckingLink => By.XPath("//a[normalize-space()='Free Checking']");
        private By SavingsAccountLink => By.XPath("//a[normalize-space()='Savings Account']");
        private By AutoLoansLink => By.XPath("//a[contains(normalize-space(),'Auto Loan')]");

        // Dynamic Locators
        private By GetTopMenuByText(string menuText) =>
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{menuText}']");

        private By GetProductMenuByText(string menuText) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuText}']");

        private By GetSubmenuItemByText(string itemText) =>
            By.XPath($"//a[normalize-space()='{itemText}']");

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        /// <returns>True if navigation menu is visible</returns>
        public bool IsNavigationMenuVisible()
        {
            try
            {
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
        /// Verifies specific top menu option is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="menuOption">Menu option text</param>
        /// <returns>True if menu option is present</returns>
        public bool IsTopMenuOptionPresent(string menuOption)
        {
            try
            {
                By locator = GetTopMenuByText(menuOption);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isPresent = IsDisplayed(locator);
                LogHelper.Info($"Top menu option '{menuOption}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top menu option '{menuOption}' not present: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all top menu options are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="menuOptions">List of expected menu options</param>
        /// <returns>True if all menu options are present</returns>
        public bool AreAllTopMenuOptionsPresent(List<string> menuOptions)
        {
            LogHelper.Info($"Verifying {menuOptions.Count} top menu options");
            bool allPresent = true;

            foreach (string menuOption in menuOptions)
            {
                if (!IsTopMenuOptionPresent(menuOption))
                {
                    allPresent = false;
                    LogHelper.Error($"Top menu option '{menuOption}' is missing");
                }
            }

            LogHelper.Info($"All top menu options present: {allPresent}");
            return allPresent;
        }

        /// <summary>
        /// Verifies main product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="productMenu">Product menu text</param>
        /// <returns>True if product menu is displayed</returns>
        public bool IsProductMenuDisplayed(string productMenu)
        {
            try
            {
                By locator = GetProductMenuByText(productMenu);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isDisplayed = IsDisplayed(locator);
                LogHelper.Info($"Product menu '{productMenu}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu '{productMenu}' not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all main product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="productMenus">List of expected product menus</param>
        /// <returns>True if all product menus are displayed</returns>
        public bool AreAllProductMenusDisplayed(List<string> productMenus)
        {
            LogHelper.Info($"Verifying {productMenus.Count} product menus");
            bool allDisplayed = true;

            foreach (string productMenu in productMenus)
            {
                if (!IsProductMenuDisplayed(productMenu))
                {
                    allDisplayed = false;
                    LogHelper.Error($"Product menu '{productMenu}' is missing");
                }
            }

            LogHelper.Info($"All product menus displayed: {allDisplayed}");
            return allDisplayed;
        }

        /// <summary>
        /// Verifies product menu is accessible (clickable)
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="productMenu">Product menu text</param>
        /// <returns>True if product menu is accessible</returns>
        public bool IsProductMenuAccessible(string productMenu)
        {
            try
            {
                By locator = GetProductMenuByText(productMenu);
                WaitHelper.WaitClickable(Driver, locator, 10);
                bool isAccessible = Driver.FindElement(locator).Enabled;
                LogHelper.Info($"Product menu '{productMenu}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu '{productMenu}' not accessible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies submenu items are displayed after expanding menu
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <returns>True if submenu items are displayed</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                // Wait for any submenu item to be visible
                WaitHelper.WaitVisible(Driver, FreeCheckingLink, 10);
                bool isDisplayed = IsDisplayed(FreeCheckingLink);
                LogHelper.Info($"Submenu items displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items not displayed: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Expands a main product menu by hovering/clicking
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001
        /// </summary>
        /// <param name="menuName">Menu name to expand</param>
        public void ExpandProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding product menu: {menuName}");
                By locator = GetProductMenuByText(menuName);
                WaitHelper.WaitVisible(Driver, locator, 10);
                
                // Hover over menu to expand
                var element = Driver.FindElement(locator);
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                actions.MoveToElement(element).Perform();
                
                // Wait for submenu to appear
                WaitHelper.Wait(Driver, 2);
                LogHelper.Info($"Product menu '{menuName}' expanded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand product menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="submenuItem">Submenu item text</param>
        public void ClickSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {submenuItem}");
                By locator = GetSubmenuItemByText(submenuItem);
                WaitHelper.WaitClickable(Driver, locator, 10);
                Click(locator);
                WaitForPageLoad();
                LogHelper.Info($"Submenu item '{submenuItem}' clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItem}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a main product menu
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Menu name to click</param>
        public void ClickProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Clicking product menu: {menuName}");
                By locator = GetProductMenuByText(menuName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                Click(locator);
                LogHelper.Info($"Product menu '{menuName}' clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click product menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================
        
        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <returns>Current URL</returns>
        public string GetCurrentPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current URL: {url}");
            return url;
        }

        /// <summary>
        /// Verifies URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="expectedIdentifier">Expected URL identifier</param>
        /// <returns>True if URL contains identifier</returns>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            string currentUrl = GetCurrentPageUrl();
            bool contains = currentUrl.ToLower().Contains(expectedIdentifier.ToLower());
            LogHelper.Info($"URL contains '{expectedIdentifier}': {contains}");
            return contains;
        }
    }
}