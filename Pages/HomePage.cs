using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Homepage
    /// Handles all interactions with the homepage
    /// Test Cases: TASK0020445 TS-001 to TS-011
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
        
        // Logo locator (assuming standard header structure)
        private By Golden1Logo => By.CssSelector("header .logo, .header__logo, [class*='logo']");
        
        // Navigation Menu Container
        private By MenuContainer => By.CssSelector("nav.menu");
        
        // Top Tabs Navigation
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");
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
        
        // Error and Layout Elements
        private By ErrorMessages => By.CssSelector(".error, .alert-danger, [class*='error']");
        private By PageContent => By.CssSelector("main, .main-content, #main-content");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info($"Opening Golden 1 homepage: {ConfigReader.BaseUrl}");
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
                LogHelper.Info($"No cookie banner found or already dismissed: {ex.Message}");
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
            By menuLocator = GetMenuLocator(menuName);
            WaitHelper.WaitVisible(Driver, menuLocator, 10);
            HoverOverElement(menuLocator);
            System.Threading.Thread.Sleep(500); // Brief pause for submenu to appear
            LogHelper.Info($"Hovered over {menuName} menu");
        }
        
        /// <summary>
        /// Clicks on a main product menu
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to click</param>
        public void ClickMenu(string menuName)
        {
            LogHelper.Info($"Clicking menu: {menuName}");
            By menuLocator = GetMenuLocator(menuName);
            WaitHelper.WaitClickable(Driver, menuLocator, 10);
            Click(menuLocator);
            LogHelper.Info($"Clicked {menuName} menu");
        }
        
        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        /// <param name="submenuName">Name of the submenu item to click</param>
        public void ClickSubmenuItem(string submenuName)
        {
            LogHelper.Info($"Clicking submenu item: {submenuName}");
            By submenuLocator = GetSubmenuLocator(submenuName);
            WaitHelper.WaitClickable(Driver, submenuLocator, 10);
            Click(submenuLocator);
            WaitForPageLoad();
            LogHelper.Info($"Clicked submenu item: {submenuName}");
        }
        
        /// <summary>
        /// Hovers over an element using Actions class
        /// </summary>
        private void HoverOverElement(By locator)
        {
            var element = Driver.FindElement(locator);
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
            actions.MoveToElement(element).Perform();
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if the navigation menu is visible
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
        /// Verifies if the Golden 1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        public bool IsLogoVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, Golden1Logo, 10);
                bool isVisible = IsDisplayed(Golden1Logo);
                LogHelper.Info($"Golden 1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Golden 1 logo not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if a top menu tab is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsTopMenuTabPresent(string tabName)
        {
            try
            {
                By tabLocator = GetTopTabLocator(tabName);
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
        /// Verifies if a main product menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsMainProductMenuDisplayed(string menuName)
        {
            try
            {
                By menuLocator = GetMenuLocator(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isDisplayed = IsDisplayed(menuLocator);
                LogHelper.Info($"Main product menu '{menuName}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main product menu '{menuName}' not displayed: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if a main product menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsMainProductMenuClickable(string menuName)
        {
            try
            {
                By menuLocator = GetMenuLocator(menuName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                var element = Driver.FindElement(menuLocator);
                bool isClickable = element.Enabled && element.Displayed;
                LogHelper.Info($"Main product menu '{menuName}' clickable: {isClickable}");
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main product menu '{menuName}' not clickable: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if submenu items are displayed after hovering
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                // Check for common submenu container patterns
                By submenuContainer = By.CssSelector(".submenu, .dropdown-menu, [class*='submenu'], [class*='dropdown']");
                WaitHelper.WaitVisible(Driver, submenuContainer, 5);
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
        /// Verifies if there are any error messages on the page
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        public bool AreErrorMessagesPresent()
        {
            try
            {
                var errorElements = Driver.FindElements(ErrorMessages);
                bool hasErrors = errorElements.Count > 0 && errorElements.Any(e => e.Displayed);
                LogHelper.Info($"Error messages present: {hasErrors}");
                return hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No error messages found: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if page content is loaded
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool IsPageContentLoaded()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PageContent, 10);
                bool isLoaded = IsDisplayed(PageContent);
                LogHelper.Info($"Page content loaded: {isLoaded}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page content not loaded: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if there are layout issues on the page
        /// Test Cases: TASK0020445 TS-009 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        public bool HasLayoutIssues()
        {
            try
            {
                // Check if main structural elements are present
                bool menuVisible = IsDisplayed(MenuContainer, 5);
                bool contentVisible = IsDisplayed(PageContent, 5);
                bool logoVisible = IsDisplayed(Golden1Logo, 5);
                
                bool hasIssues = !menuVisible || !contentVisible || !logoVisible;
                LogHelper.Info($"Page has layout issues: {hasIssues}");
                return hasIssues;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking layout: {ex.Message}");
                return true;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================
        
        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public string GetPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }
        
        /// <summary>
        /// Gets the page title
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            LogHelper.Info($"Page title: {title}");
            return title;
        }

        // =============================================================
        // HELPER METHODS
        // =============================================================
        
        /// <summary>
        /// Gets the locator for a top tab by name
        /// </summary>
        private By GetTopTabLocator(string tabName)
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
                _ => throw new ArgumentException($"Unknown top tab: {tabName}")
            };
        }
        
        /// <summary>
        /// Gets the locator for a main menu by name
        /// </summary>
        private By GetMenuLocator(string menuName)
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
        /// Gets the locator for a submenu item by name
        /// </summary>
        private By GetSubmenuLocator(string submenuName)
        {
            return submenuName switch
            {
                "Free Checking" => FreeCheckingLink,
                "Savings Account" => SavingsAccountLink,
                "Auto Loans" => AutoLoansLink,
                _ => By.XPath($"//a[normalize-space()='{submenuName}']") // Generic fallback
            };
        }
    }
}