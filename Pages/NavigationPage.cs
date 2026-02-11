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
    /// Test Cases: TASK0020445 TS-002 through TS-007, TS-012
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
        private By GetMenuItemByText(string menuText) => 
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuText}']");
        
        private By GetSubmenuItemByText(string submenuText) => 
            By.XPath($"//a[normalize-space()='{submenuText}']");
        
        private By GetTopTabByText(string tabText) => 
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabText}']");

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
                LogHelper.Info("Checking if global navigation menu is visible");
                WaitHelper.WaitVisible(Driver, MenuContainer, 15);
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
        /// Verifies specific top navigation tab is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsTopTabPresent(string tabName)
        {
            try
            {
                LogHelper.Info($"Checking if '{tabName}' tab is present");
                By tabLocator = GetTopTabByText(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isPresent = IsDisplayed(tabLocator);
                LogHelper.Info($"'{tabName}' tab present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"'{tabName}' tab not present: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies all specified top tabs are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool AreAllTopTabsPresent(List<string> tabNames)
        {
            LogHelper.Info($"Verifying {tabNames.Count} top navigation tabs are present");
            bool allPresent = true;
            
            foreach (string tabName in tabNames)
            {
                if (!IsTopTabPresent(tabName))
                {
                    allPresent = false;
                    LogHelper.Error($"Tab '{tabName}' is missing");
                }
            }
            
            LogHelper.Info($"All top tabs present: {allPresent}");
            return allPresent;
        }
        
        /// <summary>
        /// Verifies main product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryDisplayed(string categoryName)
        {
            try
            {
                LogHelper.Info($"Checking if '{categoryName}' product category is displayed");
                By categoryLocator = GetMenuItemByText(categoryName);
                WaitHelper.WaitVisible(Driver, categoryLocator, 10);
                bool isDisplayed = IsDisplayed(categoryLocator);
                LogHelper.Info($"'{categoryName}' category displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"'{categoryName}' category not displayed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies all product categories are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool AreAllProductCategoriesDisplayed(List<string> categories)
        {
            LogHelper.Info($"Verifying {categories.Count} product categories are displayed");
            bool allDisplayed = true;
            
            foreach (string category in categories)
            {
                if (!IsProductCategoryDisplayed(category))
                {
                    allDisplayed = false;
                    LogHelper.Error($"Category '{category}' is not displayed");
                }
            }
            
            LogHelper.Info($"All product categories displayed: {allDisplayed}");
            return allDisplayed;
        }
        
        /// <summary>
        /// Verifies product category menu is accessible (clickable)
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryAccessible(string categoryName)
        {
            try
            {
                LogHelper.Info($"Checking if '{categoryName}' is accessible");
                By categoryLocator = GetMenuItemByText(categoryName);
                WaitHelper.WaitClickable(Driver, categoryLocator, 10);
                bool isAccessible = Driver.FindElement(categoryLocator).Enabled;
                LogHelper.Info($"'{categoryName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"'{categoryName}' not accessible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                LogHelper.Info("Checking if submenu items are displayed");
                // Wait for any submenu item to be visible
                WaitHelper.WaitVisible(Driver, By.CssSelector("[class*='submenu'], [class*='dropdown']"), 10);
                bool displayed = Driver.FindElements(By.CssSelector("[class*='submenu'] a, [class*='dropdown'] a")).Count > 0;
                LogHelper.Info($"Submenu items displayed: {displayed}");
                return displayed;
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
        /// Hovers over a main product menu
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001
        /// </summary>
        public void HoverOverMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Hovering over '{menuName}' menu");
                By menuLocator = GetMenuItemByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                Actions actions = new Actions(Driver);
                IWebElement menuElement = Driver.FindElement(menuLocator);
                actions.MoveToElement(menuElement).Perform();
                
                // Wait for submenu to appear
                System.Threading.Thread.Sleep(500); // Small wait for animation
                LogHelper.Info($"Hovered over '{menuName}' menu successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to hover over '{menuName}' menu: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Clicks a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void ClickSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item '{submenuItemName}'");
                By submenuLocator = GetSubmenuItemByText(submenuItemName);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Clicked submenu item '{submenuItemName}' successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItemName}': {ex.Message}");
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
                    
                    // Check if we've reached the menu
                    IWebElement activeElement = Driver.SwitchTo().ActiveElement();
                    if (activeElement.GetAttribute("class").Contains("nav") || 
                        activeElement.GetAttribute("class").Contains("menu"))
                    {
                        LogHelper.Info("Reached navigation menu via keyboard");
                        break;
                    }
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
        /// Presses Enter key on focused element
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void PressEnterOnFocusedElement()
        {
            try
            {
                LogHelper.Info("Pressing Enter on focused element");
                Actions actions = new Actions(Driver);
                actions.SendKeys(Keys.Enter).Perform();
                WaitForPageLoad();
                LogHelper.Info("Enter key pressed successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to press Enter: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Verifies menu item responds to keyboard selection
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public bool DoesMenuRespondToKeyboard()
        {
            try
            {
                LogHelper.Info("Verifying menu responds to keyboard");
                string urlBefore = Driver.Url;
                PressEnterOnFocusedElement();
                System.Threading.Thread.Sleep(1000);
                string urlAfter = Driver.Url;
                
                bool responded = !urlBefore.Equals(urlAfter);
                LogHelper.Info($"Menu responded to keyboard: {responded}");
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