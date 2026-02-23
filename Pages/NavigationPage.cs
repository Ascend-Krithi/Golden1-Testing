using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Navigation Menu
    /// </summary>
    public class NavigationPage : BasePage
    {
        // Constructor
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS (Based on Golden1 Locators.Json)
        
        // Main Navigation Container
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

        // Generic submenu container
        private By SubmenuContainer => By.CssSelector(".submenu, [class*='submenu'], .dropdown-menu");

        // SECTION 2: PAGE ACTIONS

        /// <summary>
        /// Expands a product category menu by name
        /// </summary>
        /// <param name="menuName">Name of the menu to expand (e.g., 'Checking', 'Savings')</param>
        /// <returns>True if menu expanded successfully, false otherwise</returns>
        public bool ExpandProductCategoryMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding '{menuName}' menu");
                By menuLocator = GetProductCategoryMenuLocator(menuName);
                
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                // Hover over the menu to expand it
                IWebElement menuElement = FindElement(menuLocator);
                Actions actions = new Actions(Driver);
                actions.MoveToElement(menuElement).Perform();
                
                // Wait for submenu to appear
                WaitHelper.WaitVisible(Driver, SubmenuContainer, 5);
                
                LogHelper.Info($"Successfully expanded '{menuName}' menu");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand '{menuName}' menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, $"NavigationPage_ExpandMenu_{menuName}_Failed");
                return false;
            }
        }

        /// <summary>
        /// Selects a submenu item by name
        /// </summary>
        /// <param name="submenuItemName">Name of the submenu item to select</param>
        /// <returns>True if submenu item selected successfully, false otherwise</returns>
        public bool SelectSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Selecting submenu item '{submenuItemName}'");
                By submenuLocator = GetSubmenuItemLocator(submenuItemName);
                
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                
                LogHelper.Info($"Successfully selected submenu item '{submenuItemName}'");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item '{submenuItemName}': {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, $"NavigationPage_SelectSubmenu_{submenuItemName}_Failed");
                return false;
            }
        }

        // SECTION 3: VERIFICATIONS

        /// <summary>
        /// Verifies if the navigation menu is visible
        /// </summary>
        /// <returns>True if navigation menu is visible, false otherwise</returns>
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Verifying navigation menu visibility");
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify navigation menu visibility: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "NavigationPage_MenuNotVisible");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a specific top menu option is present
        /// </summary>
        /// <param name="menuOption">Name of the menu option (e.g., 'Personal', 'Business')</param>
        /// <returns>True if menu option is present, false otherwise</returns>
        public bool IsTopMenuOptionPresent(string menuOption)
        {
            try
            {
                LogHelper.Info($"Verifying top menu option '{menuOption}' is present");
                By menuLocator = GetTopMenuOptionLocator(menuOption);
                WaitHelper.WaitVisible(Driver, menuLocator, 5);
                bool isPresent = IsDisplayed(menuLocator);
                LogHelper.Info($"Top menu option '{menuOption}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top menu option '{menuOption}' not found: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a product category menu is displayed
        /// </summary>
        /// <param name="categoryName">Name of the category (e.g., 'Checking', 'Savings')</param>
        /// <returns>True if category menu is displayed, false otherwise</returns>
        public bool IsProductCategoryMenuDisplayed(string categoryName)
        {
            try
            {
                LogHelper.Info($"Verifying product category '{categoryName}' is displayed");
                By categoryLocator = GetProductCategoryMenuLocator(categoryName);
                WaitHelper.WaitVisible(Driver, categoryLocator, 5);
                bool isDisplayed = IsDisplayed(categoryLocator);
                LogHelper.Info($"Product category '{categoryName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category '{categoryName}' not found: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a product category menu is accessible (can be interacted with)
        /// </summary>
        /// <param name="categoryName">Name of the category</param>
        /// <returns>True if category menu is accessible, false otherwise</returns>
        public bool IsProductCategoryMenuAccessible(string categoryName)
        {
            try
            {
                LogHelper.Info($"Verifying product category '{categoryName}' is accessible");
                By categoryLocator = GetProductCategoryMenuLocator(categoryName);
                
                WaitHelper.WaitVisible(Driver, categoryLocator, 5);
                IWebElement menuElement = FindElement(categoryLocator);
                
                bool isDisplayed = menuElement.Displayed;
                bool isEnabled = menuElement.Enabled;
                bool isAccessible = isDisplayed && isEnabled;
                
                LogHelper.Info($"Product category '{categoryName}' accessible: {isAccessible} (Displayed: {isDisplayed}, Enabled: {isEnabled})");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify accessibility of '{categoryName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if submenu items are displayed after expanding a menu
        /// </summary>
        /// <returns>True if submenu items are displayed, false otherwise</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying submenu items are displayed");
                WaitHelper.WaitVisible(Driver, SubmenuContainer, 5);
                bool areDisplayed = IsDisplayed(SubmenuContainer);
                LogHelper.Info($"Submenu items displayed: {areDisplayed}");
                return areDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a submenu item is selectable
        /// </summary>
        /// <param name="submenuItemName">Name of the submenu item</param>
        /// <returns>True if submenu item is selectable, false otherwise</returns>
        public bool IsSubmenuItemSelectable(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Verifying submenu item '{submenuItemName}' is selectable");
                By submenuLocator = GetSubmenuItemLocator(submenuItemName);
                
                WaitHelper.WaitVisible(Driver, submenuLocator, 5);
                IWebElement submenuElement = FindElement(submenuLocator);
                
                bool isDisplayed = submenuElement.Displayed;
                bool isEnabled = submenuElement.Enabled;
                bool isSelectable = isDisplayed && isEnabled;
                
                LogHelper.Info($"Submenu item '{submenuItemName}' selectable: {isSelectable} (Displayed: {isDisplayed}, Enabled: {isEnabled})");
                return isSelectable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify selectability of '{submenuItemName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if user is on the expected destination page
        /// </summary>
        /// <param name="pageName">Name of the expected page</param>
        /// <returns>True if on destination page, false otherwise</returns>
        public bool IsOnDestinationPage(string pageName)
        {
            try
            {
                LogHelper.Info($"Verifying user is on '{pageName}' destination page");
                WaitForPageLoad();
                
                string currentUrl = Driver.Url.ToLower();
                string pageTitle = Driver.Title.ToLower();
                string pageNameLower = pageName.ToLower().Replace(" ", "-");
                
                bool urlContainsPage = currentUrl.Contains(pageNameLower) || currentUrl.Contains(pageName.ToLower().Replace(" ", ""));
                bool titleContainsPage = pageTitle.Contains(pageName.ToLower());
                
                bool isOnPage = urlContainsPage || titleContainsPage;
                
                LogHelper.Info($"On '{pageName}' page: {isOnPage} (URL match: {urlContainsPage}, Title match: {titleContainsPage})");
                LogHelper.Info($"Current URL: {currentUrl}, Page Title: {pageTitle}");
                
                return isOnPage;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify destination page '{pageName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if the current page has any errors
        /// </summary>
        /// <returns>True if page has errors, false otherwise</returns>
        public bool HasPageErrors()
        {
            try
            {
                LogHelper.Info("Checking for page errors");
                By errorLocators = By.CssSelector(".error, .alert-danger, [class*='error-message']");
                bool hasErrors = IsDisplayed(errorLocators);
                
                if (hasErrors)
                {
                    string errorText = GetText(errorLocators);
                    LogHelper.Warning($"Page error detected: {errorText}");
                    ScreenshotHelper.TakeScreenshot(Driver, "NavigationPage_PageError");
                }
                else
                {
                    LogHelper.Info("No page errors detected");
                }
                
                return hasErrors;
            }
            catch (NoSuchElementException)
            {
                LogHelper.Info("No page errors found (element not present)");
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Error checking for page errors: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the current URL contains a specific identifier
        /// </summary>
        /// <param name="urlIdentifier">URL identifier to check for</param>
        /// <returns>True if URL contains identifier, false otherwise</returns>
        public bool DoesUrlContain(string urlIdentifier)
        {
            try
            {
                LogHelper.Info($"Verifying URL contains '{urlIdentifier}'");
                string currentUrl = Driver.Url.ToLower();
                bool containsIdentifier = currentUrl.Contains(urlIdentifier.ToLower());
                
                LogHelper.Info($"URL contains '{urlIdentifier}': {containsIdentifier}");
                LogHelper.Info($"Current URL: {currentUrl}");
                
                return containsIdentifier;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify URL identifier: {ex.Message}");
                return false;
            }
        }

        // SECTION 4: HELPER METHODS

        /// <summary>
        /// Gets the locator for a top menu option by name
        /// </summary>
        /// <param name="menuOption">Name of the menu option</param>
        /// <returns>By locator for the menu option</returns>
        private By GetTopMenuOptionLocator(string menuOption)
        {
            switch (menuOption)
            {
                case "Personal":
                    return PersonalTab;
                case "Business":
                    return BusinessTab;
                case "Financial Wellness":
                    return FinancialWellnessTab;
                case "Appointments":
                    return AppointmentsTab;
                case "Locations":
                    return LocationsTab;
                case "Membership":
                    return MembershipTab;
                case "Help Center":
                    return HelpCenterTab;
                default:
                    throw new ArgumentException($"Unknown menu option: {menuOption}");
            }
        }

        /// <summary>
        /// Gets the locator for a product category menu by name
        /// </summary>
        /// <param name="categoryName">Name of the category</param>
        /// <returns>By locator for the category menu</returns>
        private By GetProductCategoryMenuLocator(string categoryName)
        {
            switch (categoryName)
            {
                case "Checking":
                    return CheckingMenu;
                case "Savings":
                    return SavingsMenu;
                case "Home Loans":
                    return HomeLoansMenu;
                case "Credit Cards":
                    return CreditCardsMenu;
                case "Loans":
                    return LoansMenu;
                case "Investing":
                    return InvestingMenu;
                case "Community":
                    return CommunityMenu;
                default:
                    throw new ArgumentException($"Unknown product category: {categoryName}");
            }
        }

        /// <summary>
        /// Gets the locator for a submenu item by name
        /// </summary>
        /// <param name="submenuItemName">Name of the submenu item</param>
        /// <returns>By locator for the submenu item</returns>
        private By GetSubmenuItemLocator(string submenuItemName)
        {
            switch (submenuItemName)
            {
                case "Free Checking":
                    return FreeCheckingLink;
                case "Savings Account":
                    return SavingsAccountLink;
                case "Auto Loan":
                case "Auto Loans":
                    return AutoLoansLink;
                default:
                    // For dynamic submenu items not explicitly defined
                    return By.XPath($"//a[normalize-space()='{submenuItemName}']");
            }
        }
    }
}