using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the main homepage elements
    /// Test Cases: TASK0020445 TS-001 through TS-011
    /// </summary>
    public class HomePage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public HomePage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators
        // =============================================================
        
        // Header elements
        private By Golden1Logo => By.CssSelector("a.logo, img[alt*='Golden 1'], .header-logo");
        private By HeaderContainer => By.CssSelector("header, .header, .site-header");
        
        // Navigation menu elements
        private By GlobalNavigationMenu => By.CssSelector("nav.main-nav, nav.global-nav, .navigation-menu");
        private By NavigationContainer => By.CssSelector("nav, .nav-container");
        
        // Main menu options
        private By PersonalMenuOption => By.XPath("//nav//a[contains(text(),'Personal')]");
        private By BusinessMenuOption => By.XPath("//nav//a[contains(text(),'Business')]");
        private By FinancialWellnessMenuOption => By.XPath("//nav//a[contains(text(),'Financial Wellness')]");
        private By AppointmentsMenuOption => By.XPath("//nav//a[contains(text(),'Appointments')]");
        private By LocationsMenuOption => By.XPath("//nav//a[contains(text(),'Locations')]");
        private By MembershipMenuOption => By.XPath("//nav//a[contains(text(),'Membership')]");
        private By HelpCenterMenuOption => By.XPath("//nav//a[contains(text(),'Help Center')]");
        
        // Product category menus
        private By CheckingMenu => By.XPath("//nav//a[contains(text(),'Checking')]");
        private By SavingsMenu => By.XPath("//nav//a[contains(text(),'Savings')]");
        private By HomeLoansMenu => By.XPath("//nav//a[contains(text(),'Home Loans')]");
        private By CreditCardsMenu => By.XPath("//nav//a[contains(text(),'Credit Cards')]");
        private By LoansMenu => By.XPath("//nav//a[contains(text(),'Loans')]");
        private By InvestingMenu => By.XPath("//nav//a[contains(text(),'Investing')]");
        private By CommunityMenu => By.XPath("//nav//a[contains(text(),'Community')]");
        
        // Page content elements
        private By PageContent => By.CssSelector("main, .main-content, #main-content");
        private By ErrorMessages => By.CssSelector(".error, .alert-error, .error-message");
        
        // Dynamic locators
        private By MenuItemByText(string menuText) =>
            By.XPath($"//nav//a[contains(text(),'{menuText}')]");
        
        private By SubmenuItemByText(string submenuText) =>
            By.XPath($"//nav//ul[@class='submenu' or contains(@class,'dropdown')]//a[contains(text(),'{submenuText}')]");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info("Opening Golden1 homepage");
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                LogHelper.Info("Golden1 homepage loaded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if homepage loaded without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public bool IsHomePageLoadedSuccessfully()
        {
            try
            {
                LogHelper.Info("Verifying homepage loaded successfully");
                WaitHelper.WaitVisible(Driver, PageContent, 10);
                bool isLoaded = IsDisplayed(PageContent);
                bool hasNoErrors = !IsDisplayed(ErrorMessages);
                
                bool result = isLoaded && hasNoErrors;
                LogHelper.Info($"Homepage loaded successfully: {result}");
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        public bool IsGlobalNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Checking if global navigation menu is visible");
                WaitHelper.WaitVisible(Driver, GlobalNavigationMenu, 10);
                bool isVisible = IsDisplayed(GlobalNavigationMenu);
                LogHelper.Info($"Global navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Global navigation menu visibility check failed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if Golden1 logo is visible in header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        public bool IsGolden1LogoVisible()
        {
            try
            {
                LogHelper.Info("Checking if Golden1 logo is visible");
                WaitHelper.WaitVisible(Driver, Golden1Logo, 10);
                bool isVisible = IsDisplayed(Golden1Logo);
                LogHelper.Info($"Golden1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Golden1 logo visibility check failed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if specific menu option is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsMenuOptionPresent(string menuOption)
        {
            try
            {
                LogHelper.Info($"Checking if menu option '{menuOption}' is present");
                By locator = GetMenuOptionLocator(menuOption);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isPresent = IsDisplayed(locator);
                LogHelper.Info($"Menu option '{menuOption}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu option '{menuOption}' presence check failed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuDisplayed(string categoryName)
        {
            try
            {
                LogHelper.Info($"Checking if product category '{categoryName}' is displayed");
                By locator = GetProductCategoryLocator(categoryName);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isDisplayed = IsDisplayed(locator);
                LogHelper.Info($"Product category '{categoryName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category '{categoryName}' display check failed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if homepage displays correctly without layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool IsHomePageDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays correctly");
                bool hasContent = IsDisplayed(PageContent);
                bool hasHeader = IsDisplayed(HeaderContainer);
                bool hasNavigation = IsDisplayed(NavigationContainer);
                bool noErrors = !IsDisplayed(ErrorMessages);
                
                bool result = hasContent && hasHeader && hasNavigation && noErrors;
                LogHelper.Info($"Homepage displayed correctly: {result}");
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage display verification failed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Checks if there are any error messages on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool HasNoErrorMessages()
        {
            try
            {
                LogHelper.Info("Checking for error messages");
                bool noErrors = !IsDisplayed(ErrorMessages);
                LogHelper.Info($"No error messages: {noErrors}");
                return noErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error message check failed: {ex.Message}");
                return true; // If we can't find error elements, assume no errors
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Clicks on a product category menu
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001
        /// </summary>
        public void ClickProductCategoryMenu(string categoryName)
        {
            try
            {
                LogHelper.Info($"Clicking on product category: {categoryName}");
                By locator = GetProductCategoryLocator(categoryName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                Click(locator);
                LogHelper.Info($"Clicked on product category: {categoryName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click product category '{categoryName}': {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Expands a product menu to show submenu items
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001
        /// </summary>
        public void ExpandProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding product menu: {menuName}");
                By locator = GetProductCategoryLocator(menuName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                
                // Hover over the menu to expand it
                var element = Driver.FindElement(locator);
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                actions.MoveToElement(element).Perform();
                
                System.Threading.Thread.Sleep(500); // Brief pause for menu animation
                LogHelper.Info($"Expanded product menu: {menuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand product menu '{menuName}': {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Selects a submenu item from an expanded product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void SelectSubmenuItem(string submenuName)
        {
            try
            {
                LogHelper.Info($"Selecting submenu item: {submenuName}");
                By locator = SubmenuItemByText(submenuName);
                WaitHelper.WaitClickable(Driver, locator, 10);
                Click(locator);
                WaitForPageLoad();
                LogHelper.Info($"Selected submenu item: {submenuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item '{submenuName}': {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // HELPER METHODS
        // =============================================================
        
        /// <summary>
        /// Gets the locator for a specific menu option
        /// </summary>
        private By GetMenuOptionLocator(string menuOption)
        {
            return menuOption switch
            {
                "Personal" => PersonalMenuOption,
                "Business" => BusinessMenuOption,
                "Financial Wellness" => FinancialWellnessMenuOption,
                "Appointments" => AppointmentsMenuOption,
                "Locations" => LocationsMenuOption,
                "Membership" => MembershipMenuOption,
                "Help Center" => HelpCenterMenuOption,
                _ => MenuItemByText(menuOption)
            };
        }
        
        /// <summary>
        /// Gets the locator for a specific product category
        /// </summary>
        private By GetProductCategoryLocator(string categoryName)
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
                _ => MenuItemByText(categoryName)
            };
        }
        
        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public string GetPageUrl()
        {
            try
            {
                string url = GetCurrentUrl();
                LogHelper.Info($"Current page URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get page URL: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Verifies if URL contains expected text
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public bool DoesUrlContain(string expectedText)
        {
            try
            {
                string currentUrl = GetCurrentUrl();
                bool contains = currentUrl.Contains(expectedText, StringComparison.OrdinalIgnoreCase);
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