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
    /// Handles all interactions with navigation menu and submenu elements
    /// Test Cases: TASK0020445 TS-003 through TS-007
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators
        // =============================================================
        
        // Main navigation menu
        private By GlobalNavigationMenu => By.CssSelector("nav.main-nav, nav[role='navigation'], .global-navigation");
        
        // Top menu options
        private By PersonalMenu => By.XPath("//nav//a[contains(text(),'Personal')]");
        private By BusinessMenu => By.XPath("//nav//a[contains(text(),'Business')]");
        private By FinancialWellnessMenu => By.XPath("//nav//a[contains(text(),'Financial Wellness')]");
        private By AppointmentsMenu => By.XPath("//nav//a[contains(text(),'Appointments')]");
        private By LocationsMenu => By.XPath("//nav//a[contains(text(),'Locations')]");
        private By MembershipMenu => By.XPath("//nav//a[contains(text(),'Membership')]");
        private By HelpCenterMenu => By.XPath("//nav//a[contains(text(),'Help Center')]");
        
        // Main product category menus
        private By CheckingMenu => By.XPath("//nav//a[contains(text(),'Checking')]");
        private By SavingsMenu => By.XPath("//nav//a[contains(text(),'Savings')]");
        private By HomeLoansMenu => By.XPath("//nav//a[contains(text(),'Home Loans')]");
        private By CreditCardsMenu => By.XPath("//nav//a[contains(text(),'Credit Cards')]");
        private By LoansMenu => By.XPath("//nav//a[contains(text(),'Loans')]");
        private By InvestingMenu => By.XPath("//nav//a[contains(text(),'Investing')]");
        private By CommunityMenu => By.XPath("//nav//a[contains(text(),'Community')]");
        
        // Submenu container
        private By SubmenuContainer => By.CssSelector(".submenu, .dropdown-menu, [role='menu']");
        
        // Dynamic locators
        private By MenuItemByText(string menuText) =>
            By.XPath($"//nav//a[normalize-space()='{menuText}']");
        
        private By SubmenuItemByText(string submenuText) =>
            By.XPath($"//nav//a[normalize-space()='{submenuText}'] | //*[@class='submenu']//a[normalize-space()='{submenuText}']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Locates and waits for global navigation menu to be visible
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public void LocateGlobalNavigationMenu()
        {
            try
            {
                LogHelper.Info("Locating global navigation menu");
                WaitHelper.WaitVisible(Driver, GlobalNavigationMenu, 10);
                LogHelper.Info("Global navigation menu located successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to locate global navigation menu: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Expands a main product menu by name
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to expand</param>
        public void ExpandMainProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding main product menu: {menuName}");
                By menuLocator = MenuItemByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                Click(menuLocator);
                
                // Wait for submenu to appear
                WaitHelper.WaitVisible(Driver, SubmenuContainer, 5);
                LogHelper.Info($"Main product menu '{menuName}' expanded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a main product category menu
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to click</param>
        public void ClickMainProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Clicking main product menu: {menuName}");
                By menuLocator = MenuItemByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                Click(menuLocator);
                LogHelper.Info($"Main product menu '{menuName}' clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Selects a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="submenuItemName">Name of the submenu item to select</param>
        public void SelectSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Selecting submenu item: {submenuItemName}");
                By submenuLocator = SubmenuItemByText(submenuItemName);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Submenu item '{submenuItemName}' selected successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item '{submenuItemName}': {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if a specific menu option is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="menuOption">Menu option name to verify</param>
        /// <returns>True if menu option is present</returns>
        public bool IsMenuOptionPresent(string menuOption)
        {
            try
            {
                LogHelper.Info($"Checking if menu option '{menuOption}' is present");
                By menuLocator = MenuItemByText(menuOption);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isPresent = IsDisplayed(menuLocator);
                LogHelper.Info($"Menu option '{menuOption}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu option '{menuOption}' not found: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all specified menu options are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="menuOptions">List of menu options to verify</param>
        /// <returns>True if all menu options are present</returns>
        public bool AreAllMenuOptionsPresent(List<string> menuOptions)
        {
            try
            {
                LogHelper.Info($"Verifying {menuOptions.Count} menu options are present");
                bool allPresent = true;
                
                foreach (string menuOption in menuOptions)
                {
                    if (!IsMenuOptionPresent(menuOption))
                    {
                        allPresent = false;
                        LogHelper.Error($"Menu option '{menuOption}' is missing");
                    }
                }
                
                LogHelper.Info($"All menu options present: {allPresent}");
                return allPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify menu options: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a main product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="productCategory">Product category name</param>
        /// <returns>True if product category is displayed</returns>
        public bool IsProductCategoryDisplayed(string productCategory)
        {
            try
            {
                LogHelper.Info($"Checking if product category '{productCategory}' is displayed");
                By categoryLocator = MenuItemByText(productCategory);
                WaitHelper.WaitVisible(Driver, categoryLocator, 10);
                bool isDisplayed = IsDisplayed(categoryLocator);
                LogHelper.Info($"Product category '{productCategory}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category '{productCategory}' not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all product categories are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="productCategories">List of product categories</param>
        /// <returns>True if all categories are displayed</returns>
        public bool AreAllProductCategoriesDisplayed(List<string> productCategories)
        {
            try
            {
                LogHelper.Info($"Verifying {productCategories.Count} product categories are displayed");
                bool allDisplayed = true;
                
                foreach (string category in productCategories)
                {
                    if (!IsProductCategoryDisplayed(category))
                    {
                        allDisplayed = false;
                        LogHelper.Error($"Product category '{category}' is not displayed");
                    }
                }
                
                LogHelper.Info($"All product categories displayed: {allDisplayed}");
                return allDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify product categories: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Menu name to check</param>
        /// <returns>True if menu is clickable</returns>
        public bool IsMenuClickable(string menuName)
        {
            try
            {
                LogHelper.Info($"Checking if menu '{menuName}' is clickable");
                By menuLocator = MenuItemByText(menuName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                bool isClickable = Driver.FindElement(menuLocator).Enabled;
                LogHelper.Info($"Menu '{menuName}' clickable: {isClickable}");
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu '{menuName}' not clickable: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <returns>True if submenu items are displayed</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                LogHelper.Info("Checking if submenu items are displayed");
                WaitHelper.WaitVisible(Driver, SubmenuContainer, 10);
                bool isDisplayed = IsDisplayed(SubmenuContainer);
                LogHelper.Info($"Submenu items displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <param name="submenuItemName">Submenu item name</param>
        /// <returns>True if submenu item is selectable</returns>
        public bool IsSubmenuItemSelectable(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Checking if submenu item '{submenuItemName}' is selectable");
                By submenuLocator = SubmenuItemByText(submenuItemName);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                bool isSelectable = Driver.FindElement(submenuLocator).Enabled;
                LogHelper.Info($"Submenu item '{submenuItemName}' selectable: {isSelectable}");
                return isSelectable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item '{submenuItemName}' not selectable: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if destination page loaded without errors
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        /// <returns>True if page loaded successfully</returns>
        public bool IsDestinationPageLoadedSuccessfully()
        {
            try
            {
                LogHelper.Info("Verifying destination page loaded successfully");
                WaitForPageLoad();
                WaitHelper.WaitForPageToLoad(Driver, 30);
                
                // Check if page has loaded by verifying URL changed
                string currentUrl = Driver.Url;
                bool isLoaded = !string.IsNullOrEmpty(currentUrl) && currentUrl != ConfigReader.BaseUrl;
                
                LogHelper.Info($"Destination page loaded successfully: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify destination page load: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="expectedIdentifier">Expected URL identifier</param>
        /// <returns>True if URL contains identifier</returns>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            try
            {
                LogHelper.Info($"Checking if URL contains identifier: {expectedIdentifier}");
                string currentUrl = Driver.Url.ToLower();
                bool contains = currentUrl.Contains(expectedIdentifier.ToLower());
                LogHelper.Info($"URL contains '{expectedIdentifier}': {contains} (Current URL: {currentUrl})");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify URL identifier: {ex.Message}");
                return false;
            }
        }
    }
}