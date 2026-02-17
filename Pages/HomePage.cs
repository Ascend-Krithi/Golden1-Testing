using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the main homepage
    /// Test Cases: TASK0020445 TS-001 through TS-009
    /// </summary>
    public class HomePage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public HomePage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - Using exact locators from Golden1 Locators.Json
        // =============================================================
        
        // Cookie Banner
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Navigation Menu Container
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
        
        // Page Elements
        private By PageLogo => By.CssSelector("img[alt*='Golden 1'], .logo, header img");
        private By PageHeader => By.CssSelector("h1, .hero-title, .page-header");
        private By ErrorMessage => By.CssSelector(".error, .alert-error, [role='alert']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
        /// </summary>
        public void OpenHomePage()
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
                if (IsDisplayed(CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookies accepted");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner not found or already dismissed: {ex.Message}");
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies homepage loaded successfully
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public bool IsHomePageLoaded()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isLoaded = IsDisplayed(MenuContainer);
                LogHelper.Info($"Homepage loaded: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage failed to load: {ex.Message}");
                return false;
            }
        }

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
        /// Verifies top tabs container is visible
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsTopTabsContainerVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, TopTabsContainer, 10);
                bool isVisible = IsDisplayed(TopTabsContainer);
                LogHelper.Info($"Top tabs container visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tabs container not visible: {ex.Message}");
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
        /// Verifies product category menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuClickable(string categoryName)
        {
            try
            {
                By menuLocator = GetProductCategoryMenuLocator(categoryName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                bool isClickable = Driver.FindElement(menuLocator).Enabled;
                LogHelper.Info($"Product category menu '{categoryName}' clickable: {isClickable}");
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menu '{categoryName}' not clickable: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies Golden1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        public bool IsLogoVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageLogo, 10);
                bool isVisible = IsDisplayed(PageLogo);
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
        /// Verifies no error messages are displayed
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool HasNoErrorMessages()
        {
            try
            {
                bool hasErrors = IsDisplayed(ErrorMessage, 2);
                LogHelper.Info($"Error messages present: {hasErrors}");
                return !hasErrors;
            }
            catch (Exception)
            {
                LogHelper.Info("No error messages found on page");
                return true;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Expands a main product category menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void ExpandProductCategoryMenu(string categoryName)
        {
            try
            {
                LogHelper.Info($"Expanding product category menu: {categoryName}");
                By menuLocator = GetProductCategoryMenuLocator(categoryName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                Click(menuLocator);
                WaitHelper.WaitForSeconds(1); // Wait for submenu to expand
                LogHelper.Info($"Product category menu '{categoryName}' expanded");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand product category menu '{categoryName}': {ex.Message}");
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
                By submenuLocator = GetSubmenuItemLocator(submenuItemName);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
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
        /// Verifies submenu items are displayed after expanding menu
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                // Wait for any submenu item to be visible
                WaitHelper.WaitVisible(Driver, FreeCheckingLink, 10);
                bool isDisplayed = IsDisplayed(FreeCheckingLink);
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
        /// Verifies specific submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool IsSubmenuItemSelectable(string submenuItemName)
        {
            try
            {
                By submenuLocator = GetSubmenuItemLocator(submenuItemName);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
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
        // DATA RETRIEVAL METHODS
        // =============================================================
        
        /// <summary>
        /// Gets current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public string GetCurrentPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }

        /// <summary>
        /// Verifies URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public bool DoesUrlContain(string expectedIdentifier)
        {
            string currentUrl = GetCurrentUrl();
            bool contains = currentUrl.Contains(expectedIdentifier);
            LogHelper.Info($"URL contains '{expectedIdentifier}': {contains}");
            return contains;
        }

        // =============================================================
        // HELPER METHODS - Private utility methods
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
                _ => throw new ArgumentException($"Unknown top menu tab: {tabName}")
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
                _ => throw new ArgumentException($"Unknown product category: {categoryName}")
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
                _ => By.XPath($"//a[normalize-space()='{submenuItemName}']") // Dynamic locator for other items
            };
        }
    }
}