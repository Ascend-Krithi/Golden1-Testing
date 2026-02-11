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
    /// Handles all interactions with the global navigation menu
    /// Test Cases: TASK0020445 TS-002 through TS-007, TS-012
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
        private By GetTopTabByName(string tabName) =>
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabName}']");
        
        private By GetMainMenuByName(string menuName) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuName}']");
        
        private By GetSubmenuItemByName(string itemName) =>
            By.XPath($"//a[normalize-space()='{itemName}']");

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        /// <summary>
        /// Verifies if global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        /// <returns>True if menu is visible</returns>
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu visibility");
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a specific top tab is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="tabName">Name of the tab to verify</param>
        /// <returns>True if tab is present</returns>
        public bool IsTopTabPresent(string tabName)
        {
            try
            {
                LogHelper.Info($"Verifying presence of top tab: {tabName}");
                By tabLocator = GetTopTabByName(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isPresent = IsDisplayed(tabLocator);
                LogHelper.Info($"Top tab '{tabName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tab '{tabName}' verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all specified top tabs are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="tabNames">List of tab names to verify</param>
        /// <returns>True if all tabs are present</returns>
        public bool AreAllTopTabsPresent(List<string> tabNames)
        {
            try
            {
                LogHelper.Info($"Verifying presence of {tabNames.Count} top tabs");
                bool allPresent = true;
                
                foreach (string tabName in tabNames)
                {
                    bool isPresent = IsTopTabPresent(tabName);
                    if (!isPresent)
                    {
                        LogHelper.Warning($"Top tab '{tabName}' not found");
                        allPresent = false;
                    }
                }
                
                LogHelper.Info($"All top tabs present: {allPresent}");
                return allPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tabs verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a main product menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to verify</param>
        /// <returns>True if menu is displayed</returns>
        public bool IsMainMenuDisplayed(string menuName)
        {
            try
            {
                LogHelper.Info($"Verifying main menu: {menuName}");
                By menuLocator = GetMainMenuByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isDisplayed = IsDisplayed(menuLocator);
                LogHelper.Info($"Main menu '{menuName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main menu '{menuName}' verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all main product menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuNames">List of menu names to verify</param>
        /// <returns>True if all menus are displayed</returns>
        public bool AreAllMainMenusDisplayed(List<string> menuNames)
        {
            try
            {
                LogHelper.Info($"Verifying {menuNames.Count} main product menus");
                bool allDisplayed = true;
                
                foreach (string menuName in menuNames)
                {
                    bool isDisplayed = IsMainMenuDisplayed(menuName);
                    if (!isDisplayed)
                    {
                        LogHelper.Warning($"Main menu '{menuName}' not displayed");
                        allDisplayed = false;
                    }
                }
                
                LogHelper.Info($"All main menus displayed: {allDisplayed}");
                return allDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main menus verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a main menu is accessible (clickable)
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to verify</param>
        /// <returns>True if menu is accessible</returns>
        public bool IsMainMenuAccessible(string menuName)
        {
            try
            {
                LogHelper.Info($"Verifying accessibility of main menu: {menuName}");
                By menuLocator = GetMainMenuByName(menuName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                bool isAccessible = Driver.FindElement(menuLocator).Enabled;
                LogHelper.Info($"Main menu '{menuName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main menu '{menuName}' accessibility check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <param name="submenuItemName">Name of submenu item to verify</param>
        /// <returns>True if submenu items are displayed</returns>
        public bool AreSubmenuItemsDisplayed(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Verifying submenu item: {submenuItemName}");
                By submenuLocator = GetSubmenuItemByName(submenuItemName);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
                bool isDisplayed = IsDisplayed(submenuLocator);
                LogHelper.Info($"Submenu item '{submenuItemName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu verification failed: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        /// <summary>
        /// Hovers over a main product menu
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to hover over</param>
        public void HoverOverMainMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Hovering over main menu: {menuName}");
                By menuLocator = GetMainMenuByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                IWebElement menuElement = Driver.FindElement(menuLocator);
                Actions actions = new Actions(Driver);
                actions.MoveToElement(menuElement).Perform();
                
                // Wait for submenu to appear
                System.Threading.Thread.Sleep(500); // Brief pause for animation
                LogHelper.Info($"Successfully hovered over menu: {menuName}");
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
        /// <param name="submenuItemName">Name of the submenu item to click</param>
        public void ClickSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {submenuItemName}");
                By submenuLocator = GetSubmenuItemByName(submenuItemName);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Successfully clicked submenu item: {submenuItemName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItemName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Navigates to a page via menu and submenu
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="mainMenu">Main menu name</param>
        /// <param name="submenuItem">Submenu item name</param>
        public void NavigateViaMenu(string mainMenu, string submenuItem)
        {
            try
            {
                LogHelper.Info($"Navigating via menu: {mainMenu} -> {submenuItem}");
                HoverOverMainMenu(mainMenu);
                ClickSubmenuItem(submenuItem);
                LogHelper.Info($"Successfully navigated to: {submenuItem}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Uses keyboard navigation to access menu
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        /// <param name="menuName">Menu name to navigate to</param>
        public void NavigateToMenuUsingKeyboard(string menuName)
        {
            try
            {
                LogHelper.Info($"Navigating to menu using keyboard: {menuName}");
                By menuLocator = GetMainMenuByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                IWebElement menuElement = Driver.FindElement(menuLocator);
                Actions actions = new Actions(Driver);
                
                // Tab to the element and press Enter
                menuElement.SendKeys(Keys.Tab);
                menuElement.SendKeys(Keys.Enter);
                
                LogHelper.Info($"Successfully navigated to menu using keyboard: {menuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard navigation failed for '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Presses Enter key on a submenu item
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        /// <param name="submenuItemName">Submenu item name</param>
        public void PressEnterOnSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Pressing Enter on submenu item: {submenuItemName}");
                By submenuLocator = GetSubmenuItemByName(submenuItemName);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
                
                IWebElement submenuElement = Driver.FindElement(submenuLocator);
                submenuElement.SendKeys(Keys.Enter);
                WaitForPageLoad();
                
                LogHelper.Info($"Successfully pressed Enter on: {submenuItemName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to press Enter on '{submenuItemName}': {ex.Message}");
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
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }

        /// <summary>
        /// Verifies if URL contains expected text
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="expectedText">Expected text in URL</param>
        /// <returns>True if URL contains expected text</returns>
        public bool DoesUrlContain(string expectedText)
        {
            try
            {
                string currentUrl = GetCurrentPageUrl();
                bool contains = currentUrl.ToLower().Contains(expectedText.ToLower());
                LogHelper.Info($"URL contains '{expectedText}': {contains}");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                return false;
            }
        }
    }
}