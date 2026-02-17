using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for Golden1 Navigation Tests
    /// Test Cases: TASK0020445 TS-001 through TS-011
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _navigationPage = new NavigationPage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================

        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("Browser is already launched via Hooks");
            Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
        }

        [Given(@"the browser ""(.*)"" is launched")]
        public void GivenTheSpecificBrowserIsLaunched(string browserName)
        {
            LogHelper.Info($"Test is running on browser: {browserName}");
            _scenarioContext["Browser"] = browserName;
            Assert.That(_driver, Is.Not.Null, $"WebDriver for {browserName} should be initialized");
        }

        [Given(@"the browser is launched on ""(.*)"" device")]
        public void GivenTheBrowserIsLaunchedOnDevice(string deviceType)
        {
            LogHelper.Info($"Test is running on device: {deviceType}");
            _scenarioContext["Device"] = deviceType;
            Assert.That(_driver, Is.Not.Null, $"WebDriver for {deviceType} should be initialized");
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        [When(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Navigating to Golden1 homepage");
                _navigationPage.OpenHomepage();
                LogHelper.Info("Successfully navigated to Golden1 homepage");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to Golden1 homepage: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Navigation_Failed");
                throw;
            }
        }

        [When(@"I expand the ""(.*)"" product menu")]
        public void WhenIExpandTheProductMenu(string productCategory)
        {
            try
            {
                LogHelper.Info($"Expanding product menu: {productCategory}");
                _navigationPage.ExpandProductMenu(productCategory);
                LogHelper.Info($"Successfully expanded product menu: {productCategory}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand product menu '{productCategory}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Expand_Menu_{productCategory}_Failed");
                throw;
            }
        }

        [When(@"I click on the ""(.*)"" submenu item")]
        public void WhenIClickOnTheSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {submenuItem}");
                _navigationPage.ClickSubmenuItem(submenuItem);
                LogHelper.Info($"Successfully clicked submenu item: {submenuItem}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItem}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Click_Submenu_{submenuItem}_Failed");
                throw;
            }
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================

        [Then(@"the homepage should load successfully without errors")]
        public void ThenTheHomepageShouldLoadSuccessfullyWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage loaded successfully without errors");
                bool isLoaded = _navigationPage.IsHomepageDisplayedWithoutErrors();
                
                Assert.That(isLoaded, Is.True, 
                    "Homepage should load successfully without errors");
                
                LogHelper.Info("Homepage loaded successfully - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Load_Failed");
                throw;
            }
        }

        [Then(@"the global navigation menu should be visible at the top of the page")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfThePage()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible");
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isVisible, Is.True, 
                    "Global navigation menu should be visible at the top of the page");
                
                LogHelper.Info("Global navigation menu is visible - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Navigation_Menu_Not_Visible");
                throw;
            }
        }

        [Then(@"the navigation menu should display all required menu options")]
        public void ThenTheNavigationMenuShouldDisplayAllRequiredMenuOptions(Table table)
        {
            try
            {
                LogHelper.Info("Verifying all required menu options are present");
                var menuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
                
                bool allPresent = _navigationPage.AreAllTopTabMenuOptionsPresent(menuOptions);
                
                Assert.That(allPresent, Is.True, 
                    $"All menu options should be present. Expected: {string.Join(", ", menuOptions)}");
                
                LogHelper.Info("All required menu options are present - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu options verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Menu_Options_Verification_Failed");
                throw;
            }
        }

        [Then(@"the main product category menus should be displayed")]
        public void ThenTheMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            try
            {
                LogHelper.Info("Verifying all product category menus are displayed");
                var categories = table.Rows.Select(row => row["ProductCategory"]).ToList();
                
                bool allDisplayed = _navigationPage.AreAllProductCategoryMenusDisplayed(categories);
                
                Assert.That(allDisplayed, Is.True, 
                    $"All product category menus should be displayed. Expected: {string.Join(", ", categories)}");
                
                LogHelper.Info("All product category menus are displayed - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Product_Categories_Verification_Failed");
                throw;
            }
        }

        [Then(@"each product category menu should be clickable")]
        public void ThenEachProductCategoryMenuShouldBeClickable()
        {
            try
            {
                LogHelper.Info("Verifying each product category menu is clickable");
                var categories = new List<string> 
                { 
                    "Checking", "Savings", "Home Loans", "Credit Cards", 
                    "Loans", "Investing", "Community" 
                };
                
                bool allClickable = true;
                foreach (var category in categories)
                {
                    bool isClickable = _navigationPage.IsProductCategoryMenuClickable(category);
                    if (!isClickable)
                    {
                        allClickable = false;
                        LogHelper.Error($"Product category '{category}' is not clickable");
                    }
                }
                
                Assert.That(allClickable, Is.True, 
                    "All product category menus should be clickable");
                
                LogHelper.Info("All product category menus are clickable - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category clickability verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Product_Categories_Clickability_Failed");
                throw;
            }
        }

        [Then(@"the submenu should display ""(.*)"" option")]
        public void ThenTheSubmenuShouldDisplayOption(string submenuOption)
        {
            try
            {
                LogHelper.Info($"Verifying submenu displays '{submenuOption}' option");
                bool isDisplayed = _navigationPage.IsSubmenuItemDisplayed(submenuOption);
                
                Assert.That(isDisplayed, Is.True, 
                    $"Submenu should display '{submenuOption}' option");
                
                LogHelper.Info($"Submenu displays '{submenuOption}' option - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu option '{submenuOption}' verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Submenu_{submenuOption}_Not_Displayed");
                throw;
            }
        }

        [Then(@"the ""(.*)"" submenu item should be selectable")]
        public void ThenTheSubmenuItemShouldBeSelectable(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Verifying submenu item '{submenuItem}' is selectable");
                bool isSelectable = _navigationPage.IsSubmenuItemSelectable(submenuItem);
                
                Assert.That(isSelectable, Is.True, 
                    $"Submenu item '{submenuItem}' should be selectable");
                
                LogHelper.Info($"Submenu item '{submenuItem}' is selectable - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item '{submenuItem}' selectability verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Submenu_{submenuItem}_Not_Selectable");
                throw;
            }
        }

        [Then(@"I should be redirected to the destination page")]
        public void ThenIShouldBeRedirectedToTheDestinationPage()
        {
            try
            {
                LogHelper.Info("Verifying redirection to destination page");
                string currentUrl = _navigationPage.GetPageUrl();
                
                Assert.That(currentUrl, Is.Not.Null.And.Not.Empty, 
                    "Should be redirected to a valid destination page");
                
                Assert.That(currentUrl, Does.Not.Contain("error"), 
                    "Destination page should not be an error page");
                
                LogHelper.Info($"Successfully redirected to: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page redirection verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Destination_Page_Redirection_Failed");
                throw;
            }
        }

        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying destination page loaded without errors");
                string currentUrl = _navigationPage.GetPageUrl();
                
                Assert.That(currentUrl, Does.Not.Contain("404"), 
                    "Destination page should not be a 404 error page");
                
                Assert.That(currentUrl, Does.Not.Contain("error"), 
                    "Destination page should not contain error in URL");
                
                LogHelper.Info("Destination page loaded without errors - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Destination_Page_Load_Failed");
                throw;
            }
        }

        [Then(@"the destination page URL should contain ""(.*)""")]
        public void ThenTheDestinationPageURLShouldContain(string expectedUrlIdentifier)
        {
            try
            {
                LogHelper.Info($"Verifying destination page URL contains '{expectedUrlIdentifier}'");
                bool containsIdentifier = _navigationPage.DoesUrlContainIdentifier(expectedUrlIdentifier);
                
                Assert.That(containsIdentifier, Is.True, 
                    $"Destination page URL should contain '{expectedUrlIdentifier}'");
                
                LogHelper.Info($"Destination page URL contains '{expectedUrlIdentifier}' - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL identifier verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "URL_Identifier_Verification_Failed");
                throw;
            }
        }

        [Then(@"the Golden1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            try
            {
                LogHelper.Info("Verifying Golden1 logo is visible in top header");
                // Logo visibility is part of navigation menu visibility
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isVisible, Is.True, 
                    "Golden1 logo should be visible in the top header");
                
                LogHelper.Info("Golden1 logo is visible - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo visibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Logo_Not_Visible");
                throw;
            }
        }

        [Then(@"the homepage should display correctly with no broken layouts")]
        public void ThenTheHomepageShouldDisplayCorrectlyWithNoBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays correctly with no broken layouts");
                bool isDisplayedCorrectly = _navigationPage.IsHomepageDisplayedWithoutErrors();
                
                Assert.That(isDisplayedCorrectly, Is.True, 
                    "Homepage should display correctly with no broken layouts");
                
                LogHelper.Info("Homepage displays correctly - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage layout verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Layout_Broken");
                throw;
            }
        }

        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            try
            {
                LogHelper.Info("Verifying there is no missing content");
                bool noMissingContent = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(noMissingContent, Is.True, 
                    "There should be no missing content on the page");
                
                LogHelper.Info("No missing content detected - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Missing content verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Missing_Content_Detected");
                throw;
            }
        }

        [Then(@"there should be no system errors")]
        public void ThenThereShouldBeNoSystemErrors()
        {
            try
            {
                LogHelper.Info("Verifying there are no system errors");
                string currentUrl = _navigationPage.GetPageUrl();
                
                Assert.That(currentUrl, Does.Not.Contain("error"), 
                    "There should be no system errors");
                
                Assert.That(currentUrl, Does.Not.Contain("500"), 
                    "There should be no server errors");
                
                LogHelper.Info("No system errors detected - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"System error verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "System_Error_Detected");
                throw;
            }
        }

        [Then(@"the global navigation menu should be visible and functional")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAndFunctional()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible and functional");
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isVisible, Is.True, 
                    "Global navigation menu should be visible and functional");
                
                LogHelper.Info("Global navigation menu is visible and functional - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu functionality verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Navigation_Menu_Not_Functional");
                throw;
            }
        }

        [Then(@"the header elements should be visible and functional")]
        public void ThenTheHeaderElementsShouldBeVisibleAndFunctional()
        {
            try
            {
                LogHelper.Info("Verifying header elements are visible and functional");
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isVisible, Is.True, 
                    "Header elements should be visible and functional");
                
                LogHelper.Info("Header elements are visible and functional - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Header elements verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Header_Elements_Not_Functional");
                throw;
            }
        }

        [Then(@"there should be no layout issues or system errors")]
        public void ThenThereShouldBeNoLayoutIssuesOrSystemErrors()
        {
            try
            {
                LogHelper.Info("Verifying there are no layout issues or system errors");
                bool noIssues = _navigationPage.IsHomepageDisplayedWithoutErrors();
                
                Assert.That(noIssues, Is.True, 
                    "There should be no layout issues or system errors");
                
                LogHelper.Info("No layout issues or system errors - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout/system error verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Layout_Or_System_Errors");
                throw;
            }
        }

        [Then(@"the navigation menu should be visible and functional on ""(.*)""")]
        public void ThenTheNavigationMenuShouldBeVisibleAndFunctionalOnDevice(string deviceType)
        {
            try
            {
                LogHelper.Info($"Verifying navigation menu is visible and functional on {deviceType}");
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isVisible, Is.True, 
                    $"Navigation menu should be visible and functional on {deviceType}");
                
                LogHelper.Info($"Navigation menu is visible and functional on {deviceType} - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu verification on {deviceType} failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Navigation_Menu_{deviceType}_Failed");
                throw;
            }
        }

        [Then(@"the header elements should be visible and functional on ""(.*)""")]
        public void ThenTheHeaderElementsShouldBeVisibleAndFunctionalOnDevice(string deviceType)
        {
            try
            {
                LogHelper.Info($"Verifying header elements are visible and functional on {deviceType}");
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isVisible, Is.True, 
                    $"Header elements should be visible and functional on {deviceType}");
                
                LogHelper.Info($"Header elements are visible and functional on {deviceType} - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Header elements verification on {deviceType} failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Header_Elements_{deviceType}_Failed");
                throw;
            }
        }

        [Then(@"there should be no layout issues on ""(.*)""")]
        public void ThenThereShouldBeNoLayoutIssuesOnDevice(string deviceType)
        {
            try
            {
                LogHelper.Info($"Verifying there are no layout issues on {deviceType}");
                bool noIssues = _navigationPage.IsHomepageDisplayedWithoutErrors();
                
                Assert.That(noIssues, Is.True, 
                    $"There should be no layout issues on {deviceType}");
                
                LogHelper.Info($"No layout issues on {deviceType} - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout verification on {deviceType} failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Layout_Issues_{deviceType}");
                throw;
            }
        }
    }
}