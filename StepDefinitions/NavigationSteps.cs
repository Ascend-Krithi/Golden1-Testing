using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ProjectName.Automation.Pages;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for Golden1 Navigation scenarios
    /// Test Cases: TASK0020445 TS-001 through TS-011
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _homePage = new HomePage(_driver);
            _navigationPage = new NavigationPage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================

        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("Browser launched successfully");
            Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
        }

        [Given(@"the browser ""(.*)"" is launched")]
        public void GivenTheSpecificBrowserIsLaunched(string browser)
        {
            LogHelper.Info($"Browser '{browser}' launched successfully");
            Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
        }

        [Given(@"the browser is launched on ""(.*)"" device")]
        public void GivenTheBrowserIsLaunchedOnDevice(string device)
        {
            LogHelper.Info($"Browser launched on '{device}' device");
            // Device-specific configuration would be handled in DriverManager
            Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        [When(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden1 homepage");
            _homePage.OpenHomePage();
        }

        [When(@"I expand the ""(.*)"" menu")]
        public void WhenIExpandTheMenu(string menuName)
        {
            LogHelper.Info($"Expanding menu: {menuName}");
            _navigationPage.ExpandProductMenu(menuName);
        }

        [When(@"I click on the ""(.*)"" submenu item")]
        public void WhenIClickOnTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Clicking submenu item: {submenuItem}");
            _navigationPage.ClickSubmenuItem(submenuItem);
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================

        [Then(@"the homepage should load successfully without errors")]
        public void ThenTheHomepageShouldLoadSuccessfullyWithoutErrors()
        {
            LogHelper.Info("Verifying homepage loaded successfully");
            
            bool isLoaded = _homePage.IsHomePageLoaded();
            Assert.That(isLoaded, Is.True, "Homepage should load successfully");
            
            bool noErrors = _homePage.IsPageWithoutErrors();
            Assert.That(noErrors, Is.True, "Homepage should display without errors");
            
            LogHelper.Info("Homepage loaded successfully without errors");
        }

        [Then(@"the global navigation menu should be visible at the top of the page")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfThePage()
        {
            LogHelper.Info("Verifying global navigation menu visibility");
            
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top of the page");
            
            LogHelper.Info("Global navigation menu is visible");
        }

        [Then(@"the following top menu options should be present:")]
        public void ThenTheFollowingTopMenuOptionsShouldBePresent(Table table)
        {
            LogHelper.Info("Verifying top menu options are present");
            
            var menuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
            
            bool allPresent = _navigationPage.AreAllTopMenuOptionsPresent(menuOptions);
            Assert.That(allPresent, Is.True, "All specified top menu options should be present");
            
            LogHelper.Info($"All {menuOptions.Count} top menu options are present");
        }

        [Then(@"the following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            LogHelper.Info("Verifying main product category menus are displayed");
            
            var productMenus = table.Rows.Select(row => row["ProductMenu"]).ToList();
            
            bool allDisplayed = _navigationPage.AreAllProductMenusDisplayed(productMenus);
            Assert.That(allDisplayed, Is.True, "All main product category menus should be displayed");
            
            LogHelper.Info($"All {productMenus.Count} product category menus are displayed");
        }

        [Then(@"each main product category menu should be accessible")]
        public void ThenEachMainProductCategoryMenuShouldBeAccessible()
        {
            LogHelper.Info("Verifying each product category menu is accessible");
            
            var productMenus = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
            
            foreach (var menu in productMenus)
            {
                bool isAccessible = _navigationPage.IsProductMenuAccessible(menu);
                Assert.That(isAccessible, Is.True, $"Product menu '{menu}' should be accessible");
            }
            
            LogHelper.Info("All product category menus are accessible");
        }

        [Then(@"the submenu items should be displayed")]
        public void ThenTheSubmenuItemsShouldBeDisplayed()
        {
            LogHelper.Info("Verifying submenu items are displayed");
            
            bool areDisplayed = _navigationPage.AreSubmenuItemsDisplayed();
            Assert.That(areDisplayed, Is.True, "Submenu items should be displayed after expanding menu");
            
            LogHelper.Info("Submenu items are displayed");
        }

        [Then(@"I should be able to select the ""(.*)"" submenu item")]
        public void ThenIShouldBeAbleToSelectTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Verifying submenu item '{submenuItem}' is selectable");
            
            // Click the submenu item
            _navigationPage.ClickSubmenuItem(submenuItem);
            
            // Verify navigation occurred by checking URL changed
            string currentUrl = _navigationPage.GetCurrentPageUrl();
            Assert.That(currentUrl, Is.Not.Null.And.Not.Empty, "Should navigate to a page after selecting submenu item");
            
            LogHelper.Info($"Submenu item '{submenuItem}' is selectable");
        }

        [Then(@"I should be redirected to the Free Checking destination page")]
        public void ThenIShouldBeRedirectedToTheFreeCheckingDestinationPage()
        {
            LogHelper.Info("Verifying redirection to Free Checking destination page");
            
            string currentUrl = _navigationPage.GetCurrentPageUrl();
            Assert.That(currentUrl, Does.Contain("checking").IgnoreCase, "Should be redirected to checking page");
            
            LogHelper.Info("Redirected to Free Checking destination page");
        }

        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            LogHelper.Info("Verifying destination page loaded without errors");
            
            bool noErrors = _homePage.IsPageWithoutErrors();
            Assert.That(noErrors, Is.True, "Destination page should load without errors");
            
            LogHelper.Info("Destination page loaded without errors");
        }

        [Then(@"the destination page URL should contain ""(.*)""")]
        public void ThenTheDestinationPageURLShouldContain(string expectedIdentifier)
        {
            LogHelper.Info($"Verifying URL contains identifier: {expectedIdentifier}");
            
            bool containsIdentifier = _navigationPage.DoesUrlContainIdentifier(expectedIdentifier);
            Assert.That(containsIdentifier, Is.True, $"Destination page URL should contain '{expectedIdentifier}'");
            
            LogHelper.Info($"URL contains expected identifier: {expectedIdentifier}");
        }

        [Then(@"the Golden1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            LogHelper.Info("Verifying Golden1 logo is visible in header");
            
            bool isVisible = _homePage.IsGolden1LogoVisible();
            Assert.That(isVisible, Is.True, "Golden1 logo should be visible in the top header");
            
            LogHelper.Info("Golden1 logo is visible in header");
        }

        [Then(@"the homepage should display correctly with no broken layouts")]
        public void ThenTheHomepageShouldDisplayCorrectlyWithNoBrokenLayouts()
        {
            LogHelper.Info("Verifying homepage displays correctly");
            
            bool isCorrect = _homePage.IsPageDisplayedCorrectly();
            Assert.That(isCorrect, Is.True, "Homepage should display correctly with no broken layouts");
            
            LogHelper.Info("Homepage displays correctly");
        }

        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            LogHelper.Info("Verifying no missing content");
            
            // Check page title exists
            string pageTitle = _homePage.GetPageTitle();
            Assert.That(pageTitle, Is.Not.Null.And.Not.Empty, "Page should have a title");
            
            // Check navigation menu exists
            bool menuVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(menuVisible, Is.True, "Navigation menu should be present");
            
            LogHelper.Info("No missing content detected");
        }

        [Then(@"there should be no system errors")]
        public void ThenThereShouldBeNoSystemErrors()
        {
            LogHelper.Info("Verifying no system errors");
            
            bool noErrors = _homePage.IsPageWithoutErrors();
            Assert.That(noErrors, Is.True, "There should be no system errors displayed");
            
            LogHelper.Info("No system errors detected");
        }

        [Then(@"the global navigation menu should be visible and functional")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAndFunctional()
        {
            LogHelper.Info("Verifying navigation menu is visible and functional");
            
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Global navigation menu should be visible");
            
            // Verify at least one menu is accessible
            bool isAccessible = _navigationPage.IsProductMenuAccessible("Checking");
            Assert.That(isAccessible, Is.True, "Navigation menu should be functional");
            
            LogHelper.Info("Navigation menu is visible and functional");
        }

        [Then(@"the header elements including Golden1 logo should be visible")]
        public void ThenTheHeaderElementsIncludingGolden1LogoShouldBeVisible()
        {
            LogHelper.Info("Verifying header elements are visible");
            
            bool logoVisible = _homePage.IsGolden1LogoVisible();
            Assert.That(logoVisible, Is.True, "Golden1 logo should be visible in header");
            
            bool menuVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(menuVisible, Is.True, "Navigation menu should be visible in header");
            
            LogHelper.Info("Header elements including logo are visible");
        }

        [Then(@"there should be no layout issues or system errors")]
        public void ThenThereShouldBeNoLayoutIssuesOrSystemErrors()
        {
            LogHelper.Info("Verifying no layout issues or system errors");
            
            bool isCorrect = _homePage.IsPageDisplayedCorrectly();
            Assert.That(isCorrect, Is.True, "Page should display correctly without layout issues");
            
            bool noErrors = _homePage.IsPageWithoutErrors();
            Assert.That(noErrors, Is.True, "There should be no system errors");
            
            LogHelper.Info("No layout issues or system errors detected");
        }

        [Then(@"the navigation menu should be visible and functional on ""(.*)""")]
        public void ThenTheNavigationMenuShouldBeVisibleAndFunctionalOnDevice(string device)
        {
            LogHelper.Info($"Verifying navigation menu is visible and functional on {device}");
            
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, $"Navigation menu should be visible on {device}");
            
            bool isAccessible = _navigationPage.IsProductMenuAccessible("Checking");
            Assert.That(isAccessible, Is.True, $"Navigation menu should be functional on {device}");
            
            LogHelper.Info($"Navigation menu is visible and functional on {device}");
        }

        [Then(@"the header elements should be visible and functional on ""(.*)""")]
        public void ThenTheHeaderElementsShouldBeVisibleAndFunctionalOnDevice(string device)
        {
            LogHelper.Info($"Verifying header elements are visible and functional on {device}");
            
            bool logoVisible = _homePage.IsGolden1LogoVisible();
            Assert.That(logoVisible, Is.True, $"Golden1 logo should be visible on {device}");
            
            bool menuVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(menuVisible, Is.True, $"Navigation menu should be visible on {device}");
            
            LogHelper.Info($"Header elements are visible and functional on {device}");
        }

        [Then(@"there should be no layout issues on ""(.*)""")]
        public void ThenThereShouldBeNoLayoutIssuesOnDevice(string device)
        {
            LogHelper.Info($"Verifying no layout issues on {device}");
            
            bool isCorrect = _homePage.IsPageDisplayedCorrectly();
            Assert.That(isCorrect, Is.True, $"Page should display correctly on {device} without layout issues");
            
            LogHelper.Info($"No layout issues detected on {device}");
        }
    }
}