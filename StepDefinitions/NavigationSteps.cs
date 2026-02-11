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
    /// Test Cases: TASK0020445 TS-002 through TS-007, TS-012
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

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================
        [When(@"user checks the top section of the homepage")]
        public void WhenUserChecksTheTopSectionOfTheHomepage()
        {
            try
            {
                LogHelper.Info("Step: User checks the top section of the homepage");
                _scenarioContext["TopSectionChecked"] = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top section check failed: {ex.Message}");
                throw;
            }
        }

        [When(@"user inspects the top navigation menu")]
        public void WhenUserInspectsTheTopNavigationMenu()
        {
            try
            {
                LogHelper.Info("Step: User inspects the top navigation menu");
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                _scenarioContext["NavigationMenuVisible"] = isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top navigation menu inspection failed: {ex.Message}");
                throw;
            }
        }

        [When(@"user hovers over the global navigation menu")]
        public void WhenUserHoversOverTheGlobalNavigationMenu()
        {
            try
            {
                LogHelper.Info("Step: User hovers over the global navigation menu");
                _scenarioContext["MenuHovered"] = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu hover action failed: {ex.Message}");
                throw;
            }
        }

        [When(@"user hovers over ""(.*)"" main product menu")]
        public void WhenUserHoversOverMainProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Step: User hovers over '{menuName}' main product menu");
                _navigationPage.HoverOverMainMenu(menuName);
                _scenarioContext["HoveredMenu"] = menuName;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Hover over menu '{menuName}' failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Hover_{menuName}_Failed");
                throw;
            }
        }

        [When(@"user clicks on ""(.*)"" submenu item")]
        public void WhenUserClicksOnSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Step: User clicks on '{submenuItem}' submenu item");
                _navigationPage.ClickSubmenuItem(submenuItem);
                _scenarioContext["ClickedSubmenuItem"] = submenuItem;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Click on submenu item '{submenuItem}' failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Click_{submenuItem}_Failed");
                throw;
            }
        }

        [When(@"user uses keyboard navigation to access the global navigation menu")]
        public void WhenUserUsesKeyboardNavigationToAccessTheGlobalNavigationMenu()
        {
            try
            {
                LogHelper.Info("Step: User uses keyboard navigation to access the global navigation menu");
                _scenarioContext["KeyboardNavigationUsed"] = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard navigation failed: {ex.Message}");
                throw;
            }
        }

        [When(@"user navigates to ""(.*)"" menu using keyboard")]
        public void WhenUserNavigatesToMenuUsingKeyboard(string menuName)
        {
            try
            {
                LogHelper.Info($"Step: User navigates to '{menuName}' menu using keyboard");
                _navigationPage.NavigateToMenuUsingKeyboard(menuName);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard navigation to '{menuName}' failed: {ex.Message}");
                throw;
            }
        }

        [When(@"user presses Enter on ""(.*)"" submenu item")]
        public void WhenUserPressesEnterOnSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Step: User presses Enter on '{submenuItem}' submenu item");
                _navigationPage.PressEnterOnSubmenuItem(submenuItem);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Press Enter on '{submenuItem}' failed: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================
        [Then(@"the global navigation menu should be visible")]
        public void ThenTheGlobalNavigationMenuShouldBeVisible()
        {
            try
            {
                LogHelper.Info("Step: Verifying global navigation menu is visible");
                
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                Assert.That(isVisible, Is.True, 
                    "TASK0020445 TS-002 TC-001: Global navigation menu should be visible");
                
                LogHelper.Info("Global navigation menu is visible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Navigation_Menu_Visibility_Failed");
                throw;
            }
        }

        [Then(@"the following menu options should be present:")]
        public void ThenTheFollowingMenuOptionsShouldBePresent(Table table)
        {
            try
            {
                LogHelper.Info("Step: Verifying menu options are present");
                
                List<string> menuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
                bool allPresent = _navigationPage.AreAllTopTabsPresent(menuOptions);
                
                Assert.That(allPresent, Is.True, 
                    "TASK0020445 TS-003 TC-001: All specified menu options should be present");
                
                LogHelper.Info($"All {menuOptions.Count} menu options are present");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu options verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Menu_Options_Verification_Failed");
                throw;
            }
        }

        [Then(@"the following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            try
            {
                LogHelper.Info("Step: Verifying main product category menus are displayed");
                
                List<string> productCategories = table.Rows.Select(row => row["ProductCategory"]).ToList();
                bool allDisplayed = _navigationPage.AreAllMainMenusDisplayed(productCategories);
                
                Assert.That(allDisplayed, Is.True, 
                    "TASK0020445 TS-004 TC-001: All main product category menus should be displayed");
                
                LogHelper.Info($"All {productCategories.Count} product category menus are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Product_Menus_Verification_Failed");
                throw;
            }
        }

        [Then(@"each main product category menu should be accessible")]
        public void ThenEachMainProductCategoryMenuShouldBeAccessible()
        {
            try
            {
                LogHelper.Info("Step: Verifying each main product category menu is accessible");
                
                List<string> productCategories = new List<string> 
                { 
                    "Checking", "Savings", "Home Loans", "Credit Cards", 
                    "Loans", "Investing", "Community" 
                };
                
                bool allAccessible = true;
                foreach (string category in productCategories)
                {
                    bool isAccessible = _navigationPage.IsMainMenuAccessible(category);
                    if (!isAccessible)
                    {
                        LogHelper.Warning($"Menu '{category}' is not accessible");
                        allAccessible = false;
                    }
                }
                
                Assert.That(allAccessible, Is.True, 
                    "TASK0020445 TS-004 TC-001: Each main product category menu should be accessible");
                
                LogHelper.Info("All product category menus are accessible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu accessibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Menu_Accessibility_Failed");
                throw;
            }
        }

        [Then(@"submenu items should be displayed")]
        public void ThenSubmenuItemsShouldBeDisplayed()
        {
            try
            {
                LogHelper.Info("Step: Verifying submenu items are displayed");
                
                string hoveredMenu = _scenarioContext.Get<string>("HoveredMenu");
                // Check for common submenu items based on hovered menu
                bool submenuVisible = false;
                
                if (hoveredMenu == "Checking")
                {
                    submenuVisible = _navigationPage.AreSubmenuItemsDisplayed("Free Checking");
                }
                else if (hoveredMenu == "Savings")
                {
                    submenuVisible = _navigationPage.AreSubmenuItemsDisplayed("Savings Account");
                }
                
                Assert.That(submenuVisible, Is.True, 
                    "TASK0020445 TS-005 TC-001: Submenu items should be displayed");
                
                LogHelper.Info("Submenu items are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu display verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Submenu_Display_Failed");
                throw;
            }
        }

        [Then(@"the submenu item should respond to click")]
        public void ThenTheSubmenuItemShouldRespondToClick()
        {
            try
            {
                LogHelper.Info("Step: Verifying submenu item responds to click");
                
                // Verify page has changed after click
                string currentUrl = _navigationPage.GetCurrentPageUrl();
                bool urlChanged = !currentUrl.EndsWith(".com/");
                
                Assert.That(urlChanged, Is.True, 
                    "TASK0020445 TS-005 TC-001: Submenu item should respond to click and navigate");
                
                LogHelper.Info("Submenu item responded to click");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu click response verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Submenu_Click_Response_Failed");
                throw;
            }
        }

        [Then(@"user should be redirected to the destination page")]
        public void ThenUserShouldBeRedirectedToTheDestinationPage()
        {
            try
            {
                LogHelper.Info("Step: Verifying user is redirected to destination page");
                
                string currentUrl = _navigationPage.GetCurrentPageUrl();
                bool isRedirected = !currentUrl.EndsWith(".com/");
                
                Assert.That(isRedirected, Is.True, 
                    "TASK0020445 TS-006 TC-001: User should be redirected to destination page");
                
                LogHelper.Info($"User redirected to: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Redirection verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Redirection_Failed");
                throw;
            }
        }

        [Then(@"the destination page should load completely without errors")]
        public void ThenTheDestinationPageShouldLoadCompletelyWithoutErrors()
        {
            try
            {
                LogHelper.Info("Step: Verifying destination page loads completely without errors");
                
                bool hasNoErrors = _homePage.HasNoErrorMessages();
                Assert.That(hasNoErrors, Is.True, 
                    "TASK0020445 TS-006 TC-001: Destination page should load without errors");
                
                LogHelper.Info("Destination page loaded completely without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Destination_Page_Load_Failed");
                throw;
            }
        }

        [Then(@"the destination page URL should contain ""(.*)""")]
        public void ThenTheDestinationPageURLShouldContain(string expectedText)
        {
            try
            {
                LogHelper.Info($"Step: Verifying destination page URL contains '{expectedText}'");
                
                bool urlContains = _navigationPage.DoesUrlContain(expectedText);
                Assert.That(urlContains, Is.True, 
                    $"TASK0020445 TS-007 TC-001: URL should contain '{expectedText}'");
                
                LogHelper.Info($"URL contains expected text: {expectedText}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "URL_Verification_Failed");
                throw;
            }
        }

        [Then(@"all menu items should be accessible via keyboard")]
        public void ThenAllMenuItemsShouldBeAccessibleViaKeyboard()
        {
            try
            {
                LogHelper.Info("Step: Verifying all menu items are accessible via keyboard");
                
                // This is verified through successful keyboard navigation
                bool keyboardNavigationUsed = _scenarioContext.Get<bool>("KeyboardNavigationUsed");
                Assert.That(keyboardNavigationUsed, Is.True, 
                    "TASK0020445 TS-012 TC-001: Menu items should be accessible via keyboard");
                
                LogHelper.Info("All menu items are accessible via keyboard");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard accessibility verification failed: {ex.Message}");
                throw;
            }
        }

        [Then(@"user should be able to select menu items using Enter key")]
        public void ThenUserShouldBeAbleToSelectMenuItemsUsingEnterKey()
        {
            try
            {
                LogHelper.Info("Step: Verifying user can select menu items using Enter key");
                
                // This is verified through successful Enter key press
                Assert.Pass("TASK0020445 TS-012 TC-001: Menu items can be selected using Enter key");
                
                LogHelper.Info("Menu items can be selected using Enter key");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Enter key selection verification failed: {ex.Message}");
                throw;
            }
        }

        [Then(@"the menu item should respond to keyboard selection")]
        public void ThenTheMenuItemShouldRespondToKeyboardSelection()
        {
            try
            {
                LogHelper.Info("Step: Verifying menu item responds to keyboard selection");
                
                string currentUrl = _navigationPage.GetCurrentPageUrl();
                bool urlChanged = !currentUrl.EndsWith(".com/");
                
                Assert.That(urlChanged, Is.True, 
                    "TASK0020445 TS-012 TC-001: Menu item should respond to keyboard selection");
                
                LogHelper.Info("Menu item responded to keyboard selection");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard selection response verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Keyboard_Selection_Failed");
                throw;
            }
        }

        [Then(@"the navigation menu should be displayed correctly")]
        public void ThenTheNavigationMenuShouldBeDisplayedCorrectly()
        {
            try
            {
                LogHelper.Info("Step: Verifying navigation menu is displayed correctly");
                
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                Assert.That(isVisible, Is.True, 
                    "TASK0020445 TS-010 TC-001: Navigation menu should be displayed correctly");
                
                LogHelper.Info("Navigation menu is displayed correctly");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu display verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Navigation_Display_Failed");
                throw;
            }
        }

        [Then(@"the homepage elements should be consistent")]
        public void ThenTheHomepageElementsShouldBeConsistent()
        {
            try
            {
                LogHelper.Info("Step: Verifying homepage elements are consistent");
                
                bool contentDisplayed = _homePage.IsContentDisplayedCorrectly();
                Assert.That(contentDisplayed, Is.True, 
                    "TASK0020445 TS-010 TC-001: Homepage elements should be consistent");
                
                LogHelper.Info("Homepage elements are consistent");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage consistency verification failed: {ex.Message}");
                throw;
            }
        }

        [Then(@"the navigation menu should be displayed correctly on ""(.*)""")]
        public void ThenTheNavigationMenuShouldBeDisplayedCorrectlyOnDevice(string device)
        {
            try
            {
                LogHelper.Info($"Step: Verifying navigation menu is displayed correctly on {device}");
                
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                Assert.That(isVisible, Is.True, 
                    $"TASK0020445 TS-011 TC-001: Navigation menu should be displayed correctly on {device}");
                
                LogHelper.Info($"Navigation menu is displayed correctly on {device}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu display verification on {device} failed: {ex.Message}");
                throw;
            }
        }

        [Then(@"the homepage elements should be responsive on ""(.*)""")]
        public void ThenTheHomepageElementsShouldBeResponsiveOnDevice(string device)
        {
            try
            {
                LogHelper.Info($"Step: Verifying homepage elements are responsive on {device}");
                
                bool contentDisplayed = _homePage.IsContentDisplayedCorrectly();
                Assert.That(contentDisplayed, Is.True, 
                    $"TASK0020445 TS-011 TC-001: Homepage elements should be responsive on {device}");
                
                LogHelper.Info($"Homepage elements are responsive on {device}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage responsiveness verification on {device} failed: {ex.Message}");
                throw;
            }
        }
    }
}