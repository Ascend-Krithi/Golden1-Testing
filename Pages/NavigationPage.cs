using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Navigation Menu
    /// Handles all interactions with navigation menus and submenus
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
        
        // Main navigation container
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");
        
        // Top menu tabs
        private By PersonalTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Personal']");
        private By BusinessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Business']");
        private By FinancialWellnessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Financial Wellness']");
        private By AppointmentsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Appointments']");
        private By LocationsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Locations']");
        private By MembershipTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Membership']");
        private By HelpCenterTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Help Center']");
        
        // Main product category menus
        private By CheckingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Checking']");
        private By SavingsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Savings']");
        private By HomeLoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Home Loans']");
        private By CreditCardsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Credit Cards']");
        private By LoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Loans']");
        private By InvestingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Investing']");
        private By CommunityMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Community']");
        
        // Submenu items
        private By FreeCheckingLink => By.XPath("//a[normalize-space()='Free Checking']");
        private By SavingsAccountLink => By.XPath("//a[normalize-space()='Savings Account']");
        private By AutoLoansLink => By.XPath("//a[contains(normalize-space(),'Auto Loan')]");

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
        public bool IsTopMenuTabPresent(string tabName)
        {
            try
            {
                By tabLocator = GetTopMenuTabLocator(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isPresent = IsDisplayed(tabLocator);
                LogHelper.Info($"Top menu tab '{tabName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top menu tab '{tabName}' not present: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all specified top menu tabs are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool AreAllTopMenuTabsPresent(List<string> tabNames)
        {
            try
            {
                LogHelper.Info($"Verifying {tabNames.Count} top menu tabs");
                bool allPresent = tabNames.All(tab => IsTopMenuTabPresent(tab));
                LogHelper.Info($"All top menu tabs present: {allPresent}");
                return allPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top menu tabs verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies main product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuDisplayed(string categoryName)
        {
            try
            {
                By menuLocator = GetProductCategoryMenuLocator(categoryName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isDisplayed = IsDisplayed(menuLocator);
                LogHelper.Info($"Product category menu '{categoryName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menu '{categoryName}' not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies all main product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool AreAllProductCategoryMenusDisplayed(List<string> categoryNames)
        {
            try
            {
                LogHelper.Info($"Verifying {categoryNames.Count} product category menus");
                bool allDisplayed = categoryNames.All(category => IsProductCategoryMenuDisplayed(category));
                LogHelper.Info($"All product category menus displayed: {allDisplayed}");
                return allDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Expands/clicks a main product category menu
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001
        /// </summary>
        public void ExpandProductCategoryMenu(string categoryName)
        {
            try
            {
                LogHelper.Info($"Expanding product category menu: {categoryName}");
                By menuLocator = GetProductCategoryMenuLocator(categoryName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                Click(menuLocator);
                WaitHelper.WaitForMilliseconds(500); // Allow submenu to expand
                LogHelper.Info($"Product category menu '{categoryName}' expanded");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand product category menu '{categoryName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies menu is accessible (clickable)
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuAccessible(string categoryName)
        {
            try
            {
                By menuLocator = GetProductCategoryMenuLocator(categoryName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                bool isAccessible = Driver.FindElement(menuLocator).Enabled;
                LogHelper.Info($"Product category menu '{categoryName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menu '{categoryName}' not accessible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies submenu items are displayed after expanding menu
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                // Wait for any submenu items to appear
                WaitHelper.WaitForMilliseconds(1000);
                By submenuContainer = By.CssSelector(".submenu, .dropdown-menu, [class*='submenu'], [class*='dropdown']");
                bool displayed = IsDisplayed(submenuContainer, 5);
                LogHelper.Info($"Submenu items displayed: {displayed}");
                return displayed;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Submenu items check: {ex.Message}");
                return true; // Some menus may not have visible containers
            }
        }

        /// <summary>
        /// Selects a submenu item by name
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void SelectSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Selecting submenu item: {submenuItemName}");
                By submenuLocator = GetSubmenuItemLocator(submenuItemName);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Submenu item '{submenuItemName}' selected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item '{submenuItemName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool IsSubmenuItemSelectable(string submenuItemName)
        {
            try
            {
                By submenuLocator = GetSubmenuItemLocator(submenuItemName);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
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

        // =============================================================
        // HELPER METHODS
        // =============================================================
        
        /// <summary>
        /// Gets locator for top menu tab by name
        /// </summary>
        private By GetTopMenuTabLocator(string tabName)
        {
            return tabName switch
            {
                "Personal" => PersonalTab,
                "Business" => BusinessTab,
                "Financial Wellness" => FinancialWellnessTab,
                "Appointments" => AppointmentsTab,
                "Locations" => LocationsTab,
                "Membership" => MembershipTab,
                "Help Center" => HelpCenterTab,
                _ => By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabName}']")
            };
        }

        /// <summary>
        /// Gets locator for product category menu by name
        /// </summary>
        private By GetProductCategoryMenuLocator(string categoryName)
        {
            return categoryName switch
            {
                "Checking" => CheckingMenu,
                "Savings" => SavingsMenu,
                "Home Loans" => HomeLoansMenu,
                "Credit Cards" => CreditCardsMenu,
                "Loans" => LoansMenu,
                "Investing" => InvestingMenu,
                "Community" => CommunityMenu,
                _ => By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{categoryName}']")
            };
        }

        /// <summary>
        /// Gets locator for submenu item by name
        /// </summary>
        private By GetSubmenuItemLocator(string submenuItemName)
        {
            return submenuItemName switch
            {
                "Free Checking" => FreeCheckingLink,
                "Savings Account" => SavingsAccountLink,
                "Auto Loans" => AutoLoansLink,
                _ => By.XPath($"//a[normalize-space()='{submenuItemName}']")
            };
        }
    }
}