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
    /// Step Definitions for Golden 1 Navigation scenarios
    /// Test Cases: TASK0020445 TS-001 through TS-012
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
        /// Test Cases: All scenarios
        /// </summary>
        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("Browser has been launched successfully");
            Assert.That(_driver, Is.Not.Null, "Browser driver should be initialized");
        }

        #endregion

        #region Navigation Steps

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001, etc.
        /// </summary>
        [When(@"I navigate to the Golden 1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden 1 homepage");
            _homePage.OpenHomePage();
            _homePage.HandleCookieBanner();
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I hover over the ""(.*)"" menu")]
        public void WhenIHoverOverTheMenu(string menuName)
        {
            LogHelper.Info($"Hovering over menu: {menuName}");
            _navigationPage.HoverOverMainMenu(menuName);
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I click on the ""(.*)"" submenu item")]
        public void WhenIClickOnTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Clicking on submenu item: {submenuItem}");
            _navigationPage.ClickSubmenuItem(submenuItem);
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [When(@"I use keyboard navigation to focus on the global navigation menu")]
        public void WhenIUseKeyboardNavigationToFocusOnTheGlobalNavigationMenu()
        {
            LogHelper.Info("Using keyboard navigation to focus on navigation menu");
            _navigationPage.FocusOnNavigationMenuUsingKeyboard();
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [When(@"I use keyboard navigation to access each main menu item")]
        public void WhenIUseKeyboardNavigationToAccessEachMainMenuItem()
        {
            LogHelper.Info("Using keyboard navigation to access main menu items");
            _navigationPage.NavigateMenuItemsUsingKeyboard();
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [When(@"I press Enter on a menu item")]
        public void WhenIPressEnterOnAMenuItem()
        {
            LogHelper.Info("Pressing Enter on menu item");
            _navigationPage.PressEnterOnFocusedElement();
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Given(@"the browser type is ""(.*)""")]
        public void GivenTheBrowserTypeIs(string browserType)
        {
            LogHelper.Info($"Browser type specified: {browserType}");
            _scenarioContext["BrowserType"] = browserType;
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Given(@"the device type is ""(.*)""")]
        public void GivenTheDeviceTypeIs(string deviceType)
        {
            LogHelper.Info($"Device type specified: {deviceType}");
            _scenarioContext["DeviceType"] = deviceType;
        }

        #endregion

        #region Assertion Steps

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the Golden 1 homepage should be displayed successfully")]
        public void ThenTheGolden1HomepageShouldBeDisplayedSuccessfully()
        {
            LogHelper.Info("Verifying homepage is displayed successfully");
            bool isDisplayed = _homePage.IsHomePageDisplayed();
            Assert.That(isDisplayed, Is.True, "Golden 1 homepage should be displayed successfully");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should be visible without errors")]
        public void ThenTheHomepageShouldBeVisibleWithoutErrors()
        {
            LogHelper.Info("Verifying homepage has no errors");
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.That(hasErrors, Is.False, "Homepage should not have any error messages");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            LogHelper.Info("Verifying global navigation menu is visible");
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top of the homepage");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"all top navigation menu options should be present")]
        public void ThenAllTopNavigationMenuOptionsShouldBePresent(Table table)
        {
            LogHelper.Info("Verifying all top navigation menu options are present");
            var expectedMenus = table.Rows.Select(r => r[0]).ToList();
            
            foreach (var menu in expectedMenus)
            {
                bool isPresent = _navigationPage.IsTopNavigationTabPresent(menu);
                Assert.That(isPresent, Is.True, $"Top navigation menu option '{menu}' should be present");
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"all main product category menus should be displayed")]
        public void ThenAllMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            LogHelper.Info("Verifying all main product category menus are displayed");
            var expectedMenus = table.Rows.Select(r => r[0]).ToList();
            
            foreach (var menu in expectedMenus)
            {
                bool isDisplayed = _navigationPage.IsMainProductMenuDisplayed(menu);
                Assert.That(isDisplayed, Is.True, $"Main product category menu '{menu}' should be displayed");
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"each main product category menu should be accessible")]
        public void ThenEachMainProductCategoryMenuShouldBeAccessible()
        {
            LogHelper.Info("Verifying each main product category menu is accessible");
            bool allAccessible = _navigationPage.AreAllMainMenusAccessible();
            Assert.That(allAccessible, Is.True, "All main product category menus should be accessible");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"submenu items should be displayed under ""(.*)""")]
        public void ThenSubmenuItemsShouldBeDisplayedUnder(string menuName)
        {
            LogHelper.Info($"Verifying submenu items are displayed under {menuName}");
            bool hasSubmenu = _navigationPage.HasSubmenuItems(menuName);
            Assert.That(hasSubmenu, Is.True, $"Submenu items should be displayed under {menuName}");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"the submenu item should respond to click")]
        public void ThenTheSubmenuItemShouldRespondToClick()
        {
            LogHelper.Info("Verifying submenu item responded to click");
            bool pageChanged = _navigationPage.HasPageChanged();
            Assert.That(pageChanged, Is.True, "Submenu item should respond to click and navigate");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"I should be redirected to the destination page")]
        public void ThenIShouldBeRedirectedToTheDestinationPage()
        {
            LogHelper.Info("Verifying redirection to destination page");
            bool isRedirected = _navigationPage.IsOnDestinationPage();
            Assert.That(isRedirected, Is.True, "User should be redirected to the destination page");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-009 TC-001
        /// </summary>
        [Then(@"the destination page should load completely without errors")]
        public void ThenTheDestinationPageShouldLoadCompletelyWithoutErrors()
        {
            LogHelper.Info("Verifying destination page loaded without errors");
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.That(hasErrors, Is.False, "Destination page should load without errors");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the URL should contain the expected page identifier ""(.*)""")]
        public void ThenTheURLShouldContainTheExpectedPageIdentifier(string expectedIdentifier)
        {
            LogHelper.Info($"Verifying URL contains expected identifier: {expectedIdentifier}");
            string currentUrl = _navigationPage.GetCurrentPageUrl();
            Assert.That(currentUrl.ToLower(), Does.Contain(expectedIdentifier.ToLower()), 
                $"URL should contain the expected page identifier '{expectedIdentifier}'");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the top header area")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeaderArea()
        {
            LogHelper.Info("Verifying Golden 1 logo is visible");
            bool isLogoVisible = _homePage.IsLogoVisible();
            Assert.That(isLogoVisible, Is.True, "Golden 1 logo should be visible in the top header area");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should display all content correctly")]
        public void ThenTheHomepageShouldDisplayAllContentCorrectly()
        {
            LogHelper.Info("Verifying homepage displays all content correctly");
            bool isContentDisplayed = _homePage.IsAllContentDisplayed();
            Assert.That(isContentDisplayed, Is.True, "Homepage should display all content correctly");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no broken layouts or error messages")]
        public void ThenThereShouldBeNoBrokenLayoutsOrErrorMessages()
        {
            LogHelper.Info("Verifying no broken layouts or error messages");
            bool hasBrokenLayout = _homePage.HasBrokenLayout();
            bool hasErrors = _homePage.HasErrorMessages();
            
            Assert.That(hasBrokenLayout, Is.False, "Homepage should not have broken layouts");
            Assert.That(hasErrors, Is.False, "Homepage should not have error messages");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Then(@"the navigation menu should be displayed correctly")]
        public void ThenTheNavigationMenuShouldBeDisplayedCorrectly()
        {
            LogHelper.Info("Verifying navigation menu is displayed correctly");
            bool isDisplayedCorrectly = _navigationPage.IsNavigationMenuDisplayedCorrectly();
            Assert.That(isDisplayedCorrectly, Is.True, "Navigation menu should be displayed correctly");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Then(@"the homepage elements should be consistent")]
        public void ThenTheHomepageElementsShouldBeConsistent()
        {
            LogHelper.Info("Verifying homepage elements are consistent");
            bool areConsistent = _homePage.AreElementsConsistent();
            Assert.That(areConsistent, Is.True, "Homepage elements should be consistent across browsers");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the navigation menu should be displayed correctly on ""(.*)""")]
        public void ThenTheNavigationMenuShouldBeDisplayedCorrectlyOn(string deviceType)
        {
            LogHelper.Info($"Verifying navigation menu is displayed correctly on {deviceType}");
            bool isDisplayedCorrectly = _navigationPage.IsNavigationMenuResponsive(deviceType);
            Assert.That(isDisplayedCorrectly, Is.True, $"Navigation menu should be displayed correctly on {deviceType}");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the homepage elements should be responsive on ""(.*)""")]
        public void ThenTheHomepageElementsShouldBeResponsiveOn(string deviceType)
        {
            LogHelper.Info($"Verifying homepage elements are responsive on {deviceType}");
            bool areResponsive = _homePage.AreElementsResponsive(deviceType);
            Assert.That(areResponsive, Is.True, $"Homepage elements should be responsive on {deviceType}");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [Then(@"the focus should move to the global navigation menu")]
        public void ThenTheFocusShouldMoveToTheGlobalNavigationMenu()
        {
            LogHelper.Info("Verifying focus moved to navigation menu");
            bool hasFocus = _navigationPage.IsNavigationMenuFocused();
            Assert.That(hasFocus, Is.True, "Focus should move to the global navigation menu");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [Then(@"all menu items should be accessible via keyboard")]
        public void ThenAllMenuItemsShouldBeAccessibleViaKeyboard()
        {
            LogHelper.Info("Verifying all menu items are accessible via keyboard");
            bool allAccessible = _navigationPage.AreAllMenuItemsKeyboardAccessible();
            Assert.That(allAccessible, Is.True, "All menu items should be accessible via keyboard");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [Then(@"the menu item should respond to keyboard selection")]
        public void ThenTheMenuItemShouldRespondToKeyboardSelection()
        {
            LogHelper.Info("Verifying menu item responds to keyboard selection");
            bool responded = _navigationPage.DidMenuItemRespondToKeyboard();
            Assert.That(responded, Is.True, "Menu item should respond to keyboard selection");
        }

        #endregion
    }
}