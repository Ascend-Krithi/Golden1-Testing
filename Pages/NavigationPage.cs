using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Navigation functionality.
    /// Handles all interactions with the main navigation menu and top tabs.
    /// </summary>
    public class NavigationPage : BasePage
    {
        // Constructor - MANDATORY
        public NavigationPage(IWebDriver driver) : base(driver) { }

        #region Locators

        // Main Navigation Container
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");

        // Top Tab Menu Options
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

        // Cookie Banner
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        #endregion

        #region Navigation Actions

        /// <summary>
        /// Opens the Golden1 homepage.
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info("Opening Golden1 homepage");
                string baseUrl = ConfigReader.BaseUrl;
                NavigateTo(baseUrl);
                WaitForPageLoad();
                HandleCookieBanner();
                LogHelper.Info("Golden1 homepage loaded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomePage_LoadError");
                throw;
            }
        }

        /// <summary>
        /// Handles the cookie consent banner if present.
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
                    LogHelper.Info("Cookie banner accepted and closed");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No cookie banner present or already dismissed: {ex.Message}");
            }
        }

        #endregion

        #region Verification Methods

        /// <summary>
        /// Verifies if the global navigation menu is visible.
        /// </summary>
        /// <returns>True if menu is visible, false otherwise</returns>
        public bool IsGlobalNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Checking if global navigation menu is visible");
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Global navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Global navigation menu not visible: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "NavigationMenu_NotVisible");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a specific top tab menu option is present.
        /// </summary>
        /// <param name="menuOption">Name of the menu option</param>
        /// <returns>True if menu option is present, false otherwise</returns>
        public bool IsTopMenuOptionPresent(string menuOption)
        {
            try
            {
                LogHelper.Info($"Checking if top menu option '{menuOption}' is present");
                By locator = GetTopMenuLocator(menuOption);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isPresent = IsDisplayed(locator);
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
        /// Verifies if a main product category menu is displayed.
        /// </summary>
        /// <param name="productMenu">Name of the product menu</param>
        /// <returns>True if product menu is displayed, false otherwise</returns>
        public bool IsProductMenuDisplayed(string productMenu)
        {
            try
            {
                LogHelper.Info($"Checking if product menu '{productMenu}' is displayed");
                By locator = GetProductMenuLocator(productMenu);
                WaitHelper.WaitVisible(Driver, locator, 10);
                bool isDisplayed = IsDisplayed(locator);
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
        /// Verifies if a product menu is accessible (clickable).
        /// </summary>
        /// <param name="productMenu">Name of the product menu</param>
        /// <returns>True if accessible, false otherwise</returns>
        public bool IsProductMenuAccessible(string productMenu)
        {
            try
            {
                LogHelper.Info($"Checking if product menu '{productMenu}' is accessible");
                By locator = GetProductMenuLocator(productMenu);
                WaitHelper.WaitClickable(Driver, locator, 10);
                bool isAccessible = Driver.FindElement(locator).Enabled;
                LogHelper.Info($"Product menu '{productMenu}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu '{productMenu}' not accessible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the homepage displays correctly without errors.
        /// </summary>
        /// <returns>True if homepage is correct, false otherwise</returns>
        public bool IsHomepageDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays correctly");
                WaitHelper.WaitForPageReady(Driver, 30);
                
                // Check for common error indicators
                bool noJsErrors = !Driver.PageSource.Contains("JavaScript error");
                bool no404 = !Driver.PageSource.Contains("404") && !Driver.PageSource.Contains("Page Not Found");
                bool no500 = !Driver.PageSource.Contains("500") && !Driver.PageSource.Contains("Internal Server Error");
                bool menuVisible = IsDisplayed(MenuContainer, 5);
                
                bool isCorrect = noJsErrors && no404 && no500 && menuVisible;
                LogHelper.Info($"Homepage displayed correctly: {isCorrect}");
                return isCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage display verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "Homepage_DisplayError");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the destination page URL contains expected identifier.
        /// </summary>
        /// <param name="expectedUrlPart">Expected URL identifier</param>
        /// <returns>True if URL contains identifier, false otherwise</returns>
        public bool DoesUrlContain(string expectedUrlPart)
        {
            try
            {
                LogHelper.Info($"Checking if URL contains '{expectedUrlPart}'");
                string currentUrl = GetCurrentUrl();
                bool contains = currentUrl.Contains(expectedUrlPart);
                LogHelper.Info($"Current URL: {currentUrl}, Contains '{expectedUrlPart}': {contains}");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region Menu Interaction Methods

        /// <summary>
        /// Expands a main product menu by hovering over it.
        /// </summary>
        /// <param name="menuName">Name of the menu to expand</param>
        public void ExpandProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding product menu '{menuName}'");
                By locator = GetProductMenuLocator(menuName);
                WaitHelper.WaitVisible(Driver, locator, 10);
                
                // Hover over menu to expand
                var element = Driver.FindElement(locator);
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                actions.MoveToElement(element).Perform();
                
                // Wait for submenu to appear
                System.Threading.Thread.Sleep(1000); // Brief pause for animation
                LogHelper.Info($"Product menu '{menuName}' expanded");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand product menu '{menuName}': {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, $"ExpandMenu_{menuName}_Error");
                throw;
            }
        }

        /// <summary>
        /// Selects a submenu item.
        /// </summary>
        /// <param name="submenuItem">Name of the submenu item</param>
        public void SelectSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Selecting submenu item '{submenuItem}'");
                By locator = GetSubmenuLocator(submenuItem);
                WaitHelper.WaitClickable(Driver, locator, 10);
                Click(locator);
                WaitForPageLoad();
                LogHelper.Info($"Submenu item '{submenuItem}' selected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item '{submenuItem}': {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, $"SelectSubmenu_{submenuItem}_Error");
                throw;
            }
        }

        /// <summary>
        /// Verifies if submenu items are displayed after expanding a menu.
        /// </summary>
        /// <returns>True if submenu items are visible, false otherwise</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                LogHelper.Info("Checking if submenu items are displayed");
                // Check for any visible submenu link
                By submenuContainer = By.CssSelector(".nav-item-link, .submenu, .dropdown-menu");
                bool isDisplayed = IsDisplayed(submenuContainer, 5);
                LogHelper.Info($"Submenu items displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Submenu items not displayed: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Gets the locator for a top menu option by name.
        /// </summary>
        /// <param name="menuOption">Name of the menu option</param>
        /// <returns>By locator for the menu option</returns>
        private By GetTopMenuLocator(string menuOption)
        {
            return menuOption switch
            {
                "Personal" => PersonalTab,
                "Business" => BusinessTab,
                "Financial Wellness" => FinancialWellnessTab,
                "Appointments" => AppointmentsTab,
                "Locations" => LocationsTab,
                "Membership" => MembershipTab,
                "Help Center" => HelpCenterTab,
                _ => throw new ArgumentException($"Unknown top menu option: {menuOption}")
            };
        }

        /// <summary>
        /// Gets the locator for a product menu by name.
        /// </summary>
        /// <param name="productMenu">Name of the product menu</param>
        /// <returns>By locator for the product menu</returns>
        private By GetProductMenuLocator(string productMenu)
        {
            return productMenu switch
            {
                "Checking" => CheckingMenu,
                "Savings" => SavingsMenu,
                "Home Loans" => HomeLoansMenu,
                "Credit Cards" => CreditCardsMenu,
                "Loans" => LoansMenu,
                "Investing" => InvestingMenu,
                "Community" => CommunityMenu,
                _ => throw new ArgumentException($"Unknown product menu: {productMenu}")
            };
        }

        /// <summary>
        /// Gets the locator for a submenu item by name.
        /// </summary>
        /// <param name="submenuItem">Name of the submenu item</param>
        /// <returns>By locator for the submenu item</returns>
        private By GetSubmenuLocator(string submenuItem)
        {
            return submenuItem switch
            {
                "Free Checking" => FreeCheckingLink,
                "Savings Account" => SavingsAccountLink,
                "Auto Loan" => AutoLoansLink,
                _ => By.XPath($"//a[normalize-space()='{submenuItem}']") // Generic fallback
            };
        }

        #endregion
    }
}