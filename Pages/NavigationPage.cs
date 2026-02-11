using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Navigation Menu
    /// Handles all interactions with the main navigation and top tabs
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators from Golden1 Locators.Json
        // =============================================================
        
        // Menu Container
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");
        
        // Top Tabs
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
        
        // Overlay Elements
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
            LogHelper.Info($"Opening Golden1 homepage: {ConfigReader.BaseUrl}");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            HandleCookieBanner();
        }

        // =============================================================
        // INTERACTION METHODS - Top Tabs
        // =============================================================
        
        /// <summary>
        /// Clicks on the Personal tab in top navigation
        /// </summary>
        public void ClickPersonalTab()
        {
            LogHelper.Info("Clicking Personal tab");
            WaitHelper.WaitVisible(Driver, PersonalTab, 10);
            Click(PersonalTab);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Business tab in top navigation
        /// </summary>
        public void ClickBusinessTab()
        {
            LogHelper.Info("Clicking Business tab");
            WaitHelper.WaitVisible(Driver, BusinessTab, 10);
            Click(BusinessTab);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Financial Wellness tab in top navigation
        /// </summary>
        public void ClickFinancialWellnessTab()
        {
            LogHelper.Info("Clicking Financial Wellness tab");
            WaitHelper.WaitVisible(Driver, FinancialWellnessTab, 10);
            Click(FinancialWellnessTab);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Appointments tab in top navigation
        /// </summary>
        public void ClickAppointmentsTab()
        {
            LogHelper.Info("Clicking Appointments tab");
            WaitHelper.WaitVisible(Driver, AppointmentsTab, 10);
            Click(AppointmentsTab);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Locations tab in top navigation
        /// </summary>
        public void ClickLocationsTab()
        {
            LogHelper.Info("Clicking Locations tab");
            WaitHelper.WaitVisible(Driver, LocationsTab, 10);
            Click(LocationsTab);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Membership tab in top navigation
        /// </summary>
        public void ClickMembershipTab()
        {
            LogHelper.Info("Clicking Membership tab");
            WaitHelper.WaitVisible(Driver, MembershipTab, 10);
            Click(MembershipTab);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Help Center tab in top navigation
        /// </summary>
        public void ClickHelpCenterTab()
        {
            LogHelper.Info("Clicking Help Center tab");
            WaitHelper.WaitVisible(Driver, HelpCenterTab, 10);
            Click(HelpCenterTab);
            WaitForPageLoad();
        }

        // =============================================================
        // INTERACTION METHODS - Main Menu Items
        // =============================================================
        
        /// <summary>
        /// Clicks on the Checking menu item
        /// </summary>
        public void ClickCheckingMenu()
        {
            LogHelper.Info("Clicking Checking menu");
            WaitHelper.WaitVisible(Driver, CheckingMenu, 10);
            Click(CheckingMenu);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Savings menu item
        /// </summary>
        public void ClickSavingsMenu()
        {
            LogHelper.Info("Clicking Savings menu");
            WaitHelper.WaitVisible(Driver, SavingsMenu, 10);
            Click(SavingsMenu);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Home Loans menu item
        /// </summary>
        public void ClickHomeLoansMenu()
        {
            LogHelper.Info("Clicking Home Loans menu");
            WaitHelper.WaitVisible(Driver, HomeLoansMenu, 10);
            Click(HomeLoansMenu);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Credit Cards menu item
        /// </summary>
        public void ClickCreditCardsMenu()
        {
            LogHelper.Info("Clicking Credit Cards menu");
            WaitHelper.WaitVisible(Driver, CreditCardsMenu, 10);
            Click(CreditCardsMenu);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Loans menu item
        /// </summary>
        public void ClickLoansMenu()
        {
            LogHelper.Info("Clicking Loans menu");
            WaitHelper.WaitVisible(Driver, LoansMenu, 10);
            Click(LoansMenu);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Investing menu item
        /// </summary>
        public void ClickInvestingMenu()
        {
            LogHelper.Info("Clicking Investing menu");
            WaitHelper.WaitVisible(Driver, InvestingMenu, 10);
            Click(InvestingMenu);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Community menu item
        /// </summary>
        public void ClickCommunityMenu()
        {
            LogHelper.Info("Clicking Community menu");
            WaitHelper.WaitVisible(Driver, CommunityMenu, 10);
            Click(CommunityMenu);
            WaitForPageLoad();
        }

        // =============================================================
        // INTERACTION METHODS - Submenu Links
        // =============================================================
        
        /// <summary>
        /// Clicks on the Free Checking link in submenu
        /// </summary>
        public void ClickFreeCheckingLink()
        {
            LogHelper.Info("Clicking Free Checking link");
            WaitHelper.WaitVisible(Driver, FreeCheckingLink, 10);
            Click(FreeCheckingLink);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Savings Account link in submenu
        /// </summary>
        public void ClickSavingsAccountLink()
        {
            LogHelper.Info("Clicking Savings Account link");
            WaitHelper.WaitVisible(Driver, SavingsAccountLink, 10);
            Click(SavingsAccountLink);
            WaitForPageLoad();
        }
        
        /// <summary>
        /// Clicks on the Auto Loans link in submenu
        /// </summary>
        public void ClickAutoLoansLink()
        {
            LogHelper.Info("Clicking Auto Loans link");
            WaitHelper.WaitVisible(Driver, AutoLoansLink, 10);
            Click(AutoLoansLink);
            WaitForPageLoad();
        }

        // =============================================================
        // NAVIGATION FLOWS - Combined Actions
        // =============================================================
        
        /// <summary>
        /// Navigates to Free Checking page: Home → Checking → Free Checking
        /// </summary>
        public void NavigateToFreeCheckingPage()
        {
            LogHelper.Info("Navigating to Free Checking page");
            ClickCheckingMenu();
            ClickFreeCheckingLink();
        }
        
        /// <summary>
        /// Navigates to Savings Account page: Home → Savings → Savings Account
        /// </summary>
        public void NavigateToSavingsAccountPage()
        {
            LogHelper.Info("Navigating to Savings Account page");
            ClickSavingsMenu();
            ClickSavingsAccountLink();
        }
        
        /// <summary>
        /// Navigates to Auto Loans page: Home → Loans → Auto Loans
        /// </summary>
        public void NavigateToAutoLoansPage()
        {
            LogHelper.Info("Navigating to Auto Loans page");
            ClickLoansMenu();
            ClickAutoLoansLink();
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies if the main menu container is visible
        /// </summary>
        public bool IsMenuContainerVisible()
        {
            try
            {
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
        /// Verifies if the top tabs container is visible
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
        /// Verifies if the Personal tab is visible
        /// </summary>
        public bool IsPersonalTabVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, PersonalTab, 10);
                bool isVisible = IsDisplayed(PersonalTab);
                LogHelper.Info($"Personal tab visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Personal tab not visible: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Verifies if the Checking menu is visible
        /// </summary>
        public bool IsCheckingMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, CheckingMenu, 10);
                bool isVisible = IsDisplayed(CheckingMenu);
                LogHelper.Info($"Checking menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Checking menu not visible: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================
        
        /// <summary>
        /// Gets the current page URL
        /// </summary>
        public string GetCurrentPageUrl()
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
            LogHelper.Info($"Page title: {title}");
            return title;
        }

        // =============================================================
        // UTILITY METHODS
        // =============================================================
        
        /// <summary>
        /// Handles cookie banner if present
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
                    LogHelper.Info("Cookies accepted");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No cookie banner found or already dismissed: {ex.Message}");
            }
        }
    }
}