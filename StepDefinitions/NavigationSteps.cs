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
    /// Step definitions for Golden 1 website navigation scenarios
    /// Test Cases: TASK0020445 TS-001 to TS-011
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
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("Browser has been launched via Hooks");
            Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Given(@"the browser type is ""(.*)""")]
        public void GivenTheBrowserTypeIs(string browserType)
        {
            LogHelper.Info($"Test is configured to run on browser: {browserType}");
            _scenarioContext["BrowserType"] = browserType;
            // Note: Browser type is configured in appsettings.json or via test configuration
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Given(@"the viewport is set to ""(.*)"" size")]
        public void GivenTheViewportIsSetToSize(string deviceType)
        {
            LogHelper.Info($"Setting viewport to {deviceType} size");
            
            switch (deviceType.ToLower())
            {
                case "desktop":
                    _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
                    break;
                case "tablet":
                    _driver.Manage().Window.Size = new System.Drawing.Size(768, 1024);
                    break;
                case "mobile":
                    _driver.Manage().Window.Size = new System.Drawing.Size(375, 667);
                    break;
                default:
                    throw new ArgumentException($"Unknown device type: {deviceType}");
            }
            
            LogHelper.Info($"Viewport set to {deviceType}: {_driver.Manage().Window.Size.Width}x{_driver.Manage().Window.Size.Height}");
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
        /// </summary>
        [When(@"I navigate to the Golden 1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden 1 homepage");
            _homePage.OpenHomePage();
            LogHelper.Info("Successfully navigated to homepage");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I hover over the ""(.*)"" menu")]
        public void WhenIHoverOverTheMenu(string menuName)
        {
            LogHelper.Info($"Hovering over menu: {menuName}");
            _homePage.HoverOverMenu(menuName);
            LogHelper.Info($"Successfully hovered over {menuName} menu");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I click on the ""(.*)"" submenu item")]
        public void WhenIClickOnTheSubmenuItem(string submenuName)
        {
            LogHelper.Info($"Clicking submenu item: {submenuName}");
            _homePage.ClickSubmenuItem(submenuName);
            LogHelper.Info($"Successfully clicked {submenuName} submenu item");
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the homepage should load without errors")]
        public void ThenTheHomepageShouldLoadWithoutErrors()
        {
            LogHelper.Info("Verifying homepage loaded without errors");
            
            bool hasErrors = _homePage.AreErrorMessagesPresent();
            Assert.That(hasErrors, Is.False, "Homepage should not display any error messages");
            
            bool contentLoaded = _homePage.IsPageContentLoaded();
            Assert.That(contentLoaded, Is.True, "Homepage content should be loaded");
            
            LogHelper.Info("Homepage loaded successfully without errors");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the page title should be displayed")]
        public void ThenThePageTitleShouldBeDisplayed()
        {
            LogHelper.Info("Verifying page title is displayed");
            
            string pageTitle = _homePage.GetPageTitle();
            Assert.That(pageTitle, Is.Not.Null.And.Not.Empty, "Page title should not be null or empty");
            Assert.That(pageTitle.ToLower(), Does.Contain("golden").Or.Contain("credit union"), 
                "Page title should contain 'Golden' or 'Credit Union'");
            
            LogHelper.Info($"Page title verified: {pageTitle}");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-002 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        [Then(@"the global navigation menu should be visible")]
        public void ThenTheGlobalNavigationMenuShouldBeVisible()
        {
            LogHelper.Info("Verifying global navigation menu is visible");
            
            bool isVisible = _homePage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top of the page");
            
            LogHelper.Info("Global navigation menu is visible");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"the following top menu options should be present:")]
        public void ThenTheFollowingTopMenuOptionsShouldBePresent(Table table)
        {
            LogHelper.Info("Verifying all top menu options are present");
            
            var menuOptions = table.Rows.Select(row => row[0]).ToList();
            
            foreach (var menuOption in menuOptions)
            {
                bool isPresent = _homePage.IsTopMenuTabPresent(menuOption);
                Assert.That(isPresent, Is.True, $"Top menu option '{menuOption}' should be present");
                LogHelper.Info($"Verified top menu option: {menuOption}");
            }
            
            LogHelper.Info($"All {menuOptions.Count} top menu options are present");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"the following main product menus should be displayed:")]
        public void ThenTheFollowingMainProductMenusShouldBeDisplayed(Table table)
        {
            LogHelper.Info("Verifying all main product menus are displayed");
            
            var productMenus = table.Rows.Select(row => row[0]).ToList();
            
            foreach (var productMenu in productMenus)
            {
                bool isDisplayed = _homePage.IsMainProductMenuDisplayed(productMenu);
                Assert.That(isDisplayed, Is.True, $"Main product menu '{productMenu}' should be displayed");
                LogHelper.Info($"Verified main product menu: {productMenu}");
            }
            
            LogHelper.Info($"All {productMenus.Count} main product menus are displayed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"each main product menu should be clickable")]
        public void ThenEachMainProductMenuShouldBeClickable()
        {
            LogHelper.Info("Verifying all main product menus are clickable");
            
            var productMenus = new List<string> 
            { 
                "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" 
            };
            
            foreach (var productMenu in productMenus)
            {
                bool isClickable = _homePage.IsMainProductMenuClickable(productMenu);
                Assert.That(isClickable, Is.True, $"Main product menu '{productMenu}' should be clickable");
                LogHelper.Info($"Verified menu '{productMenu}' is clickable");
            }
            
            LogHelper.Info("All main product menus are clickable");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"the submenu items should be displayed")]
        public void ThenTheSubmenuItemsShouldBeDisplayed()
        {
            LogHelper.Info("Verifying submenu items are displayed");
            
            bool areDisplayed = _homePage.AreSubmenuItemsDisplayed();
            Assert.That(areDisplayed, Is.True, "Submenu items should be displayed after hovering over menu");
            
            LogHelper.Info("Submenu items are displayed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"I should be able to click on ""(.*)"" submenu item")]
        public void ThenIShouldBeAbleToClickOnSubmenuItem(string submenuName)
        {
            LogHelper.Info($"Attempting to click submenu item: {submenuName}");
            
            try
            {
                _homePage.ClickSubmenuItem(submenuName);
                LogHelper.Info($"Successfully clicked submenu item: {submenuName}");
                Assert.Pass($"Submenu item '{submenuName}' is clickable and was clicked successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuName}': {ex.Message}");
                Assert.Fail($"Submenu item '{submenuName}' should be clickable");
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"the Free Checking destination page should load successfully")]
        [Then(@"the (.*) destination page should load successfully")]
        public void ThenTheDestinationPageShouldLoadSuccessfully(string pageName = "Free Checking")
        {
            LogHelper.Info($"Verifying {pageName} destination page loaded successfully");
            
            bool hasErrors = _homePage.AreErrorMessagesPresent();
            Assert.That(hasErrors, Is.False, $"{pageName} page should not display any error messages");
            
            bool contentLoaded = _homePage.IsPageContentLoaded();
            Assert.That(contentLoaded, Is.True, $"{pageName} page content should be loaded");
            
            LogHelper.Info($"{pageName} destination page loaded successfully");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the page URL should contain ""(.*)""")]
        public void ThenThePageUrlShouldContain(string expectedUrlPart)
        {
            LogHelper.Info($"Verifying page URL contains: {expectedUrlPart}");
            
            string currentUrl = _homePage.GetPageUrl();
            Assert.That(currentUrl.ToLower(), Does.Contain(expectedUrlPart.ToLower()), 
                $"Page URL should contain '{expectedUrlPart}'. Actual URL: {currentUrl}");
            
            LogHelper.Info($"Page URL verified to contain: {expectedUrlPart}");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-008 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            LogHelper.Info("Verifying Golden 1 logo is visible in header");
            
            bool isVisible = _homePage.IsLogoVisible();
            Assert.That(isVisible, Is.True, "Golden 1 logo should be visible in the header");
            
            LogHelper.Info("Golden 1 logo is visible in header");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001, TS-010 TC-001, TS-011 TC-001
        /// </summary>
        [Then(@"there should be no layout issues on the page")]
        public void ThenThereShouldBeNoLayoutIssuesOnThePage()
        {
            LogHelper.Info("Verifying there are no layout issues");
            
            bool hasLayoutIssues = _homePage.HasLayoutIssues();
            Assert.That(hasLayoutIssues, Is.False, "Page should not have any layout issues");
            
            LogHelper.Info("No layout issues detected on the page");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no error messages displayed")]
        public void ThenThereShouldBeNoErrorMessagesDisplayed()
        {
            LogHelper.Info("Verifying there are no error messages");
            
            bool hasErrors = _homePage.AreErrorMessagesPresent();
            Assert.That(hasErrors, Is.False, "Page should not display any error messages");
            
            LogHelper.Info("No error messages displayed on the page");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"all page content should be loaded")]
        public void ThenAllPageContentShouldBeLoaded()
        {
            LogHelper.Info("Verifying all page content is loaded");
            
            bool contentLoaded = _homePage.IsPageContentLoaded();
            Assert.That(contentLoaded, Is.True, "All page content should be loaded");
            
            LogHelper.Info("All page content is loaded");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the navigation menu should be visible and functional")]
        public void ThenTheNavigationMenuShouldBeVisibleAndFunctional()
        {
            LogHelper.Info("Verifying navigation menu is visible and functional");
            
            bool isVisible = _homePage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Navigation menu should be visible");
            
            // Verify at least one menu is clickable to confirm functionality
            bool isClickable = _homePage.IsMainProductMenuClickable("Checking");
            Assert.That(isClickable, Is.True, "Navigation menu should be functional (clickable)");
            
            LogHelper.Info("Navigation menu is visible and functional");
        }
    }
}