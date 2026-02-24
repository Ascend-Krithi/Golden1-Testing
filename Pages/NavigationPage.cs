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
    /// Test Cases: TASK0020445 TS-002 through TS-007
    /// </summary>
    public class NavigationPage : BasePage
    {
        // Constructor
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS
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

        // SECTION 2: PAGE ACTIONS
        
        /// <summary>
        /// Clicks on a main product menu by name
        /// Test Cases: TASK0020445 TS-004 TC-001, TASK0020445 TS-005 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to click</param>
        public void ClickProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Clicking on {menuName} menu");
                By menuLocator = GetProductMenuLocator(menuName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                Click(menuLocator);
                LogHelper.Info($"Successfully clicked {menuName} menu");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click {menuName} menu: {ex.Message}");
                throw new Exception($"Failed to click product menu: {menuName}", ex);
            }
        }

        /// <summary>
        /// Selects a submenu item by name
        /// Test Cases: TASK0020445 TS-005 TC-001, TASK0020445 TS-006 TC-001
        /// </summary>
        /// <param name="submenuName">Name of the submenu item to select</param>
        public void SelectSubmenuItem(string submenuName)
        {
            try
            {
                LogHelper.Info($"Selecting submenu item: {submenuName}");
                By submenuLocator = GetSubmenuLocator(submenuName);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Successfully selected submenu item: {submenuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item {submenuName}: {ex.Message}");
                throw new Exception($"Failed to select submenu item: {submenuName}", ex);
            }
        }

        /// <summary>
        /// Clicks on a top menu tab by name
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="tabName">Name of the tab to click</param>
        public void ClickTopMenuTab(string tabName)
        {
            try
            {
                LogHelper.Info($"Clicking on top menu tab: {tabName}");
                By tabLocator = GetTopMenuTabLocator(tabName);
                WaitHelper.WaitClickable(Driver, tabLocator, 10);
                Click(tabLocator);
                LogHelper.Info($"Successfully clicked top menu tab: {tabName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click top menu tab {tabName}: {ex.Message}");
                throw new Exception($"Failed to click top menu tab: {tabName}", ex);
            }
        }

        // SECTION 3: VERIFICATIONS
        
        /// <summary>
        /// Verifies if the global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        /// <returns>True if menu is visible, false otherwise</returns>
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Checking if navigation menu is visible");
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
        /// Verifies if a specific top menu option is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="menuOption">Name of the menu option</param>
        /// <returns>True if menu option is present, false otherwise</returns>
        public bool IsTopMenuOptionPresent(string menuOption)
        {
            try
            {
                LogHelper.Info($"Checking if top menu option '{menuOption}' is present");
                By menuLocator = GetTopMenuTabLocator(menuOption);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isPresent = IsDisplayed(menuLocator);
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
        /// Verifies if a specific product menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="productMenu">Name of the product menu</param>
        /// <returns>True if product menu is displayed, false otherwise</returns>
        public bool IsProductMenuDisplayed(string productMenu)
        {
            try
            {
                LogHelper.Info($"Checking if product menu '{productMenu}' is displayed");
                By menuLocator = GetProductMenuLocator(productMenu);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isDisplayed = IsDisplayed(menuLocator);
                LogHelper.Info($"Product menu '{productMenu}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu '{productMenu}' not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a product menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="productMenu">Name of the product menu</param>
        /// <returns>True if menu is clickable, false otherwise</returns>
        public bool IsProductMenuClickable(string productMenu)
        {
            try
            {
                LogHelper.Info($"Checking if product menu '{productMenu}' is clickable");
                By menuLocator = GetProductMenuLocator(productMenu);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                bool isClickable = IsEnabled(menuLocator);
                LogHelper.Info($"Product menu '{productMenu}' clickable: {isClickable}");
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu '{productMenu}' not clickable: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if submenu is displayed after clicking product menu
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <returns>True if submenu is displayed, false otherwise</returns>
        public bool IsSubmenuDisplayed()
        {
            try
            {
                LogHelper.Info("Checking if submenu is displayed");
                // Wait for any submenu link to be visible
                WaitHelper.WaitVisible(Driver, By.CssSelector(".submenu, .dropdown-menu, [class*='submenu']"), 5);
                bool isDisplayed = Driver.FindElements(By.CssSelector("a[href*='/'], .submenu a")).Count > 0;
                LogHelper.Info($"Submenu displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Submenu check: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the destination page URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="urlIdentifier">Expected URL identifier</param>
        /// <returns>True if URL contains identifier, false otherwise</returns>
        public bool DoesUrlContainIdentifier(string urlIdentifier)
        {
            try
            {
                string currentUrl = Driver.Url.ToLower();
                bool contains = currentUrl.Contains(urlIdentifier.ToLower());
                LogHelper.Info($"URL '{currentUrl}' contains '{urlIdentifier}': {contains}");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to check URL identifier: {ex.Message}");
                return false;
            }
        }

        // SECTION 4: HELPER METHODS
        
        /// <summary>
        /// Gets the locator for a product menu by name
        /// </summary>
        /// <param name="menuName">Name of the product menu</param>
        /// <returns>By locator for the menu</returns>
        private By GetProductMenuLocator(string menuName)
        {
            return menuName.ToLower() switch
            {
                "checking" => CheckingMenu,
                "savings" => SavingsMenu,
                "home loans" => HomeLoansMenu,
                "credit cards" => CreditCardsMenu,
                "loans" => LoansMenu,
                "investing" => InvestingMenu,
                "community" => CommunityMenu,
                _ => throw new ArgumentException($"Unknown product menu: {menuName}")
            };
        }

        /// <summary>
        /// Gets the locator for a submenu item by name
        /// </summary>
        /// <param name="submenuName">Name of the submenu item</param>
        /// <returns>By locator for the submenu item</returns>
        private By GetSubmenuLocator(string submenuName)
        {
            return submenuName.ToLower() switch
            {
                "free checking" => FreeCheckingLink,
                "savings account" => SavingsAccountLink,
                "auto loan" or "auto loans" => AutoLoansLink,
                _ => By.XPath($"//a[normalize-space()='{submenuName}']") // Generic fallback
            };
        }

        /// <summary>
        /// Gets the locator for a top menu tab by name
        /// </summary>
        /// <param name="tabName">Name of the top menu tab</param>
        /// <returns>By locator for the tab</returns>
        private By GetTopMenuTabLocator(string tabName)
        {
            return tabName.ToLower() switch
            {
                "personal" => PersonalTab,
                "business" => BusinessTab,
                "financial wellness" => FinancialWellnessTab,
                "appointments" => AppointmentsTab,
                "locations" => LocationsTab,
                "membership" => MembershipTab,
                "help center" => HelpCenterTab,
                _ => throw new ArgumentException($"Unknown top menu tab: {tabName}")
            };
        }

        /// <summary>
        /// Gets all top menu options that are currently displayed
        /// </summary>
        /// <returns>List of menu option names</returns>
        public List<string> GetDisplayedTopMenuOptions()
        {
            try
            {
                LogHelper.Info("Getting all displayed top menu options");
                var menuOptions = new List<string>();
                var tabs = new Dictionary<string, By>
                {
                    { "Personal", PersonalTab },
                    { "Business", BusinessTab },
                    { "Financial Wellness", FinancialWellnessTab },
                    { "Appointments", AppointmentsTab },
                    { "Locations", LocationsTab },
                    { "Membership", MembershipTab },
                    { "Help Center", HelpCenterTab }
                };

                foreach (var tab in tabs)
                {
                    try
                    {
                        if (IsDisplayed(tab.Value))
                        {
                            menuOptions.Add(tab.Key);
                        }
                    }
                    catch
                    {
                        // Skip if element not found
                    }
                }

                LogHelper.Info($"Found {menuOptions.Count} top menu options");
                return menuOptions;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get top menu options: {ex.Message}");
                return new List<string>();
            }
        }
    }
}