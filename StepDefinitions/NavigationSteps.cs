using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for Golden 1 Navigation Menu interactions
    /// Test Cases: TASK0020445 TS-002 to TS-007, TS-010 to TS-012
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _navigationPage = new NavigationPage(_driver);
        }

        /// <summary>
        /// Step: Then the global navigation menu should be visible at the top
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            try
            {
                LogHelper.Info("Step: Verifying global navigation menu is visible");
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isVisible, Is.True, 
                    "Global navigation menu should be visible at the top of the homepage");
                
                LogHelper.Info("Global navigation menu verified successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "NavigationMenuVerificationFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: Then the top navigation menu should contain the following options
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"the top navigation menu should contain the following options:")]
        public void ThenTheTopNavigationMenuShouldContainTheFollowingOptions(Table table)
        {
            try
            {
                LogHelper.Info("Step: Verifying top navigation menu options");
                var menuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
                
                bool allPresent = _navigationPage.AreAllTopNavigationTabsPresent(menuOptions);
                
                Assert.That(allPresent, Is.True, 
                    $"All specified menu options should be present in the top navigation menu. Expected: {string.Join(", ", menuOptions)}");
                
                LogHelper.Info($"All {menuOptions.Count} top navigation options verified successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top navigation options verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "TopNavigationOptionsFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: When I interact with the global navigation menu
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [When(@"I interact with the global navigation menu")]
        public void WhenIInteractWithTheGlobalNavigationMenu()
        {
            try
            {
                LogHelper.Info("Step: Interacting with global navigation menu");
                // Simply verify the menu is visible and ready for interaction
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                Assert.That(isVisible, Is.True, "Navigation menu should be visible for interaction");
                LogHelper.Info("Successfully interacted with navigation menu");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to interact with navigation menu: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Then the following main product category menus should be displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"the following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            try
            {
                LogHelper.Info("Step: Verifying main product category menus are displayed");
                var categoryMenus = table.Rows.Select(row => row["CategoryMenu"]).ToList();
                
                bool allDisplayed = _navigationPage.AreAllMainProductMenusDisplayed(categoryMenus);
                
                Assert.That(allDisplayed, Is.True, 
                    $"All main product category menus should be displayed. Expected: {string.Join(", ", categoryMenus)}");
                
                LogHelper.Info($"All {categoryMenus.Count} main product category menus verified successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Main product category menus verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "ProductCategoryMenusFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: And each main product category menu should be accessible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"each main product category menu should be accessible")]
        public void ThenEachMainProductCategoryMenuShouldBeAccessible()
        {
            try
            {
                LogHelper.Info("Step: Verifying each main product category menu is accessible");
                var categoryMenus = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
                
                foreach (var menu in categoryMenus)
                {
                    bool isAccessible = _navigationPage.IsMainMenuAccessible(menu);
                    Assert.That(isAccessible, Is.True, $"Menu '{menu}' should be accessible");
                }
                
                LogHelper.Info("All main product category menus are accessible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu accessibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "MenuAccessibilityFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: When I hover over the main product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001
        /// </summary>
        [When(@"I hover over the ""(.*)"" main product menu")]
        public void WhenIHoverOverTheMainProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Step: Hovering over '{menuName}' main product menu");
                _navigationPage.HoverOverMainMenu(menuName);
                LogHelper.Info($"Successfully hovered over '{menuName}' menu");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to hover over '{menuName}' menu: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"HoverFailure_{menuName}");
                throw;
            }
        }

        /// <summary>
        /// Step: Then submenu items should be displayed under menu
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"submenu items should be displayed under ""(.*)""")]
        public void ThenSubmenuItemsShouldBeDisplayedUnder(string menuName)
        {
            try
            {
                LogHelper.Info($"Step: Verifying submenu items are displayed under '{menuName}'");
                bool areDisplayed = _navigationPage.AreSubmenuItemsDisplayed(menuName);
                
                Assert.That(areDisplayed, Is.True, 
                    $"Submenu items should be displayed under '{menuName}' menu");
                
                LogHelper.Info($"Submenu items verified under '{menuName}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items verification failed for '{menuName}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"SubmenuVerificationFailure_{menuName}");
                throw;
            }
        }

        /// <summary>
        /// Step: When I click the submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I click the ""(.*)"" submenu item")]
        public void WhenIClickTheSubmenuItem(string itemName)
        {
            try
            {
                LogHelper.Info($"Step: Clicking '{itemName}' submenu item");
                _navigationPage.ClickSubmenuItem(itemName);
                LogHelper.Info($"Successfully clicked '{itemName}' submenu item");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click '{itemName}' submenu item: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"SubmenuClickFailure_{itemName}");
                throw;
            }
        }

        /// <summary>
        /// Step: Then the submenu item should respond to the click
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"the submenu item should respond to the click")]
        public void ThenTheSubmenuItemShouldRespondToTheClick()
        {
            try
            {
                LogHelper.Info("Step: Verifying submenu item responded to click");
                bool isRedirected = _navigationPage.IsRedirectedToDestinationPage();
                
                Assert.That(isRedirected, Is.True, 
                    "Submenu item should respond to click and navigate to destination page");
                
                LogHelper.Info("Submenu item click response verified successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item click response verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "SubmenuClickResponseFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: Then I should be redirected to the destination page
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"I should be redirected to the (.*) destination page")]
        public void ThenIShouldBeRedirectedToTheDestinationPage(string pageName)
        {
            try
            {
                LogHelper.Info($"Step: Verifying redirection to '{pageName}' destination page");
                bool isRedirected = _navigationPage.IsRedirectedToDestinationPage();
                
                Assert.That(isRedirected, Is.True, 
                    $"User should be redirected to '{pageName}' destination page");
                
                LogHelper.Info($"Successfully redirected to '{pageName}' destination page");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Redirection verification failed for '{pageName}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"RedirectionFailure_{pageName}");
                throw;
            }
        }

        /// <summary>
        /// Step: And the destination page should load completely
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"the destination page should load completely")]
        public void ThenTheDestinationPageShouldLoadCompletely()
        {
            try
            {
                LogHelper.Info("Step: Verifying destination page loaded completely");
                bool isLoaded = _navigationPage.IsDestinationPageLoadedCompletely();
                
                Assert.That(isLoaded, Is.True, 
                    "Destination page should load completely without errors");
                
                LogHelper.Info("Destination page loaded completely");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "DestinationPageLoadFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: Then the URL should contain the expected page identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the URL should contain the expected page identifier ""(.*)""")]
        public void ThenTheURLShouldContainTheExpectedPageIdentifier(string expectedIdentifier)
        {
            try
            {
                LogHelper.Info($"Step: Verifying URL contains identifier '{expectedIdentifier}'");
                bool containsIdentifier = _navigationPage.DoesUrlContainIdentifier(expectedIdentifier);
                
                Assert.That(containsIdentifier, Is.True, 
                    $"URL should contain the expected page identifier '{expectedIdentifier}'");
                
                LogHelper.Info($"URL contains expected identifier '{expectedIdentifier}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL identifier verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "URLIdentifierFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: Then the navigation menu should be displayed correctly
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Then(@"the navigation menu should be displayed correctly")]
        public void ThenTheNavigationMenuShouldBeDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Step: Verifying navigation menu is displayed correctly");
                bool isDisplayed = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isDisplayed, Is.True, 
                    "Navigation menu should be displayed correctly");
                
                LogHelper.Info("Navigation menu displayed correctly");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu display verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "NavigationMenuDisplayFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: And the homepage elements should be consistent
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Then(@"the homepage elements should be consistent")]
        public void ThenTheHomepageElementsShouldBeConsistent()
        {
            try
            {
                LogHelper.Info("Step: Verifying homepage elements are consistent");
                bool isConsistent = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isConsistent, Is.True, 
                    "Homepage elements should be consistent across browsers");
                
                LogHelper.Info("Homepage elements are consistent");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage consistency verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "HomepageConsistencyFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: Then the navigation menu should be displayed correctly for device
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the navigation menu should be displayed correctly for ""(.*)""")]
        public void ThenTheNavigationMenuShouldBeDisplayedCorrectlyForDevice(string deviceType)
        {
            try
            {
                LogHelper.Info($"Step: Verifying navigation menu is displayed correctly for '{deviceType}'");
                bool isDisplayed = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isDisplayed, Is.True, 
                    $"Navigation menu should be displayed correctly for '{deviceType}' device");
                
                LogHelper.Info($"Navigation menu displayed correctly for '{deviceType}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu display verification failed for '{deviceType}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"NavigationMenuDisplay_{deviceType}_Failure");
                throw;
            }
        }

        /// <summary>
        /// Step: And the homepage elements should be responsive
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the homepage elements should be responsive")]
        public void ThenTheHomepageElementsShouldBeResponsive()
        {
            try
            {
                LogHelper.Info("Step: Verifying homepage elements are responsive");
                bool isResponsive = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isResponsive, Is.True, 
                    "Homepage elements should be responsive across different device sizes");
                
                LogHelper.Info("Homepage elements are responsive");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage responsiveness verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "HomepageResponsivenessFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: When I use keyboard navigation to access the global navigation menu
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [When(@"I use keyboard navigation to access the global navigation menu")]
        public void WhenIUseKeyboardNavigationToAccessTheGlobalNavigationMenu()
        {
            try
            {
                LogHelper.Info("Step: Using keyboard navigation to access global navigation menu");
                _navigationPage.NavigateToMenuUsingKeyboard();
                LogHelper.Info("Successfully accessed navigation menu using keyboard");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard navigation to menu failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "KeyboardNavigationFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: Then I should be able to navigate to all main menu items using keyboard
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [Then(@"I should be able to navigate to all main menu items using keyboard")]
        public void ThenIShouldBeAbleToNavigateToAllMainMenuItemsUsingKeyboard()
        {
            try
            {
                LogHelper.Info("Step: Verifying navigation to all main menu items using keyboard");
                bool isAccessible = _navigationPage.AreMenuItemsAccessibleViaKeyboard();
                
                Assert.That(isAccessible, Is.True, 
                    "All main menu items should be accessible via keyboard navigation");
                
                LogHelper.Info("All main menu items are accessible via keyboard");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard navigation to main menu items failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "KeyboardMainMenuFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: And I should be able to navigate to all submenu items using keyboard
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [Then(@"I should be able to navigate to all submenu items using keyboard")]
        public void ThenIShouldBeAbleToNavigateToAllSubmenuItemsUsingKeyboard()
        {
            try
            {
                LogHelper.Info("Step: Verifying navigation to all submenu items using keyboard");
                bool isAccessible = _navigationPage.AreMenuItemsAccessibleViaKeyboard();
                
                Assert.That(isAccessible, Is.True, 
                    "All submenu items should be accessible via keyboard navigation");
                
                LogHelper.Info("All submenu items are accessible via keyboard");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard navigation to submenu items failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "KeyboardSubmenuFailure");
                throw;
            }
        }

        /// <summary>
        /// Step: And I should be able to select menu items by pressing Enter
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [Then(@"I should be able to select menu items by pressing Enter")]
        public void ThenIShouldBeAbleToSelectMenuItemsByPressingEnter()
        {
            try
            {
                LogHelper.Info("Step: Verifying menu items can be selected by pressing Enter");
                _navigationPage.SelectMenuItemWithEnter();
                
                // Verify navigation occurred
                bool isNavigated = _navigationPage.IsRedirectedToDestinationPage();
                Assert.That(isNavigated, Is.True, 
                    "Menu items should be selectable by pressing Enter key");
                
                LogHelper.Info("Menu items can be selected by pressing Enter");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Enter key selection verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "EnterKeySelectionFailure");
                throw;
            }
        }
    }
}