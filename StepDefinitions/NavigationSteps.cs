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
    /// Step definitions for Global Navigation Menu testing
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
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _homePage = new HomePage(_driver);
            _navigationPage = new NavigationPage(_driver);
        }

        #region Background Steps

        /// <summary>
        /// Launches the browser
        /// Test Cases: All TASK0020445 test cases
        /// </summary>
        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("Browser has been launched successfully");
            Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
        }

        /// <summary>
        /// Launches specific browser for cross-browser testing
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Given(@"the browser ""(.*)"" is launched")]
        public void GivenTheBrowserIsLaunched(string browserName)
        {
            LogHelper.Info($"Browser '{browserName}' has been launched successfully");
            _scenarioContext["Browser"] = browserName;
            Assert.That(_driver, Is.Not.Null, $"WebDriver should be initialized for {browserName}");
        }

        /// <summary>
        /// Launches browser on specific device for responsive testing
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Given(@"the browser is launched on ""(.*)"" device")]
        public void GivenTheBrowserIsLaunchedOnDevice(string deviceType)
        {
            LogHelper.Info($"Browser has been launched on {deviceType} device");
            _scenarioContext["Device"] = deviceType;
            Assert.That(_driver, Is.Not.Null, $"WebDriver should be initialized for {deviceType}");
        }

        #endregion

        #region Navigation Steps

        /// <summary>
        /// Navigates to Golden 1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001, TS-004 TC-001, TS-005 TC-001, TS-006 TC-001, TS-007 TC-001, TS-008 TC-001, TS-009 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        [When(@"I navigate to the Golden 1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden 1 homepage");
            _homePage.OpenHomePage();
            LogHelper.Info("Successfully navigated to Golden 1 homepage");
        }

        /// <summary>
        /// Expands a product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I expand the ""(.*)"" product menu")]
        public void WhenIExpandTheProductMenu(string menuName)
        {
            LogHelper.Info($"Expanding '{menuName}' product menu");
            _navigationPage.ExpandProductMenu(menuName);
            LogHelper.Info($"Successfully expanded '{menuName}' product menu");
        }

        /// <summary>
        /// Clicks on a submenu item
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I click on the ""(.*)"" submenu item")]
        public void WhenIClickOnTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Clicking on '{submenuItem}' submenu item");
            _navigationPage.ClickSubmenuItem(submenuItem);
            LogHelper.Info($"Successfully clicked on '{submenuItem}' submenu item");
        }

        #endregion

        #region Verification Steps - Homepage

        /// <summary>
        /// Verifies homepage loads without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the homepage should load without errors")]
        public void ThenTheHomepageShouldLoadWithoutErrors()
        {
            LogHelper.Info("Verifying homepage loaded without errors");
            bool isLoaded = _homePage.IsHomePageLoaded();
            Assert.That(isLoaded, Is.True, "Homepage should load successfully without errors");
            LogHelper.Info("Homepage loaded successfully without errors");
        }

        /// <summary>
        /// Verifies page displays correctly
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the page should display correctly")]
        public void ThenThePageShouldDisplayCorrectly()
        {
            LogHelper.Info("Verifying page displays correctly");
            bool isDisplayedCorrectly = _homePage.IsPageDisplayedCorrectly();
            Assert.That(isDisplayedCorrectly, Is.True, "Page should display correctly without layout issues");
            LogHelper.Info("Page is displayed correctly");
        }

        /// <summary>
        /// Verifies homepage displays correctly with no layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should display correctly with no layout issues")]
        public void ThenTheHomepageShouldDisplayCorrectlyWithNoLayoutIssues()
        {
            LogHelper.Info("Verifying homepage displays correctly with no layout issues");
            bool hasNoLayoutIssues = _homePage.HasNoLayoutIssues();
            Assert.That(hasNoLayoutIssues, Is.True, "Homepage should display correctly with no layout issues");
            LogHelper.Info("Homepage displays correctly with no layout issues");
        }

        /// <summary>
        /// Verifies there is no missing content
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            LogHelper.Info("Verifying there is no missing content");
            bool hasNoMissingContent = _homePage.HasNoMissingContent();
            Assert.That(hasNoMissingContent, Is.True, "Page should not have any missing content");
            LogHelper.Info("No missing content found on the page");
        }

        /// <summary>
        /// Verifies there are no system error messages
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no system error messages")]
        public void ThenThereShouldBeNoSystemErrorMessages()
        {
            LogHelper.Info("Verifying there are no system error messages");
            bool hasNoErrors = _homePage.HasNoSystemErrors();
            Assert.That(hasNoErrors, Is.True, "Page should not display any system error messages");
            LogHelper.Info("No system error messages found");
        }

        #endregion

        #region Verification Steps - Navigation Menu

        /// <summary>
        /// Verifies global navigation menu is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            LogHelper.Info("Verifying global navigation menu is visible at the top");
            bool isVisible = _navigationPage.IsGlobalNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top of the page");
            LogHelper.Info("Global navigation menu is visible at the top");
        }

        /// <summary>
        /// Verifies navigation menu options are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"the navigation menu should display the following options:")]
        public void ThenTheNavigationMenuShouldDisplayTheFollowingOptions(Table table)
        {
            LogHelper.Info("Verifying navigation menu options are present");
            var expectedOptions = table.Rows.Select(row => row[0]).ToList();
            
            foreach (var option in expectedOptions)
            {
                bool isPresent = _navigationPage.IsNavigationMenuOptionPresent(option);
                Assert.That(isPresent, Is.True, $"Navigation menu option '{option}' should be present");
                LogHelper.Info($"Navigation menu option '{option}' is present");
            }
            
            LogHelper.Info("All expected navigation menu options are present");
        }

        /// <summary>
        /// Verifies main product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"the following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            LogHelper.Info("Verifying main product category menus are displayed");
            var expectedMenus = table.Rows.Select(row => row[0]).ToList();
            
            foreach (var menu in expectedMenus)
            {
                bool isDisplayed = _navigationPage.IsProductCategoryMenuDisplayed(menu);
                Assert.That(isDisplayed, Is.True, $"Product category menu '{menu}' should be displayed");
                LogHelper.Info($"Product category menu '{menu}' is displayed");
            }
            
            LogHelper.Info("All main product category menus are displayed");
        }

        /// <summary>
        /// Verifies each product category menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"each product category menu should be clickable")]
        public void ThenEachProductCategoryMenuShouldBeClickable()
        {
            LogHelper.Info("Verifying each product category menu is clickable");
            bool areClickable = _navigationPage.AreProductCategoryMenusClickable();
            Assert.That(areClickable, Is.True, "All product category menus should be clickable");
            LogHelper.Info("All product category menus are clickable");
        }

        /// <summary>
        /// Verifies submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"submenu items should be displayed")]
        public void ThenSubmenuItemsShouldBeDisplayed()
        {
            LogHelper.Info("Verifying submenu items are displayed");
            bool areDisplayed = _navigationPage.AreSubmenuItemsDisplayed();
            Assert.That(areDisplayed, Is.True, "Submenu items should be displayed after expanding menu");
            LogHelper.Info("Submenu items are displayed");
        }

        /// <summary>
        /// Verifies submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"I should be able to select the ""(.*)"" submenu item")]
        public void ThenIShouldBeAbleToSelectTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Verifying '{submenuItem}' submenu item is selectable");
            bool isSelectable = _navigationPage.IsSubmenuItemSelectable(submenuItem);
            Assert.That(isSelectable, Is.True, $"Submenu item '{submenuItem}' should be selectable");
            LogHelper.Info($"Submenu item '{submenuItem}' is selectable");
        }

        #endregion

        #region Verification Steps - Destination Page

        /// <summary>
        /// Verifies destination page loads successfully
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"the destination page should load successfully")]
        public void ThenTheDestinationPageShouldLoadSuccessfully()
        {
            LogHelper.Info("Verifying destination page loads successfully");
            bool isLoaded = _homePage.IsPageLoaded();
            Assert.That(isLoaded, Is.True, "Destination page should load successfully");
            LogHelper.Info("Destination page loaded successfully");
        }

        /// <summary>
        /// Verifies page displays without errors
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"the page should display without errors")]
        public void ThenThePageShouldDisplayWithoutErrors()
        {
            LogHelper.Info("Verifying page displays without errors");
            bool hasNoErrors = _homePage.HasNoSystemErrors();
            Assert.That(hasNoErrors, Is.True, "Page should display without any errors");
            LogHelper.Info("Page displays without errors");
        }

        /// <summary>
        /// Verifies page URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the page URL should contain ""(.*)""")]
        public void ThenThePageURLShouldContain(string expectedUrlIdentifier)
        {
            LogHelper.Info($"Verifying page URL contains '{expectedUrlIdentifier}'");
            string currentUrl = _homePage.GetCurrentPageUrl();
            Assert.That(currentUrl, Does.Contain(expectedUrlIdentifier), 
                $"Page URL should contain '{expectedUrlIdentifier}'. Actual URL: {currentUrl}");
            LogHelper.Info($"Page URL contains expected identifier '{expectedUrlIdentifier}'");
        }

        #endregion

        #region Verification Steps - Header Elements

        /// <summary>
        /// Verifies Golden 1 logo is visible in header
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            LogHelper.Info("Verifying Golden 1 logo is visible in the top header");
            bool isVisible = _homePage.IsGolden1LogoVisible();
            Assert.That(isVisible, Is.True, "Golden 1 logo should be visible in the top header");
            LogHelper.Info("Golden 1 logo is visible in the top header");
        }

        #endregion

        #region Verification Steps - Cross-Browser and Responsive

        /// <summary>
        /// Verifies navigation menu is visible and functional in specific browser
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible and functional")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAndFunctional()
        {
            string browser = _scenarioContext.ContainsKey("Browser") ? _scenarioContext["Browser"].ToString() : "default";
            LogHelper.Info($"Verifying global navigation menu is visible and functional in {browser}");
            
            bool isVisible = _navigationPage.IsGlobalNavigationMenuVisible();
            Assert.That(isVisible, Is.True, $"Global navigation menu should be visible in {browser}");
            
            bool isFunctional = _navigationPage.IsNavigationMenuFunctional();
            Assert.That(isFunctional, Is.True, $"Global navigation menu should be functional in {browser}");
            
            LogHelper.Info($"Global navigation menu is visible and functional in {browser}");
        }

        /// <summary>
        /// Verifies Golden 1 logo is visible in header for cross-browser testing
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            string browser = _scenarioContext.ContainsKey("Browser") ? _scenarioContext["Browser"].ToString() : "default";
            LogHelper.Info($"Verifying Golden 1 logo is visible in the header in {browser}");
            
            bool isVisible = _homePage.IsGolden1LogoVisible();
            Assert.That(isVisible, Is.True, $"Golden 1 logo should be visible in the header in {browser}");
            
            LogHelper.Info($"Golden 1 logo is visible in the header in {browser}");
        }

        /// <summary>
        /// Verifies page displays without layout issues in specific browser
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Then(@"the page should display without layout issues in ""(.*)""")]
        public void ThenThePageShouldDisplayWithoutLayoutIssuesIn(string browser)
        {
            LogHelper.Info($"Verifying page displays without layout issues in {browser}");
            bool hasNoLayoutIssues = _homePage.HasNoLayoutIssues();
            Assert.That(hasNoLayoutIssues, Is.True, $"Page should display without layout issues in {browser}");
            LogHelper.Info($"Page displays without layout issues in {browser}");
        }

        /// <summary>
        /// Verifies navigation menu is visible and functional on specific device
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the navigation menu should be visible and functional on ""(.*)""")]
        public void ThenTheNavigationMenuShouldBeVisibleAndFunctionalOn(string device)
        {
            LogHelper.Info($"Verifying navigation menu is visible and functional on {device}");
            
            bool isVisible = _navigationPage.IsGlobalNavigationMenuVisible();
            Assert.That(isVisible, Is.True, $"Navigation menu should be visible on {device}");
            
            bool isFunctional = _navigationPage.IsNavigationMenuFunctional();
            Assert.That(isFunctional, Is.True, $"Navigation menu should be functional on {device}");
            
            LogHelper.Info($"Navigation menu is visible and functional on {device}");
        }

        /// <summary>
        /// Verifies header elements are visible on specific device
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the header elements should be visible on ""(.*)""")]
        public void ThenTheHeaderElementsShouldBeVisibleOn(string device)
        {
            LogHelper.Info($"Verifying header elements are visible on {device}");
            bool areVisible = _homePage.AreHeaderElementsVisible();
            Assert.That(areVisible, Is.True, $"Header elements should be visible on {device}");
            LogHelper.Info($"Header elements are visible on {device}");
        }

        /// <summary>
        /// Verifies page displays without layout issues on specific device
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the page should display without layout issues on ""(.*)""")]
        public void ThenThePageShouldDisplayWithoutLayoutIssuesOn(string device)
        {
            LogHelper.Info($"Verifying page displays without layout issues on {device}");
            bool hasNoLayoutIssues = _homePage.HasNoLayoutIssues();
            Assert.That(hasNoLayoutIssues, Is.True, $"Page should display without layout issues on {device}");
            LogHelper.Info($"Page displays without layout issues on {device}");
        }

        #endregion
    }
}