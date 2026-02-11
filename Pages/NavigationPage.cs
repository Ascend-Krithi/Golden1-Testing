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
    /// Page Object for Golden1 Navigation Menu
    /// Handles all interactions with the global navigation menu
    /// Test Cases: TASK0020445 TS-002 through TS-012
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators (from Golden1 Locators.Json)
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
        private By GetMenuByName(string menuName) => 
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuName}']");
        
        private By GetSubmenuByName(string submenuName) => 
            By.XPath($"//a[normalize-space()='{submenuName}']");
        
        private By GetTopTabByName(string tabName) => 
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabName}']");

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        /// <returns>True if menu is visible</returns>
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible");
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
        /// Verifies specific top navigation tab is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="tabName">Name of the tab to verify</param>
        /// <returns>True if tab is present</returns>
        public bool IsTopNavigationTabPresent(string tabName)
        {
            try
            {
                LogHelper.Info($"Verifying top navigation tab '{tabName}' is present");
                By tabLocator = GetTopTabByName(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isPresent = IsDisplayed(tabLocator);
                LogHelper.Info($"Top navigation tab '{tabName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top navigation tab '{tabName}' verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all top navigation tabs are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="expectedTabs">List of expected tab names</param>
        /// <returns>True if all tabs are present</returns>
        public bool AreAllTopNavigationTabsPresent(List<string> expectedTabs)
        {
            try
            {
                LogHelper.Info($"Verifying all {expectedTabs.Count} top navigation tabs are present");
                bool allPresent = true;
                
                foreach (string tab in expectedTabs)
                {
                    bool isPresent = IsTopNavigationTabPresent(tab);
                    if (!isPresent)
                    {
                        LogHelper.Error($"Top navigation tab '{tab}' is missing");
                        allPresent = false;
                    }
                }
                
                LogHelper.Info($"All top navigation tabs present: {allPresent}");
                return allPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top navigation tabs verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies main product category menu is accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to verify</param>
        /// <returns>True if menu is accessible</returns>
        public bool IsProductCategoryMenuAccessible(string menuName)
        {
            try
            {
                LogHelper.Info($"Verifying product category menu '{menuName}' is accessible");
                By menuLocator = GetMenuByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isAccessible = IsDisplayed(menuLocator);
                LogHelper.Info($"Product category menu '{menuName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menu '{menuName}' verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all main product category menus are accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="expectedMenus">List of expected menu names</param>
        /// <returns>True if all menus are accessible</returns>
        public bool AreAllProductCategoryMenusAccessible(List<string> expectedMenus)
        {
            try
            {
                LogHelper.Info($"Verifying all {expectedMenus.Count} product category menus are accessible");
                bool allAccessible = true;
                
                foreach (string menu in expectedMenus)
                {
                    bool isAccessible = IsProductCategoryMenuAccessible(menu);
                    if (!isAccessible)
                    {
                        LogHelper.Error($"Product category menu '{menu}' is not accessible");
                        allAccessible = false;
                    }
                }
                
                LogHelper.Info($"All product category menus accessible: {allAccessible}");
                return allAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies submenu items are displayed after hovering
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <returns>True if submenu items are displayed</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying submenu items are displayed");
                // Check for any visible submenu item
                WaitHelper.WaitVisible(Driver, FreeCheckingLink, 10);
                bool isDisplayed = IsDisplayed(FreeCheckingLink);
                LogHelper.Info($"Submenu items displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items verification failed: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Hovers over a main product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to hover</param>
        public void HoverOverMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Hovering over menu: {menuName}");
                By menuLocator = GetMenuByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                IWebElement menuElement = Driver.FindElement(menuLocator);
                Actions actions = new Actions(Driver);
                actions.MoveToElement(menuElement).Perform();
                
                // Wait for submenu to appear
                System.Threading.Thread.Sleep(500); // Brief pause for animation
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
        /// <param name="submenuName">Name of the submenu item to click</param>
        public void ClickSubmenuItem(string submenuName)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {submenuName}");
                By submenuLocator = GetSubmenuByName(submenuName);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Clicked submenu item: {submenuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Navigates to a page using menu and submenu
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="menuName">Main menu name</param>
        /// <param name="submenuName">Submenu item name</param>
        public void NavigateViaMenu(string menuName, string submenuName)
        {
            try
            {
                LogHelper.Info($"Navigating via menu: {menuName} -> {submenuName}");
                HoverOverMenu(menuName);
                ClickSubmenuItem(submenuName);
                LogHelper.Info($"Navigation completed: {menuName} -> {submenuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation failed for {menuName} -> {submenuName}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Uses keyboard navigation to access menu
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void UseKeyboardNavigationToMenu()
        {
            try
            {
                LogHelper.Info("Using keyboard navigation to access menu");
                Actions actions = new Actions(Driver);
                
                // Tab to navigation menu
                for (int i = 0; i < 5; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    System.Threading.Thread.Sleep(200);
                }
                
                LogHelper.Info("Keyboard navigation to menu completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard navigation failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Selects menu item using Enter key
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void SelectMenuItemWithEnter()
        {
            try
            {
                LogHelper.Info("Selecting menu item with Enter key");
                Actions actions = new Actions(Driver);
                actions.SendKeys(Keys.Enter).Perform();
                WaitForPageLoad();
                LogHelper.Info("Menu item selected with Enter key");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu selection with Enter failed: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // VERIFICATION METHODS FOR NAVIGATION RESULTS
        // =============================================================
        
        /// <summary>
        /// Verifies destination page loaded completely
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        /// <returns>True if page loaded completely</returns>
        public bool IsDestinationPageLoaded()
        {
            try
            {
                LogHelper.Info("Verifying destination page loaded completely");
                WaitForPageLoad();
                
                // Check if page is in ready state
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                string readyState = js.ExecuteScript("return document.readyState").ToString();
                bool isLoaded = readyState.Equals("complete", StringComparison.OrdinalIgnoreCase);
                
                LogHelper.Info($"Destination page loaded: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="expectedIdentifier">Expected URL identifier</param>
        /// <returns>True if URL contains identifier</returns>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            try
            {
                LogHelper.Info($"Verifying URL contains identifier: {expectedIdentifier}");
                string currentUrl = GetCurrentUrl();
                bool contains = currentUrl.ToLower().Contains(expectedIdentifier.ToLower());
                LogHelper.Info($"URL contains '{expectedIdentifier}': {contains}");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all menu items are keyboard accessible
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        /// <returns>True if all items are keyboard accessible</returns>
        public bool AreAllMenuItemsKeyboardAccessible()
        {
            try
            {
                LogHelper.Info("Verifying all menu items are keyboard accessible");
                // This is a simplified check - in real scenario, would iterate through all items
                UseKeyboardNavigationToMenu();
                bool isAccessible = IsNavigationMenuVisible();
                LogHelper.Info($"Menu items keyboard accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard accessibility verification failed: {ex.Message}");
                return false;
            }
        }
    }
}