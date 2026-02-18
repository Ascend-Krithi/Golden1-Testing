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
    /// Step Definitions for Golden1 Navigation Menu interactions
    /// Test Cases: TASK0020445 TS-002 through TS-007
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _navigationPage = new NavigationPage(_driver);
            _homePage = new HomePage(_driver);
        }

        /// <summary>
        /// Step: Global navigation menu should be visible at the top
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"Global navigation menu should be visible at the top")]
        public void ThenGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            LogHelper.Info("Step: Verifying global navigation menu is visible at the top");
            
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top of the page");
            
            LogHelper.Info("Global navigation menu is visible");
        }

        /// <summary>
        /// Step: Navigation menu should be visible
        /// Test Cases: TASK0020445 TS-003 TC-001, TS-004 TC-001
        /// </summary>
        [Then(@"Navigation menu should be visible")]
        public void ThenNavigationMenuShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying navigation menu is visible");
            
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Navigation menu should be visible");
            
            LogHelper.Info("Navigation menu is visible");
        }

        /// <summary>
        /// Step: All top menu options should be present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"All top menu options should be present")]
        public void ThenAllTopMenuOptionsShouldBePresent(Table table)
        {
            LogHelper.Info("Step: Verifying all top menu options are present");
            
            List<string> menuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
            
            bool allPresent = _navigationPage.AreAllTopMenuOptionsPresent(menuOptions);
            Assert.That(allPresent, Is.True, "All specified top menu options should be present in the navigation menu");
            
            LogHelper.Info($"All {menuOptions.Count} top menu options are present");
        }

        /// <summary>
        /// Step: All main product category menus should be displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"All main product category menus should be displayed")]
        public void ThenAllMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            LogHelper.Info("Step: Verifying all main product category menus are displayed");
            
            List<string> categories = table.Rows.Select(row => row["ProductCategory"]).ToList();
            
            bool allDisplayed = _navigationPage.AreAllProductCategoryMenusDisplayed(categories);
            Assert.That(allDisplayed, Is.True, "All main product category menus should be displayed in the navigation");
            
            LogHelper.Info($"All {categories.Count} product category menus are displayed");
        }

        /// <summary>
        /// Step: Each product category menu should be clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"Each product category menu should be clickable")]
        public void ThenEachProductCategoryMenuShouldBeClickable()
        {
            LogHelper.Info("Step: Verifying each product category menu is clickable");
            
            List<string> categories = new List<string> 
            { 
                "Checking", "Savings", "Home Loans", "Credit Cards", 
                "Loans", "Investing", "Community" 
            };
            
            bool allClickable = _navigationPage.AreAllProductCategoryMenusClickable(categories);
            Assert.That(allClickable, Is.True, "Each product category menu should be clickable");
            
            LogHelper.Info("All product category menus are clickable");
        }

        /// <summary>
        /// Step: User expands menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"User expands ""(.*)"" menu")]
        public void WhenUserExpandsMenu(string menuName)
        {
            LogHelper.Info($"Step: User expands '{menuName}' menu");
            
            _navigationPage.ExpandProductMenu(menuName);
            
            LogHelper.Info($"Menu '{menuName}' expanded");
        }

        /// <summary>
        /// Step: Submenu items should be displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"Submenu items should be displayed")]
        public void ThenSubmenuItemsShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying submenu items are displayed");
            
            bool areDisplayed = _navigationPage.AreSubmenuItemsDisplayed();
            Assert.That(areDisplayed, Is.True, "Submenu items should be displayed after expanding menu");
            
            LogHelper.Info("Submenu items are displayed");
        }

        /// <summary>
        /// Step: User should be able to select submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"User should be able to select ""(.*)"" submenu item")]
        public void ThenUserShouldBeAbleToSelectSubmenuItem(string itemName)
        {
            LogHelper.Info($"Step: Verifying user can select '{itemName}' submenu item");
            
            bool canSelect = _navigationPage.CanSelectSubmenuItem(itemName);
            Assert.That(canSelect, Is.True, $"User should be able to select '{itemName}' submenu item");
            
            LogHelper.Info($"Submenu item '{itemName}' is selectable");
        }

        /// <summary>
        /// Step: User clicks on submenu item
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"User clicks on ""(.*)"" submenu item")]
        public void WhenUserClicksOnSubmenuItem(string itemName)
        {
            LogHelper.Info($"Step: User clicks on '{itemName}' submenu item");
            
            _navigationPage.ClickSubmenuItem(itemName);
            
            LogHelper.Info($"Clicked on submenu item '{itemName}'");
        }

        /// <summary>
        /// Step: User should be redirected to destination page
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"User should be redirected to destination page")]
        public void ThenUserShouldBeRedirectedToDestinationPage()
        {
            LogHelper.Info("Step: Verifying user is redirected to destination page");
            
            bool isRedirected = _navigationPage.IsDestinationPageLoaded();
            Assert.That(isRedirected, Is.True, "User should be redirected to the destination page");
            
            LogHelper.Info("User redirected to destination page");
        }

        /// <summary>
        /// Step: Destination page should load without errors
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"Destination page should load without errors")]
        public void ThenDestinationPageShouldLoadWithoutErrors()
        {
            LogHelper.Info("Step: Verifying destination page loads without errors");
            
            bool hasNoErrors = _homePage.HasNoErrors();
            Assert.That(hasNoErrors, Is.True, "Destination page should load without errors");
            
            LogHelper.Info("Destination page loaded without errors");
        }

        /// <summary>
        /// Step: Destination page URL should contain expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"Destination page URL should contain ""(.*)""")] 
        public void ThenDestinationPageUrlShouldContainIdentifier(string identifier)
        {
            LogHelper.Info($"Step: Verifying destination page URL contains '{identifier}'");
            
            bool containsIdentifier = _navigationPage.DoesUrlContainIdentifier(identifier);
            Assert.That(containsIdentifier, Is.True, 
                $"Destination page URL should contain the expected identifier '{identifier}'");
            
            LogHelper.Info($"URL contains expected identifier '{identifier}'");
        }
    }
}