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
    /// Handles all interactions with navigation menu and top tabs
    /// Test Cases: TASK0020445 TS-001 to TS-009
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
        
        // Menu Container
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
        
        // Overlay Elements
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Dynamic Locators
        private By GetMenuByName(string menuName) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuName}']");
        
        private By GetSubmenuByName(string submenuName) =>
            By.XPath($"//a[normalize-space()='{submenuName}']");
        
        private By GetTopTabByName(string tabName) =>
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabName}']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info($"Opening Golden1 homepage: {ConfigReader.BaseUrl}");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            HandleCookieBanner();
            LogHelper.Info("Homepage loaded successfully");
        }

        /// <summary>
        /// Handles cookie consent banner if present
        /// </summary>
        private void HandleCookieBanner()
        {
            try
            {
                if (IsDisplayed(CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookie banner accepted");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No cookie banner present or already accepted: {ex.Message}");
            }
        }

        // =============================================================
        // INTERACTION METHODS - User actions on page
        // =============================================================
        
        /// <summary>
        /// Expands a main product category menu
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to expand</param>
        public void ExpandMainProductMenu(string menuName)
        {
            LogHelper.Info($"Expanding main product menu: {menuName}");
            By menuLocator = GetMenuByName(menuName);
            WaitHelper.WaitVisible(Driver, menuLocator, 10);
            WaitHelper.WaitClickable(Driver, menuLocator, 10);
            Click(menuLocator);
            LogHelper.Info($"Main product menu '{menuName}' expanded");
        }
        
        /// <summary>
        /// Selects a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001
        /// </summary>
        /// <param name="submenuName">Name of the submenu to select</param>
        public void SelectSubmenuItem(string submenuName)
        {
            LogHelper.Info($"Selecting submenu item: {submenuName}");
            By submenuLocator = GetSubmenuByName(submenuName);
            WaitHelper.WaitVisible(Driver, submenuLocator, 10);
            WaitHelper.WaitClickable(Driver, submenuLocator, 10);
            Click(submenuLocator);
            WaitForPageLoad();
            LogHelper.Info($"Submenu item '{submenuName}' selected");
        }
        
        /// <summary>
        /// Clicks a top navigation tab
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="tabName">Name of the tab to click</param>
        public void ClickTopNavigationTab(string tabName)
        {
            LogHelper.Info($"Clicking top navigation tab: {tabName}");
            By tabLocator = GetTopTabByName(tabName);
            WaitHelper.WaitVisible(Driver, tabLocator, 10);
            WaitHelper.WaitClickable(Driver, tabLocator, 10);
            Click(tabLocator);
            LogHelper.Info($"Top navigation tab '{tabName}' clicked");
        }

        // =============================================================
        // VERIFICATION METHODS - Return boolean or data
        // =============================================================
        
        /// <summary>
        /// Verifies if the global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        /// <returns>True if menu is visible, false otherwise</returns>
        public bool IsGlobalNavigationMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Global navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Global navigation menu not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if a specific top navigation tab is visible
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="tabName">Name of the tab to verify</param>
        /// <returns>True if tab is visible, false otherwise</returns>
        public bool IsTopNavigationTabVisible(string tabName)
        {
            try
            {
                By tabLocator = GetTopTabByName(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isVisible = IsDisplayed(tabLocator);
                LogHelper.Info($"Top navigation tab '{tabName}' visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top navigation tab '{tabName}' not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if all required top navigation tabs are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="expectedTabs">List of expected tab names</param>
        /// <returns>True if all tabs are present, false otherwise</returns>
        public bool AreAllTopNavigationTabsPresent(List<string> expectedTabs)
        {
            LogHelper.Info($"Verifying presence of {expectedTabs.Count} top navigation tabs");
            foreach (string tabName in expectedTabs)
            {
                if (!IsTopNavigationTabVisible(tabName))
                {
                    LogHelper.Error($"Top navigation tab '{tabName}' is missing");
                    return false;
                }
            }
            LogHelper.Info("All top navigation tabs are present");
            return true;
        }
        
        /// <summary>
        /// Verifies if a main product category menu is visible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to verify</param>
        /// <returns>True if menu is visible, false otherwise</returns>
        public bool IsMainProductMenuVisible(string menuName)
        {
            try
            {
                By menuLocator = GetMenuByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isVisible = IsDisplayed(menuLocator);
                LogHelper.Info($"Main product menu '{menuName}' visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main product menu '{menuName}' not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if all main product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="expectedMenus">List of expected menu names</param>
        /// <returns>True if all menus are displayed, false otherwise</returns>
        public bool AreAllMainProductMenusDisplayed(List<string> expectedMenus)
        {
            LogHelper.Info($"Verifying presence of {expectedMenus.Count} main product menus");
            foreach (string menuName in expectedMenus)
            {
                if (!IsMainProductMenuVisible(menuName))
                {
                    LogHelper.Error($"Main product menu '{menuName}' is missing");
                    return false;
                }
            }
            LogHelper.Info("All main product menus are displayed");
            return true;
        }
        
        /// <summary>
        /// Verifies if a main product menu is accessible (clickable)
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to verify</param>
        /// <returns>True if menu is accessible, false otherwise</returns>
        public bool IsMainProductMenuAccessible(string menuName)
        {
            try
            {
                By menuLocator = GetMenuByName(menuName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                bool isAccessible = Driver.FindElement(menuLocator).Enabled;
                LogHelper.Info($"Main product menu '{menuName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main product menu '{menuName}' not accessible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if submenu items are displayed after expanding a menu
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <returns>True if submenu items are displayed, false otherwise</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                // Wait for any submenu item to be visible
                By submenuContainer = By.XPath("//div[contains(@class,'submenu')]//a");
                WaitHelper.WaitVisible(Driver, submenuContainer, 10);
                bool isDisplayed = IsDisplayed(submenuContainer);
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
        /// Verifies if a specific submenu item is visible
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <param name="submenuName">Name of the submenu to verify</param>
        /// <returns>True if submenu is visible, false otherwise</returns>
        public bool IsSubmenuItemVisible(string submenuName)
        {
            try
            {
                By submenuLocator = GetSubmenuByName(submenuName);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
                bool isVisible = IsDisplayed(submenuLocator);
                LogHelper.Info($"Submenu item '{submenuName}' visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item '{submenuName}' not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <returns>Current page URL</returns>
        public string GetCurrentPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }
        
        /// <summary>
        /// Verifies if the current URL contains the expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="expectedIdentifier">Expected URL identifier</param>
        /// <returns>True if URL contains identifier, false otherwise</returns>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            string currentUrl = GetCurrentPageUrl();
            bool contains = currentUrl.Contains(expectedIdentifier, StringComparison.OrdinalIgnoreCase);
            LogHelper.Info($"URL contains '{expectedIdentifier}': {contains}");
            return contains;
        }
        
        /// <summary>
        /// Verifies if the homepage loaded successfully
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        /// <returns>True if homepage loaded, false otherwise</returns>
        public bool IsHomepageLoaded()
        {
            try
            {
                WaitForPageLoad();
                bool isLoaded = Driver.Url.Contains("golden1.com", StringComparison.OrdinalIgnoreCase);
                LogHelper.Info($"Homepage loaded: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage not loaded: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if there are any error messages on the page
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        /// <returns>True if no errors, false if errors present</returns>
        public bool AreThereNoErrorMessages()
        {
            try
            {
                By errorLocators = By.XPath("//div[contains(@class,'error')] | //div[contains(@class,'alert-danger')] | //*[contains(text(),'Error')] | //*[contains(text(),'error')]");
                bool noErrors = !IsDisplayed(errorLocators, 2);
                LogHelper.Info($"No error messages present: {noErrors}");
                return noErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No error messages detected: {ex.Message}");
                return true;
            }
        }
        
        /// <summary>
        /// Verifies if the page content is displayed correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if content is correct, false otherwise</returns>
        public bool IsPageContentDisplayedCorrectly()
        {
            try
            {
                // Check if main content container is present
                By mainContent = By.XPath("//main | //div[@id='main'] | //div[contains(@class,'main-content')]");
                WaitHelper.WaitVisible(Driver, mainContent, 10);
                bool isDisplayed = IsDisplayed(mainContent);
                LogHelper.Info($"Page content displayed correctly: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page content not displayed correctly: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if there are any broken layouts
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no broken layouts, false otherwise</returns>
        public bool AreThereNoBrokenLayouts()
        {
            try
            {
                // Check if key layout elements are present
                bool menuVisible = IsDisplayed(MenuContainer, 5);
                bool contentVisible = IsPageContentDisplayedCorrectly();
                bool noBrokenLayouts = menuVisible && contentVisible;
                LogHelper.Info($"No broken layouts: {noBrokenLayouts}");
                return noBrokenLayouts;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Broken layouts detected: {ex.Message}");
                return false;
            }
        }
    }
}