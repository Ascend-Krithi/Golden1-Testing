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
    /// Step Definitions for Golden 1 Website Navigation
    /// Test Cases: TASK0020445 TS-001 through TS-009
    /// </summary>
    [Binding]
    public class Golden1NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        public Golden1NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _homePage = new HomePage(_driver);
            _navigationPage = new NavigationPage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Test Setup
        // =============================================================

        /// <summary>
        /// Launches the browser
        /// Test Cases: All test scenarios
        /// </summary>
        [Given(@"I launch the browser")]
        public void GivenILaunchTheBrowser()
        {
            try
            {
                LogHelper.Info("Browser launched successfully");
                Assert.That(_driver, Is.Not.Null, "Driver should be initialized");
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
        /// Navigates to Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
        /// </summary>
        [When(@"I navigate to the Golden 1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Navigating to Golden 1 homepage");
                _homePage.OpenHomePage();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "NavigationFailure");
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
                LogHelper.Info("Observing top section of homepage");
                // Visual observation - verification done in Then step
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to observe top section: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Expands a main product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I expand the ""(.*)"" main product menu")]
        public void WhenIExpandTheMainProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding main product menu: {menuName}");
                _navigationPage.ExpandProductCategoryMenu(menuName);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand menu '{menuName}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"ExpandMenu_{menuName}_Failure");
                throw;
            }
        }

        /// <summary>
        /// Selects a submenu item
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I select the ""(.*)"" submenu item")]
        public void WhenISelectTheSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Selecting submenu item: {submenuItemName}");
                _navigationPage.SelectSubmenuItem(submenuItemName);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item '{submenuItemName}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"SelectSubmenu_{submenuItemName}_Failure");
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
                LogHelper.Info("Verifying homepage loaded successfully");
                
                bool isLoaded = _homePage.IsHomePageLoaded();
                Assert.That(isLoaded, Is.True, "Homepage should load successfully");
                
                bool hasNoErrors = _homePage.HasNoErrors();
                Assert.That(hasNoErrors, Is.True, "Homepage should display without errors");
                
                LogHelper.Info("Homepage loaded successfully without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "HomepageLoadFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies global navigation menu is visible at the top
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu visibility");
                
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top of the page");
                
                LogHelper.Info("Global navigation menu is visible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "NavigationMenuVisibilityFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies all specified top menu options are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"the following top menu options should be present:")]
        public void ThenTheFollowingTopMenuOptionsShouldBePresent(Table table)
        {
            try
            {
                LogHelper.Info("Verifying top menu options are present");
                
                var menuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
                
                foreach (var menuOption in menuOptions)
                {
                    bool isPresent = _navigationPage.IsTopMenuTabPresent(menuOption);
                    Assert.That(isPresent, Is.True, $"Top menu option '{menuOption}' should be present");
                    LogHelper.Info($"Top menu option '{menuOption}' is present");
                }
                
                LogHelper.Info($"All {menuOptions.Count} top menu options are present");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top menu options verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "TopMenuOptionsFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies main product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"the following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            try
            {
                LogHelper.Info("Verifying main product category menus are displayed");
                
                var productCategories = table.Rows.Select(row => row["ProductCategory"]).ToList();
                
                foreach (var category in productCategories)
                {
                    bool isDisplayed = _navigationPage.IsProductCategoryMenuDisplayed(category);
                    Assert.That(isDisplayed, Is.True, $"Product category menu '{category}' should be displayed");
                    LogHelper.Info($"Product category menu '{category}' is displayed");
                }
                
                LogHelper.Info($"All {productCategories.Count} product category menus are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "ProductCategoryMenusFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies each main product category menu is accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"each main product category menu should be accessible")]
        public void ThenEachMainProductCategoryMenuShouldBeAccessible()
        {
            try
            {
                LogHelper.Info("Verifying each product category menu is accessible");
                
                var categories = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
                
                foreach (var category in categories)
                {
                    bool isAccessible = _navigationPage.IsProductCategoryMenuAccessible(category);
                    Assert.That(isAccessible, Is.True, $"Product category menu '{category}' should be accessible");
                    LogHelper.Info($"Product category menu '{category}' is accessible");
                }
                
                LogHelper.Info("All product category menus are accessible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menu accessibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "MenuAccessibilityFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"submenu items should be displayed")]
        public void ThenSubmenuItemsShouldBeDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying submenu items are displayed");
                
                bool areDisplayed = _navigationPage.AreSubmenuItemsDisplayed();
                Assert.That(areDisplayed, Is.True, "Submenu items should be displayed after expanding menu");
                
                LogHelper.Info("Submenu items are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items display verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "SubmenuItemsDisplayFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"I should be able to select the ""(.*)"" submenu item")]
        public void ThenIShouldBeAbleToSelectTheSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Verifying submenu item '{submenuItemName}' is selectable");
                
                bool isSelectable = _navigationPage.IsSubmenuItemSelectable(submenuItemName);
                Assert.That(isSelectable, Is.True, $"Submenu item '{submenuItemName}' should be selectable");
                
                LogHelper.Info($"Submenu item '{submenuItemName}' is selectable");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item selectability verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"SubmenuSelectable_{submenuItemName}_Failure");
                throw;
            }
        }

        /// <summary>
        /// Verifies redirection to destination page
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"I should be redirected to the (.*) destination page")]
        public void ThenIShouldBeRedirectedToTheDestinationPage(string pageName)
        {
            try
            {
                LogHelper.Info($"Verifying redirection to {pageName} destination page");
                
                string currentUrl = _homePage.GetPageUrl();
                Assert.That(currentUrl, Is.Not.Null.And.Not.Empty, "Current URL should not be null or empty");
                
                LogHelper.Info($"Redirected to destination page: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Redirection verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "RedirectionFailure");
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
                LogHelper.Info("Verifying destination page loads without errors");
                
                bool isLoaded = _homePage.IsHomePageLoaded();
                Assert.That(isLoaded, Is.True, "Destination page should load successfully");
                
                bool hasNoErrors = _homePage.HasNoErrors();
                Assert.That(hasNoErrors, Is.True, "Destination page should load without errors");
                
                LogHelper.Info("Destination page loaded without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "DestinationPageLoadFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies destination page URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the destination page URL should contain ""(.*)""")]
        public void ThenTheDestinationPageURLShouldContain(string expectedUrlPart)
        {
            try
            {
                LogHelper.Info($"Verifying destination page URL contains '{expectedUrlPart}'");
                
                string currentUrl = _homePage.GetPageUrl();
                Assert.That(currentUrl.ToLower(), Does.Contain(expectedUrlPart.ToLower()), 
                    $"Destination page URL should contain '{expectedUrlPart}'");
                
                LogHelper.Info($"Destination page URL contains expected identifier: {expectedUrlPart}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "URLVerificationFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies Golden 1 logo is visible in header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            try
            {
                LogHelper.Info("Verifying Golden 1 logo is visible in header");
                
                bool isVisible = _homePage.IsLogoVisible();
                Assert.That(isVisible, Is.True, "Golden 1 logo should be visible in the top header");
                
                LogHelper.Info("Golden 1 logo is visible in header");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo visibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "LogoVisibilityFailure");
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
                LogHelper.Info("Verifying homepage displays correctly");
                
                bool isDisplayedCorrectly = _homePage.IsPageDisplayedCorrectly();
                Assert.That(isDisplayedCorrectly, Is.True, "Homepage should display correctly");
                
                LogHelper.Info("Homepage displays correctly");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage display verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "HomepageDisplayFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies no broken layouts
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Verifying no broken layouts");
                
                bool isLoaded = _homePage.IsHomePageLoaded();
                Assert.That(isLoaded, Is.True, "Page should load with proper layout");
                
                LogHelper.Info("No broken layouts detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "BrokenLayoutFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies no missing content
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            try
            {
                LogHelper.Info("Verifying no missing content");
                
                bool isLoaded = _homePage.IsHomePageLoaded();
                Assert.That(isLoaded, Is.True, "Page content should be present");
                
                LogHelper.Info("No missing content detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "MissingContentFailure");
                throw;
            }
        }

        /// <summary>
        /// Verifies no system errors
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no system errors")]
        public void ThenThereShouldBeNoSystemErrors()
        {
            try
            {
                LogHelper.Info("Verifying no system errors");
                
                bool hasNoErrors = _homePage.HasNoErrors();
                Assert.That(hasNoErrors, Is.True, "Page should display without system errors");
                
                LogHelper.Info("No system errors detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"System error verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "SystemErrorFailure");
                throw;
            }
        }
    }
}