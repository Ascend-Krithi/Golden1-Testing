using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden 1 Navigation functionality
    /// Handles all navigation menu interactions and verifications
    /// </summary>
    public class NavigationPage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // SECTION 1: LOCATORS (Private, Read-only Properties)
        // =============================================================
        
        // Main Navigation Container
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

        // Overlay Elements
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // =============================================================
        // SECTION 2: PAGE ACTIONS (Public Methods)
        // =============================================================

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
        /// Handles cookie banner if present on page
        /// </summary>
        public void HandleCookieBannerIfPresent()
        {
            try
            {
                if (IsDisplayed(CookieBanner, 3))
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
                LogHelper.Info($"No cookie banner present or already handled: {ex.Message}");
            }
        }

        /// <summary>
        /// Clicks on the Checking menu to expand it
        /// </summary>
        public void ClickCheckingMenu()
        {
            try
            {
                LogHelper.Info("Clicking Checking menu");
                WaitHelper.WaitClickable(Driver, CheckingMenu, 10);
                Click(CheckingMenu);
                WaitHelper.WaitVisible(Driver, FreeCheckingLink, 10);
                LogHelper.Info("Checking menu clicked and expanded");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Checking menu: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Free Checking submenu link
        /// </summary>
        public void ClickFreeCheckingLink()
        {
            try
            {
                LogHelper.Info("Clicking Free Checking link");
                WaitHelper.WaitClickable(Driver, FreeCheckingLink, 10);
                Click(FreeCheckingLink);
                WaitForPageLoad();
                LogHelper.Info("Free Checking link clicked");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Free Checking link: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // SECTION 3: VERIFICATIONS (Public Methods returning bool)
        // =============================================================

        /// <summary>
        /// Verifies if navigation menu container is visible
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
        /// Verifies if top tabs container is visible
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

        // Top Navigation Tab Visibility Methods
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

        public bool IsBusinessTabVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, BusinessTab, 10);
                bool isVisible = IsDisplayed(BusinessTab);
                LogHelper.Info($"Business tab visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Business tab not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsFinancialWellnessTabVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, FinancialWellnessTab, 10);
                bool isVisible = IsDisplayed(FinancialWellnessTab);
                LogHelper.Info($"Financial Wellness tab visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Financial Wellness tab not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsAppointmentsTabVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, AppointmentsTab, 10);
                bool isVisible = IsDisplayed(AppointmentsTab);
                LogHelper.Info($"Appointments tab visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Appointments tab not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsLocationsTabVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, LocationsTab, 10);
                bool isVisible = IsDisplayed(LocationsTab);
                LogHelper.Info($"Locations tab visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Locations tab not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsMembershipTabVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, MembershipTab, 10);
                bool isVisible = IsDisplayed(MembershipTab);
                LogHelper.Info($"Membership tab visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Membership tab not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsHelpCenterTabVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, HelpCenterTab, 10);
                bool isVisible = IsDisplayed(HelpCenterTab);
                LogHelper.Info($"Help Center tab visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Help Center tab not visible: {ex.Message}");
                return false;
            }
        }

        // Product Category Menu Visibility Methods
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

        public bool IsSavingsMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, SavingsMenu, 10);
                bool isVisible = IsDisplayed(SavingsMenu);
                LogHelper.Info($"Savings menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Savings menu not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsHomeLoansMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, HomeLoansMenu, 10);
                bool isVisible = IsDisplayed(HomeLoansMenu);
                LogHelper.Info($"Home Loans menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Home Loans menu not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsCreditCardsMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, CreditCardsMenu, 10);
                bool isVisible = IsDisplayed(CreditCardsMenu);
                LogHelper.Info($"Credit Cards menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Credit Cards menu not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsLoansMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, LoansMenu, 10);
                bool isVisible = IsDisplayed(LoansMenu);
                LogHelper.Info($"Loans menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Loans menu not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsInvestingMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, InvestingMenu, 10);
                bool isVisible = IsDisplayed(InvestingMenu);
                LogHelper.Info($"Investing menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Investing menu not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsCommunityMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, CommunityMenu, 10);
                bool isVisible = IsDisplayed(CommunityMenu);
                LogHelper.Info($"Community menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Community menu not visible: {ex.Message}");
                return false;
            }
        }

        // Product Category Menu Clickable/Accessible Methods
        public bool IsCheckingMenuClickable()
        {
            try
            {
                WaitHelper.WaitClickable(Driver, CheckingMenu, 10);
                LogHelper.Info("Checking menu is clickable");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Checking menu not clickable: {ex.Message}");
                return false;
            }
        }

        public bool IsSavingsMenuClickable()
        {
            try
            {
                WaitHelper.WaitClickable(Driver, SavingsMenu, 10);
                LogHelper.Info("Savings menu is clickable");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Savings menu not clickable: {ex.Message}");
                return false;
            }
        }

        public bool IsHomeLoansMenuClickable()
        {
            try
            {
                WaitHelper.WaitClickable(Driver, HomeLoansMenu, 10);
                LogHelper.Info("Home Loans menu is clickable");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Home Loans menu not clickable: {ex.Message}");
                return false;
            }
        }

        public bool IsCreditCardsMenuClickable()
        {
            try
            {
                WaitHelper.WaitClickable(Driver, CreditCardsMenu, 10);
                LogHelper.Info("Credit Cards menu is clickable");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Credit Cards menu not clickable: {ex.Message}");
                return false;
            }
        }

        public bool IsLoansMenuClickable()
        {
            try
            {
                WaitHelper.WaitClickable(Driver, LoansMenu, 10);
                LogHelper.Info("Loans menu is clickable");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Loans menu not clickable: {ex.Message}");
                return false;
            }
        }

        public bool IsInvestingMenuClickable()
        {
            try
            {
                WaitHelper.WaitClickable(Driver, InvestingMenu, 10);
                LogHelper.Info("Investing menu is clickable");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Investing menu not clickable: {ex.Message}");
                return false;
            }
        }

        public bool IsCommunityMenuClickable()
        {
            try
            {
                WaitHelper.WaitClickable(Driver, CommunityMenu, 10);
                LogHelper.Info("Community menu is clickable");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Community menu not clickable: {ex.Message}");
                return false;
            }
        }

        // Submenu Item Visibility and Clickable Methods
        public bool IsFreeCheckingLinkVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, FreeCheckingLink, 10);
                bool isVisible = IsDisplayed(FreeCheckingLink);
                LogHelper.Info($"Free Checking link visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Free Checking link not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsFreeCheckingLinkClickable()
        {
            try
            {
                WaitHelper.WaitClickable(Driver, FreeCheckingLink, 10);
                LogHelper.Info("Free Checking link is clickable");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Free Checking link not clickable: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // SECTION 4: DATA RETRIEVAL (Public Methods returning data)
        // =============================================================

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        public string GetCurrentUrl()
        {
            try
            {
                string url = Driver.Url;
                LogHelper.Info($"Current URL: {url}");
                return url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get current URL: {ex.Message}");
                return string.Empty;
            }
        }
    }
}