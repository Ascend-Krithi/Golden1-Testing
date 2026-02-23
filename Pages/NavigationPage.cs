using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    public class NavigationPage : BasePage
    {
        // CONSTRUCTOR
        public NavigationPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS - Based on Golden1 Locators.Json
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

        // SECTION 2: PAGE ACTIONS
        public void OpenHomePage()
        {
            LogHelper.Info("Opening Golden1 homepage");
            try
            {
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                LogHelper.Info("Golden1 homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open Golden1 homepage: {ex.Message}");
                throw;
            }
        }

        public void ClickMenuOption(string menuOption)
        {
            LogHelper.Info($"Attempting to click on menu option: {menuOption}");
            try
            {
                By menuLocator = GetMenuLocator(menuOption);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                Click(menuLocator);
                LogHelper.Info($"Successfully clicked on {menuOption} menu");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click on {menuOption} menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, $"MenuClick_{menuOption}_Failed");
                throw;
            }
        }

        public void ClickTopTab(string tabName)
        {
            LogHelper.Info($"Attempting to click on top tab: {tabName}");
            try
            {
                By tabLocator = GetTopTabLocator(tabName);
                WaitHelper.WaitClickable(Driver, tabLocator, 10);
                Click(tabLocator);
                LogHelper.Info($"Successfully clicked on {tabName} tab");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click on {tabName} tab: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, $"TabClick_{tabName}_Failed");
                throw;
            }
        }

        public void ClickSubMenuLink(string linkName)
        {
            LogHelper.Info($"Attempting to click on submenu link: {linkName}");
            try
            {
                By linkLocator = GetSubMenuLinkLocator(linkName);
                WaitHelper.WaitClickable(Driver, linkLocator, 10);
                Click(linkLocator);
                LogHelper.Info($"Successfully clicked on {linkName} link");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click on {linkName} link: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, $"SubMenuClick_{linkName}_Failed");
                throw;
            }
        }

        // SECTION 3: VERIFICATIONS
        public bool IsMenuContainerVisible()
        {
            LogHelper.Info("Checking if menu container is visible");
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

        public bool IsTopTabVisible(string tabName)
        {
            LogHelper.Info($"Checking if top tab '{tabName}' is visible");
            try
            {
                By tabLocator = GetTopTabLocator(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 5);
                bool isVisible = IsDisplayed(tabLocator);
                LogHelper.Info($"Top tab '{tabName}' visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top tab '{tabName}' not visible: {ex.Message}");
                return false;
            }
        }

        public bool IsPageDisplayed(string pageName)
        {
            LogHelper.Info($"Verifying if {pageName} page is displayed");
            try
            {
                WaitForPageLoad();
                string currentUrl = Driver.Url.ToLower();
                string pageTitle = Driver.Title.ToLower();
                
                bool isDisplayed = currentUrl.Contains(pageName.ToLower().Replace(" ", "")) || 
                                   pageTitle.Contains(pageName.ToLower());
                
                LogHelper.Info($"{pageName} page displayed: {isDisplayed} (URL: {currentUrl}, Title: {pageTitle})");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify {pageName} page: {ex.Message}");
                return false;
            }
        }

        // SECTION 4: HELPER METHODS
        private By GetMenuLocator(string menuOption)
        {
            return menuOption switch
            {
                "Checking" => CheckingMenu,
                "Savings" => SavingsMenu,
                "Home Loans" => HomeLoansMenu,
                "Credit Cards" => CreditCardsMenu,
                "Loans" => LoansMenu,
                "Investing" => InvestingMenu,
                "Community" => CommunityMenu,
                _ => throw new ArgumentException($"Unknown menu option: {menuOption}")
            };
        }

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

        private By GetSubMenuLinkLocator(string linkName)
        {
            return linkName switch
            {
                "Free Checking" => FreeCheckingLink,
                "Savings Account" => SavingsAccountLink,
                "Auto Loans" => AutoLoansLink,
                _ => throw new ArgumentException($"Unknown submenu link: {linkName}")
            };
        }
    }
}