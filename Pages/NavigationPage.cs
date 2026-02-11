using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Navigation
    /// Handles all interactions with main navigation menu and top tabs
    /// Test Cases: TASK0020445 TS-001 to TS-009
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - Navigation Elements
        // =============================================================
        
        // Main Menu Container
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

        // Main Menu Items
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
            LogHelper.Info($"Homepage opened successfully: {GetCurrentUrl()}");
        }

        /// <summary>
        /// Accepts cookies if banner is displayed
        /// Test Cases: All scenarios - Background step
        /// </summary>
        public void AcceptCookiesIfDisplayed()
        {
            try
            {
                LogHelper.Info("Checking for cookie banner");
                if (IsDisplayed(CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner found, clicking accept button");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    LogHelper.Info("Cookies accepted successfully");
                }
                else
                {
                    LogHelper.Info("Cookie banner not displayed");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner handling: {ex.Message}");
            }
        }

        // =============================================================
        // TOP TAB NAVIGATION METHODS
        // =============================================================

        /// <summary>
        /// Clicks on a top navigation tab by name
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        /// <param name="tabName">Name of the tab to click</param>
        public void ClickTopTab(string tabName)
        {
            LogHelper.Info($"Clicking on top tab: {tabName}");
            By tabLocator = GetTopTabLocator(tabName);
            WaitHelper.WaitVisible(Driver, tabLocator, 10);
            WaitHelper.WaitClickable(Driver, tabLocator, 10);
            Click(tabLocator);
            WaitForPageLoad();
            LogHelper.Info($"Successfully clicked on {tabName} tab");
        }

        /// <summary>
        /// Gets the locator for a specific top tab
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
                _ => throw new ArgumentException($"Unknown tab name: {tabName}")
            };
        }

        // =============================================================
        // MAIN MENU NAVIGATION METHODS
        // =============================================================

        /// <summary>
        /// Clicks on a main menu item by name
        /// Test Cases: TASK0020445 TS-004, TS-006, TS-008 TC-001
        /// </summary>
        /// <param name="menuName">Name of the menu to click</param>
        public void ClickMainMenu(string menuName)
        {
            LogHelper.Info($"Clicking on main menu: {menuName}");
            By menuLocator = GetMainMenuLocator(menuName);
            WaitHelper.WaitVisible(Driver, menuLocator, 10);
            WaitHelper.WaitClickable(Driver, menuLocator, 10);
            Click(menuLocator);
            System.Threading.Thread.Sleep(1000); // Allow submenu to appear
            LogHelper.Info($"Successfully clicked on {menuName} menu");
        }

        /// <summary>
        /// Gets the locator for a specific main menu item
        /// </summary>
        private By GetMainMenuLocator(string menuName)
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
                _ => throw new ArgumentException($"Unknown menu name: {menuName}")
            };
        }

        // =============================================================
        // SUBMENU NAVIGATION METHODS
        // =============================================================

        /// <summary>
        /// Clicks on a submenu link by name
        /// Test Cases: TASK0020445 TS-005, TS-007 TC-001
        /// </summary>
        /// <param name="linkName">Name of the link to click</param>
        public void ClickSubmenuLink(string linkName)
        {
            LogHelper.Info($"Clicking on submenu link: {linkName}");
            By linkLocator = GetSubmenuLinkLocator(linkName);
            WaitHelper.WaitVisible(Driver, linkLocator, 10);
            WaitHelper.WaitClickable(Driver, linkLocator, 10);
            Click(linkLocator);
            WaitForPageLoad();
            LogHelper.Info($"Successfully clicked on {linkName} link");
        }

        /// <summary>
        /// Gets the locator for a specific submenu link
        /// </summary>
        private By GetSubmenuLinkLocator(string linkName)
        {
            return linkName switch
            {
                "Free Checking" => FreeCheckingLink,
                "Savings Account" => SavingsAccountLink,
                "Auto Loans" => AutoLoansLink,
                _ => throw new ArgumentException($"Unknown link name: {linkName}")
            };
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================

        /// <summary>
        /// Verifies main navigation menu is visible
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public bool IsMainMenuVisible()
        {
            try
            {
                LogHelper.Info("Verifying main navigation menu visibility");
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Main menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main menu not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies top tabs container is visible
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public bool IsTopTabsVisible()
        {
            try
            {
                LogHelper.Info("Verifying top tabs visibility");
                WaitHelper.WaitVisible(Driver, TopTabsContainer, 10);
                bool isVisible = IsDisplayed(TopTabsContainer);
                LogHelper.Info($"Top tabs visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tabs not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies a specific top tab is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        public bool IsTopTabVisible(string tabName)
        {
            try
            {
                LogHelper.Info($"Verifying {tabName} tab visibility");
                By tabLocator = GetTopTabLocator(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isVisible = IsDisplayed(tabLocator);
                LogHelper.Info($"{tabName} tab visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"{tabName} tab not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies a specific main menu option is visible
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsMainMenuOptionVisible(string menuName)
        {
            try
            {
                LogHelper.Info($"Verifying {menuName} menu option visibility");
                By menuLocator = GetMainMenuLocator(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isVisible = IsDisplayed(menuLocator);
                LogHelper.Info($"{menuName} menu option visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"{menuName} menu option not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies a specific submenu link is visible
        /// Test Cases: TASK0020445 TS-004, TS-006, TS-008 TC-001
        /// </summary>
        public bool IsSubmenuLinkVisible(string linkName)
        {
            try
            {
                LogHelper.Info($"Verifying {linkName} link visibility");
                By linkLocator = GetSubmenuLinkLocator(linkName);
                WaitHelper.WaitVisible(Driver, linkLocator, 10);
                bool isVisible = IsDisplayed(linkLocator);
                LogHelper.Info($"{linkName} link visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"{linkName} link not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies user is on a specific page by checking URL
        /// Test Cases: TASK0020445 TS-005, TS-007, TS-009 TC-001
        /// </summary>
        public bool IsOnPage(string pageName)
        {
            try
            {
                LogHelper.Info($"Verifying user is on {pageName} page");
                string currentUrl = GetCurrentUrl().ToLower();
                string expectedUrlPart = pageName.ToLower().replace(" ", "-");
                bool isOnPage = currentUrl.Contains(expectedUrlPart);
                LogHelper.Info($"Current URL: {currentUrl}, Expected part: {expectedUrlPart}, Match: {isOnPage}");
                return isOnPage;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verifying page: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================

        /// <summary>
        /// Gets the current page title
        /// </summary>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            LogHelper.Info($"Page title: {title}");
            return title;
        }

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        public string GetPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current URL: {url}");
            return url;
        }
    }
}