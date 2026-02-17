using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Navigation
    /// Handles all interactions with the main navigation menu and top tabs
    /// Test Cases: TASK0020445 TS-001 through TS-011
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - Navigation Elements
        // =============================================================
        
        // Main Navigation Container
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");

        // Top Tab Menu Items
        private By PersonalTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Personal']");
        private By BusinessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Business']");
        private By FinancialWellnessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Financial Wellness']");
        private By AppointmentsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Appointments']");
        private By LocationsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Locations']");
        private By MembershipTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Membership']");
        private By HelpCenterTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Help Center']");

        // Product Category Menus
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

        // Overlay Elements
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // Dynamic Locators
        private By GetMenuItemByText(string menuText) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuText}']");

        private By GetSubmenuItemByText(string submenuText) =>
            By.XPath($"//a[normalize-space()='{submenuText}']");

        private By GetTopTabByText(string tabText) =>
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabText}']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================

        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001
        /// </summary>
        public void OpenHomepage()
        {
            LogHelper.Info("Opening Golden1 homepage");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            HandleCookieBanner();
            LogHelper.Info("Golden1 homepage loaded successfully");
        }

        /// <summary>
        /// Handles cookie consent banner if present
        /// </summary>
        private void HandleCookieBanner()
        {
            try
            {
                if (WaitHelper.WaitVisible(Driver, CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookie banner accepted and dismissed");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No cookie banner present or already dismissed: {ex.Message}");
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================

        /// <summary>
        /// Verifies if the navigation menu container is visible
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
        /// Verifies if a specific top tab menu option is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsTopTabMenuOptionPresent(string menuOption)
        {
            try
            {
                By locator = GetTopTabByText(menuOption);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isPresent = IsDisplayed(locator);
                LogHelper.Info($"Top tab menu option '{menuOption}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tab menu option '{menuOption}' not present: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all top tab menu options are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool AreAllTopTabMenuOptionsPresent(List<string> menuOptions)
        {
            LogHelper.Info("Verifying all top tab menu options are present");
            bool allPresent = true;

            foreach (string option in menuOptions)
            {
                if (!IsTopTabMenuOptionPresent(option))
                {
                    allPresent = false;
                    LogHelper.Error($"Top tab menu option '{option}' is missing");
                }
            }

            LogHelper.Info($"All top tab menu options present: {allPresent}");
            return allPresent;
        }

        /// <summary>
        /// Verifies if a product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuDisplayed(string categoryName)
        {
            try
            {
                By locator = GetMenuItemByText(categoryName);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isDisplayed = IsDisplayed(locator);
                LogHelper.Info($"Product category '{categoryName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category '{categoryName}' not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if all product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool AreAllProductCategoryMenusDisplayed(List<string> categories)
        {
            LogHelper.Info("Verifying all product category menus are displayed");
            bool allDisplayed = true;

            foreach (string category in categories)
            {
                if (!IsProductCategoryMenuDisplayed(category))
                {
                    allDisplayed = false;
                    LogHelper.Error($"Product category '{category}' is missing");
                }
            }

            LogHelper.Info($"All product category menus displayed: {allDisplayed}");
            return allDisplayed;
        }

        /// <summary>
        /// Verifies if a product category menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuClickable(string categoryName)
        {
            try
            {
                By locator = GetMenuItemByText(categoryName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                bool isClickable = Driver.FindElement(locator).Enabled;
                LogHelper.Info($"Product category '{categoryName}' clickable: {isClickable}");
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category '{categoryName}' not clickable: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if homepage displays without errors
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        public bool IsHomepageDisplayedWithoutErrors()
        {
            try
            {
                WaitForPageLoad();
                bool noErrors = !GetCurrentUrl().Contains("error") && 
                               !GetCurrentUrl().Contains("404") &&
                               IsNavigationMenuVisible();
                LogHelper.Info($"Homepage displayed without errors: {noErrors}");
                return noErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage has errors: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================

        /// <summary>
        /// Expands a product category menu by hovering over it
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001
        /// </summary>
        public void ExpandProductMenu(string categoryName)
        {
            try
            {
                LogHelper.Info($"Expanding product menu: {categoryName}");
                By locator = GetMenuItemByText(categoryName);
                WaitHelper.WaitVisible(Driver, locator, 10);
                
                var element = Driver.FindElement(locator);
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                actions.MoveToElement(element).Perform();
                
                System.Threading.Thread.Sleep(500); // Brief pause for menu animation
                LogHelper.Info($"Product menu '{categoryName}' expanded");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand product menu '{categoryName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a product category menu
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public void ClickProductCategoryMenu(string categoryName)
        {
            try
            {
                LogHelper.Info($"Clicking product category menu: {categoryName}");
                By locator = GetMenuItemByText(categoryName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                Click(locator);
                WaitForPageLoad();
                LogHelper.Info($"Product category menu '{categoryName}' clicked");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click product category menu '{categoryName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void ClickSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {submenuItemName}");
                By locator = GetSubmenuItemByText(submenuItemName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                Click(locator);
                WaitForPageLoad();
                LogHelper.Info($"Submenu item '{submenuItemName}' clicked");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItemName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies if a submenu item is displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool IsSubmenuItemDisplayed(string submenuItemName)
        {
            try
            {
                By locator = GetSubmenuItemByText(submenuItemName);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isDisplayed = IsDisplayed(locator);
                LogHelper.Info($"Submenu item '{submenuItemName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item '{submenuItemName}' not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a submenu item is selectable (clickable)
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool IsSubmenuItemSelectable(string submenuItemName)
        {
            try
            {
                By locator = GetSubmenuItemByText(submenuItemName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                bool isSelectable = Driver.FindElement(locator).Enabled;
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
        // URL VERIFICATION METHODS
        // =============================================================

        /// <summary>
        /// Verifies if the current URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            try
            {
                string currentUrl = GetCurrentUrl();
                bool contains = currentUrl.ToLower().Contains(expectedIdentifier.ToLower());
                LogHelper.Info($"Current URL: {currentUrl}");
                LogHelper.Info($"URL contains '{expectedIdentifier}': {contains}");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify URL identifier: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public string GetPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }
    }
}