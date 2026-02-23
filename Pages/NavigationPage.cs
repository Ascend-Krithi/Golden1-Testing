using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Navigation Menu
    /// Test Cases: TASK0020445 TS-001 to TS-008
    /// </summary>
    public class NavigationPage : BasePage
    {
        // CONSTRUCTOR
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS (Private, Read-only Properties)
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");
        private By PersonalTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Personal']");
        private By BusinessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Business']");
        private By FinancialWellnessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Financial Wellness']");
        private By AppointmentsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Appointments']");
        private By LocationsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Locations']");
        private By MembershipTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Membership']");
        private By HelpCenterTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Help Center']");
        private By CheckingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Checking']");
        private By SavingsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Savings']");
        private By HomeLoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Home Loans']");
        private By CreditCardsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Credit Cards']");
        private By LoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Loans']");
        private By InvestingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Investing']");
        private By CommunityMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Community']");
        private By FreeCheckingLink => By.XPath("//a[normalize-space()='Free Checking']");
        private By SavingsAccountLink => By.XPath("//a[normalize-space()='Savings Account']");
        private By AutoLoansLink => By.XPath("//a[contains(normalize-space(),'Auto Loan')]");
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // SECTION 2: PAGE ACTIONS (Public Methods)
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// </summary>
        public void OpenHomepage()
        {
            LogHelper.Info($"Opening Golden1 homepage: {ConfigReader.BaseUrl}");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            LogHelper.Info("Homepage loaded successfully");
        }

        /// <summary>
        /// Clicks on the Personal tab in top navigation
        /// </summary>
        public void ClickPersonalTab()
        {
            LogHelper.Info("Clicking on Personal tab");
            WaitHelper.WaitClickable(Driver, PersonalTab, 10);
            Click(PersonalTab);
            LogHelper.Info("Personal tab clicked successfully");
        }

        /// <summary>
        /// Clicks on the Business tab in top navigation
        /// </summary>
        public void ClickBusinessTab()
        {
            LogHelper.Info("Clicking on Business tab");
            WaitHelper.WaitClickable(Driver, BusinessTab, 10);
            Click(BusinessTab);
            LogHelper.Info("Business tab clicked successfully");
        }

        /// <summary>
        /// Clicks on the Checking menu option
        /// </summary>
        public void ClickCheckingMenu()
        {
            LogHelper.Info("Clicking on Checking menu");
            WaitHelper.WaitClickable(Driver, CheckingMenu, 10);
            Click(CheckingMenu);
            LogHelper.Info("Checking menu clicked successfully");
        }

        /// <summary>
        /// Clicks on the Savings menu option
        /// </summary>
        public void ClickSavingsMenu()
        {
            LogHelper.Info("Clicking on Savings menu");
            WaitHelper.WaitClickable(Driver, SavingsMenu, 10);
            Click(SavingsMenu);
            LogHelper.Info("Savings menu clicked successfully");
        }

        /// <summary>
        /// Clicks on the Free Checking link
        /// </summary>
        public void ClickFreeCheckingLink()
        {
            LogHelper.Info("Clicking on Free Checking link");
            WaitHelper.WaitClickable(Driver, FreeCheckingLink, 10);
            Click(FreeCheckingLink);
            LogHelper.Info("Free Checking link clicked successfully");
        }

        /// <summary>
        /// Clicks on the Savings Account link
        /// </summary>
        public void ClickSavingsAccountLink()
        {
            LogHelper.Info("Clicking on Savings Account link");
            WaitHelper.WaitClickable(Driver, SavingsAccountLink, 10);
            Click(SavingsAccountLink);
            LogHelper.Info("Savings Account link clicked successfully");
        }

        /// <summary>
        /// Accepts cookies if the cookie banner is displayed
        /// </summary>
        public void AcceptCookies()
        {
            try
            {
                if (IsCookieBannerDisplayed())
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
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
                LogHelper.Warning($"Could not accept cookies: {ex.Message}");
            }
        }

        // SECTION 3: VERIFICATIONS (Public Methods returning bool)
        
        /// <summary>
        /// Verifies if the main navigation menu is visible
        /// </summary>
        /// <returns>True if menu is visible, false otherwise</returns>
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
        /// Verifies if the Personal tab is visible
        /// </summary>
        /// <returns>True if Personal tab is visible, false otherwise</returns>
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
        /// Verifies if the Business tab is visible
        /// </summary>
        /// <returns>True if Business tab is visible, false otherwise</returns>
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

        /// <summary>
        /// Verifies if the Financial Wellness tab is visible
        /// </summary>
        /// <returns>True if Financial Wellness tab is visible, false otherwise</returns>
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

        /// <summary>
        /// Verifies if the Appointments tab is visible
        /// </summary>
        /// <returns>True if Appointments tab is visible, false otherwise</returns>
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

        /// <summary>
        /// Verifies if the Locations tab is visible
        /// </summary>
        /// <returns>True if Locations tab is visible, false otherwise</returns>
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

        /// <summary>
        /// Verifies if the Membership tab is visible
        /// </summary>
        /// <returns>True if Membership tab is visible, false otherwise</returns>
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

        /// <summary>
        /// Verifies if the Help Center tab is visible
        /// </summary>
        /// <returns>True if Help Center tab is visible, false otherwise</returns>
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

        /// <summary>
        /// Verifies if the Checking menu is visible
        /// </summary>
        /// <returns>True if Checking menu is visible, false otherwise</returns>
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

        /// <summary>
        /// Verifies if the Free Checking link is visible
        /// </summary>
        /// <returns>True if Free Checking link is visible, false otherwise</returns>
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

        /// <summary>
        /// Verifies if the cookie banner is displayed
        /// </summary>
        /// <returns>True if cookie banner is displayed, false otherwise</returns>
        public bool IsCookieBannerDisplayed()
        {
            try
            {
                bool isDisplayed = IsDisplayed(CookieBanner, 5);
                LogHelper.Info($"Cookie banner displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Cookie banner not displayed: {ex.Message}");
                return false;
            }
        }

        // SECTION 4: DATA RETRIEVAL
        
        /// <summary>
        /// Gets the current page URL
        /// </summary>
        /// <returns>Current URL as string</returns>
        public string GetPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }

        /// <summary>
        /// Verifies if the current URL contains expected text
        /// </summary>
        /// <param name="expectedText">Text to search in URL</param>
        /// <returns>True if URL contains expected text, false otherwise</returns>
        public bool VerifyUrlContains(string expectedText)
        {
            string currentUrl = GetCurrentUrl();
            bool contains = currentUrl.ToLower().Contains(expectedText.ToLower());
            LogHelper.Info($"URL contains '{expectedText}': {contains}");
            return contains;
        }
    }
}