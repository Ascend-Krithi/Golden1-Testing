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
    /// Test Cases: TASK0020445 TS-002 to TS-007, TS-010 to TS-012
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

        // Submenu Links
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
        /// Verifies if the global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
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
                LogHelper.Info($"Tab '{tabName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Tab '{tabName}' not present: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all specified top navigation tabs are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool AreAllTopNavigationTabsPresent(List<string> tabNames)
        {
            try
            {
                LogHelper.Info("Verifying all top navigation tabs are present");
                bool allPresent = true;

                foreach (string tabName in tabNames)
                {
                    bool isPresent = IsTopNavigationTabPresent(tabName);
                    if (!isPresent)
                    {
                        allPresent = false;
                        LogHelper.Warning($"Tab '{tabName}' is missing");
                    }
                }

                LogHelper.Info($"All top navigation tabs present: {allPresent}");
                return allPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying top navigation tabs: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a main product category menu is displayed
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
                LogHelper.Info($"Menu '{menuName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu '{menuName}' not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all main product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool AreAllMainProductMenusDisplayed(List<string> menuNames)
        {
            try
            {
                LogHelper.Info("Verifying all main product category menus are displayed");
                bool allDisplayed = true;

                foreach (string menuName in menuNames)
                {
                    bool isDisplayed = IsMainProductMenuDisplayed(menuName);
                    if (!isDisplayed)
                    {
                        allDisplayed = false;
                        LogHelper.Warning($"Menu '{menuName}' is not displayed");
                    }
                }

                LogHelper.Info($"All main product menus displayed: {allDisplayed}");
                return allDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying main product menus: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a main menu is accessible (clickable)
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsMainMenuAccessible(string menuName)
        {
            try
            {
                LogHelper.Info($"Checking if menu '{menuName}' is accessible");
                By menuLocator = GetMainMenuByName(menuName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                bool isAccessible = Driver.FindElement(menuLocator).Enabled;
                LogHelper.Info($"Menu '{menuName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu '{menuName}' not accessible: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        /// <summary>
        /// Hovers over a main product menu to display submenu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001
        /// </summary>
        public void HoverOverMainMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Hovering over main menu '{menuName}'");
                By menuLocator = GetMainMenuByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                IWebElement menuElement = Driver.FindElement(menuLocator);
                Actions actions = new Actions(Driver);
                actions.MoveToElement(menuElement).Perform();
                
                // Wait for submenu to appear
                System.Threading.Thread.Sleep(500); // Small delay for animation
                
                LogHelper.Info($"Hovered over menu '{menuName}'");
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
        public void ClickSubmenuItem(string itemName)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item '{itemName}'");
                By itemLocator = GetSubmenuItemByName(itemName);
                WaitHelper.WaitClickable(Driver, itemLocator, 10);
                Click(itemLocator);
                WaitForPageLoad();
                LogHelper.Info($"Clicked submenu item '{itemName}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{itemName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies if submenu items are displayed under a main menu
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool AreSubmenuItemsDisplayed(string menuName)
        {
            try
            {
                LogHelper.Info($"Checking if submenu items are displayed under '{menuName}'");
                
                // After hovering, check if any submenu items are visible
                var submenuItems = Driver.FindElements(By.CssSelector("a[class*='submenu'], .submenu a, [class*='dropdown'] a"));
                bool hasSubmenuItems = submenuItems.Count > 0 && submenuItems.Any(item => item.Displayed);
                
                LogHelper.Info($"Submenu items displayed under '{menuName}': {hasSubmenuItems}");
                return hasSubmenuItems;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking submenu items: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a submenu item responds to click
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool DoesSubmenuItemRespondToClick(string itemName)
        {
            try
            {
                LogHelper.Info($"Verifying if submenu item '{itemName}' responds to click");
                string currentUrl = GetCurrentUrl();
                ClickSubmenuItem(itemName);
                System.Threading.Thread.Sleep(1000); // Wait for navigation
                string newUrl = GetCurrentUrl();
                
                bool responded = !currentUrl.Equals(newUrl);
                LogHelper.Info($"Submenu item '{itemName}' responded to click: {responded}");
                return responded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item '{itemName}' did not respond: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // NAVIGATION VERIFICATION METHODS
        // =============================================================
        /// <summary>
        /// Verifies if user is redirected to destination page
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        public bool IsRedirectedToDestinationPage()
        {
            try
            {
                LogHelper.Info("Verifying redirection to destination page");
                WaitForPageLoad();
                string currentUrl = GetCurrentUrl();
                bool isRedirected = !currentUrl.Equals(ConfigReader.BaseUrl) && !currentUrl.EndsWith("/");
                LogHelper.Info($"Redirected to destination page: {isRedirected}, URL: {currentUrl}");
                return isRedirected;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying redirection: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if destination page loads completely
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        public bool IsDestinationPageLoadedCompletely()
        {
            try
            {
                LogHelper.Info("Verifying destination page loaded completely");
                WaitForPageLoad();
                
                // Check if page has main content
                By mainContent = By.CssSelector("main, #main-content, .main-content, article");
                WaitHelper.WaitVisible(Driver, mainContent, 15);
                
                bool isLoaded = IsDisplayed(mainContent);
                LogHelper.Info($"Destination page loaded completely: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page not loaded: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if URL contains expected page identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            try
            {
                LogHelper.Info($"Checking if URL contains identifier '{expectedIdentifier}'");
                string currentUrl = GetCurrentUrl().ToLower();
                bool contains = currentUrl.Contains(expectedIdentifier.ToLower());
                LogHelper.Info($"URL contains '{expectedIdentifier}': {contains}, Current URL: {currentUrl}");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking URL identifier: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // KEYBOARD NAVIGATION METHODS
        // =============================================================
        /// <summary>
        /// Navigates to navigation menu using keyboard
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void NavigateToMenuUsingKeyboard()
        {
            try
            {
                LogHelper.Info("Navigating to menu using keyboard");
                Actions actions = new Actions(Driver);
                
                // Tab to navigation menu
                for (int i = 0; i < 5; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    System.Threading.Thread.Sleep(200);
                    
                    // Check if we've reached the menu
                    var activeElement = Driver.SwitchTo().ActiveElement();
                    if (activeElement.GetAttribute("class").Contains("nav") || 
                        activeElement.GetAttribute("class").Contains("menu"))
                    {
                        LogHelper.Info("Reached navigation menu via keyboard");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate using keyboard: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies if menu items are accessible via keyboard
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public bool AreMenuItemsAccessibleViaKeyboard()
        {
            try
            {
                LogHelper.Info("Verifying menu items are accessible via keyboard");
                Actions actions = new Actions(Driver);
                
                // Try to navigate through menu items
                for (int i = 0; i < 3; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    System.Threading.Thread.Sleep(200);
                }
                
                var activeElement = Driver.SwitchTo().ActiveElement();
                bool isAccessible = activeElement != null && activeElement.Displayed;
                
                LogHelper.Info($"Menu items accessible via keyboard: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu items not accessible via keyboard: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Selects menu item by pressing Enter
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
                LogHelper.Error($"Failed to select menu item with Enter: {ex.Message}");
                throw;
            }
        }
    }
}