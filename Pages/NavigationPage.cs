using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Navigation Menu
    /// Handles all interactions with the global navigation menu
    /// Test Cases: TASK0020445 TS-002 through TS-007
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators from Golden1 Locators.Json
        // =============================================================
        
        // Main Navigation Container
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");

        // Top Menu Tabs
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
        private By GetMenuByName(string menuName) => 
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuName}']");
        
        private By GetSubmenuItemByName(string itemName) => 
            By.XPath($"//a[normalize-space()='{itemName}']");
        
        private By GetTopTabByName(string tabName) => 
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabName}']");

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
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
        /// Verifies specific top menu tab is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsTopMenuOptionPresent(string menuOption)
        {
            try
            {
                By locator = GetTopTabByName(menuOption);
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
        public bool AreAllTopMenuOptionsPresent(List<string> menuOptions)
        {
            LogHelper.Info("Verifying all top menu options are present");
            bool allPresent = true;
            
            foreach (string option in menuOptions)
            {
                bool isPresent = IsTopMenuOptionPresent(option);
                if (!isPresent)
                {
                    allPresent = false;
                    LogHelper.Error($"Top menu option missing: {option}");
                }
            }
            
            LogHelper.Info($"All top menu options present: {allPresent}");
            return allPresent;
        }

        /// <summary>
        /// Verifies main product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuDisplayed(string categoryName)
        {
            try
            {
                By locator = GetMenuByName(categoryName);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isDisplayed = IsDisplayed(locator);
                LogHelper.Info($"Product category '{categoryName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category '{categoryName}' not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all main product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool AreAllProductCategoryMenusDisplayed(List<string> categories)
        {
            LogHelper.Info("Verifying all product category menus are displayed");
            bool allDisplayed = true;
            
            foreach (string category in categories)
            {
                bool isDisplayed = IsProductCategoryMenuDisplayed(category);
                if (!isDisplayed)
                {
                    allDisplayed = false;
                    LogHelper.Error($"Product category missing: {category}");
                }
            }
            
            LogHelper.Info($"All product categories displayed: {allDisplayed}");
            return allDisplayed;
        }

        /// <summary>
        /// Verifies submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
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
        /// Expands a main product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void ExpandProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding product menu: {menuName}");
                By locator = GetMenuByName(menuName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                Click(locator);
                System.Threading.Thread.Sleep(1000); // Allow menu animation
                LogHelper.Info($"Product menu '{menuName}' expanded");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void ClickSubmenuItem(string itemName)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {itemName}");
                By locator = GetSubmenuItemByName(itemName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                Click(locator);
                WaitForPageLoad();
                LogHelper.Info($"Submenu item '{itemName}' clicked");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{itemName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies product category menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuClickable(string categoryName)
        {
            try
            {
                By locator = GetMenuByName(categoryName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                bool isClickable = Driver.FindElement(locator).Enabled;
                LogHelper.Info($"Product category '{categoryName}' clickable: {isClickable}");
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category '{categoryName}' not clickable: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies each product category menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool AreAllProductCategoryMenusClickable(List<string> categories)
        {
            LogHelper.Info("Verifying all product category menus are clickable");
            bool allClickable = true;
            
            foreach (string category in categories)
            {
                bool isClickable = IsProductCategoryMenuClickable(category);
                if (!isClickable)
                {
                    allClickable = false;
                    LogHelper.Error($"Product category not clickable: {category}");
                }
            }
            
            LogHelper.Info($"All product categories clickable: {allClickable}");
            return allClickable;
        }

        /// <summary>
        /// Verifies user can select submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool CanSelectSubmenuItem(string itemName)
        {
            try
            {
                By locator = GetSubmenuItemByName(itemName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                bool canSelect = Driver.FindElement(locator).Enabled && Driver.FindElement(locator).Displayed;
                LogHelper.Info($"Submenu item '{itemName}' selectable: {canSelect}");
                return canSelect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Cannot select submenu item '{itemName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies destination page loaded
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        public bool IsDestinationPageLoaded()
        {
            try
            {
                WaitForPageLoad();
                string url = GetCurrentUrl();
                bool isLoaded = !string.IsNullOrEmpty(url) && url != ConfigReader.BaseUrl;
                LogHelper.Info($"Destination page loaded: {isLoaded}, URL: {url}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page not loaded: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies destination page URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public bool DoesUrlContainIdentifier(string identifier)
        {
            try
            {
                string url = GetCurrentUrl().ToLower();
                bool contains = url.Contains(identifier.ToLower());
                LogHelper.Info($"URL contains '{identifier}': {contains}, Current URL: {url}");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify URL identifier '{identifier}': {ex.Message}");
                return false;
            }
        }
    }
}