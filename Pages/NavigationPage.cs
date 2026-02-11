using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Navigation Menu
    /// Handles all interactions with the global navigation menu and product categories
    /// Test Cases: TASK0020445 TS-002 to TS-012
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
        private By GetTopTabByText(string tabText) =>
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabText}']");

        private By GetMenuByText(string menuText) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuText}']");

        private By GetSubmenuItemByText(string itemText) =>
            By.XPath($"//a[normalize-space()='{itemText}']");

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        /// <returns>True if navigation menu is visible</returns>
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Checking if global navigation menu is visible");
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
        /// Verifies if top navigation tab is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="tabName">Name of the tab to verify</param>
        /// <returns>True if tab is present</returns>
        public bool IsTopTabPresent(string tabName)
        {
            try
            {
                LogHelper.Info($"Checking if top tab '{tabName}' is present");
                By tabLocator = GetTopTabByText(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isPresent = IsDisplayed(tabLocator);
                LogHelper.Info($"Top tab '{tabName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tab '{tabName}' not present: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all specified top tabs are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="expectedTabs">List of expected tab names</param>
        /// <returns>True if all tabs are present</returns>
        public bool AreAllTopTabsPresent(List<string> expectedTabs)
        {
            LogHelper.Info($"Verifying all top tabs are present: {string.Join(", ", expectedTabs)}");
            bool allPresent = true;

            foreach (string tab in expectedTabs)
            {
                if (!IsTopTabPresent(tab))
                {
                    allPresent = false;
                    LogHelper.Error($"Top tab '{tab}' is missing");
                }
            }

            LogHelper.Info($"All top tabs present: {allPresent}");
            return allPresent;
        }

        /// <summary>
        /// Verifies if main product menu is accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to verify</param>
        /// <returns>True if menu is accessible</returns>
        public bool IsMainMenuAccessible(string menuName)
        {
            try
            {
                LogHelper.Info($"Checking if main menu '{menuName}' is accessible");
                By menuLocator = GetMenuByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isAccessible = IsDisplayed(menuLocator);
                LogHelper.Info($"Main menu '{menuName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main menu '{menuName}' not accessible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all main product menus are accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="expectedMenus">List of expected menu names</param>
        /// <returns>True if all menus are accessible</returns>
        public bool AreAllMainMenusAccessible(List<string> expectedMenus)
        {
            LogHelper.Info($"Verifying all main menus are accessible: {string.Join(", ", expectedMenus)}");
            bool allAccessible = true;

            foreach (string menu in expectedMenus)
            {
                if (!IsMainMenuAccessible(menu))
                {
                    allAccessible = false;
                    LogHelper.Error($"Main menu '{menu}' is not accessible");
                }
            }

            LogHelper.Info($"All main menus accessible: {allAccessible}");
            return allAccessible;
        }

        /// <summary>
        /// Verifies if submenu item is visible after hovering
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <param name="submenuItem">Name of the submenu item</param>
        /// <returns>True if submenu item is visible</returns>
        public bool IsSubmenuItemVisible(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Checking if submenu item '{submenuItem}' is visible");
                By submenuLocator = GetSubmenuItemByText(submenuItem);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
                bool isVisible = IsDisplayed(submenuLocator);
                LogHelper.Info($"Submenu item '{submenuItem}' visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item '{submenuItem}' not visible: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Hovers over a main product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to hover over</param>
        public void HoverOverMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Hovering over menu: {menuName}");
                By menuLocator = GetMenuByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                IWebElement menuElement = Driver.FindElement(menuLocator);
                Actions actions = new Actions(Driver);
                actions.MoveToElement(menuElement).Perform();
                
                // Wait for submenu to appear
                System.Threading.Thread.Sleep(500); // Small wait for animation
                LogHelper.Info($"Hovered over menu: {menuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to hover over menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="submenuItem">Name of the submenu item to click</param>
        public void ClickSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {submenuItem}");
                By submenuLocator = GetSubmenuItemByText(submenuItem);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Clicked submenu item: {submenuItem}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItem}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Navigates to a page using menu and submenu
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="menuName">Main menu name</param>
        /// <param name="submenuItem">Submenu item name</param>
        public void NavigateToPageViaMenu(string menuName, string submenuItem)
        {
            LogHelper.Info($"Navigating to page via menu: {menuName} -> {submenuItem}");
            HoverOverMenu(menuName);
            ClickSubmenuItem(submenuItem);
            LogHelper.Info($"Navigation completed to: {submenuItem}");
        }

        /// <summary>
        /// Uses keyboard to navigate to navigation menu
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void NavigateToMenuUsingKeyboard()
        {
            try
            {
                LogHelper.Info("Navigating to menu using keyboard Tab key");
                Actions actions = new Actions(Driver);
                
                // Press Tab multiple times to reach navigation menu
                for (int i = 0; i < 10; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    System.Threading.Thread.Sleep(200);
                    
                    // Check if navigation menu has focus
                    IWebElement activeElement = Driver.SwitchTo().ActiveElement();
                    if (activeElement.GetAttribute("class").Contains("nav-item-link") || 
                        activeElement.GetAttribute("class").Contains("menu"))
                    {
                        LogHelper.Info("Navigation menu reached using keyboard");
                        return;
                    }
                }
                
                LogHelper.Info("Completed keyboard navigation to menu");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate using keyboard: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Selects menu item using Enter key
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void SelectMenuItemUsingEnterKey()
        {
            try
            {
                LogHelper.Info("Selecting menu item using Enter key");
                Actions actions = new Actions(Driver);
                actions.SendKeys(Keys.Enter).Perform();
                WaitForPageLoad();
                LogHelper.Info("Menu item selected using Enter key");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select menu item using Enter key: {ex.Message}");
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
        public string GetCurrentUrl()
        {
            string url = Driver.Url;
            LogHelper.Info($"Current URL: {url}");
            return url;
        }

        /// <summary>
        /// Verifies if URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="expectedIdentifier">Expected URL identifier</param>
        /// <returns>True if URL contains identifier</returns>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            string currentUrl = GetCurrentUrl();
            bool contains = currentUrl.Contains(expectedIdentifier);
            LogHelper.Info($"URL contains '{expectedIdentifier}': {contains}");
            return contains;
        }
    }
}