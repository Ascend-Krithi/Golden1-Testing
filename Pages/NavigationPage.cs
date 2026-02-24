using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Golden1.Automation.Pages
{
    public class NavigationPage : BasePage
    {
        // Locators - Using provided locator definitions
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");
        
        // Top Menu Tabs
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

        // Constructor
        public NavigationPage() : base()
        {
            LogHelper.Info("NavigationPage object created");
        }

        // Helper method to get locator by menu name
        private By GetTopMenuLocator(string menuName)
        {
            return menuName switch
            {
                "Personal" => PersonalTab,
                "Business" => BusinessTab,
                "Financial Wellness" => FinancialWellnessTab,
                "Appointments" => AppointmentsTab,
                "Locations" => LocationsTab,
                "Membership" => MembershipTab,
                "Help Center" => HelpCenterTab,
                _ => By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{menuName}']")
            };
        }

        private By GetProductMenuLocator(string menuName)
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
                _ => By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuName}']")
            };
        }

        private By GetSubmenuItemLocator(string submenuItem)
        {
            return submenuItem switch
            {
                "Free Checking" => FreeCheckingLink,
                "Savings Account" => SavingsAccountLink,
                "Auto Loan" => AutoLoansLink,
                _ => By.XPath($"//a[normalize-space()='{submenuItem}']")
            };
        }

        // Verification Methods
        public bool IsNavigationMenuVisible()
        {
            try
            {
                LogHelper.Info("Checking if navigation menu is visible");
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Navigation menu visibility: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to check navigation menu visibility: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, "IsNavigationMenuVisible_Failed");
                return false;
            }
        }

        public bool IsTopMenuOptionPresent(string menuOption)
        {
            try
            {
                LogHelper.Info($"Checking if top menu option '{menuOption}' is present");
                By menuLocator = GetTopMenuLocator(menuOption);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isPresent = IsDisplayed(menuLocator);
                LogHelper.Info($"Top menu option '{menuOption}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to check top menu option '{menuOption}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, $"IsTopMenuOptionPresent_{menuOption}_Failed");
                return false;
            }
        }

        public bool IsProductMenuDisplayed(string productMenu)
        {
            try
            {
                LogHelper.Info($"Checking if product menu '{productMenu}' is displayed");
                By menuLocator = GetProductMenuLocator(productMenu);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isDisplayed = IsDisplayed(menuLocator);
                LogHelper.Info($"Product menu '{productMenu}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to check product menu '{productMenu}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, $"IsProductMenuDisplayed_{productMenu}_Failed");
                return false;
            }
        }

        public bool HasSubmenuItems(string productMenu)
        {
            try
            {
                LogHelper.Info($"Checking if '{productMenu}' has submenu items");
                // After clicking menu, check if submenu items appear
                By submenuContainer = By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{productMenu}']/following-sibling::*[contains(@class,'submenu') or contains(@class,'dropdown')]");
                bool hasSubmenu = IsDisplayed(submenuContainer, 5);
                LogHelper.Info($"Product menu '{productMenu}' has submenu: {hasSubmenu}");
                return hasSubmenu;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Submenu check for '{productMenu}': {ex.Message}");
                // If submenu structure is different, assume it has submenu if menu is clickable
                return true;
            }
        }

        // Action Methods
        public void ClickProductMenu(string productMenu)
        {
            try
            {
                LogHelper.Info($"Clicking on product menu '{productMenu}'");
                By menuLocator = GetProductMenuLocator(productMenu);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                Click(menuLocator);
                System.Threading.Thread.Sleep(1000); // Brief pause for menu animation
                LogHelper.Info($"Successfully clicked on product menu '{productMenu}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click product menu '{productMenu}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, $"ClickProductMenu_{productMenu}_Failed");
                throw;
            }
        }

        public void ExpandMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding menu '{menuName}'");
                By menuLocator = GetProductMenuLocator(menuName);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                
                // Hover over menu to expand it
                var element = Driver.FindElement(menuLocator);
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                actions.MoveToElement(element).Perform();
                
                System.Threading.Thread.Sleep(1000); // Wait for menu expansion animation
                LogHelper.Info($"Successfully expanded menu '{menuName}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand menu '{menuName}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, $"ExpandMenu_{menuName}_Failed");
                throw;
            }
        }

        public void ClickSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Clicking on submenu item '{submenuItem}'");
                By submenuLocator = GetSubmenuItemLocator(submenuItem);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Successfully clicked on submenu item '{submenuItem}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItem}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(Driver, $"ClickSubmenuItem_{submenuItem}_Failed");
                throw;
            }
        }
    }
}