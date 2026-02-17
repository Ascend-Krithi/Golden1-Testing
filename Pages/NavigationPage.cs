using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Website Navigation
    /// Handles all interactions with main navigation menu and top tabs
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
        
        // Menu Container
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

        // Main Menu Options
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
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info("Opening Golden1 homepage");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            LogHelper.Info($"Homepage opened successfully: {ConfigReader.BaseUrl}");
        }

        /// <summary>
        /// Handles cookie consent banner if displayed
        /// </summary>
        public void AcceptCookiesIfDisplayed()
        {
            try
            {
                LogHelper.Info("Checking for cookie consent banner");
                if (WaitHelper.WaitVisible(Driver, CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner is displayed, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    LogHelper.Info("Cookies accepted successfully");
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
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
        /// </summary>
        /// <param name="tabName">Name of the tab (Personal, Business, etc.)</param>
        public void ClickTopTab(string tabName)
        {
            LogHelper.Info($"Clicking on top tab: {tabName}");
            By tabLocator = GetTopTabLocator(tabName);
            WaitHelper.WaitVisible(Driver, tabLocator, 10);
            WaitHelper.WaitClickable(Driver, tabLocator, 10);
            Click(tabLocator);
            LogHelper.Info($"Successfully clicked on {tabName} tab");
        }

        /// <summary>
        /// Gets the locator for a specific top tab
        /// </summary>
        private By GetTopTabLocator(string tabName)
        {
            return tabName.ToLower() switch
            {
                "personal" => PersonalTab,
                "business" => BusinessTab,
                "financial wellness" => FinancialWellnessTab,
                "appointments" => AppointmentsTab,
                "locations" => LocationsTab,
                "membership" => MembershipTab,
                "help center" => HelpCenterTab,
                _ => throw new ArgumentException($"Unknown tab name: {tabName}")
            };
        }

        // =============================================================
        // MAIN MENU NAVIGATION METHODS
        // =============================================================

        /// <summary>
        /// Clicks on a main menu option by name
        /// </summary>
        /// <param name="menuName">Name of the menu (Checking, Savings, etc.)</param>
        public void ClickMainMenu(string menuName)
        {
            LogHelper.Info($"Clicking on main menu: {menuName}");
            By menuLocator = GetMainMenuLocator(menuName);
            WaitHelper.WaitVisible(Driver, menuLocator, 10);
            WaitHelper.WaitClickable(Driver, menuLocator, 10);
            Click(menuLocator);
            LogHelper.Info($"Successfully clicked on {menuName} menu");
            WaitForPageLoad();
        }

        /// <summary>
        /// Gets the locator for a specific main menu
        /// </summary>
        private By GetMainMenuLocator(string menuName)
        {
            return menuName.ToLower() switch
            {
                "checking" => CheckingMenu,
                "savings" => SavingsMenu,
                "home loans" => HomeLoansMenu,
                "credit cards" => CreditCardsMenu,
                "loans" => LoansMenu,
                "investing" => InvestingMenu,
                "community" => CommunityMenu,
                _ => throw new ArgumentException($"Unknown menu name: {menuName}")
            };
        }

        // =============================================================
        // SUBMENU NAVIGATION METHODS
        // =============================================================

        /// <summary>
        /// Clicks on a submenu link by name
        /// </summary>
        /// <param name="linkName">Name of the link</param>
        public void ClickSubmenuLink(string linkName)
        {
            LogHelper.Info($"Clicking on submenu link: {linkName}");
            By linkLocator = GetSubmenuLinkLocator(linkName);
            WaitHelper.WaitVisible(Driver, linkLocator, 10);
            WaitHelper.WaitClickable(Driver, linkLocator, 10);
            Click(linkLocator);
            LogHelper.Info($"Successfully clicked on {linkName} link");
            WaitForPageLoad();
        }

        /// <summary>
        /// Gets the locator for a specific submenu link
        /// </summary>
        private By GetSubmenuLinkLocator(string linkName)
        {
            return linkName.ToLower() switch
            {
                "free checking" => FreeCheckingLink,
                "savings account" => SavingsAccountLink,
                "auto loan" => AutoLoansLink,
                _ => throw new ArgumentException($"Unknown link name: {linkName}")
            };
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================

        /// <summary>
        /// Verifies if menu container is visible
        /// </summary>
        public bool IsMenuContainerVisible()
        {
            try
            {
                LogHelper.Info("Checking if menu container is visible");
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Menu container visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu container not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a specific top tab is visible
        /// </summary>
        public bool IsTopTabVisible(string tabName)
        {
            try
            {
                LogHelper.Info($"Checking if {tabName} tab is visible");
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
        /// Verifies if all specified tabs are visible
        /// </summary>
        public bool AreAllTabsVisible(List<string> tabNames)
        {
            LogHelper.Info($"Verifying visibility of {tabNames.Count} tabs");
            bool allVisible = true;
            
            foreach (string tabName in tabNames)
            {
                if (!IsTopTabVisible(tabName))
                {
                    allVisible = false;
                    LogHelper.Error($"Tab not visible: {tabName}");
                }
            }
            
            LogHelper.Info($"All tabs visible: {allVisible}");
            return allVisible;
        }

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        public string GetPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }

        /// <summary>
        /// Gets the current page title
        /// </summary>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            LogHelper.Info($"Current page title: {title}");
            return title;
        }

        /// <summary>
        /// Verifies if URL contains expected text
        /// </summary>
        public bool DoesUrlContain(string expectedText)
        {
            string currentUrl = GetPageUrl();
            bool contains = currentUrl.ToLower().Contains(expectedText.ToLower());
            LogHelper.Info($"URL contains '{expectedText}': {contains}");
            return contains;
        }

        /// <summary>
        /// Verifies if page title contains expected text
        /// </summary>
        public bool DoesTitleContain(string expectedText)
        {
            string currentTitle = GetPageTitle();
            bool contains = currentTitle.ToLower().Contains(expectedText.ToLower());
            LogHelper.Info($"Title contains '{expectedText}': {contains}");
            return contains;
        }
    }
}