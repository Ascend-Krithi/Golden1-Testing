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

        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("Browser has been launched successfully");
            Assert.That(_driver, Is.Not.Null, "Browser should be initialized");
        }

        #endregion

        #region Navigation Steps

        [When(@"I navigate to the Golden 1 homepage")]
        [Given(@"I navigate to the Golden 1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden 1 homepage");
            _homePage.OpenHomePage();
            _homePage.HandleCookieBanner();
        }

        [When(@"I check the top section of the homepage")]
        public void WhenICheckTheTopSectionOfTheHomepage()
        {
            LogHelper.Info("Checking top section of homepage for navigation menu");
            // Method call to verify top section - actual verification in Then step
        }

        [When(@"I inspect the top navigation menu")]
        public void WhenIInspectTheTopNavigationMenu()
        {
            LogHelper.Info("Inspecting top navigation menu options");
            // Inspection happens in Then step
        }

        [When(@"I interact with the global navigation menu")]
        public void WhenIInteractWithTheGlobalNavigationMenu()
        {
            LogHelper.Info("Interacting with global navigation menu");
            _navigationPage.EnsureNavigationMenuIsVisible();
        }

        [When(@"I hover over the ""(.*)"" main product menu")]
        public void WhenIHoverOverTheMainProductMenu(string menuName)
        {
            LogHelper.Info($"Hovering over '{menuName}' main product menu");
            _navigationPage.HoverOverMainMenu(menuName);
        }

        [When(@"I click the ""(.*)"" submenu item")]
        public void WhenIClickTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Clicking submenu item: {submenuItem}");
            _navigationPage.ClickSubmenuItem(submenuItem);
        }

        [When(@"I select the ""(.*)"" submenu item under ""(.*)"" menu")]
        public void WhenISelectTheSubmenuItemUnderMenu(string submenuItem, string mainMenu)
        {
            LogHelper.Info($"Selecting '{submenuItem}' under '{mainMenu}' menu");
            _navigationPage.HoverOverMainMenu(mainMenu);
            _navigationPage.ClickSubmenuItem(submenuItem);
        }

        [When(@"I check the top header area")]
        public void WhenICheckTheTopHeaderArea()
        {
            LogHelper.Info("Checking top header area for logo");
            // Verification in Then step
        }

        [When(@"I inspect the homepage for layout and content")]
        public void WhenIInspectTheHomepageForLayoutAndContent()
        {
            LogHelper.Info("Inspecting homepage layout and content");
            // Verification in Then step
        }

        [When(@"I use keyboard navigation to move to the global navigation menu")]
        public void WhenIUseKeyboardNavigationToMoveToTheGlobalNavigationMenu()
        {
            LogHelper.Info("Using keyboard navigation to reach global navigation menu");
            _navigationPage.NavigateToMenuUsingKeyboard();
        }

        [When(@"I use keyboard navigation to access each main menu item")]
        public void WhenIUseKeyboardNavigationToAccessEachMainMenuItem()
        {
            LogHelper.Info("Using keyboard to navigate through main menu items");
            _navigationPage.NavigateMenuItemsUsingKeyboard();
        }

        [When(@"I press Enter on a menu item")]
        public void WhenIPressEnterOnAMenuItem()
        {
            LogHelper.Info("Pressing Enter key on menu item");
            _navigationPage.PressEnterOnFocusedElement();
        }

        #endregion

        #region Browser and Device Steps

        [Given(@"I launch the ""(.*)"" browser")]
        public void GivenILaunchTheBrowser(string browserName)
        {
            LogHelper.Info($"Browser '{browserName}' is being used for this test");
            // Browser is already launched in Hooks, this step is for documentation
            _scenarioContext["Browser"] = browserName;
        }

        [Given(@"I set the viewport to ""(.*)"" size")]
        public void GivenISetTheViewportToSize(string deviceType)
        {
            LogHelper.Info($"Setting viewport to {deviceType} size");
            _homePage.SetViewportSize(deviceType);
            _scenarioContext["DeviceType"] = deviceType;
        }

        #endregion

        #region Assertion Steps

        [Then(@"the Golden 1 homepage should be displayed successfully")]
        public void ThenTheGolden1HomepageShouldBeDisplayedSuccessfully()
        {
            LogHelper.Info("Verifying Golden 1 homepage is displayed");
            bool isDisplayed = _homePage.IsHomePageDisplayed();
            Assert.That(isDisplayed, Is.True, "Golden 1 homepage should be displayed successfully");
        }

        [Then(@"the homepage should be visible without errors")]
        public void ThenTheHomepageShouldBeVisibleWithoutErrors()
        {
            LogHelper.Info("Verifying homepage is visible without errors");
            bool hasNoErrors = _homePage.VerifyNoErrorsOnPage();
            Assert.That(hasNoErrors, Is.True, "Homepage should be visible without error messages");
        }

        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            LogHelper.Info("Verifying global navigation menu visibility");
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top of the homepage");
        }

        [Then(@"the following menu options should be present:")]
        public void ThenTheFollowingMenuOptionsShouldBePresent(Table table)
        {
            LogHelper.Info("Verifying top navigation menu options are present");
            var expectedMenuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
            
            foreach (var menuOption in expectedMenuOptions)
            {
                bool isPresent = _navigationPage.IsTopMenuOptionPresent(menuOption);
                Assert.That(isPresent, Is.True, $"Menu option '{menuOption}' should be present in top navigation");
                LogHelper.Info($"Menu option '{menuOption}' is present");
            }
        }

        [Then(@"the following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            LogHelper.Info("Verifying main product category menus are displayed");
            var expectedCategories = table.Rows.Select(row => row["CategoryMenu"]).ToList();
            
            foreach (var category in expectedCategories)
            {
                bool isDisplayed = _navigationPage.IsMainCategoryMenuDisplayed(category);
                Assert.That(isDisplayed, Is.True, $"Main product category '{category}' should be displayed");
                LogHelper.Info($"Category menu '{category}' is displayed");
            }
        }

        [Then(@"each main product category menu should be accessible")]
        public void ThenEachMainProductCategoryMenuShouldBeAccessible()
        {
            LogHelper.Info("Verifying each main product category menu is accessible");
            bool allAccessible = _navigationPage.VerifyAllMainCategoriesAccessible();
            Assert.That(allAccessible, Is.True, "All main product category menus should be accessible");
        }

        [Then(@"submenu items should be displayed under the main product menu")]
        public void ThenSubmenuItemsShouldBeDisplayedUnderTheMainProductMenu()
        {
            LogHelper.Info("Verifying submenu items are displayed");
            bool submenuDisplayed = _navigationPage.IsSubmenuDisplayed();
            Assert.That(submenuDisplayed, Is.True, "Submenu items should be displayed under main product menu");
        }

        [Then(@"the submenu item should respond to the click")]
        public void ThenTheSubmenuItemShouldRespondToTheClick()
        {
            LogHelper.Info("Verifying submenu item responded to click");
            bool pageChanged = _navigationPage.VerifyPageNavigationOccurred();
            Assert.That(pageChanged, Is.True, "Submenu item should respond to click and navigate");
        }

        [Then(@"I should be redirected to the destination page")]
        public void ThenIShouldBeRedirectedToTheDestinationPage()
        {
            LogHelper.Info("Verifying redirection to destination page");
            bool isRedirected = _navigationPage.VerifyPageNavigationOccurred();
            Assert.That(isRedirected, Is.True, "User should be redirected to the destination page");
        }

        [Then(@"the destination page should load completely without errors")]
        public void ThenTheDestinationPageShouldLoadCompletelyWithoutErrors()
        {
            LogHelper.Info("Verifying destination page loaded without errors");
            bool pageLoaded = _homePage.VerifyPageLoadedSuccessfully();
            bool noErrors = _homePage.VerifyNoErrorsOnPage();
            
            Assert.That(pageLoaded, Is.True, "Destination page should load completely");
            Assert.That(noErrors, Is.True, "Destination page should have no errors");
        }

        [Then(@"the URL should contain the expected page identifier ""(.*)""")]
        public void ThenTheURLShouldContainTheExpectedPageIdentifier(string expectedIdentifier)
        {
            LogHelper.Info($"Verifying URL contains expected identifier: {expectedIdentifier}");
            string currentUrl = _homePage.GetCurrentPageUrl();
            Assert.That(currentUrl, Does.Contain(expectedIdentifier), 
                $"URL should contain the expected page identifier '{expectedIdentifier}'. Actual URL: {currentUrl}");
        }

        [Then(@"the Golden 1 logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            LogHelper.Info("Verifying Golden 1 logo is visible in header");
            bool logoVisible = _homePage.IsLogoVisible();
            Assert.That(logoVisible, Is.True, "Golden 1 logo should be visible in the top header area");
        }

        [Then(@"the homepage should display all content correctly")]
        public void ThenTheHomepageShouldDisplayAllContentCorrectly()
        {
            LogHelper.Info("Verifying homepage displays all content correctly");
            bool contentDisplayed = _homePage.VerifyAllContentDisplayed();
            Assert.That(contentDisplayed, Is.True, "Homepage should display all content correctly");
        }

        [Then(@"there should be no broken layouts or error messages")]
        public void ThenThereShouldBeNoBrokenLayoutsOrErrorMessages()
        {
            LogHelper.Info("Verifying no broken layouts or error messages");
            bool noBrokenLayouts = _homePage.VerifyNoLayoutIssues();
            bool noErrors = _homePage.VerifyNoErrorsOnPage();
            
            Assert.That(noBrokenLayouts, Is.True, "Homepage should have no broken layouts");
            Assert.That(noErrors, Is.True, "Homepage should have no error messages");
        }

        [Then(@"the navigation menu should be displayed correctly")]
        public void ThenTheNavigationMenuShouldBeDisplayedCorrectly()
        {
            LogHelper.Info("Verifying navigation menu displays correctly");
            bool menuDisplayed = _navigationPage.IsNavigationMenuVisible();
            Assert.That(menuDisplayed, Is.True, "Navigation menu should be displayed correctly");
        }

        [Then(@"the homepage elements should be consistent")]
        public void ThenTheHomepageElementsShouldBeConsistent()
        {
            LogHelper.Info("Verifying homepage elements are consistent");
            bool elementsConsistent = _homePage.VerifyElementsConsistent();
            Assert.That(elementsConsistent, Is.True, "Homepage elements should be consistent across browsers");
        }

        [Then(@"the homepage elements should be responsive")]
        public void ThenTheHomepageElementsShouldBeResponsive()
        {
            LogHelper.Info("Verifying homepage elements are responsive");
            bool elementsResponsive = _homePage.VerifyElementsResponsive();
            Assert.That(elementsResponsive, Is.True, "Homepage elements should be responsive across devices");
        }

        [Then(@"the focus should move to the global navigation menu")]
        public void ThenTheFocusShouldMoveToTheGlobalNavigationMenu()
        {
            LogHelper.Info("Verifying focus moved to global navigation menu");
            bool focusMoved = _navigationPage.VerifyFocusOnNavigationMenu();
            Assert.That(focusMoved, Is.True, "Focus should move to the global navigation menu using keyboard");
        }

        [Then(@"all menu items should be accessible via keyboard")]
        public void ThenAllMenuItemsShouldBeAccessibleViaKeyboard()
        {
            LogHelper.Info("Verifying all menu items are accessible via keyboard");
            bool allAccessible = _navigationPage.VerifyKeyboardAccessibility();
            Assert.That(allAccessible, Is.True, "All menu and submenu items should be accessible via keyboard");
        }

        [Then(@"the menu item should respond to keyboard selection")]
        public void ThenTheMenuItemShouldRespondToKeyboardSelection()
        {
            LogHelper.Info("Verifying menu item responds to keyboard selection");
            bool responded = _navigationPage.VerifyKeyboardSelectionResponse();
            Assert.That(responded, Is.True, "Menu item should respond to keyboard selection (Enter key)");
        }

        #endregion
    }
}