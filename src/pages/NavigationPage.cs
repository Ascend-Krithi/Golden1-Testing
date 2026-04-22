using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Golden1.Automation.Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Golden1.Automation.Framework.Pages
{
    public class NavigationPage : BasePage
    {
        private readonly IWebDriver _driver;
        private readonly Actions _actions;

        // Locators
        private By _globalNavigationMenu = By.XPath("//nav[@class='main-navigation'] | //div[@class='global-nav']");
        private By _personalMenu = By.XPath("//a[contains(text(),'Personal')] | //li[contains(@class,'personal')]");
        private By _businessMenu = By.XPath("//a[contains(text(),'Business')] | //li[contains(@class,'business')]");
        private By _financialWellnessMenu = By.XPath("//a[contains(text(),'Financial Wellness')] | //li[contains(@class,'financial-wellness')]");
        private By _appointmentsMenu = By.XPath("//a[contains(text(),'Appointments')] | //li[contains(@class,'appointments')]");
        private By _locationsMenu = By.XPath("//a[contains(text(),'Locations')] | //li[contains(@class,'locations')]");
        private By _membershipMenu = By.XPath("//a[contains(text(),'Membership')] | //li[contains(@class,'membership')]");
        private By _helpCenterMenu = By.XPath("//a[contains(text(),'Help Center')] | //li[contains(@class,'help-center')]");
        
        // Product menu locators
        private By _checkingMenu = By.XPath("//a[contains(text(),'Checking')] | //li[contains(@class,'checking')]");
        private By _savingsMenu = By.XPath("//a[contains(text(),'Savings')] | //li[contains(@class,'savings')]");
        private By _homeLoansMenu = By.XPath("//a[contains(text(),'Home Loans')] | //li[contains(@class,'home-loans')]");
        private By _creditCardsMenu = By.XPath("//a[contains(text(),'Credit Cards')] | //li[contains(@class,'credit-cards')]");
        private By _loansMenu = By.XPath("//a[contains(text(),'Loans')] | //li[contains(@class,'loans')]");
        private By _investingMenu = By.XPath("//a[contains(text(),'Investing')] | //li[contains(@class,'investing')]");
        private By _communityMenu = By.XPath("//a[contains(text(),'Community')] | //li[contains(@class,'community')]");

        public NavigationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _actions = new Actions(_driver);
        }

        public bool IsGlobalNavigationMenuVisible()
        {
            try
            {
                WaitHelper.WaitForElementToBeVisible(_driver, _globalNavigationMenu, 10);
                bool isVisible = IsElementDisplayed(_globalNavigationMenu);
                LogHelper.Info($"Global navigation menu visibility: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking global navigation menu visibility: {ex.Message}");
                return false;
            }
        }

        public By GetGlobalNavigationMenu()
        {
            return _globalNavigationMenu;
        }

        public bool IsNavigationOptionVisible(string optionName)
        {
            try
            {
                By locator = GetNavigationOptionLocator(optionName);
                WaitHelper.WaitForElementToBeVisible(_driver, locator, 10);
                bool isVisible = IsElementDisplayed(locator);
                LogHelper.Info($"Navigation option '{optionName}' visibility: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking navigation option '{optionName}' visibility: {ex.Message}");
                return false;
            }
        }

        private By GetNavigationOptionLocator(string optionName)
        {
            switch (optionName)
            {
                case "Personal":
                    return _personalMenu;
                case "Business":
                    return _businessMenu;
                case "Financial Wellness":
                    return _financialWellnessMenu;
                case "Appointments":
                    return _appointmentsMenu;
                case "Locations":
                    return _locationsMenu;
                case "Membership":
                    return _membershipMenu;
                case "Help Center":
                    return _helpCenterMenu;
                default:
                    return By.XPath($"//a[contains(text(),'{optionName}')] | //li[contains(text(),'{optionName}')]");
            }
        }

        public void HoverOverProductMenu(string menuName)
        {
            try
            {
                By menuLocator = GetProductMenuLocator(menuName);
                WaitHelper.WaitForElementToBeVisible(_driver, menuLocator, 10);
                IWebElement menuElement = _driver.FindElement(menuLocator);
                
                _actions.MoveToElement(menuElement).Perform();
                LogHelper.Info($"Hovered over product menu: {menuName}");
                
                // Wait for submenu to appear
                System.Threading.Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error hovering over product menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        private By GetProductMenuLocator(string menuName)
        {
            switch (menuName)
            {
                case "Checking":
                    return _checkingMenu;
                case "Savings":
                    return _savingsMenu;
                case "Home Loans":
                    return _homeLoansMenu;
                case "Credit Cards":
                    return _creditCardsMenu;
                case "Loans":
                    return _loansMenu;
                case "Investing":
                    return _investingMenu;
                case "Community":
                    return _communityMenu;
                default:
                    return By.XPath($"//a[contains(text(),'{menuName}')] | //li[contains(@class,'{menuName.ToLower().Replace(" ", "-")}')] ");
            }
        }

        public By GetSubmenuForProductMenu(string menuName)
        {
            string menuClass = menuName.ToLower().Replace(" ", "-");
            return By.XPath($"//div[contains(@class,'submenu-{menuClass}')] | //ul[contains(@class,'submenu')] | //div[@class='dropdown-menu']");
        }

        public bool IsSubmenuDisplayed(string menuName)
        {
            try
            {
                By submenuLocator = GetSubmenuForProductMenu(menuName);
                bool isDisplayed = IsElementDisplayed(submenuLocator);
                LogHelper.Info($"Submenu for '{menuName}' display status: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking submenu display for '{menuName}': {ex.Message}");
                return false;
            }
        }

        public List<IWebElement> GetAllSubmenuItems(string menuName)
        {
            try
            {
                By submenuLocator = GetSubmenuForProductMenu(menuName);
                WaitHelper.WaitForElementToBeVisible(_driver, submenuLocator, 5);
                
                IWebElement submenu = _driver.FindElement(submenuLocator);
                List<IWebElement> submenuItems = submenu.FindElements(By.XPath(".//a | .//li//a")).ToList();
                
                LogHelper.Info($"Found {submenuItems.Count} submenu items for '{menuName}'");
                return submenuItems;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error getting submenu items for '{menuName}': {ex.Message}");
                return new List<IWebElement>();
            }
        }

        public bool IsSubmenuItemClickable(IWebElement submenuItem)
        {
            try
            {
                bool isDisplayed = submenuItem.Displayed;
                bool isEnabled = submenuItem.Enabled;
                bool isClickable = isDisplayed && isEnabled;
                
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking if submenu item is clickable: {ex.Message}");
                return false;
            }
        }

        public void ClickSubmenuItem(string menuName, string submenuItemText)
        {
            try
            {
                HoverOverProductMenu(menuName);
                
                By submenuItemLocator = By.XPath($"//a[contains(text(),'{submenuItemText}')] | //li//a[contains(text(),'{submenuItemText}')]");
                WaitHelper.WaitForElementToBeClickable(_driver, submenuItemLocator, 10);
                
                IWebElement submenuItem = _driver.FindElement(submenuItemLocator);
                submenuItem.Click();
                
                LogHelper.Info($"Clicked submenu item '{submenuItemText}' under menu '{menuName}'");
                WaitHelper.WaitForPageLoad(_driver);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error clicking submenu item '{submenuItemText}' under menu '{menuName}': {ex.Message}");
                throw;
            }
        }
    }
}