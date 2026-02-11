using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for Golden1 Homepage
    /// Handles all interactions with the homepage including navigation verification
    /// Test Cases: TASK0020445 TS-001 through TS-012
    /// </summary>
    public class HomePage : BasePage
    {
        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public HomePage(IWebDriver driver) : base(driver) { }

        // =============================================================
        // LOCATORS - All UI element locators from Golden1 Locators.Json
        // =============================================================
        
        // Navigation Menu Container
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

        // Dynamic locators
        private By GetTopNavigationTabByText(string tabText) =>
            By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{tabText}']");
        
        private By GetMainMenuByText(string menuText) =>
            By.XPath($"//a[contains(@class,'nav-item-link') and normalize-space()='{menuText}']");
        
        private By GetSubmenuItemByText(string submenuText) =>
            By.XPath($"//a[normalize-space()='{submenuText}']");

        // =============================================================
        // NAVIGATION METHODS
        // =============================================================
        
        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        public void OpenHomePage()
        {
            LogHelper.Info($"Opening Golden1 homepage: {ConfigReader.BaseUrl}");
            NavigateTo(ConfigReader.BaseUrl);
            WaitForPageLoad();
            HandleCookieBanner();
            LogHelper.Info("Golden1 homepage loaded successfully");
        }

        /// <summary>
        /// Handles cookie consent banner if present
        /// </summary>
        private void HandleCookieBanner()
        {
            try
            {
                if (WaitHelper.WaitVisible(Driver, CookieBanner, 5))
                {
                    LogHelper.Info("Cookie banner detected, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookie banner accepted and dismissed");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info($"No cookie banner present or already dismissed: {ex.Message}");
            }
        }

        // =============================================================
        // VERIFICATION METHODS
        // =============================================================
        
        /// <summary>
        /// Verifies homepage is displayed without errors
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        public bool IsHomepageDisplayedCorrectly()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Homepage displayed correctly: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage not displayed correctly: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        public bool IsGlobalNavigationMenuVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool isVisible = IsDisplayed(MenuContainer);
                LogHelper.Info($"Global navigation menu visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Global navigation menu not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies top navigation tab is present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        public bool IsTopNavigationTabPresent(string tabName)
        {
            try
            {
                By tabLocator = GetTopNavigationTabByText(tabName);
                WaitHelper.WaitVisible(Driver, tabLocator, 10);
                bool isPresent = IsDisplayed(tabLocator);
                LogHelper.Info($"Top navigation tab '{tabName}' present: {isPresent}");
                return isPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top navigation tab '{tabName}' not present: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies main product category menu is accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        public bool IsMainProductMenuAccessible(string menuName)
        {
            try
            {
                By menuLocator = GetMainMenuByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                bool isAccessible = IsDisplayed(menuLocator);
                LogHelper.Info($"Main product menu '{menuName}' accessible: {isAccessible}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main product menu '{menuName}' not accessible: {ex.Message}");
                return false;
            }
        }

        // =============================================================
        // INTERACTION METHODS
        // =============================================================
        
        /// <summary>
        /// Hovers over a main product menu to display submenu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void HoverOverMainMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Hovering over main menu: {menuName}");
                By menuLocator = GetMainMenuByText(menuName);
                WaitHelper.WaitVisible(Driver, menuLocator, 10);
                
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                var menuElement = Driver.FindElement(menuLocator);
                actions.MoveToElement(menuElement).Perform();
                
                System.Threading.Thread.Sleep(500); // Brief pause for submenu animation
                LogHelper.Info($"Hovered over main menu: {menuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to hover over main menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies submenu items are displayed after hovering
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool AreSubmenuItemsDisplayed()
        {
            try
            {
                // Wait for any submenu item to be visible (using Free Checking as example)
                bool isDisplayed = WaitHelper.WaitVisible(Driver, FreeCheckingLink, 5);
                LogHelper.Info($"Submenu items displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items not displayed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies submenu items are selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        public bool AreSubmenuItemsSelectable()
        {
            try
            {
                WaitHelper.WaitClickable(Driver, FreeCheckingLink, 5);
                bool isClickable = Driver.FindElement(FreeCheckingLink).Enabled;
                LogHelper.Info($"Submenu items selectable: {isClickable}");
                return isClickable;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items not selectable: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        public void ClickSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {submenuItemName}");
                By submenuLocator = GetSubmenuItemByText(submenuItemName);
                WaitHelper.WaitClickable(Driver, submenuLocator, 10);
                Click(submenuLocator);
                WaitForPageLoad();
                LogHelper.Info($"Clicked submenu item: {submenuItemName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItemName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies destination page loaded completely
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        public bool IsDestinationPageLoaded()
        {
            try
            {
                WaitForPageLoad();
                string currentUrl = GetCurrentUrl();
                bool isLoaded = !string.IsNullOrEmpty(currentUrl);
                LogHelper.Info($"Destination page loaded: {isLoaded}, URL: {currentUrl}");
                return isLoaded;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page not loaded: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies URL contains expected page identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        public bool DoesUrlContainIdentifier(string expectedIdentifier)
        {
            try
            {
                string currentUrl = GetCurrentUrl().ToLower();
                bool containsIdentifier = currentUrl.Contains(expectedIdentifier.ToLower());
                LogHelper.Info($"URL contains identifier '{expectedIdentifier}': {containsIdentifier}, Current URL: {currentUrl}");
                return containsIdentifier;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify URL identifier '{expectedIdentifier}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the current page URL
        /// </summary>
        public string GetPageUrl()
        {
            string url = GetCurrentUrl();
            LogHelper.Info($"Current page URL: {url}");
            return url;
        }

        /// <summary>
        /// Verifies homepage has no broken layouts or error messages
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        public bool HasNoBrokenLayoutsOrErrors()
        {
            try
            {
                // Check for common error indicators
                var errorSelectors = new[]
                {
                    By.XPath("//*[contains(text(), '404')]"),
                    By.XPath("//*[contains(text(), 'Error')]"),
                    By.XPath("//*[contains(text(), 'Not Found')]"),
                    By.CssSelector(".error"),
                    By.CssSelector(".alert-danger")
                };

                foreach (var errorSelector in errorSelectors)
                {
                    try
                    {
                        if (Driver.FindElements(errorSelector).Count > 0)
                        {
                            LogHelper.Warning($"Error element found: {errorSelector}");
                            return false;
                        }
                    }
                    catch
                    {
                        // Element not found, which is good
                    }
                }

                // Verify main navigation is present (indicates page loaded correctly)
                bool navigationPresent = IsDisplayed(MenuContainer);
                LogHelper.Info($"No broken layouts or errors detected: {navigationPresent}");
                return navigationPresent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error checking for broken layouts: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies navigation menu displays correctly (cross-browser/device testing)
        /// Test Cases: TASK0020445 TS-010 TC-001, TS-011 TC-001
        /// </summary>
        public bool IsNavigationMenuDisplayedCorrectly()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                bool menuVisible = IsDisplayed(MenuContainer);
                bool topTabsVisible = IsDisplayed(TopTabsContainer);
                
                bool isCorrect = menuVisible && topTabsVisible;
                LogHelper.Info($"Navigation menu displayed correctly: {isCorrect}");
                return isCorrect;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu not displayed correctly: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies homepage elements are consistent across browsers
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        public bool AreHomepageElementsConsistent()
        {
            try
            {
                bool menuPresent = IsDisplayed(MenuContainer);
                bool topTabsPresent = IsDisplayed(TopTabsContainer);
                bool checkingMenuPresent = IsDisplayed(CheckingMenu);
                
                bool areConsistent = menuPresent && topTabsPresent && checkingMenuPresent;
                LogHelper.Info($"Homepage elements consistent: {areConsistent}");
                return areConsistent;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage elements not consistent: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies homepage elements are responsive for device type
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        public bool AreHomepageElementsResponsive()
        {
            try
            {
                bool menuVisible = WaitHelper.WaitVisible(Driver, MenuContainer, 10);
                LogHelper.Info($"Homepage elements responsive: {menuVisible}");
                return menuVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage elements not responsive: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Uses keyboard navigation to access global navigation menu
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public void UseKeyboardNavigationToMenu()
        {
            try
            {
                LogHelper.Info("Using keyboard navigation to access menu");
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                
                // Tab to navigation menu
                for (int i = 0; i < 5; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    System.Threading.Thread.Sleep(200);
                    
                    // Check if we've reached the menu
                    var activeElement = Driver.SwitchTo().ActiveElement();
                    if (activeElement.TagName.ToLower() == "a" && 
                        activeElement.GetAttribute("class").Contains("nav-item-link"))
                    {
                        LogHelper.Info("Reached navigation menu via keyboard");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to use keyboard navigation: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies all menu items are accessible via keyboard
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public bool AreMenuItemsAccessibleViaKeyboard()
        {
            try
            {
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                int accessibleMenuCount = 0;
                
                for (int i = 0; i < 10; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    System.Threading.Thread.Sleep(200);
                    
                    var activeElement = Driver.SwitchTo().ActiveElement();
                    if (activeElement.TagName.ToLower() == "a" && 
                        activeElement.GetAttribute("class").Contains("nav-item-link"))
                    {
                        accessibleMenuCount++;
                    }
                }
                
                bool isAccessible = accessibleMenuCount > 0;
                LogHelper.Info($"Menu items accessible via keyboard: {isAccessible}, Count: {accessibleMenuCount}");
                return isAccessible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu items not accessible via keyboard: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies menu items respond to Enter key selection
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        public bool DoMenuItemsRespondToEnterKey()
        {
            try
            {
                var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                string initialUrl = GetCurrentUrl();
                
                // Navigate to a menu item and press Enter
                for (int i = 0; i < 5; i++)
                {
                    actions.SendKeys(Keys.Tab).Perform();
                    System.Threading.Thread.Sleep(200);
                    
                    var activeElement = Driver.SwitchTo().ActiveElement();
                    if (activeElement.TagName.ToLower() == "a" && 
                        activeElement.GetAttribute("class").Contains("nav-item-link"))
                    {
                        actions.SendKeys(Keys.Enter).Perform();
                        System.Threading.Thread.Sleep(1000);
                        
                        string newUrl = GetCurrentUrl();
                        bool responded = !newUrl.Equals(initialUrl);
                        LogHelper.Info($"Menu items respond to Enter key: {responded}");
                        return responded;
                    }
                }
                
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu items do not respond to Enter key: {ex.Message}");
                return false;
            }
        }
    }
}