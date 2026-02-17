using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Navigation
    /// Handles all interactions with navigation menu and page verification
    /// Test Cases: TASK0020445 TS-001 through TS-009
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

        // Navigation Container
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

        // Main Product Category Menus
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

        // Cookie Banner
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // Page Elements for Verification
        private By PageLogo => By.CssSelector("a.logo, img[alt*='Golden 1'], img[alt*='logo']");
        private By PageBody => By.TagName("body");
        private By ErrorMessages => By.CssSelector(".error, .alert-danger, [class*='error'], [id*='error']");
        private By LoadingSpinner => By.CssSelector(".spinner, .loading, [class*='loading']");

        // Dynamic Locators
        private By GetTopMenuByText(string menuText) =>
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{menuText}']");

        private By GetMainProductMenuByText(string menuText) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuText}']");

        private By GetSubmenuItemByText(string submenuText) =>
            By.XPath($"//a[normalize-space()='{submenuText}']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================

        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001 Step 2
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info($"[NavigationPage] Opening Golden1 homepage: {ConfigReader.BaseUrl}");
            try
            {
                NavigateTo(ConfigReader.BaseUrl);
                WaitForPageLoad();
                WaitHelper.WaitForPageReady(Driver, 30);
                LogHelper.Info("Homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Handles cookie consent banner if present
        /// Test Cases: All test cases (Background step)
        /// </summary>
        public void HandleCookieBanner()
        {
            LogHelper.Info("[NavigationPage] Checking for cookie banner");
            try
            {
                if (IsDisplayed(CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookie banner handled successfully");
                }
                else
                {
                    LogHelper.Info("No cookie banner present");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner handling failed (non-critical): {ex.Message}");
            }
        }

        // =============================================================
        // INTERACTION METHODS - Menu Actions
        // =============================================================

        /// <summary>
        /// Clicks on a main product menu
        /// Test Cases: TASK0020445 TS-004 TC-001 Step 4, TS-005 TC-001 Step 2
        /// </summary>
        public void ClickMainProductMenu(string menuName)
        {
            LogHelper.Info($"[NavigationPage] Clicking main product menu: {menuName}");
            try
            {
                By menuLocator = GetMainProductMenuLocator(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                Click(menuLocator);
                System.Threading.Thread.Sleep(1000); // Allow submenu to expand
                LogHelper.Info($"Main product menu '{menuName}' clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click main product menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001 Step 4, TS-006 TC-001 Step 3
        /// </summary>
        public void ClickSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"[NavigationPage] Clicking submenu item: {submenuItem}");
            try
            {
                By submenuLocator = GetSubmenuLocator(submenuItem);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Submenu item '{submenuItem}' clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItem}': {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // VERIFICATION METHODS - Boolean Returns
        // =============================================================

        /// <summary>
        /// Verifies if homepage is loaded
        /// Test Cases: TASK0020445 TS-001 TC-001 Step 2 Expected Result
        /// </summary>
        public bool IsHomePageLoaded()
        {
            LogHelper.Info("[NavigationPage] Verifying homepage is loaded");
            try
            {
                string currentUrl = GetCurrentUrl();
                bool urlMatches = currentUrl.Contains("golden1.com");
                bool pageReady = IsPageReady();
                bool result = urlMatches && pageReady;
                
                LogHelper.Info($"Homepage loaded: {result} (URL: {currentUrl}, PageReady: {pageReady})");
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001 Step 2, TS-003 TC-001 Step 2
        /// </summary>
        public bool IsNavigationMenuVisible()
        {
            LogHelper.Info("[NavigationPage] Checking navigation menu visibility");
            try
            {
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if navigation menu is at the top of the page
        /// Test Cases: TASK0020445 TS-002 TC-001 Step 2 Expected Result
        /// </summary>
        public bool IsNavigationMenuAtTop()
        {
            LogHelper.Info("[NavigationPage] Checking if navigation menu is at top");
            try
            {
                IWebElement menuElement = Driver.FindElement(MenuContainer);
                int yPosition = menuElement.Location.Y;
                bool isAtTop = yPosition < 200; // Menu should be within top 200px
                LogHelper.Info($"Navigation menu at top: {isAtTop} (Y position: {yPosition})");
                return isAtTop;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu position check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if a specific top menu option is present
        /// Test Cases: TASK0020445 TS-003 TC-001 Step 3 Expected Result
        /// </summary>
        public bool IsTopMenuOptionPresent(string menuOption)
        {
            LogHelper.Info($"[NavigationPage] Checking if top menu option '{menuOption}' is present");
            try
            {
                By menuLocator = GetTopMenuLocator(menuOption);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isPresent = IsDisplayed(menuLocator);
                LogHelper.Info($"Top menu option '{menuOption}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Top menu option '{menuOption}' not found: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if a main product menu is displayed
        /// Test Cases: TASK0020445 TS-004 TC-001 Step 3 Expected Result
        /// </summary>
        public bool IsMainProductMenuDisplayed(string productMenu)
        {
            LogHelper.Info($"[NavigationPage] Checking if product menu '{productMenu}' is displayed");
            try
            {
                By menuLocator = GetMainProductMenuLocator(productMenu);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isDisplayed = IsDisplayed(menuLocator);
                LogHelper.Info($"Product menu '{productMenu}' displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Product menu '{productMenu}' not found: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if a main product menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001 Step 4 Expected Result
        /// </summary>
        public bool IsMainProductMenuClickable(string productMenu)
        {
            LogHelper.Info($"[NavigationPage] Checking if product menu '{productMenu}' is clickable");
            try
            {
                By menuLocator = GetMainProductMenuLocator(productMenu);
                WaitHelper.WaitClickable(Driver, menuLocator, 10);
                IWebElement menuElement = Driver.FindElement(menuLocator);
                bool isClickable = menuElement.Enabled && menuElement.Displayed;
                LogHelper.Info($"Product menu '{productMenu}' clickable: {isClickable}");
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Product menu '{productMenu}' clickability check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001 Step 3 Expected Result
        /// </summary>
        public bool HasSubmenuItems()
        {
            LogHelper.Info("[NavigationPage] Checking if submenu items are displayed");
            try
            {
                // Wait for any submenu items to appear
                System.Threading.Thread.Sleep(1000);
                var submenuItems = Driver.FindElements(By.CssSelector("nav a, .menu a, [class*='submenu'] a"));
                bool hasItems = submenuItems.Count > 5; // Should have multiple submenu items
                LogHelper.Info($"Submenu items present: {hasItems} (Found {submenuItems.Count} items)");
                return hasItems;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if a submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001 Step 4 Expected Result
        /// </summary>
        public bool IsSubmenuItemSelectable(string submenuItem)
        {
            LogHelper.Info($"[NavigationPage] Checking if submenu item '{submenuItem}' is selectable");
            try
            {
                By submenuLocator = GetSubmenuLocator(submenuItem);
                WaitHelper.WaitVisible(Driver, submenuLocator, 10);
                IWebElement submenuElement = Driver.FindElement(submenuLocator);
                bool isSelectable = submenuElement.Enabled && submenuElement.Displayed;
                LogHelper.Info($"Submenu item '{submenuItem}' selectable: {isSelectable}");
                return isSelectable;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Submenu item '{submenuItem}' selectability check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if page has error messages
        /// Test Cases: TASK0020445 TS-001 TC-001 Step 3, TS-006 TC-001 Step 3
        /// </summary>
        public bool HasErrorMessages()
        {
            LogHelper.Info("[NavigationPage] Checking for error messages");
            try
            {
                var errorElements = Driver.FindElements(ErrorMessages);
                bool hasErrors = errorElements.Any(e => e.Displayed);
                
                if (hasErrors)
                {
                    var errorTexts = errorElements.Where(e => e.Displayed).Select(e => e.Text);
                    LogHelper.Warning($"Error messages found: {string.Join(", ", errorTexts)}");
                }
                else
                {
                    LogHelper.Info("No error messages found");
                }
                
                return hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No error messages detected: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if page is fully loaded and ready
        /// Test Cases: TASK0020445 TS-001 TC-001 Step 3, TS-006 TC-001 Step 3
        /// </summary>
        public bool IsPageReady()
        {
            LogHelper.Info("[NavigationPage] Checking if page is ready");
            try
            {
                WaitForPageLoad();
                
                // Check if loading spinner is gone
                bool noSpinner = !IsDisplayed(LoadingSpinner, 2);
                
                // Check if body is present
                bool bodyPresent = IsDisplayed(PageBody);
                
                bool isReady = noSpinner && bodyPresent;
                LogHelper.Info($"Page ready: {isReady} (NoSpinner: {noSpinner}, BodyPresent: {bodyPresent})");
                return isReady;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Page ready check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if Golden1 logo is visible
        /// Test Cases: TASK0020445 TS-008 TC-001 Step 2 Expected Result
        /// </summary>
        public bool IsLogoVisible()
        {
            LogHelper.Info("[NavigationPage] Checking if Golden1 logo is visible");
            try
            {
                WaitHelper.WaitVisible(Driver, PageLogo, 10);
                bool isVisible = IsDisplayed(PageLogo);
                LogHelper.Info($"Golden1 logo visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo visibility check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if homepage displays correctly
        /// Test Cases: TASK0020445 TS-009 TC-001 Step 2 Expected Result
        /// </summary>
        public bool IsHomePageDisplayedCorrectly()
        {
            LogHelper.Info("[NavigationPage] Checking if homepage displays correctly");
            try
            {
                bool logoVisible = IsLogoVisible();
                bool menuVisible = IsNavigationMenuVisible();
                bool pageReady = IsPageReady();
                bool noErrors = !HasErrorMessages();
                
                bool isCorrect = logoVisible && menuVisible && pageReady && noErrors;
                LogHelper.Info($"Homepage displayed correctly: {isCorrect}");
                return isCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage display check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks for broken layouts
        /// Test Cases: TASK0020445 TS-009 TC-001 Step 2 Expected Result
        /// </summary>
        public bool HasBrokenLayout()
        {
            LogHelper.Info("[NavigationPage] Checking for broken layouts");
            try
            {
                // Check if major page elements are in expected positions
                bool logoPresent = IsDisplayed(PageLogo, 5);
                bool menuPresent = IsDisplayed(MenuContainer, 5);
                bool bodyPresent = IsDisplayed(PageBody);
                
                bool layoutOk = logoPresent && menuPresent && bodyPresent;
                bool hasBroken = !layoutOk;
                
                LogHelper.Info($"Broken layout detected: {hasBroken}");
                return hasBroken;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Layout check encountered issue: {ex.Message}");
                return true; // Assume broken if check fails
            }
        }

        /// <summary>
        /// Checks for missing content
        /// Test Cases: TASK0020445 TS-009 TC-001 Step 2 Expected Result
        /// </summary>
        public bool HasMissingContent()
        {
            LogHelper.Info("[NavigationPage] Checking for missing content");
            try
            {
                // Verify essential content is present
                bool hasLogo = IsDisplayed(PageLogo, 5);
                bool hasMenu = IsDisplayed(MenuContainer, 5);
                bool hasBody = IsDisplayed(PageBody);
                
                string bodyText = Driver.FindElement(PageBody).Text;
                bool hasText = !string.IsNullOrWhiteSpace(bodyText) && bodyText.Length > 100;
                
                bool contentComplete = hasLogo && hasMenu && hasBody && hasText;
                bool hasMissing = !contentComplete;
                
                LogHelper.Info($"Missing content detected: {hasMissing}");
                return hasMissing;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Content check encountered issue: {ex.Message}");
                return true; // Assume missing if check fails
            }
        }

        /// <summary>
        /// Checks for system errors
        /// Test Cases: TASK0020445 TS-009 TC-001 Step 2 Expected Result
        /// </summary>
        public bool HasSystemErrors()
        {
            LogHelper.Info("[NavigationPage] Checking for system errors");
            try
            {
                // Check for various error indicators
                bool hasErrorMessages = HasErrorMessages();
                
                // Check for common error text in body
                string pageText = Driver.FindElement(PageBody).Text.ToLower();
                bool hasErrorText = pageText.Contains("error") || 
                                   pageText.Contains("exception") || 
                                   pageText.Contains("500") ||
                                   pageText.Contains("404") ||
                                   pageText.Contains("something went wrong");
                
                bool hasErrors = hasErrorMessages || hasErrorText;
                LogHelper.Info($"System errors detected: {hasErrors}");
                return hasErrors;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"System error check encountered issue: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // DATA RETRIEVAL METHODS
        // =============================================================

        /// <summary>
        /// Gets the current page URL
        /// Test Cases: TASK0020445 TS-007 TC-001 Step 3 Expected Result
        /// </summary>
        public string GetCurrentUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"[NavigationPage] Current URL: {url}");
            return url;
        }

        // =============================================================
        // HELPER METHODS - Private
        // =============================================================

        /// <summary>
        /// Gets the locator for a top menu option
        /// </summary>
        private By GetTopMenuLocator(string menuOption)
        {
            return menuOption switch
            {
                "Personal" => PersonalTab,
                "Business" => BusinessTab,
                "Financial Wellness" => FinancialWellnessTab,
                "Appointments" => AppointmentsTab,
                "Locations" => LocationsTab,
                "Membership" => MembershipTab,
                "Help Center" => HelpCenterTab,
                _ => GetTopMenuByText(menuOption)
            };
        }

        /// <summary>
        /// Gets the locator for a main product menu
        /// </summary>
        private By GetMainProductMenuLocator(string productMenu)
        {
            return productMenu switch
            {
                "Checking" => CheckingMenu,
                "Savings" => SavingsMenu,
                "Home Loans" => HomeLoansMenu,
                "Credit Cards" => CreditCardsMenu,
                "Loans" => LoansMenu,
                "Investing" => InvestingMenu,
                "Community" => CommunityMenu,
                _ => GetMainProductMenuByText(productMenu)
            };
        }

        /// <summary>
        /// Gets the locator for a submenu item
        /// </summary>
        private By GetSubmenuLocator(string submenuItem)
        {
            return submenuItem switch
            {
                "Free Checking" => FreeCheckingLink,
                "Savings Account" => SavingsAccountLink,
                "Auto Loans" => AutoLoansLink,
                _ => GetSubmenuItemByText(submenuItem)
            };
        }
    }
}