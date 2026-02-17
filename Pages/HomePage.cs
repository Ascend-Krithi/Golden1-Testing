using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using ProjectName.Automation.Config;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the main homepage
    /// Test Cases: TASK0020445 TS-001 to TS-011
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
        private By GlobalNavigationMenu => By.CssSelector("nav.main-nav, nav[role='navigation'], .global-navigation");
        private By NavigationMenuContainer => By.CssSelector(".nav-container, nav.menu, .navigation-wrapper");
        
        // Main menu options
        private By PersonalMenuOption => By.XPath("//nav//a[normalize-space()='Personal' or contains(@href, 'personal')]");
        private By BusinessMenuOption => By.XPath("//nav//a[normalize-space()='Business' or contains(@href, 'business')]");
        private By FinancialWellnessMenuOption => By.XPath("//nav//a[normalize-space()='Financial Wellness' or contains(@href, 'financial-wellness')]");
        private By AppointmentsMenuOption => By.XPath("//nav//a[normalize-space()='Appointments' or contains(@href, 'appointments')]");
        private By LocationsMenuOption => By.XPath("//nav//a[normalize-space()='Locations' or contains(@href, 'locations')]");
        private By MembershipMenuOption => By.XPath("//nav//a[normalize-space()='Membership' or contains(@href, 'membership')]");
        private By HelpCenterMenuOption => By.XPath("//nav//a[normalize-space()='Help Center' or contains(@href, 'help')]");
        
        // Product category menus
        private By CheckingMenu => By.XPath("//nav//a[normalize-space()='Checking' or contains(@href, 'checking')]");
        private By SavingsMenu => By.XPath("//nav//a[normalize-space()='Savings' or contains(@href, 'savings')]");
        private By HomeLoansMenu => By.XPath("//nav//a[normalize-space()='Home Loans' or contains(@href, 'home-loans')]");
        private By CreditCardsMenu => By.XPath("//nav//a[normalize-space()='Credit Cards' or contains(@href, 'credit-cards')]");
        private By LoansMenu => By.XPath("//nav//a[normalize-space()='Loans' or contains(@href, 'loans')]");
        private By InvestingMenu => By.XPath("//nav//a[normalize-space()='Investing' or contains(@href, 'investing')]");
        private By CommunityMenu => By.XPath("//nav//a[normalize-space()='Community' or contains(@href, 'community')]");
        
        // Submenu items
        private By FreeCheckingSubmenu => By.XPath("//a[normalize-space()='Free Checking' or contains(@href, 'free-checking')]");
        private By SubmenuContainer => By.CssSelector(".submenu, .dropdown-menu, [role='menu']");
        
        // Error and loading indicators
        private By ErrorMessage => By.CssSelector(".error, .alert-error, .error-message");
        private By LoadingSpinner => By.CssSelector(".spinner, .loading, .loader");
        private By BrokenContent => By.XPath("//img[@alt='broken' or @src='']");
        
        // Dynamic locators
        private By MenuItemByText(string menuText) =>
            By.XPath($"//nav//a[normalize-space()='{menuText}' or contains(text(), '{menuText}')]");
        
        private By SubmenuItemByText(string submenuText) =>
            By.XPath($"//a[normalize-space()='{submenuText}' or contains(text(), '{submenuText}')]");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001 to TS-011 TC-001
        /// </summary>
        public void OpenHomepage()
        {
            LogHelper.Info($"Opening Golden1 homepage: {ConfigReader.BaseUrl}");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            WaitForLoadingToComplete();
            LogHelper.Info("Golden1 homepage opened successfully");
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Expands a product category menu by name
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to expand (e.g., 'Checking')</param>
        public void ExpandProductMenu(string menuName)
        {
            LogHelper.Info($"Expanding product menu: {menuName}");
            By menuLocator = MenuItemByText(menuName);
            WaitHelper.WaitVisible(Driver, menuLocator, 10);
            WaitHelper.WaitClickable(Driver, menuLocator, 10);
            
            var menuElement = Driver.FindElement(menuLocator);
            
            // Hover over menu to expand
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
            actions.MoveToElement(menuElement).Perform();
            
            // Wait for submenu to appear
            WaitHelper.WaitVisible(Driver, SubmenuContainer, 5);
            LogHelper.Info($"Product menu '{menuName}' expanded successfully");
        }
        
        /// <summary>
        /// Clicks on a product category menu
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to click</param>
        public void ClickProductMenu(string menuName)
        {
            LogHelper.Info($"Clicking product menu: {menuName}");
            By menuLocator = MenuItemByText(menuName);
            WaitHelper.WaitVisible(Driver, menuLocator, 10);
            WaitHelper.WaitClickable(Driver, menuLocator, 10);
            Click(menuLocator);
            LogHelper.Info($"Product menu '{menuName}' clicked successfully");
        }
        
        /// <summary>
        /// Selects a submenu item by name
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="submenuName">Name of the submenu item to select</param>
        public void SelectSubmenuItem(string submenuName)
        {
            LogHelper.Info($"Selecting submenu item: {submenuName}");
            By submenuLocator = SubmenuItemByText(submenuName);
            WaitHelper.WaitVisible(Driver, submenuLocator, 10);
            WaitHelper.WaitClickable(Driver, submenuLocator, 10);
            Click(submenuLocator);
            WaitForPageLoad();
            LogHelper.Info($"Submenu item '{submenuName}' selected successfully");
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if the homepage loaded successfully
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        /// <returns>True if homepage loaded successfully</returns>
        public bool IsHomepageLoaded()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, HeaderContainer, 10);
                bool isLoaded = IsDisplayed(HeaderContainer) && !GetCurrentUrl().Contains("error");
                LogHelper.Info($"Homepage loaded status: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage failed to load: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if the global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        /// <returns>True if navigation menu is visible</returns>
        public bool IsGlobalNavigationMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, GlobalNavigationMenu, 10);
                bool isVisible = IsDisplayed(GlobalNavigationMenu);
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
        /// Verifies if a specific menu option is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="menuOption">Name of the menu option</param>
        /// <returns>True if menu option is present</returns>
        public bool IsMenuOptionPresent(string menuOption)
        {
            try
            {
                By menuLocator = MenuItemByText(menuOption);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isPresent = IsDisplayed(menuLocator);
                LogHelper.Info($"Menu option '{menuOption}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu option '{menuOption}' not found: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if a product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="categoryName">Name of the product category</param>
        /// <returns>True if category menu is displayed</returns>
        public bool IsProductCategoryDisplayed(string categoryName)
        {
            try
            {
                By categoryLocator = MenuItemByText(categoryName);
                WaitHelper.WaitVisible(Driver, categoryLocator, 10);
                bool isDisplayed = IsDisplayed(categoryLocator);
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
        /// Verifies if a product category menu is clickable and expandable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="categoryName">Name of the product category</param>
        /// <returns>True if category menu is clickable</returns>
        public bool IsProductCategoryClickable(string categoryName)
        {
            try
            {
                By categoryLocator = MenuItemByText(categoryName);
                WaitHelper.WaitClickable(Driver, categoryLocator, 10);
                bool isClickable = Driver.FindElement(categoryLocator).Enabled;
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
        /// Verifies if submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <returns>True if submenu items are displayed</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, SubmenuContainer, 10);
                bool isDisplayed = IsDisplayed(SubmenuContainer);
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
        /// Verifies if a submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <param name="submenuName">Name of the submenu item</param>
        /// <returns>True if submenu item is selectable</returns>
        public bool IsSubmenuItemSelectable(string submenuName)
        {
            try
            {
                By submenuLocator = SubmenuItemByText(submenuName);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                bool isSelectable = Driver.FindElement(submenuLocator).Enabled;
                LogHelper.Info($"Submenu item '{submenuName}' selectable: {isSelectable}");
                return isSelectable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item '{submenuName}' not selectable: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if the destination page loaded without errors
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        /// <returns>True if destination page loaded successfully</returns>
        public bool IsDestinationPageLoadedSuccessfully()
        {
            try
            {
                WaitForPageLoad();
                bool noErrors = !IsDisplayed(ErrorMessage, 5);
                bool urlValid = !GetCurrentUrl().Contains("error") && !GetCurrentUrl().Contains("404");
                bool isLoaded = noErrors && urlValid;
                LogHelper.Info($"Destination page loaded successfully: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page failed to load: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if the current URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="expectedUrlPart">Expected URL identifier</param>
        /// <returns>True if URL contains expected identifier</returns>
        public bool DoesUrlContainExpectedIdentifier(string expectedUrlPart)
        {
            try
            {
                string currentUrl = GetCurrentUrl();
                bool containsIdentifier = currentUrl.Contains(expectedUrlPart);
                LogHelper.Info($"Current URL: {currentUrl}");
                LogHelper.Info($"URL contains '{expectedUrlPart}': {containsIdentifier}");
                return containsIdentifier;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify URL identifier: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if the Golden1 logo is visible in header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        /// <returns>True if logo is visible</returns>
        public bool IsGolden1LogoVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, Golden1Logo, 10);
                bool isVisible = IsDisplayed(Golden1Logo);
                LogHelper.Info($"Golden1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Golden1 logo not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if there are any error messages on the page
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        /// <returns>True if no error messages are present</returns>
        public bool AreThereNoErrorMessages()
        {
            try
            {
                bool noErrors = !IsDisplayed(ErrorMessage, 5);
                LogHelper.Info($"No error messages present: {noErrors}");
                return noErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for error messages: {ex.Message}");
                return true; // Assume no errors if we can't find error element
            }
        }
        
        /// <summary>
        /// Verifies if there are any broken layouts on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no broken layouts detected</returns>
        public bool AreThereNoBrokenLayouts()
        {
            try
            {
                bool noBrokenImages = !IsDisplayed(BrokenContent, 5);
                bool headerVisible = IsDisplayed(HeaderContainer);
                bool navVisible = IsDisplayed(GlobalNavigationMenu);
                bool noLayoutIssues = noBrokenImages && headerVisible && navVisible;
                LogHelper.Info($"No broken layouts: {noLayoutIssues}");
                return noLayoutIssues;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for broken layouts: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if the homepage displays correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if homepage displays correctly</returns>
        public bool IsHomepageDisplayedCorrectly()
        {
            try
            {
                bool headerVisible = IsDisplayed(HeaderContainer);
                bool navVisible = IsDisplayed(GlobalNavigationMenu);
                bool logoVisible = IsDisplayed(Golden1Logo);
                bool displayedCorrectly = headerVisible && navVisible && logoVisible;
                LogHelper.Info($"Homepage displayed correctly: {displayedCorrectly}");
                return displayedCorrectly;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage not displayed correctly: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if navigation menu is functional
        /// Test Cases: TASK0020445 TS-010 TC-001, TS-011 TC-001
        /// </summary>
        /// <returns>True if navigation menu is functional</returns>
        public bool IsNavigationMenuFunctional()
        {
            try
            {
                bool isVisible = IsGlobalNavigationMenuVisible();
                bool isClickable = IsProductCategoryClickable("Checking");
                bool isFunctional = isVisible && isClickable;
                LogHelper.Info($"Navigation menu functional: {isFunctional}");
                return isFunctional;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu not functional: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if header elements are visible
        /// Test Cases: TASK0020445 TS-010 TC-001, TS-011 TC-001
        /// </summary>
        /// <returns>True if header elements are visible</returns>
        public bool AreHeaderElementsVisible()
        {
            try
            {
                bool headerVisible = IsDisplayed(HeaderContainer);
                bool logoVisible = IsDisplayed(Golden1Logo);
                bool elementsVisible = headerVisible && logoVisible;
                LogHelper.Info($"Header elements visible: {elementsVisible}");
                return elementsVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Header elements not visible: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // HELPER METHODS
        // =============================================================
        
        /// <summary>
        /// Waits for loading spinner to disappear
        /// </summary>
        private void WaitForLoadingToComplete()
        {
            try
            {
                WaitHelper.WaitInvisible(Driver, LoadingSpinner, 10);
                LogHelper.Info("Page loading completed");
            }
            catch
            {
                // Loading spinner might not be present, which is fine
                LogHelper.Info("No loading spinner detected");
            }
        }
        
        /// <summary>
        /// Gets all menu options present on the page
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <returns>List of menu option names</returns>
        public List<string> GetAllMenuOptions()
        {
            try
            {
                LogHelper.Info("Retrieving all menu options");
                var menuElements = Driver.FindElements(By.CssSelector("nav a, nav button"));
                var menuOptions = menuElements
                    .Where(e => !string.IsNullOrWhiteSpace(e.Text))
                    .Select(e => e.Text.Trim())
                    .ToList();
                LogHelper.Info($"Found {menuOptions.Count} menu options");
                return menuOptions;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to retrieve menu options: {ex.Message}");
                return new List<string>();
            }
        }
        
        /// <summary>
        /// Gets current page title
        /// </summary>
        /// <returns>Page title</returns>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            LogHelper.Info($"Page title: {title}");
            return title;
        }
    }
}