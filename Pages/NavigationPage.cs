using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 website navigation functionality
    /// Handles top navigation tabs, main menus, and submenus
    /// </summary>
    public class NavigationPage : BasePage
    {
        #region Constructor
        
        public NavigationPage(IWebDriver driver) : base(driver) { }
        
        #endregion

        #region Locators - Navigation Container
        
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");
        
        #endregion

        #region Locators - Top Navigation Tabs
        
        private By PersonalTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Personal']");
        private By BusinessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Business']");
        private By FinancialWellnessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Financial Wellness']");
        private By AppointmentsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Appointments']");
        private By LocationsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Locations']");
        private By MembershipTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Membership']");
        private By HelpCenterTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Help Center']");
        
        #endregion

        #region Locators - Main Menu Items
        
        private By CheckingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Checking']");
        private By SavingsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Savings']");
        private By HomeLoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Home Loans']");
        private By CreditCardsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Credit Cards']");
        private By LoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Loans']");
        private By InvestingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Investing']");
        private By CommunityMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Community']");
        
        #endregion

        #region Locators - Submenu Links
        
        private By FreeCheckingLink => By.XPath("//a[normalize-space()='Free Checking']");
        private By SavingsAccountLink => By.XPath("//a[normalize-space()='Savings Account']");
        private By AutoLoansLink => By.XPath("//a[contains(normalize-space(),'Auto Loan')]");
        
        #endregion

        #region Page Actions - Navigation
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// </summary>
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info("Opening Golden1 homepage");
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                LogHelper.Info("Homepage loaded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomePage_LoadFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Personal tab in top navigation
        /// </summary>
        public void ClickPersonalTab()
        {
            try
            {
                LogHelper.Info("Clicking on Personal tab");
                WaitHelper.WaitClickable(Driver, PersonalTab, 10);
                Click(PersonalTab);
                LogHelper.Info("Personal tab clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Personal tab: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "PersonalTab_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Business tab in top navigation
        /// </summary>
        public void ClickBusinessTab()
        {
            try
            {
                LogHelper.Info("Clicking on Business tab");
                WaitHelper.WaitClickable(Driver, BusinessTab, 10);
                Click(BusinessTab);
                LogHelper.Info("Business tab clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Business tab: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "BusinessTab_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Financial Wellness tab in top navigation
        /// </summary>
        public void ClickFinancialWellnessTab()
        {
            try
            {
                LogHelper.Info("Clicking on Financial Wellness tab");
                WaitHelper.WaitClickable(Driver, FinancialWellnessTab, 10);
                Click(FinancialWellnessTab);
                LogHelper.Info("Financial Wellness tab clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Financial Wellness tab: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "FinancialWellnessTab_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Appointments tab in top navigation
        /// </summary>
        public void ClickAppointmentsTab()
        {
            try
            {
                LogHelper.Info("Clicking on Appointments tab");
                WaitHelper.WaitClickable(Driver, AppointmentsTab, 10);
                Click(AppointmentsTab);
                LogHelper.Info("Appointments tab clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Appointments tab: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "AppointmentsTab_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Locations tab in top navigation
        /// </summary>
        public void ClickLocationsTab()
        {
            try
            {
                LogHelper.Info("Clicking on Locations tab");
                WaitHelper.WaitClickable(Driver, LocationsTab, 10);
                Click(LocationsTab);
                LogHelper.Info("Locations tab clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Locations tab: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "LocationsTab_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Membership tab in top navigation
        /// </summary>
        public void ClickMembershipTab()
        {
            try
            {
                LogHelper.Info("Clicking on Membership tab");
                WaitHelper.WaitClickable(Driver, MembershipTab, 10);
                Click(MembershipTab);
                LogHelper.Info("Membership tab clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Membership tab: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "MembershipTab_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Help Center tab in top navigation
        /// </summary>
        public void ClickHelpCenterTab()
        {
            try
            {
                LogHelper.Info("Clicking on Help Center tab");
                WaitHelper.WaitClickable(Driver, HelpCenterTab, 10);
                Click(HelpCenterTab);
                LogHelper.Info("Help Center tab clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Help Center tab: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HelpCenterTab_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a specific tab by name
        /// </summary>
        /// <param name="tabName">Name of the tab to click</param>
        public void ClickTabByName(string tabName)
        {
            try
            {
                LogHelper.Info($"Clicking on {tabName} tab");
                
                switch (tabName.Trim())
                {
                    case "Personal":
                        ClickPersonalTab();
                        break;
                    case "Business":
                        ClickBusinessTab();
                        break;
                    case "Financial Wellness":
                        ClickFinancialWellnessTab();
                        break;
                    case "Appointments":
                        ClickAppointmentsTab();
                        break;
                    case "Locations":
                        ClickLocationsTab();
                        break;
                    case "Membership":
                        ClickMembershipTab();
                        break;
                    case "Help Center":
                        ClickHelpCenterTab();
                        break;
                    default:
                        throw new ArgumentException($"Unknown tab name: {tabName}");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click tab {tabName}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Checking menu item
        /// </summary>
        public void ClickCheckingMenu()
        {
            try
            {
                LogHelper.Info("Clicking on Checking menu");
                WaitHelper.WaitClickable(Driver, CheckingMenu, 10);
                Click(CheckingMenu);
                LogHelper.Info("Checking menu clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Checking menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "CheckingMenu_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Savings menu item
        /// </summary>
        public void ClickSavingsMenu()
        {
            try
            {
                LogHelper.Info("Clicking on Savings menu");
                WaitHelper.WaitClickable(Driver, SavingsMenu, 10);
                Click(SavingsMenu);
                LogHelper.Info("Savings menu clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Savings menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "SavingsMenu_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Home Loans menu item
        /// </summary>
        public void ClickHomeLoansMenu()
        {
            try
            {
                LogHelper.Info("Clicking on Home Loans menu");
                WaitHelper.WaitClickable(Driver, HomeLoansMenu, 10);
                Click(HomeLoansMenu);
                LogHelper.Info("Home Loans menu clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Home Loans menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomeLoansMenu_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Credit Cards menu item
        /// </summary>
        public void ClickCreditCardsMenu()
        {
            try
            {
                LogHelper.Info("Clicking on Credit Cards menu");
                WaitHelper.WaitClickable(Driver, CreditCardsMenu, 10);
                Click(CreditCardsMenu);
                LogHelper.Info("Credit Cards menu clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Credit Cards menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "CreditCardsMenu_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Loans menu item
        /// </summary>
        public void ClickLoansMenu()
        {
            try
            {
                LogHelper.Info("Clicking on Loans menu");
                WaitHelper.WaitClickable(Driver, LoansMenu, 10);
                Click(LoansMenu);
                LogHelper.Info("Loans menu clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Loans menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "LoansMenu_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Investing menu item
        /// </summary>
        public void ClickInvestingMenu()
        {
            try
            {
                LogHelper.Info("Clicking on Investing menu");
                WaitHelper.WaitClickable(Driver, InvestingMenu, 10);
                Click(InvestingMenu);
                LogHelper.Info("Investing menu clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Investing menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "InvestingMenu_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Community menu item
        /// </summary>
        public void ClickCommunityMenu()
        {
            try
            {
                LogHelper.Info("Clicking on Community menu");
                WaitHelper.WaitClickable(Driver, CommunityMenu, 10);
                Click(CommunityMenu);
                LogHelper.Info("Community menu clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Community menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "CommunityMenu_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a specific menu by name
        /// </summary>
        /// <param name="menuName">Name of the menu to click</param>
        public void ClickMenuByName(string menuName)
        {
            try
            {
                LogHelper.Info($"Clicking on {menuName} menu");
                
                switch (menuName.Trim())
                {
                    case "Checking":
                        ClickCheckingMenu();
                        break;
                    case "Savings":
                        ClickSavingsMenu();
                        break;
                    case "Home Loans":
                        ClickHomeLoansMenu();
                        break;
                    case "Credit Cards":
                        ClickCreditCardsMenu();
                        break;
                    case "Loans":
                        ClickLoansMenu();
                        break;
                    case "Investing":
                        ClickInvestingMenu();
                        break;
                    case "Community":
                        ClickCommunityMenu();
                        break;
                    default:
                        throw new ArgumentException($"Unknown menu name: {menuName}");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click menu {menuName}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Free Checking link in submenu
        /// </summary>
        public void ClickFreeCheckingLink()
        {
            try
            {
                LogHelper.Info("Clicking on Free Checking link");
                WaitHelper.WaitClickable(Driver, FreeCheckingLink, 10);
                Click(FreeCheckingLink);
                LogHelper.Info("Free Checking link clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Free Checking link: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "FreeCheckingLink_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Savings Account link in submenu
        /// </summary>
        public void ClickSavingsAccountLink()
        {
            try
            {
                LogHelper.Info("Clicking on Savings Account link");
                WaitHelper.WaitClickable(Driver, SavingsAccountLink, 10);
                Click(SavingsAccountLink);
                LogHelper.Info("Savings Account link clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Savings Account link: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "SavingsAccountLink_ClickFailed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on the Auto Loans link in submenu
        /// </summary>
        public void ClickAutoLoansLink()
        {
            try
            {
                LogHelper.Info("Clicking on Auto Loans link");
                WaitHelper.WaitClickable(Driver, AutoLoansLink, 10);
                Click(AutoLoansLink);
                LogHelper.Info("Auto Loans link clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Auto Loans link: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "AutoLoansLink_ClickFailed");
                throw;
            }
        }
        
        #endregion

        #region Verifications
        
        /// <summary>
        /// Verifies if the main navigation menu is visible
        /// </summary>
        /// <returns>True if menu is visible, false otherwise</returns>
        public bool IsMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Main navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main navigation menu not visible: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "MenuContainer_NotVisible");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the top tabs container is visible
        /// </summary>
        /// <returns>True if top tabs container is visible, false otherwise</returns>
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
                ScreenshotHelper.TakeScreenshot(Driver, "TopTabsContainer_NotVisible");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a specific tab is active
        /// </summary>
        /// <param name="tabName">Name of the tab to verify</param>
        /// <returns>True if tab is active, false otherwise</returns>
        public bool IsTabActive(string tabName)
        {
            try
            {
                LogHelper.Info($"Verifying if {tabName} tab is active");
                By tabLocator = GetTabLocatorByName(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                
                IWebElement tabElement = Driver.FindElement(tabLocator);
                string classAttribute = tabElement.GetAttribute("class");
                bool isActive = classAttribute != null && classAttribute.Contains("active");
                
                LogHelper.Info($"{tabName} tab active status: {isActive}");
                return isActive;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify {tabName} tab active status: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the Checking submenu is displayed
        /// </summary>
        /// <returns>True if submenu is displayed, false otherwise</returns>
        public bool IsCheckingSubmenuDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, FreeCheckingLink, 10);
                bool isDisplayed = IsDisplayed(FreeCheckingLink);
                LogHelper.Info($"Checking submenu displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Checking submenu not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the Savings submenu is displayed
        /// </summary>
        /// <returns>True if submenu is displayed, false otherwise</returns>
        public bool IsSavingsSubmenuDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, SavingsAccountLink, 10);
                bool isDisplayed = IsDisplayed(SavingsAccountLink);
                LogHelper.Info($"Savings submenu displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Savings submenu not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if a specific submenu is displayed by menu name
        /// </summary>
        /// <param name="menuName">Name of the menu</param>
        /// <returns>True if submenu is displayed, false otherwise</returns>
        public bool IsSubmenuDisplayed(string menuName)
        {
            try
            {
                LogHelper.Info($"Verifying if {menuName} submenu is displayed");
                
                switch (menuName.Trim())
                {
                    case "Checking":
                        return IsCheckingSubmenuDisplayed();
                    case "Savings":
                        return IsSavingsSubmenuDisplayed();
                    default:
                        LogHelper.Warning($"Submenu verification not implemented for: {menuName}");
                        return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify {menuName} submenu: {ex.Message}");
                return false;
            }
        }
        
        #endregion

        #region Data Retrieval
        
        /// <summary>
        /// Gets the current page title
        /// </summary>
        /// <returns>Page title as string</returns>
        public string GetPageTitle()
        {
            try
            {
                string title = Driver.Title;
                LogHelper.Info($"Page title: {title}");
                return title;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to get page title: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        /// <returns>Current URL as string</returns>
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
        
        #endregion

        #region Helper Methods
        
        /// <summary>
        /// Gets the locator for a tab by its name
        /// </summary>
        /// <param name="tabName">Name of the tab</param>
        /// <returns>By locator for the tab</returns>
        private By GetTabLocatorByName(string tabName)
        {
            switch (tabName.Trim())
            {
                case "Personal":
                    return PersonalTab;
                case "Business":
                    return BusinessTab;
                case "Financial Wellness":
                    return FinancialWellnessTab;
                case "Appointments":
                    return AppointmentsTab;
                case "Locations":
                    return LocationsTab;
                case "Membership":
                    return MembershipTab;
                case "Help Center":
                    return HelpCenterTab;
                default:
                    throw new ArgumentException($"Unknown tab name: {tabName}");
            }
        }
        
        #endregion
    }
}