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
    /// Step Definitions for Golden1 Navigation scenarios
    /// Test Cases: TASK0020445 TS-001 through TS-009
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _homePage = new HomePage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================

        /// <summary>
        /// Launches the browser
        /// Test Cases: TASK0020445 TS-001 TC-001 through TS-009 TC-001
        /// </summary>
        [Given(@"I launch the browser")]
        public void GivenILaunchTheBrowser()
        {
            try
            {
                LogHelper.Info("Step: Launching browser");
                // Browser is already launched in Hooks.cs
                Assert.That(_driver, Is.Not.Null, "Browser should be launched");
                LogHelper.Info("Browser launched successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to launch browser: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        /// <summary>
        /// Navigates to Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001 through TS-009 TC-001
        /// </summary>
        [When(@"I navigate to Golden1 homepage")]
        public void WhenINavigateToGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Step: Navigating to Golden1 homepage");
                _homePage.OpenHomePage();
                LogHelper.Info("Navigation to homepage completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "NavigationError");
                throw;
            }
        }

        /// <summary>
        /// Expands a product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I expand the ""(.*)"" menu")]
        public void WhenIExpandTheMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Step: Expanding '{menuName}' menu");
                _homePage.ExpandProductMenu(menuName);
                LogHelper.Info($"Menu '{menuName}' expanded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand menu '{menuName}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"ExpandMenu_{menuName}_Error");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I click on ""(.*)"" submenu item")]
        public void WhenIClickOnSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Step: Clicking submenu item '{submenuItemName}'");
                _homePage.ClickSubmenuItem(submenuItemName);
                LogHelper.Info($"Submenu item '{submenuItemName}' clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItemName}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"ClickSubmenu_{submenuItemName}_Error");
                throw;
            }
        }

        /// <summary>
        /// Observes the top section of homepage
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [When(@"I observe the top section of the homepage")]
        public void WhenIObserveTheTopSectionOfTheHomepage()
        {
            try
            {
                LogHelper.Info("Step: Observing top section of homepage");
                // Verification will be done in Then step
                System.Threading.Thread.Sleep(500); // Brief pause for observation
                LogHelper.Info("Top section observation completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to observe top section: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================

        /// <summary>
        /// Verifies homepage loads successfully without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the homepage should load successfully without errors")]
        public void ThenTheHomepageShouldLoadSuccessfullyWithoutErrors()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying homepage loaded successfully");
                
                bool isLoaded = _homePage.IsHomePageLoaded();
                Assert.That(isLoaded, Is.True, "Homepage should load successfully");
                
                bool hasNoErrors = _homePage.HasNoErrors();
                Assert.That(hasNoErrors, Is.True, "Homepage should not display any errors");
                
                LogHelper.Info("Homepage loaded successfully without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "HomepageLoadError");
                throw;
            }
        }

        /// <summary>
        /// Verifies global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying navigation menu visibility");
                
                bool isVisible = _homePage.IsNavigationMenuVisible();
                Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top");
                
                LogHelper.Info("Navigation menu is visible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "NavigationMenuVisibilityError");
                throw;
            }
        }

        /// <summary>
        /// Verifies all specified menu options are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"the navigation menu should contain the following options:")]
        public void ThenTheNavigationMenuShouldContainTheFollowingOptions(Table table)
        {
            try
            {
                LogHelper.Info("Assertion: Verifying menu options are present");
                
                var menuOptions = table.Rows.Select(row => row[0]).ToList();
                
                foreach (var option in menuOptions)
                {
                    LogHelper.Info($"Checking menu option: {option}");
                    bool isPresent = _homePage.IsTopTabMenuOptionPresent(option);
                    Assert.That(isPresent, Is.True, $"Menu option '{option}' should be present");
                    LogHelper.Info($"Menu option '{option}' is present");
                }
                
                LogHelper.Info("All menu options are present");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu options verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "MenuOptionsError");
                throw;
            }
        }

        /// <summary>
        /// Verifies main product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"the main product category menus should be displayed:")]
        public void ThenTheMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            try
            {
                LogHelper.Info("Assertion: Verifying product category menus are displayed");
                
                var productMenus = table.Rows.Select(row => row[0]).ToList();
                
                foreach (var menu in productMenus)
                {
                    LogHelper.Info($"Checking product menu: {menu}");
                    bool isDisplayed = _homePage.IsProductCategoryMenuDisplayed(menu);
                    Assert.That(isDisplayed, Is.True, $"Product menu '{menu}' should be displayed");
                    LogHelper.Info($"Product menu '{menu}' is displayed");
                }
                
                LogHelper.Info("All product category menus are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "ProductMenusError");
                throw;
            }
        }

        /// <summary>
        /// Verifies each product category menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"each product category menu should be clickable")]
        public void ThenEachProductCategoryMenuShouldBeClickable()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying product menus are clickable");
                
                var productMenus = new List<string> 
                { 
                    "Checking", "Savings", "Home Loans", "Credit Cards", 
                    "Loans", "Investing", "Community" 
                };
                
                foreach (var menu in productMenus)
                {
                    LogHelper.Info($"Checking if menu '{menu}' is clickable");
                    bool isClickable = _homePage.IsProductCategoryMenuClickable(menu);
                    Assert.That(isClickable, Is.True, $"Product menu '{menu}' should be clickable");
                    LogHelper.Info($"Product menu '{menu}' is clickable");
                }
                
                LogHelper.Info("All product category menus are clickable");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menus clickability verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "MenuClickabilityError");
                throw;
            }
        }

        /// <summary>
        /// Verifies submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"the submenu should display items")]
        public void ThenTheSubmenuShouldDisplayItems()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying submenu items are displayed");
                
                bool areDisplayed = _homePage.AreSubmenuItemsDisplayed();
                Assert.That(areDisplayed, Is.True, "Submenu items should be displayed");
                
                LogHelper.Info("Submenu items are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "SubmenuItemsError");
                throw;
            }
        }

        /// <summary>
        /// Verifies submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"I should be able to select ""(.*)"" submenu item")]
        public void ThenIShouldBeAbleToSelectSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Assertion: Verifying submenu item '{submenuItemName}' is selectable");
                
                // Attempt to click the submenu item
                _homePage.ClickSubmenuItem(submenuItemName);
                
                // If no exception, item was selectable
                LogHelper.Info($"Submenu item '{submenuItemName}' is selectable");
                Assert.Pass($"Submenu item '{submenuItemName}' was successfully selected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item selection failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"SubmenuSelection_{submenuItemName}_Error");
                throw;
            }
        }

        /// <summary>
        /// Verifies user is redirected to destination page
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"I should be redirected to the Free Checking page")]
        public void ThenIShouldBeRedirectedToTheFreeCheckingPage()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying redirection to Free Checking page");
                
                string currentUrl = _homePage.GetPageUrl();
                bool isRedirected = currentUrl.Contains("checking") || currentUrl.Contains("free");
                Assert.That(isRedirected, Is.True, "User should be redirected to Free Checking page");
                
                LogHelper.Info("Successfully redirected to Free Checking page");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Redirection verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "RedirectionError");
                throw;
            }
        }

        /// <summary>
        /// Verifies destination page loads without errors
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying destination page loaded without errors");
                
                bool hasNoErrors = _homePage.HasNoErrors();
                Assert.That(hasNoErrors, Is.True, "Destination page should load without errors");
                
                LogHelper.Info("Destination page loaded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "DestinationPageError");
                throw;
            }
        }

        /// <summary>
        /// Verifies page URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the page URL should contain ""(.*)""")]
        public void ThenThePageURLShouldContain(string expectedIdentifier)
        {
            try
            {
                LogHelper.Info($"Assertion: Verifying URL contains '{expectedIdentifier}'");
                
                bool containsIdentifier = _homePage.DoesUrlContain(expectedIdentifier);
                Assert.That(containsIdentifier, Is.True, 
                    $"Page URL should contain '{expectedIdentifier}'");
                
                LogHelper.Info($"URL contains expected identifier '{expectedIdentifier}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "URLVerificationError");
                throw;
            }
        }

        /// <summary>
        /// Verifies Golden1 logo is visible in header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"the Golden1 logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying Golden1 logo visibility");
                
                bool isLogoVisible = _homePage.IsLogoVisible();
                Assert.That(isLogoVisible, Is.True, "Golden1 logo should be visible in the header");
                
                LogHelper.Info("Golden1 logo is visible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo visibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "LogoVisibilityError");
                throw;
            }
        }

        /// <summary>
        /// Verifies homepage displays correctly
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should display correctly")]
        public void ThenTheHomepageShouldDisplayCorrectly()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying homepage displays correctly");
                
                bool isDisplayedCorrectly = _homePage.IsPageDisplayedCorrectly();
                Assert.That(isDisplayedCorrectly, Is.True, "Homepage should display correctly");
                
                LogHelper.Info("Homepage displays correctly");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage display verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "HomepageDisplayError");
                throw;
            }
        }

        /// <summary>
        /// Verifies there are no broken layouts
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying no broken layouts");
                
                bool isNavigationVisible = _homePage.IsNavigationMenuVisible();
                bool isLogoVisible = _homePage.IsLogoVisible();
                
                Assert.That(isNavigationVisible && isLogoVisible, Is.True, 
                    "Page should not have broken layouts");
                
                LogHelper.Info("No broken layouts detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "LayoutError");
                throw;
            }
        }

        /// <summary>
        /// Verifies there is no missing content
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying no missing content");
                
                bool isPageDisplayedCorrectly = _homePage.IsPageDisplayedCorrectly();
                Assert.That(isPageDisplayedCorrectly, Is.True, "Page should not have missing content");
                
                LogHelper.Info("No missing content detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Missing content verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "MissingContentError");
                throw;
            }
        }

        /// <summary>
        /// Verifies there are no system errors
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no system errors")]
        public void ThenThereShouldBeNoSystemErrors()
        {
            try
            {
                LogHelper.Info("Assertion: Verifying no system errors");
                
                bool hasNoErrors = _homePage.HasNoErrors();
                Assert.That(hasNoErrors, Is.True, "Page should not display system errors");
                
                LogHelper.Info("No system errors detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"System error verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "SystemError");
                throw;
            }
        }
    }
}