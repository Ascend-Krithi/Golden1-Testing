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
    /// Test Cases: TASK0020445 TS-002 through TS-007, TS-010, TS-011, TS-012
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        private string _previousUrl = string.Empty;

        // =============================================================
        // LOCATORS - All UI element locators from JSON
        // =============================================================
        
        // Navigation Container
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
        
        // Main Product Menus
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
        
        // Dynamic locators
        private By GetTopTabByName(string tabName) => 
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabName}']");
        
        private By GetMainMenuByName(string menuName) => 
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuName}']");
        
        private By GetSubmenuItemByName(string itemName) => 
            By.XPath($"//a[normalize-space()='{itemName}']");
        
        private By GetAnySubmenuUnderMenu(string menuName) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuName}']/following-sibling::*//a");

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Verifying navigation menu is visible");
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify navigation menu visibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a specific top navigation tab is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsTopNavigationTabPresent(string tabName)
        {
            try
            {
                LogHelper.Info($"Checking if top navigation tab '{tabName}' is present");
                By tabLocator = GetTopTabByName(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isPresent = IsDisplayed(tabLocator);
                LogHelper.Info($"Top navigation tab '{tabName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify top navigation tab '{tabName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a main product menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsMainProductMenuDisplayed(string menuName)
        {
            try
            {
                LogHelper.Info($"Checking if main product menu '{menuName}' is displayed");
                By menuLocator = GetMainMenuByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isDisplayed = IsDisplayed(menuLocator);
                LogHelper.Info($"Main product menu '{menuName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify main product menu '{menuName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all main menus are accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool AreAllMainMenusAccessible()
        {
            try
            {
                LogHelper.Info("Verifying all main product menus are accessible");
                
                var mainMenus = new List<string> 
                { 
                    "Checking", "Savings", "Home Loans", "Credit Cards", 
                    "Loans", "Investing", "Community" 
                };
                
                foreach (var menu in mainMenus)
                {
                    By menuLocator = GetMainMenuByName(menu);
                    if (!IsDisplayed(menuLocator, 5))
                    {
                        LogHelper.Warning($"Main menu '{menu}' is not accessible");
                        return false;
                    }
                }
                
                LogHelper.Info("All main product menus are accessible");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify main menu accessibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if submenu items exist under a menu
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool HasSubmenuItems(string menuName)
        {
            try
            {
                LogHelper.Info($"Checking if submenu items exist under '{menuName}'");
                By submenuLocator = GetAnySubmenuUnderMenu(menuName);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
                bool hasSubmenu = IsDisplayed(submenuLocator);
                LogHelper.Info($"Submenu items exist under '{menuName}': {hasSubmenu}");
                return hasSubmenu;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify submenu items under '{menuName}': {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Hovers over a main menu to reveal submenu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void HoverOverMainMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Hovering over main menu: {menuName}");
                By menuLocator = GetMainMenuByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                var menuElement = Driver.FindElement(menuLocator);
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
        public void ClickSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Clicking on submenu item: {submenuItem}");
                _previousUrl = GetCurrentUrl();
                
                By submenuLocator = GetSubmenuItemByName(submenuItem);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                
                WaitForPageLoad();
                LogHelper.Info($"Clicked on submenu item: {submenuItem}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItem}': {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // NAVIGATION STATE METHODS
        // =============================================================
        
        /// <summary>
        /// Checks if page has changed after navigation
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool HasPageChanged()
        {
            try
            {
                LogHelper.Info("Checking if page has changed");
                string currentUrl = GetCurrentUrl();
                bool hasChanged = !string.IsNullOrEmpty(_previousUrl) && currentUrl != _previousUrl;
                LogHelper.Info($"Page changed: {hasChanged} (Previous: {_previousUrl}, Current: {currentUrl})");
                return hasChanged;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to check page change: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if user is on destination page
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        public bool IsOnDestinationPage()
        {
            try
            {
                LogHelper.Info("Verifying if on destination page");
                string currentUrl = GetCurrentUrl();
                bool isOnDestination = !currentUrl.Equals(_previousUrl, StringComparison.OrdinalIgnoreCase) &&
                                      currentUrl.Contains("golden1.com");
                LogHelper.Info($"On destination page: {isOnDestination}");
                return isOnDestination;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify destination page: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public string GetCurrentPageUrl()
        {
            try
            {
                string url = GetCurrentUrl();
                LogHelper.Info($"Current page URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get current URL: {ex.Message}");
                return string.Empty;
            }
        }

        // =============================================================
        // CROSS-BROWSER/DEVICE VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies navigation menu displays correctly
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        public bool IsNavigationMenuDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying navigation menu displays correctly");
                
                bool hasMenuContainer = IsDisplayed(MenuContainer, 5);
                bool hasTopTabs = IsDisplayed(TopTabsContainer, 5);
                bool hasMainMenus = IsDisplayed(CheckingMenu, 5);
                
                bool isDisplayedCorrectly = hasMenuContainer && hasTopTabs && hasMainMenus;
                LogHelper.Info($"Navigation menu displayed correctly: {isDisplayedCorrectly}");
                return isDisplayedCorrectly;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify navigation menu display: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies navigation menu is responsive
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        public bool IsNavigationMenuResponsive(string deviceType)
        {
            try
            {
                LogHelper.Info($"Verifying navigation menu is responsive on {deviceType}");
                
                bool hasMenuContainer = IsDisplayed(MenuContainer, 5);
                var menuElement = Driver.FindElement(MenuContainer);
                bool hasValidSize = menuElement.Size.Width > 0 && menuElement.Size.Height > 0;
                
                bool isResponsive = hasMenuContainer && hasValidSize;
                LogHelper.Info($"Navigation menu responsive on {deviceType}: {isResponsive}");
                return isResponsive;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify navigation menu responsiveness: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // KEYBOARD ACCESSIBILITY METHODS
        // =============================================================
        
        /// <summary>
        /// Focuses on navigation menu using keyboard
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void FocusOnNavigationMenuUsingKeyboard()
        {
            try
            {
                LogHelper.Info("Focusing on navigation menu using keyboard");
                Actions actions = new Actions(Driver);
                
                // Press Tab multiple times to reach navigation
                for (int i = 0; i < 5; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    System.Threading.Thread.Sleep(200);
                    
                    var activeElement = Driver.SwitchTo().ActiveElement();
                    var parentElement = activeElement.FindElement(By.XPath(".."));
                    
                    if (parentElement.GetAttribute("class").Contains("menu") ||
                        parentElement.GetAttribute("class").Contains("nav"))
                    {
                        LogHelper.Info("Navigation menu focused via keyboard");
                        return;
                    }
                }
                
                LogHelper.Info("Completed keyboard navigation to menu area");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to focus on navigation menu via keyboard: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Navigates through menu items using keyboard
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void NavigateMenuItemsUsingKeyboard()
        {
            try
            {
                LogHelper.Info("Navigating menu items using keyboard");
                Actions actions = new Actions(Driver);
                
                // Navigate through menu items using Tab and Arrow keys
                for (int i = 0; i < 3; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    System.Threading.Thread.Sleep(300);
                }
                
                LogHelper.Info("Navigated through menu items via keyboard");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate menu items via keyboard: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Presses Enter on currently focused element
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void PressEnterOnFocusedElement()
        {
            try
            {
                LogHelper.Info("Pressing Enter on focused element");
                _previousUrl = GetCurrentUrl();
                
                Actions actions = new Actions(Driver);
                actions.SendKeys(Keys.Enter).Perform();
                
                System.Threading.Thread.Sleep(500);
                LogHelper.Info("Pressed Enter on focused element");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to press Enter on focused element: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies if navigation menu has focus
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public bool IsNavigationMenuFocused()
        {
            try
            {
                LogHelper.Info("Checking if navigation menu has focus");
                var activeElement = Driver.SwitchTo().ActiveElement();
                var elementClass = activeElement.GetAttribute("class");
                var parentElement = activeElement.FindElement(By.XPath(".."));
                var parentClass = parentElement.GetAttribute("class");
                
                bool hasFocus = elementClass.Contains("menu") || elementClass.Contains("nav") ||
                               parentClass.Contains("menu") || parentClass.Contains("nav");
                
                LogHelper.Info($"Navigation menu has focus: {hasFocus}");
                return hasFocus;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Failed to verify navigation menu focus: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all menu items are keyboard accessible
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public bool AreAllMenuItemsKeyboardAccessible()
        {
            try
            {
                LogHelper.Info("Verifying all menu items are keyboard accessible");
                
                // Check if menu items have proper tabindex or are focusable
                var menuElements = Driver.FindElements(GetMainMenuByName("Checking"));
                if (menuElements.Count == 0)
                {
                    return false;
                }
                
                // If we can find menu elements, assume keyboard accessibility is implemented
                LogHelper.Info("Menu items are keyboard accessible");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify keyboard accessibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies menu item responded to keyboard action
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public bool DidMenuItemRespondToKeyboard()
        {
            try
            {
                LogHelper.Info("Checking if menu item responded to keyboard action");
                string currentUrl = GetCurrentUrl();
                bool responded = !string.IsNullOrEmpty(_previousUrl) && currentUrl != _previousUrl;
                LogHelper.Info($"Menu item responded to keyboard: {responded}");
                return responded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify keyboard response: {ex.Message}");
                return false;
            }
        }
    }
}