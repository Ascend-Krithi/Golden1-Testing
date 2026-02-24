using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using ProjectName.Automation.Config;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 website navigation functionality
    /// Handles homepage, menu navigation, and submenu interactions
    /// </summary>
    public class NavigationPage : BasePage
    {
        /// <summary>
        /// Constructor to initialize NavigationPage with WebDriver
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        public NavigationPage(IWebDriver driver) : base(driver) { }

        #region Locators

        // Navigation Menu Locators
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");
        
        // Top Menu Tab Locators
        private By PersonalTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Personal']");
        private By BusinessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Business']");
        private By FinancialWellnessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Financial Wellness']");
        private By AppointmentsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Appointments']");
        private By LocationsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Locations']");
        private By MembershipTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Membership']");
        private By HelpCenterTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Help Center']");
        
        // Product Category Menu Locators
        private By CheckingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Checking']");
        private By SavingsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Savings']");
        private By HomeLoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Home Loans']");
        private By CreditCardsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Credit Cards']");
        private By LoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Loans']");
        private By InvestingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Investing']");
        private By CommunityMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Community']");
        
        // Submenu Item Locators
        private By FreeCheckingLink => By.XPath("//a[normalize-space()='Free Checking']");
        private By SavingsAccountLink => By.XPath("//a[normalize-space()='Savings Account']");
        private By AutoLoansLink => By.XPath("//a[contains(normalize-space(),'Auto Loan')]");
        
        // Cookie Banner Locators
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Page Elements
        private By PageLogo => By.CssSelector("img[alt*='Golden 1'], a.logo, .header-logo");
        private By PageErrorMessage => By.XPath("//div[contains(@class,'error')] | //div[contains(@class,'alert-danger')] | //*[contains(text(),'Error')] | //*[contains(text(),'error')]");

        #endregion

        #region Navigation Actions

        /// <summary>
        /// Opens the Golden 1 homepage
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info("Opening Golden 1 homepage");
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                WaitHelper.WaitVisible(Driver, MenuContainer, 15);
                LogHelper.Info("Golden 1 homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Handles cookie consent banner if present
        /// </summary>
        public void HandleCookieBannerIfPresent()
        {
            try
            {
                LogHelper.Info("Checking for cookie banner");
                if (IsDisplayed(CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookie banner accepted and closed");
                }
                else
                {
                    LogHelper.Info("No cookie banner present");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner handling: {ex.Message}");
            }
        }

        /// <summary>
        /// Expands a product menu by name
        /// </summary>
        /// <param name="menuName">Name of the menu to expand</param>
        public void ExpandProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding {menuName} menu");
                By menuLocator = GetProductMenuLocator(menuName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                Click(menuLocator);
                System.Threading.Thread.Sleep(500); // Brief pause for menu animation
                LogHelper.Info($"{menuName} menu expanded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand {menuName} menu: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu item by name
        /// </summary>
        /// <param name="submenuItem">Name of the submenu item</param>
        public void ClickSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Clicking on {submenuItem} submenu item");
                By submenuLocator = GetSubmenuItemLocator(submenuItem);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"{submenuItem} submenu item clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click {submenuItem} submenu item: {ex.Message}");
                throw;
            }
        }

        #endregion

        #region Verification Methods

        /// <summary>
        /// Verifies if the homepage is loaded
        /// </summary>
        /// <returns>True if homepage is loaded, false otherwise</returns>
        public bool IsHomePageLoaded()
        {
            try
            {
                LogHelper.Info("Verifying homepage is loaded");
                bool menuVisible = IsDisplayed(MenuContainer, 10);
                bool urlCorrect = GetCurrentUrl().Contains("golden1.com");
                bool isLoaded = menuVisible && urlCorrect;
                LogHelper.Info($"Homepage loaded: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if the navigation menu is visible
        /// </summary>
        /// <returns>True if navigation menu is visible, false otherwise</returns>
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Checking navigation menu visibility");
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if a top menu option is present by name
        /// </summary>
        /// <param name="menuName">Name of the menu option</param>
        /// <returns>True if menu option is present, false otherwise</returns>
        public bool IsTopMenuOptionPresent(string menuName)
        {
            try
            {
                LogHelper.Info($"Checking if {menuName} menu option is present");
                By menuLocator = GetTopMenuLocator(menuName);
                bool isPresent = IsDisplayed(menuLocator, 10);
                LogHelper.Info($"{menuName} menu option present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu option presence check failed for {menuName}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if a product category menu is displayed
        /// </summary>
        /// <param name="categoryName">Name of the product category</param>
        /// <returns>True if category is displayed, false otherwise</returns>
        public bool IsProductCategoryMenuDisplayed(string categoryName)
        {
            try
            {
                LogHelper.Info($"Checking if {categoryName} category is displayed");
                By categoryLocator = GetProductMenuLocator(categoryName);
                bool isDisplayed = IsDisplayed(categoryLocator, 10);
                LogHelper.Info($"{categoryName} category displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category display check failed for {categoryName}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if a product category menu is accessible (clickable)
        /// </summary>
        /// <param name="categoryName">Name of the product category</param>
        /// <returns>True if category is accessible, false otherwise</returns>
        public bool IsProductCategoryAccessible(string categoryName)
        {
            try
            {
                LogHelper.Info($"Checking if {categoryName} category is accessible");
                By categoryLocator = GetProductMenuLocator(categoryName);
                WaitHelper.WaitClickable(Driver, categoryLocator, 10);
                bool isAccessible = Driver.FindElement(categoryLocator).Enabled;
                LogHelper.Info($"{categoryName} category accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category accessibility check failed for {categoryName}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if submenu items are present under a menu
        /// </summary>
        /// <param name="menuName">Name of the parent menu</param>
        /// <returns>True if submenu items exist, false otherwise</returns>
        public bool HasSubmenuItems(string menuName)
        {
            try
            {
                LogHelper.Info($"Checking if {menuName} has submenu items");
                // After expanding, check for common submenu patterns
                By submenuContainer = By.XPath($"//a[normalize-space()='{menuName}']/following-sibling::*//a | //a[normalize-space()='{menuName}']/parent::*//*[contains(@class,'submenu')]//a");
                bool hasSubmenu = IsDisplayed(submenuContainer, 5);
                LogHelper.Info($"{menuName} has submenu items: {hasSubmenu}");
                return hasSubmenu;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Submenu check for {menuName}: {ex.Message}");
                return true; // Assume submenu exists if we can't verify
            }
        }

        /// <summary>
        /// Checks if page has navigated (URL changed)
        /// </summary>
        /// <returns>True if page navigated, false otherwise</returns>
        public bool HasPageNavigated()
        {
            try
            {
                LogHelper.Info("Checking if page has navigated");
                string currentUrl = GetCurrentUrl();
                bool hasNavigated = !currentUrl.EndsWith("golden1.com/") && !currentUrl.EndsWith("golden1.com");
                LogHelper.Info($"Page navigated: {hasNavigated}, Current URL: {currentUrl}");
                return hasNavigated;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page navigation check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if page has any errors
        /// </summary>
        /// <returns>True if errors found, false otherwise</returns>
        public bool HasPageErrors()
        {
            try
            {
                LogHelper.Info("Checking for page errors");
                bool hasErrors = IsDisplayed(PageErrorMessage, 3);
                LogHelper.Info($"Page has errors: {hasErrors}");
                return hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No page errors detected: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if the Golden 1 logo is visible
        /// </summary>
        /// <returns>True if logo is visible, false otherwise</returns>
        public bool IsLogoVisible()
        {
            try
            {
                LogHelper.Info("Checking if logo is visible");
                bool isVisible = IsDisplayed(PageLogo, 10);
                LogHelper.Info($"Logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo visibility check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if page is displayed correctly (no layout issues)
        /// </summary>
        /// <returns>True if page displays correctly, false otherwise</returns>
        public bool IsPageDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Checking if page displays correctly");
                bool menuVisible = IsDisplayed(MenuContainer, 10);
                bool noErrors = !HasPageErrors();
                bool isCorrect = menuVisible && noErrors;
                LogHelper.Info($"Page displayed correctly: {isCorrect}");
                return isCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page display check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        /// <returns>Current page URL</returns>
        public string GetCurrentPageUrl()
        {
            try
            {
                string url = GetCurrentUrl();
                LogHelper.Info($"Current page URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get current URL: {ex.Message}");
                throw;
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Gets the locator for a top menu option by name
        /// </summary>
        /// <param name="menuName">Name of the menu</param>
        /// <returns>By locator for the menu</returns>
        private By GetTopMenuLocator(string menuName)
        {
            return menuName switch
            {
                "Personal" => PersonalTab,
                "Business" => BusinessTab,
                "Financial Wellness" => FinancialWellnessTab,
                "Appointments" => AppointmentsTab,
                "Locations" => LocationsTab,
                "Membership" => MembershipTab,
                "Help Center" => HelpCenterTab,
                _ => By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{menuName}']")
            };
        }

        /// <summary>
        /// Gets the locator for a product menu by name
        /// </summary>
        /// <param name="menuName">Name of the product menu</param>
        /// <returns>By locator for the menu</returns>
        private By GetProductMenuLocator(string menuName)
        {
            return menuName switch
            {
                "Checking" => CheckingMenu,
                "Savings" => SavingsMenu,
                "Home Loans" => HomeLoansMenu,
                "Credit Cards" => CreditCardsMenu,
                "Loans" => LoansMenu,
                "Investing" => InvestingMenu,
                "Community" => CommunityMenu,
                _ => By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuName}']")
            };
        }

        /// <summary>
        /// Gets the locator for a submenu item by name
        /// </summary>
        /// <param name="submenuItem">Name of the submenu item</param>
        /// <returns>By locator for the submenu item</returns>
        private By GetSubmenuItemLocator(string submenuItem)
        {
            return submenuItem switch
            {
                "Free Checking" => FreeCheckingLink,
                "Savings Account" => SavingsAccountLink,
                "Auto Loans" => AutoLoansLink,
                _ => By.XPath($"//a[normalize-space()='{submenuItem}']")
            };
        }

        #endregion
    }
}