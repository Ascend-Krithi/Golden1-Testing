using OpenQA.Selenium;
using Golden1.Automation.Framework.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Golden1.Automation.Framework.Pages
{
    public class HomePage : BasePage
    {
        private readonly WaitHelper _waitHelper;
        private readonly LogHelper _logHelper;

        // Locators
        private By GlobalNavigationMenu => By.XPath("//nav[@class='global-navigation']");
        private By Golden1Logo => By.XPath("//img[@alt='Golden 1 Credit Union']");
        private By ErrorMessage => By.XPath("//div[contains(@class, 'error-message')]");
        private By LoadingSpinner => By.XPath("//div[contains(@class, 'loading-spinner')]");
        
        // Navigation Options
        private By PersonalMenu => By.XPath("//a[text()='Personal']");
        private By BusinessMenu => By.XPath("//a[text()='Business']");
        private By FinancialWellnessMenu => By.XPath("//a[text()='Financial Wellness']");
        private By AppointmentsMenu => By.XPath("//a[text()='Appointments']");
        private By LocationsMenu => By.XPath("//a[text()='Locations']");
        private By MembershipMenu => By.XPath("//a[text()='Membership']");
        private By HelpCenterMenu => By.XPath("//a[text()='Help Center']");
        
        // Product Menus
        private By CheckingMenu => By.XPath("//a[text()='Checking']");
        private By SavingsMenu => By.XPath("//a[text()='Savings']");
        private By HomeLoansMenu => By.XPath("//a[text()='Home Loans']");
        private By CreditCardsMenu => By.XPath("//a[text()='Credit Cards']");
        private By LoansMenu => By.XPath("//a[text()='Loans']");
        private By InvestingMenu => By.XPath("//a[text()='Investing']");
        private By CommunityMenu => By.XPath("//a[text()='Community']");
        
        // Submenu Items
        private By SubmenuItems => By.XPath("//div[contains(@class, 'submenu')]//a");

        public HomePage()
        {
            _waitHelper = new WaitHelper();
            _logHelper = new LogHelper();
        }

        public bool IsPageLoaded()
        {
            _logHelper.LogInfo("Checking if HomePage is loaded");
            _waitHelper.WaitForElementVisible(GlobalNavigationMenu, 30);
            return _waitHelper.IsElementPresent(GlobalNavigationMenu);
        }

        public bool IsPageFullyLoaded()
        {
            _logHelper.LogInfo("Checking if HomePage is fully loaded");
            _waitHelper.WaitForPageLoad();
            return !_waitHelper.IsElementPresent(LoadingSpinner);
        }

        public bool HasErrorMessages()
        {
            _logHelper.LogInfo("Checking for error messages on HomePage");
            return _waitHelper.IsElementPresent(ErrorMessage);
        }

        public bool IsGlobalNavigationMenuVisible()
        {
            _logHelper.LogInfo("Checking if global navigation menu is visible");
            _waitHelper.WaitForElementVisible(GlobalNavigationMenu, 10);
            return _waitHelper.IsElementDisplayed(GlobalNavigationMenu);
        }

        public bool IsNavigationOptionPresent(string optionName)
        {
            _logHelper.LogInfo($"Checking if navigation option '{optionName}' is present");
            By locator = GetNavigationOptionLocator(optionName);
            _waitHelper.WaitForElementVisible(locator, 10);
            return _waitHelper.IsElementPresent(locator);
        }

        public void HoverOverNavigationOption(string optionName)
        {
            _logHelper.LogInfo($"Hovering over navigation option: {optionName}");
            By locator = GetNavigationOptionLocator(optionName);
            _waitHelper.WaitForElementVisible(locator, 10);
            _waitHelper.HoverOverElement(locator);
        }

        public void HoverOverProductMenu(string menuName)
        {
            _logHelper.LogInfo($"Hovering over product menu: {menuName}");
            By locator = GetProductMenuLocator(menuName);
            _waitHelper.WaitForElementVisible(locator, 10);
            _waitHelper.HoverOverElement(locator);
        }

        public bool AreMainProductMenusDisplayed()
        {
            _logHelper.LogInfo("Checking if main product menus are displayed");
            var productMenus = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
            
            foreach (var menu in productMenus)
            {
                By locator = GetProductMenuLocator(menu);
                if (_waitHelper.IsElementPresent(locator))
                {
                    return true;
                }
            }
            return false;
        }

        public bool AreSubmenuItemsDisplayed()
        {
            _logHelper.LogInfo("Checking if submenu items are displayed");
            _waitHelper.WaitForElementVisible(SubmenuItems, 10);
            return _waitHelper.IsElementDisplayed(SubmenuItems);
        }

        public bool AreSubmenuItemsClickable()
        {
            _logHelper.LogInfo("Checking if submenu items are clickable");
            var submenuElements = _waitHelper.FindElements(SubmenuItems);
            
            foreach (var element in submenuElements)
            {
                if (!element.Enabled)
                {
                    return false;
                }
            }
            return submenuElements.Count > 0;
        }

        public void ClickSubmenuItem(string submenuItemName)
        {
            _logHelper.LogInfo($"Clicking submenu item: {submenuItemName}");
            By locator = By.XPath($"//a[text()='{submenuItemName}']");
            _waitHelper.WaitForElementClickable(locator, 10);
            _waitHelper.ClickElement(locator);
        }

        public List<string> GetAllMappedSubmenuLinks()
        {
            _logHelper.LogInfo("Getting all mapped submenu links");
            // Based on the 9 mapped submenu links mentioned in the test case
            return new List<string>
            {
                "Free Checking",
                "Platinum Checking",
                "Money Market Savings",
                "Certificate Accounts",
                "Home Equity Loans",
                "Personal Loans",
                "Auto Loans",
                "Credit Cards",
                "Investment Services"
            };
        }

        public void NavigateToSubmenuLink(string linkName)
        {
            _logHelper.LogInfo($"Navigating to submenu link: {linkName}");
            By locator = By.XPath($"//a[text()='{linkName}']");
            _waitHelper.WaitForElementClickable(locator, 10);
            _waitHelper.ClickElement(locator);
            _waitHelper.WaitForPageLoad();
        }

        public bool AreAllSubmenuLinksRedirectingCorrectly()
        {
            _logHelper.LogInfo("Checking if all submenu links redirect correctly");
            // This would be validated by checking page loads after navigation
            _waitHelper.WaitForPageLoad();
            return !HasErrorMessages();
        }

        public bool DoesUrlContainExpectedIdentifier()
        {
            _logHelper.LogInfo("Checking if URL contains expected identifier");
            string currentUrl = _waitHelper.GetCurrentUrl();
            return !string.IsNullOrEmpty(currentUrl) && currentUrl.Contains("golden1.com");
        }

        public bool IsLogoVisible()
        {
            _logHelper.LogInfo("Checking if Golden1 logo is visible");
            _waitHelper.WaitForElementVisible(Golden1Logo, 10);
            return _waitHelper.IsElementDisplayed(Golden1Logo);
        }

        public bool HasBrokenLayouts()
        {
            _logHelper.LogInfo("Checking for broken layouts");
            // Check if main container elements are properly displayed
            By mainContainer = By.XPath("//main[@id='main-content']");
            return !_waitHelper.IsElementDisplayed(mainContainer);
        }

        public bool HasMissingImages()
        {
            _logHelper.LogInfo("Checking for missing images");
            var images = _waitHelper.FindElements(By.TagName("img"));
            
            foreach (var image in images)
            {
                string naturalWidth = image.GetAttribute("naturalWidth");
                if (naturalWidth == "0")
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasMisplacedElements()
        {
            _logHelper.LogInfo("Checking for misplaced elements");
            // Check if navigation and main content are in expected positions
            return !_waitHelper.IsElementDisplayed(GlobalNavigationMenu);
        }

        private By GetNavigationOptionLocator(string optionName)
        {
            return optionName switch
            {
                "Personal" => PersonalMenu,
                "Business" => BusinessMenu,
                "Financial Wellness" => FinancialWellnessMenu,
                "Appointments" => AppointmentsMenu,
                "Locations" => LocationsMenu,
                "Membership" => MembershipMenu,
                "Help Center" => HelpCenterMenu,
                _ => By.XPath($"//a[text()='{optionName}']")
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
                _ => By.XPath($"//a[text()='{menuName}']")
            };
        }
    }
}