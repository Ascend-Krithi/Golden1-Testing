using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Global Navigation Menu
    /// Handles all interactions with the navigation menu and submenus
    /// Test Cases: TASK0020445 TS-002 through TS-011
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - Navigation Menu Elements
        // =============================================================
        
        // Global navigation menu
        private By GlobalNavigationMenu => By.CssSelector("nav.global-nav, nav.main-nav, .navigation-menu, header nav");
        private By NavigationContainer => By.CssSelector(".nav-container, .navigation, nav");
        
        // Navigation menu options (top level)
        private By PersonalMenuOption => By.XPath("//nav//a[contains(text(), 'Personal')]");
        private By BusinessMenuOption => By.XPath("//nav//a[contains(text(), 'Business')]");
        private By FinancialWellnessMenuOption => By.XPath("//nav//a[contains(text(), 'Financial Wellness')]");
        private By AppointmentsMenuOption => By.XPath("//nav//a[contains(text(), 'Appointments')]");
        private By LocationsMenuOption => By.XPath("//nav//a[contains(text(), 'Locations')]");
        private By MembershipMenuOption => By.XPath("//nav//a[contains(text(), 'Membership')]");
        private By HelpCenterMenuOption => By.XPath("//nav//a[contains(text(), 'Help Center')]");
        
        // Product category menus
        private By CheckingMenu => By.XPath("//nav//a[contains(text(), 'Checking')]");
        private By SavingsMenu => By.XPath("//nav//a[contains(text(), 'Savings')]");
        private By HomeLoansMenu => By.XPath("//nav//a[contains(text(), 'Home Loans')]");
        private By CreditCardsMenu => By.XPath("//nav//a[contains(text(), 'Credit Cards')]");
        private By LoansMenu => By.XPath("//nav//a[contains(text(), 'Loans')]");
        private By InvestingMenu => By.XPath("//nav//a[contains(text(), 'Investing')]");
        private By CommunityMenu => By.XPath("//nav//a[contains(text(), 'Community')]");
        
        // Submenu container
        private By SubmenuContainer => By.CssSelector(".submenu, .dropdown-menu, .sub-navigation");
        
        // Dynamic locators
        private By NavigationMenuOptionByText(string text) =>
            By.XPath($"//nav//a[normalize-space()='{text}']");
        
        private By ProductCategoryMenuByText(string text) =>
            By.XPath($"//nav//a[contains(normalize-space(), '{text}')]");
        
        private By SubmenuItemByText(string text) =>
            By.XPath($"//nav//ul[contains(@class, 'submenu') or contains(@class, 'dropdown')]//a[contains(normalize-space(), '{text}')]");

        // =============================================================
        // VERIFICATION METHODS - Global Navigation
        // =============================================================
        
        /// <summary>
        /// Verifies if the global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        /// <returns>True if global navigation menu is visible, false otherwise</returns>
        public bool IsGlobalNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible");
                WaitHelper.WaitVisible(Driver, GlobalNavigationMenu, 10);
                bool isVisible = IsDisplayed(GlobalNavigationMenu);
                LogHelper.Info($"Global navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying global navigation menu visibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a specific navigation menu option is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="optionName">Name of the navigation menu option</param>
        /// <returns>True if option is present, false otherwise</returns>
        public bool IsNavigationMenuOptionPresent(string optionName)
        {
            try
            {
                LogHelper.Info($"Verifying navigation menu option '{optionName}' is present");
                By optionLocator = NavigationMenuOptionByText(optionName);
                WaitHelper.WaitVisible(Driver, optionLocator, 10);
                bool isPresent = IsDisplayed(optionLocator);
                LogHelper.Info($"Navigation menu option '{optionName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying navigation menu option '{optionName}': {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // VERIFICATION METHODS - Product Category Menus
        // =============================================================
        
        /// <summary>
        /// Verifies if a product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the product category menu</param>
        /// <returns>True if menu is displayed, false otherwise</returns>
        public bool IsProductCategoryMenuDisplayed(string menuName)
        {
            try
            {
                LogHelper.Info($"Verifying product category menu '{menuName}' is displayed");
                By menuLocator = ProductCategoryMenuByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isDisplayed = IsDisplayed(menuLocator);
                LogHelper.Info($"Product category menu '{menuName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying product category menu '{menuName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all product category menus are clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <returns>True if all menus are clickable, false otherwise</returns>
        public bool AreProductCategoryMenusClickable()
        {
            try
            {
                LogHelper.Info("Verifying all product category menus are clickable");
                
                List<string> productMenus = new List<string>
                {
                    "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community"
                };
                
                foreach (string menu in productMenus)
                {
                    By menuLocator = ProductCategoryMenuByText(menu);
                    WaitHelper.WaitClickable(Driver, menuLocator, 10);
                    
                    var menuElement = Driver.FindElement(menuLocator);
                    bool isEnabled = menuElement.Enabled;
                    
                    if (!isEnabled)
                    {
                        LogHelper.Warning($"Product category menu '{menu}' is not clickable");
                        return false;
                    }
                    
                    LogHelper.Info($"Product category menu '{menu}' is clickable");
                }
                
                LogHelper.Info("All product category menus are clickable");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying product category menus clickability: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // VERIFICATION METHODS - Submenu
        // =============================================================
        
        /// <summary>
        /// Verifies if submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <returns>True if submenu items are displayed, false otherwise</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying submenu items are displayed");
                WaitHelper.WaitVisible(Driver, SubmenuContainer, 10);
                bool areDisplayed = IsDisplayed(SubmenuContainer);
                LogHelper.Info($"Submenu items displayed: {areDisplayed}");
                return areDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying submenu items display: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a specific submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <param name="submenuItem">Name of the submenu item</param>
        /// <returns>True if submenu item is selectable, false otherwise</returns>
        public bool IsSubmenuItemSelectable(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Verifying submenu item '{submenuItem}' is selectable");
                By submenuLocator = SubmenuItemByText(submenuItem);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                
                var submenuElement = Driver.FindElement(submenuLocator);
                bool isSelectable = submenuElement.Enabled && submenuElement.Displayed;
                
                LogHelper.Info($"Submenu item '{submenuItem}' selectable: {isSelectable}");
                return isSelectable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying submenu item '{submenuItem}' selectability: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // VERIFICATION METHODS - Navigation Functionality
        // =============================================================
        
        /// <summary>
        /// Verifies if the navigation menu is functional
        /// Test Cases: TASK0020445 TS-010 TC-001, TS-011 TC-001
        /// </summary>
        /// <returns>True if navigation menu is functional, false otherwise</returns>
        public bool IsNavigationMenuFunctional()
        {
            try
            {
                LogHelper.Info("Verifying navigation menu is functional");
                
                // Check if menu is visible
                bool isVisible = IsDisplayed(GlobalNavigationMenu, 5);
                
                // Check if at least one menu item is clickable
                bool isCheckingMenuClickable = false;
                try
                {
                    WaitHelper.WaitClickable(Driver, CheckingMenu, 5);
                    isCheckingMenuClickable = Driver.FindElement(CheckingMenu).Enabled;
                }
                catch
                {
                    LogHelper.Warning("Checking menu not found or not clickable");
                }
                
                bool isFunctional = isVisible && isCheckingMenuClickable;
                LogHelper.Info($"Navigation menu functional: {isFunctional}");
                
                return isFunctional;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying navigation menu functionality: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS - Menu Actions
        // =============================================================
        
        /// <summary>
        /// Expands a product menu by hovering or clicking
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="menuName">Name of the product menu to expand</param>
        public void ExpandProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding product menu '{menuName}'");
                By menuLocator = ProductCategoryMenuByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                var menuElement = Driver.FindElement(menuLocator);
                
                // Hover over the menu to expand it
                Actions actions = new Actions(Driver);
                actions.MoveToElement(menuElement).Perform();
                
                // Wait for submenu to appear
                System.Threading.Thread.Sleep(500); // Small wait for animation
                
                LogHelper.Info($"Product menu '{menuName}' expanded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error expanding product menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="submenuItem">Name of the submenu item to click</param>
        public void ClickSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item '{submenuItem}'");
                By submenuLocator = SubmenuItemByText(submenuItem);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Submenu item '{submenuItem}' clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error clicking submenu item '{submenuItem}': {ex.Message}");
                throw;
            }
        }
    }
}