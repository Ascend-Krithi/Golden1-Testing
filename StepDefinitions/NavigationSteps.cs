using NUnit.Framework;
using OpenQA.Selenium;
using ProjectName.Automation.Pages;
using ProjectName.Automation.Utilities;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ProjectName.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Golden1 website navigation functionality
    /// Maps to test scenarios TASK0020445 TS-001 through TS-009
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        /// <summary>
        /// Constructor to initialize driver and page objects
        /// </summary>
        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _navigationPage = new NavigationPage(_driver);
        }

        /// <summary>
        /// Opens a supported browser
        /// Test Step: Launch a supported browser
        /// </summary>
        [Given(@"the user opens a supported browser")]
        public void GivenTheUserOpensASupportedBrowser()
        {
            LogHelper.Info("Browser opened successfully via Hooks");
            Assert.IsNotNull(_driver, "Browser should be initialized");
        }

        /// <summary>
        /// Navigates to the Golden 1 website homepage
        /// Test Step: Navigate to https://www.golden1.com/
        /// </summary>
        [When(@"the user navigates to the Golden 1 website")]
        public void WhenTheUserNavigatesToTheGolden1Website()
        {
            LogHelper.Info("Navigating to Golden 1 website");
            _navigationPage.OpenHomePage();
            _navigationPage.HandleCookieBannerIfPresent();
        }

        /// <summary>
        /// Verifies the homepage loads successfully
        /// Expected Result: Golden 1 homepage loads successfully
        /// </summary>
        [Then(@"the Golden 1 homepage should load successfully")]
        public void ThenTheGolden1HomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("Verifying homepage loaded successfully");
            bool isLoaded = _navigationPage.IsHomePageLoaded();
            Assert.IsTrue(isLoaded, "Golden 1 homepage should load successfully");
        }

        /// <summary>
        /// Verifies there are no error messages or loading issues
        /// Expected Result: Homepage displays without errors
        /// </summary>
        [Then(@"there should be no error messages or loading issues")]
        public void ThenThereShouldBeNoErrorMessagesOrLoadingIssues()
        {
            LogHelper.Info("Verifying no error messages on homepage");
            bool hasErrors = _navigationPage.HasPageErrors();
            Assert.IsFalse(hasErrors, "Homepage should display without errors");
        }

        /// <summary>
        /// Verifies the global navigation menu is visible
        /// Expected Result: Global navigation menu is visible at the top of the page
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top of the page")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfThePage()
        {
            LogHelper.Info("Verifying global navigation menu visibility");
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.IsTrue(isVisible, "Global navigation menu should be visible at the top of the page");
        }

        /// <summary>
        /// Locates the global navigation menu
        /// Test Step: Locate the global navigation menu
        /// </summary>
        [When(@"the user locates the global navigation menu")]
        public void WhenTheUserLocatesTheGlobalNavigationMenu()
        {
            LogHelper.Info("Locating global navigation menu");
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.IsTrue(isVisible, "Navigation menu should be visible to locate it");
        }

        /// <summary>
        /// Verifies all specified menu options are present
        /// Expected Result: All specified menu options are present in the navigation menu
        /// </summary>
        [Then(@"the following menu options should be present:")]
        public void ThenTheFollowingMenuOptionsShouldBePresent(Table table)
        {
            LogHelper.Info("Verifying menu options presence");
            var expectedMenus = table.Rows;
            
            foreach (var row in expectedMenus)
            {
                string menuName = row[0];
                LogHelper.Info($"Checking menu option: {menuName}");
                bool isPresent = _navigationPage.IsTopMenuOptionPresent(menuName);
                Assert.IsTrue(isPresent, $"Menu option '{menuName}' should be present in navigation");
            }
        }

        /// <summary>
        /// Verifies main product category menus are displayed
        /// Expected Result: All main product category menus are displayed in the navigation
        /// </summary>
        [Then(@"the following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            LogHelper.Info("Verifying main product category menus");
            var expectedCategories = table.Rows;
            
            foreach (var row in expectedCategories)
            {
                string categoryName = row[0];
                LogHelper.Info($"Checking product category: {categoryName}");
                bool isDisplayed = _navigationPage.IsProductCategoryMenuDisplayed(categoryName);
                Assert.IsTrue(isDisplayed, $"Product category '{categoryName}' should be displayed in navigation");
            }
        }

        /// <summary>
        /// Verifies each main product category menu is accessible
        /// Expected Result: Each menu expands or displays submenu items as expected
        /// </summary>
        [Then(@"each main product category menu should be accessible")]
        public void ThenEachMainProductCategoryMenuShouldBeAccessible()
        {
            LogHelper.Info("Verifying product category menus are accessible");
            List<string> categories = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
            
            foreach (string category in categories)
            {
                LogHelper.Info($"Testing accessibility of {category} menu");
                bool isAccessible = _navigationPage.IsProductCategoryAccessible(category);
                Assert.IsTrue(isAccessible, $"{category} menu should be accessible");
            }
        }

        /// <summary>
        /// Locates the main product category menus
        /// Test Step: Locate main product category menus
        /// </summary>
        [When(@"the user locates the main product category menus")]
        public void WhenTheUserLocatesTheMainProductCategoryMenus()
        {
            LogHelper.Info("Locating main product category menus");
            bool menusVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.IsTrue(menusVisible, "Main product category menus should be visible");
        }

        /// <summary>
        /// Expands a specific product menu
        /// Test Step: Expand main product menu
        /// </summary>
        [When(@"the user expands the ""(.*)"" menu")]
        public void WhenTheUserExpandsTheMenu(string menuName)
        {
            LogHelper.Info($"Expanding {menuName} menu");
            _navigationPage.ExpandProductMenu(menuName);
            _scenarioContext["ExpandedMenu"] = menuName;
        }

        /// <summary>
        /// Verifies submenu items are displayed
        /// Expected Result: Submenu items are displayed under each main product menu
        /// </summary>
        [Then(@"submenu items should be displayed under the main product menu")]
        public void ThenSubmenuItemsShouldBeDisplayedUnderTheMainProductMenu()
        {
            LogHelper.Info("Verifying submenu items are displayed");
            string menuName = _scenarioContext["ExpandedMenu"].ToString();
            bool hasSubmenu = _navigationPage.HasSubmenuItems(menuName);
            Assert.IsTrue(hasSubmenu, $"Submenu items should be displayed under {menuName} menu");
        }

        /// <summary>
        /// Clicks on a specific submenu item
        /// Test Step: Click on submenu item
        /// </summary>
        [When(@"the user clicks on the ""(.*)"" submenu item")]
        public void WhenTheUserClicksOnTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Clicking on {submenuItem} submenu item");
            _navigationPage.ClickSubmenuItem(submenuItem);
            _scenarioContext["SelectedSubmenu"] = submenuItem;
        }

        /// <summary>
        /// Verifies submenu item responds to interaction
        /// Expected Result: Submenu item is selectable and responds to user interaction
        /// </summary>
        [Then(@"the submenu item should respond to user interaction")]
        public void ThenTheSubmenuItemShouldRespondToUserInteraction()
        {
            LogHelper.Info("Verifying submenu item responded to interaction");
            bool pageChanged = _navigationPage.HasPageNavigated();
            Assert.IsTrue(pageChanged, "Submenu item should respond to user interaction and navigate");
        }

        /// <summary>
        /// Selects a specific submenu item
        /// Test Step: Select submenu item
        /// </summary>
        [When(@"the user selects the ""(.*)"" submenu item")]
        public void WhenTheUserSelectsTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Selecting {submenuItem} submenu item");
            _navigationPage.ClickSubmenuItem(submenuItem);
            _scenarioContext["SelectedSubmenu"] = submenuItem;
        }

        /// <summary>
        /// Verifies user is redirected to destination page
        /// Expected Result: User is redirected to the destination page for the selected submenu item
        /// </summary>
        [Then(@"the user should be redirected to the destination page")]
        public void ThenTheUserShouldBeRedirectedToTheDestinationPage()
        {
            LogHelper.Info("Verifying redirection to destination page");
            bool isRedirected = _navigationPage.HasPageNavigated();
            Assert.IsTrue(isRedirected, "User should be redirected to the destination page");
        }

        /// <summary>
        /// Verifies destination page loads without errors
        /// Expected Result: Destination page loads successfully
        /// </summary>
        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            LogHelper.Info("Verifying destination page loaded without errors");
            bool hasErrors = _navigationPage.HasPageErrors();
            Assert.IsFalse(hasErrors, "Destination page should load without errors");
        }

        /// <summary>
        /// Verifies destination page URL contains expected identifier
        /// Expected Result: Destination page URL contains the correct identifier
        /// </summary>
        [Then(@"the destination page URL should contain ""(.*)""")]
        public void ThenTheDestinationPageURLShouldContain(string expectedUrlPart)
        {
            LogHelper.Info($"Verifying URL contains: {expectedUrlPart}");
            string currentUrl = _navigationPage.GetCurrentPageUrl();
            bool containsExpected = currentUrl.Contains(expectedUrlPart);
            Assert.IsTrue(containsExpected, $"Destination page URL should contain '{expectedUrlPart}'. Actual URL: {currentUrl}");
        }

        /// <summary>
        /// Verifies Golden 1 logo is visible in header
        /// Expected Result: Golden 1 logo is visible in the top header
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            LogHelper.Info("Verifying Golden 1 logo visibility");
            bool isLogoVisible = _navigationPage.IsLogoVisible();
            Assert.IsTrue(isLogoVisible, "Golden 1 logo should be visible in the top header");
        }

        /// <summary>
        /// Verifies homepage displays correctly with no broken layouts
        /// Expected Result: Homepage displays correctly with no broken layouts
        /// </summary>
        [Then(@"the homepage should display correctly with no broken layouts")]
        public void ThenTheHomepageShouldDisplayCorrectlyWithNoBrokenLayouts()
        {
            LogHelper.Info("Verifying homepage displays correctly");
            bool isDisplayedCorrectly = _navigationPage.IsPageDisplayedCorrectly();
            Assert.IsTrue(isDisplayedCorrectly, "Homepage should display correctly with no broken layouts");
        }

        /// <summary>
        /// Verifies there are no missing content or system errors
        /// Expected Result: No missing content or system errors
        /// </summary>
        [Then(@"there should be no missing content or system errors")]
        public void ThenThereShouldBeNoMissingContentOrSystemErrors()
        {
            LogHelper.Info("Verifying no missing content or system errors");
            bool hasErrors = _navigationPage.HasPageErrors();
            Assert.IsFalse(hasErrors, "There should be no missing content or system errors");
        }
    }
}