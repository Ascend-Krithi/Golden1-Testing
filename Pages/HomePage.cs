using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the Golden1 homepage
    /// Test Cases: TASK0020445 TS-001 to TS-012
    /// </summary>
    public class HomePage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public HomePage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators from Golden1 Locators.Json
        // =============================================================
        
        // Logo
        private By Golden1Logo => By.CssSelector("a.logo");
        
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
        
        // Overlay Elements
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        // Page Content
        private By PageContent => By.CssSelector("main, .main-content");
        private By ErrorMessages => By.CssSelector(".error, .alert-error, .error-message");
        
        // Dynamic Locators
        private By GetTopNavigationTabByText(string tabText) =>
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabText}']");
        
        private By GetProductMenuByText(string menuText) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuText}']");
        
        private By GetSubmenuItemByText(string submenuText) =>
            By.XPath($"//a[normalize-space()='{submenuText}']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info("Opening Golden1 homepage");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            HandleCookieBanner();
            LogHelper.Info("Golden1 homepage loaded successfully");
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
                    LogHelper.Info("Cookie banner accepted and closed");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner not found or already dismissed: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Hovers over a product menu to display submenu items
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <param name="menuName">Name of the product menu</param>
        public void HoverOverProductMenu(string menuName)
        {
            LogHelper.Info($"Hovering over product menu: {menuName}");
            By menuLocator = GetProductMenuByText(menuName);
            WaitHelper.WaitVisible(Driver, menuLocator, 10);
            
            var menuElement = Driver.FindElement(menuLocator);
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
            actions.MoveToElement(menuElement).Perform();
            
            System.Threading.Thread.Sleep(500); // Allow submenu animation
            LogHelper.Info($"Hovered over {menuName} menu successfully");
        }
        
        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001
        /// </summary>
        /// <param name="submenuItemName">Name of the submenu item</param>
        public void ClickSubmenuItem(string submenuItemName)
        {
            LogHelper.Info($"Clicking submenu item: {submenuItemName}");
            By submenuLocator = GetSubmenuItemByText(submenuItemName);
            WaitHelper.WaitVisible(Driver, submenuLocator, 10);
            WaitHelper.WaitClickable(Driver, submenuLocator, 10);
            Click(submenuLocator);
            WaitForPageLoad();
            LogHelper.Info($"Clicked submenu item: {submenuItemName}");
        }
        
        /// <summary>
        /// Uses keyboard to navigate to menu
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void NavigateToMenuUsingKeyboard()
        {
            LogHelper.Info("Navigating to menu using keyboard");
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
            
            // Tab to navigation menu
            for (int i = 0; i < 5; i++)
            {
                actions.SendKeys(Keys.Tab).Perform();
                System.Threading.Thread.Sleep(200);
            }
            
            LogHelper.Info("Navigated to menu using keyboard");
        }
        
        /// <summary>
        /// Presses Enter key on focused element
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void PressEnterKey()
        {
            LogHelper.Info("Pressing Enter key");
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
            actions.SendKeys(Keys.Enter).Perform();
            System.Threading.Thread.Sleep(500);
            LogHelper.Info("Enter key pressed");
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if homepage is displayed without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        /// <returns>True if homepage is visible without errors</returns>
        public bool IsHomepageDisplayedWithoutErrors()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageContent, 10);
                bool isContentVisible = IsDisplayed(PageContent);
                bool hasNoErrors = !IsDisplayed(ErrorMessages, 2);
                
                bool result = isContentVisible && hasNoErrors;
                LogHelper.Info($"Homepage displayed without errors: {result}");
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking homepage display: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        /// <returns>True if navigation menu is visible</returns>
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
        /// Verifies if a specific top navigation tab is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="tabName">Name of the tab</param>
        /// <returns>True if tab is present</returns>
        public bool IsTopNavigationTabPresent(string tabName)
        {
            try
            {
                By tabLocator = GetTopNavigationTabByText(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isPresent = IsDisplayed(tabLocator);
                LogHelper.Info($"Top navigation tab '{tabName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top navigation tab '{tabName}' not found: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if a product category menu is accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="categoryName">Name of the product category</param>
        /// <returns>True if category is accessible</returns>
        public bool IsProductCategoryAccessible(string categoryName)
        {
            try
            {
                By categoryLocator = GetProductMenuByText(categoryName);
                WaitHelper.WaitVisible(Driver, categoryLocator, 10);
                bool isAccessible = IsDisplayed(categoryLocator);
                LogHelper.Info($"Product category '{categoryName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category '{categoryName}' not accessible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <returns>True if submenu is visible</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                // Check if any submenu item is visible
                bool isDisplayed = IsDisplayed(FreeCheckingLink, 5) || 
                                 IsDisplayed(SavingsAccountLink, 5) || 
                                 IsDisplayed(AutoLoansLink, 5);
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
        /// Verifies if Golden1 logo is visible
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
        /// Verifies if page content displays correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if content displays correctly</returns>
        public bool IsContentDisplayedCorrectly()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageContent, 10);
                bool hasContent = IsDisplayed(PageContent);
                bool hasNoErrors = !IsDisplayed(ErrorMessages, 2);
                
                bool result = hasContent && hasNoErrors;
                LogHelper.Info($"Content displayed correctly: {result}");
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content display check failed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if there are no broken layouts or error messages
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no errors found</returns>
        public bool HasNoBrokenLayoutsOrErrors()
        {
            try
            {
                bool hasNoErrors = !IsDisplayed(ErrorMessages, 2);
                LogHelper.Info($"No broken layouts or errors: {hasNoErrors}");
                return hasNoErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for broken layouts: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if URL contains expected page identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="expectedIdentifier">Expected URL identifier</param>
        /// <returns>True if URL contains identifier</returns>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            try
            {
                string currentUrl = GetCurrentUrl();
                bool containsIdentifier = currentUrl.Contains(expectedIdentifier, StringComparison.OrdinalIgnoreCase);
                LogHelper.Info($"URL '{currentUrl}' contains '{expectedIdentifier}': {containsIdentifier}");
                return containsIdentifier;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking URL identifier: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if destination page loaded completely
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        /// <returns>True if page loaded</returns>
        public bool IsDestinationPageLoaded()
        {
            try
            {
                WaitForPageLoad();
                WaitHelper.WaitVisible(Driver, PageContent, 15);
                bool isLoaded = IsDisplayed(PageContent);
                LogHelper.Info($"Destination page loaded: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page not loaded: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================
        
        /// <summary>
        /// Gets the current page title
        /// </summary>
        /// <returns>Page title</returns>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            LogHelper.Info($"Page title: {title}");
            return title;
        }
        
        /// <summary>
        /// Gets the current page URL
        /// </summary>
        /// <returns>Current URL</returns>
        public string GetPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current URL: {url}");
            return url;
        }
    }
}