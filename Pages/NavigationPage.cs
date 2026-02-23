using System;
using OpenQA.Selenium;
using ProjectName.Automation.Config;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.Pages
{
    public class NavigationPage : BasePage
    {
        // Constructor
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

        // SECTION 2: PAGE ACTIONS (Public Methods)
        public void OpenHomePage()
        {
            try
            {
                LogHelper.Info("Opening Golden1 homepage");
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                LogHelper.Info("Homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "Homepage_OpenFailed");
                throw;
            }
        }

        public void HoverOverCheckingMenu()
        {
            try
            {
                LogHelper.Info("Hovering over Checking menu");
                WaitHelper.WaitVisible(Driver, CheckingMenu, 10);
                HoverElement(CheckingMenu);
                LogHelper.Info("Hovered over Checking menu successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to hover over Checking menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "CheckingMenu_HoverFailed");
                throw;
            }
        }

        public void HoverOverSavingsMenu()
        {
            try
            {
                LogHelper.Info("Hovering over Savings menu");
                WaitHelper.WaitVisible(Driver, SavingsMenu, 10);
                HoverElement(SavingsMenu);
                LogHelper.Info("Hovered over Savings menu successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to hover over Savings menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "SavingsMenu_HoverFailed");
                throw;
            }
        }

        public void HoverOverLoansMenu()
        {
            try
            {
                LogHelper.Info("Hovering over Loans menu");
                WaitHelper.WaitVisible(Driver, LoansMenu, 10);
                HoverElement(LoansMenu);
                LogHelper.Info("Hovered over Loans menu successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to hover over Loans menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "LoansMenu_HoverFailed");
                throw;
            }
        }

        public void HoverOverMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Hovering over {menuName} menu");
                By menuLocator = GetMenuLocatorByName(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                HoverElement(menuLocator);
                LogHelper.Info($"Hovered over {menuName} menu successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to hover over {menuName} menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, $"{menuName}Menu_HoverFailed");
                throw;
            }
        }

        public void ClickFreeCheckingLink()
        {
            try
            {
                LogHelper.Info("Clicking on Free Checking link");
                WaitHelper.WaitClickable(Driver, FreeCheckingLink, 10);
                Click(FreeCheckingLink);
                WaitForPageLoad();
                LogHelper.Info("Free Checking link clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Free Checking link: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "FreeCheckingLink_ClickFailed");
                throw;
            }
        }

        public void ClickSavingsAccountLink()
        {
            try
            {
                LogHelper.Info("Clicking on Savings Account link");
                WaitHelper.WaitClickable(Driver, SavingsAccountLink, 10);
                Click(SavingsAccountLink);
                WaitForPageLoad();
                LogHelper.Info("Savings Account link clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Savings Account link: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "SavingsAccountLink_ClickFailed");
                throw;
            }
        }

        public void ClickAutoLoansLink()
        {
            try
            {
                LogHelper.Info("Clicking on Auto Loans link");
                WaitHelper.WaitClickable(Driver, AutoLoansLink, 10);
                Click(AutoLoansLink);
                WaitForPageLoad();
                LogHelper.Info("Auto Loans link clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Auto Loans link: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "AutoLoansLink_ClickFailed");
                throw;
            }
        }

        // SECTION 3: VERIFICATIONS (Public Methods returning bool)
        public bool IsHomePageDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isDisplayed = IsDisplayed(MenuContainer);
                LogHelper.Info($"Homepage displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage not displayed: {ex.Message}");
                return false;
            }
        }

        public bool IsMainMenuVisible()
        {
            try
            {
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

        public bool IsCheckingSubmenuDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, FreeCheckingLink, 5);
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

        public bool IsSubmenuDisplayed(string menuName)
        {
            try
            {
                By submenuLocator = GetSubmenuLocatorByName(menuName);
                WaitHelper.WaitVisible(Driver, submenuLocator, 5);
                bool isDisplayed = IsDisplayed(submenuLocator);
                LogHelper.Info($"{menuName} submenu displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"{menuName} submenu not displayed: {ex.Message}");
                return false;
            }
        }

        // SECTION 4: HELPER METHODS (Private)
        private By GetMenuLocatorByName(string menuName)
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

        private By GetSubmenuLocatorByName(string menuName)
        {
            return menuName switch
            {
                "Checking" => FreeCheckingLink,
                "Savings" => SavingsAccountLink,
                "Loans" => AutoLoansLink,
                _ => throw new ArgumentException($"Unknown submenu for: {menuName}")
            };
        }
    }
}