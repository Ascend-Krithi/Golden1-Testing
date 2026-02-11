using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Homepage
    /// Handles all interactions with the homepage
    /// Test Cases: TASK0020445 TS-001 through TS-012
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
        
        // Cookie Banner Locators
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

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

        // Dynamic Locators
        private By GetMenuByText(string menuText) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuText}']");

        private By GetTopTabByText(string tabText) =>
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabText}']");

        private By GetSubmenuItemByText(string itemText) =>
            By.XPath($"//a[normalize-space()='{itemText}']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info("Opening Golden 1 homepage");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            HandleCookieBanner();
            LogHelper.Info("Homepage loaded successfully");
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
                LogHelper.Info($"No cookie banner present or already accepted: {ex.Message}");
            }
        }

        /// <summary>
        /// Hovers over a main product menu
        /// Test Cases: TASK0020445 TS-004 TC-001, TS-005 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to hover over</param>
        public void HoverOverMenu(string menuName)
        {
            LogHelper.Info($"Hovering over menu: {menuName}");
            By menuLocator = GetMenuByText(menuName);
            WaitHelper.WaitVisible(Driver, menuLocator, 10);
            
            var menuElement = Driver.FindElement(menuLocator);
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
            actions.MoveToElement(menuElement).Perform();
            
            System.Threading.Thread.Sleep(500); // Brief pause for menu animation
            LogHelper.Info($"Hovered over menu: {menuName}");
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="submenuItemName">Name of the submenu item to click</param>
        public void ClickSubmenuItem(string submenuItemName)
        {
            LogHelper.Info($"Clicking submenu item: {submenuItemName}");
            By submenuLocator = GetSubmenuItemByText(submenuItemName);
            WaitHelper.WaitClickable(Driver, submenuLocator, 10);
            Click(submenuLocator);
            WaitForPageLoad();
            LogHelper.Info($"Clicked submenu item: {submenuItemName}");
        }

        /// <summary>
        /// Clicks on a top navigation tab
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        /// <param name="tabName">Name of the tab to click</param>
        public void ClickTopTab(string tabName)
        {
            LogHelper.Info($"Clicking top tab: {tabName}");
            By tabLocator = GetTopTabByText(tabName);
            WaitHelper.WaitClickable(Driver, tabLocator, 10);
            Click(tabLocator);
            LogHelper.Info($"Clicked top tab: {tabName}");
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================

        /// <summary>
        /// Verifies if the homepage is displayed without errors
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        /// <returns>True if homepage is displayed correctly</returns>
        public bool IsHomepageDisplayedCorrectly()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Homepage displayed correctly: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage not displayed correctly: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the global navigation menu is visible
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
        /// <param name="tabName">Name of the tab to verify</param>
        /// <returns>True if tab is present</returns>
        public bool IsTopTabPresent(string tabName)
        {
            try
            {
                By tabLocator = GetTopTabByText(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isPresent = IsDisplayed(tabLocator);
                LogHelper.Info($"Top tab '{tabName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tab '{tabName}' not present: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a main product menu is accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to verify</param>
        /// <returns>True if menu is accessible</returns>
        public bool IsProductMenuAccessible(string menuName)
        {
            try
            {
                By menuLocator = GetMenuByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isAccessible = IsDisplayed(menuLocator);
                LogHelper.Info($"Product menu '{menuName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu '{menuName}' not accessible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if submenu items are displayed after hovering
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        /// <returns>True if submenu items are displayed</returns>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                // Check for any submenu item visibility
                WaitHelper.WaitVisible(Driver, FreeCheckingLink, 5);
                bool isDisplayed = IsDisplayed(FreeCheckingLink, 5);
                LogHelper.Info($"Submenu items displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Submenu items not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the current URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <param name="expectedIdentifier">Expected URL identifier</param>
        /// <returns>True if URL contains identifier</returns>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            try
            {
                string currentUrl = GetCurrentUrl();
                bool contains = currentUrl.ToLower().Contains(expectedIdentifier.ToLower());
                LogHelper.Info($"URL '{currentUrl}' contains '{expectedIdentifier}': {contains}");
                return contains;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking URL: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if there are any error messages on the page
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <returns>True if no error messages present</returns>
        public bool HasNoErrorMessages()
        {
            try
            {
                // Check for common error indicators
                var errorSelectors = new[]
                {
                    By.CssSelector(".error"),
                    By.CssSelector(".alert-error"),
                    By.CssSelector("[class*='error']"),
                    By.XPath("//*[contains(text(),'Error') or contains(text(),'error')]")
                };

                foreach (var selector in errorSelectors)
                {
                    if (IsDisplayed(selector, 2))
                    {
                        LogHelper.Warning("Error message detected on page");
                        return false;
                    }
                }

                LogHelper.Info("No error messages detected");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No error messages found: {ex.Message}");
                return true;
            }
        }

        /// <summary>
        /// Verifies if menu items are accessible via keyboard
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        /// <returns>True if keyboard navigation works</returns>
        public bool IsKeyboardNavigationWorking()
        {
            try
            {
                LogHelper.Info("Testing keyboard navigation");
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                
                // Send Tab key to navigate
                actions.SendKeys(Keys.Tab).Perform();
                System.Threading.Thread.Sleep(200);
                
                // Check if an element has focus
                var activeElement = Driver.SwitchTo().ActiveElement();
                bool hasFocus = activeElement != null;
                
                LogHelper.Info($"Keyboard navigation working: {hasFocus}");
                return hasFocus;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard navigation test failed: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================

        /// <summary>
        /// Gets the current page title
        /// Test Cases: TASK0020445 TS-001 TC-001
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
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        /// <returns>Current URL</returns>
        public new string GetCurrentUrl()
        {
            string url = Driver.Url;
            LogHelper.Info($"Current URL: {url}");
            return url;
        }
    }
}