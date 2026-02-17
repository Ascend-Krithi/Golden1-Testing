using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the homepage
    /// Test Cases: TASK0020445 TS-001 through TS-009
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
        
        // Logo
        private By Golden1Logo => By.CssSelector("a.logo, .header-logo, img[alt*='Golden 1']");
        
        // Navigation Menu Container
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
        
        // Cookie Banner
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Error Messages
        private By ErrorMessage => By.CssSelector(".error-message, .alert-error, [class*='error']");
        
        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info("Opening Golden1 homepage");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            HandleCookieBanner();
            LogHelper.Info("Golden1 homepage opened successfully");
        }
        
        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
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
                LogHelper.Info($"No cookie banner present or already handled: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Expands a main product menu by name
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001
        /// </summary>
        public void ExpandProductMenu(string menuName)
        {
            LogHelper.Info($"Expanding '{menuName}' menu");
            By menuLocator = GetMenuLocatorByName(menuName);
            WaitHelper.WaitVisible(Driver, menuLocator, 10);
            WaitHelper.WaitClickable(Driver, menuLocator, 10);
            Click(menuLocator);
            System.Threading.Thread.Sleep(500); // Brief pause for submenu animation
            LogHelper.Info($"'{menuName}' menu expanded");
        }
        
        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001
        /// </summary>
        public void ClickSubmenuItem(string submenuItemName)
        {
            LogHelper.Info($"Clicking submenu item: '{submenuItemName}'");
            By submenuLocator = GetSubmenuLocatorByName(submenuItemName);
            WaitHelper.WaitVisible(Driver, submenuLocator, 10);
            WaitHelper.WaitClickable(Driver, submenuLocator, 10);
            Click(submenuLocator);
            WaitForPageLoad();
            LogHelper.Info($"Submenu item '{submenuItemName}' clicked");
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
                LogHelper.Info("Verifying homepage loaded");
                WaitForPageLoad();
                bool isLoaded = Driver.Url.Contains("golden1.com");
                LogHelper.Info($"Homepage loaded status: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies no error messages are displayed
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        public bool HasNoErrors()
        {
            try
            {
                LogHelper.Info("Checking for error messages");
                bool hasErrors = IsDisplayed(ErrorMessage, 2);
                LogHelper.Info($"Error messages present: {hasErrors}");
                return !hasErrors;
            }
            catch
            {
                LogHelper.Info("No error messages found");
                return true;
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
                LogHelper.Info("Verifying navigation menu visibility");
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
        /// Verifies specific top tab menu option is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsTopTabMenuOptionPresent(string optionName)
        {
            try
            {
                LogHelper.Info($"Verifying top tab menu option: '{optionName}'");
                By optionLocator = GetTopTabLocatorByName(optionName);
                WaitHelper.WaitVisible(Driver, optionLocator, 10);
                bool isPresent = IsDisplayed(optionLocator);
                LogHelper.Info($"Top tab '{optionName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tab '{optionName}' not found: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies main product category menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuDisplayed(string menuName)
        {
            try
            {
                LogHelper.Info($"Verifying product category menu: '{menuName}'");
                By menuLocator = GetMenuLocatorByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isDisplayed = IsDisplayed(menuLocator);
                LogHelper.Info($"Product menu '{menuName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu '{menuName}' not found: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies product category menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsProductCategoryMenuClickable(string menuName)
        {
            try
            {
                LogHelper.Info($"Verifying product menu '{menuName}' is clickable");
                By menuLocator = GetMenuLocatorByName(menuName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                bool isClickable = Driver.FindElement(menuLocator).Enabled;
                LogHelper.Info($"Product menu '{menuName}' clickable: {isClickable}");
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu '{menuName}' not clickable: {ex.Message}");
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
                LogHelper.Info("Verifying submenu items are displayed");
                // Wait for any submenu link to be visible
                WaitHelper.WaitVisible(Driver, By.CssSelector("a[class*='submenu'], .dropdown-item, .nav-submenu a"), 10);
                bool areDisplayed = Driver.FindElements(By.CssSelector("a[class*='submenu'], .dropdown-item, .nav-submenu a")).Count > 0;
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
        /// Verifies Golden1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        public bool IsLogoVisible()
        {
            try
            {
                LogHelper.Info("Verifying Golden1 logo visibility");
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
        /// Verifies page displays correctly without layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool IsPageDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying page displays correctly");
                WaitForPageLoad();
                
                // Check multiple key elements are visible
                bool logoVisible = IsDisplayed(Golden1Logo, 5);
                bool menuVisible = IsDisplayed(MenuContainer, 5);
                bool noErrors = HasNoErrors();
                
                bool isCorrect = logoVisible && menuVisible && noErrors;
                LogHelper.Info($"Page displayed correctly: {isCorrect}");
                return isCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page display verification failed: {ex.Message}");
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
        public string GetPageUrl()
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
            try
            {
                string currentUrl = GetCurrentUrl();
                bool contains = currentUrl.Contains(expectedIdentifier);
                LogHelper.Info($"URL contains '{expectedIdentifier}': {contains}");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                return false;
            }
        }
        
        // =============================================================
        // HELPER METHODS
        // =============================================================
        
        /// <summary>
        /// Gets locator for top tab menu by name
        /// </summary>
        private By GetTopTabLocatorByName(string tabName)
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
                _ => throw new ArgumentException($"Unknown top tab menu: {tabName}")
            };
        }
        
        /// <summary>
        /// Gets locator for main product menu by name
        /// </summary>
        private By GetMenuLocatorByName(string menuName)
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
                _ => throw new ArgumentException($"Unknown menu: {menuName}")
            };
        }
        
        /// <summary>
        /// Gets locator for submenu item by name
        /// </summary>
        private By GetSubmenuLocatorByName(string submenuName)
        {
            return submenuName switch
            {
                "Free Checking" => FreeCheckingLink,
                "Savings Account" => SavingsAccountLink,
                "Auto Loans" => AutoLoansLink,
                _ => By.XPath($"//a[normalize-space()='{submenuName}']") // Dynamic fallback
            };
        }
    }
}