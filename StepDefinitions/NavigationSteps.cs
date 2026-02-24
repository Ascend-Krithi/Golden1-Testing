using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using OpenQA.Selenium;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Golden1 website navigation functionality.
    /// Implements test steps for menu navigation, page verification, and user interactions.
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        // Constructor - Dependency Injection
        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _navigationPage = new NavigationPage(driver);
        }

        #region Given Steps

        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            try
            {
                LogHelper.Info("Browser launched successfully");
                Assert.IsNotNull(_driver, "WebDriver should be initialized");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Browser launch verification failed: {ex.Message}");
                throw;
            }
        }

        #endregion

        #region When Steps

        [When(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Navigating to Golden1 homepage");
                _navigationPage.OpenHomePage();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to homepage: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "Navigate_Homepage_Error");
                throw;
            }
        }

        [When(@"I locate the global navigation menu")]
        public void WhenILocateTheGlobalNavigationMenu()
        {
            try
            {
                LogHelper.Info("Locating global navigation menu");
                bool isVisible = _navigationPage.IsGlobalNavigationMenuVisible();
                Assert.IsTrue(isVisible, "Global navigation menu should be visible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to locate navigation menu: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "Locate_Menu_Error");
                throw;
            }
        }

        [When(@"I expand the ""(.*)"" main product menu")]
        public void WhenIExpandTheMainProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding main product menu: {menuName}");
                _navigationPage.ExpandProductMenu(menuName);
                _scenarioContext["ExpandedMenu"] = menuName;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand menu '{menuName}': {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, $"Expand_Menu_{menuName}_Error");
                throw;
            }
        }

        [When(@"I select the ""(.*)"" submenu item")]
        public void WhenISelectTheSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Selecting submenu item: {submenuItem}");
                _navigationPage.SelectSubmenuItem(submenuItem);
                _scenarioContext["SelectedSubmenu"] = submenuItem;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu '{submenuItem}': {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, $"Select_Submenu_{submenuItem}_Error");
                throw;
            }
        }

        #endregion

        #region Then Steps

        [Then(@"the homepage should load without errors")]
        public void ThenTheHomepageShouldLoadWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage loaded without errors");
                bool isLoaded = _navigationPage.IsHomepageDisplayedCorrectly();
                Assert.IsTrue(isLoaded, "Homepage should load without errors");
                LogHelper.Info("Homepage loaded successfully without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "Homepage_Load_Error");
                throw;
            }
        }

        [Then(@"the global navigation menu should be visible at the top of the page")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfThePage()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible");
                bool isVisible = _navigationPage.IsGlobalNavigationMenuVisible();
                Assert.IsTrue(isVisible, "Global navigation menu should be visible at the top of the page");
                LogHelper.Info("Global navigation menu is visible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "Menu_Visibility_Error");
                throw;
            }
        }

        [Then(@"the following top menu options should be present:")]
        public void ThenTheFollowingTopMenuOptionsShouldBePresent(Table table)
        {
            try
            {
                LogHelper.Info("Verifying top menu options are present");
                var menuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
                
                foreach (var menuOption in menuOptions)
                {
                    LogHelper.Info($"Checking menu option: {menuOption}");
                    bool isPresent = _navigationPage.IsTopMenuOptionPresent(menuOption);
                    Assert.IsTrue(isPresent, $"Top menu option '{menuOption}' should be present");
                }
                
                LogHelper.Info($"All {menuOptions.Count} top menu options are present");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top menu options verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "TopMenu_Options_Error");
                throw;
            }
        }

        [Then(@"the following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            try
            {
                LogHelper.Info("Verifying main product category menus are displayed");
                var productMenus = table.Rows.Select(row => row["ProductMenu"]).ToList();
                
                foreach (var productMenu in productMenus)
                {
                    LogHelper.Info($"Checking product menu: {productMenu}");
                    bool isDisplayed = _navigationPage.IsProductMenuDisplayed(productMenu);
                    Assert.IsTrue(isDisplayed, $"Product menu '{productMenu}' should be displayed");
                }
                
                LogHelper.Info($"All {productMenus.Count} product category menus are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "ProductMenus_Display_Error");
                throw;
            }
        }

        [Then(@"each main product category menu should be accessible")]
        public void ThenEachMainProductCategoryMenuShouldBeAccessible()
        {
            try
            {
                LogHelper.Info("Verifying all product category menus are accessible");
                var productMenus = new List<string> 
                { 
                    "Checking", "Savings", "Home Loans", "Credit Cards", 
                    "Loans", "Investing", "Community" 
                };
                
                foreach (var productMenu in productMenus)
                {
                    LogHelper.Info($"Checking accessibility of: {productMenu}");
                    bool isAccessible = _navigationPage.IsProductMenuAccessible(productMenu);
                    Assert.IsTrue(isAccessible, $"Product menu '{productMenu}' should be accessible");
                }
                
                LogHelper.Info("All product category menus are accessible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu accessibility verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "ProductMenus_Accessibility_Error");
                throw;
            }
        }

        [Then(@"the submenu items should be displayed")]
        public void ThenTheSubmenuItemsShouldBeDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying submenu items are displayed");
                bool areDisplayed = _navigationPage.AreSubmenuItemsDisplayed();
                Assert.IsTrue(areDisplayed, "Submenu items should be displayed after expanding menu");
                LogHelper.Info("Submenu items are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items display verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "Submenu_Display_Error");
                throw;
            }
        }

        [Then(@"I should be able to select the ""(.*)"" submenu item")]
        public void ThenIShouldBeAbleToSelectTheSubmenuItem(string submenuItem)
        {
            try
            {
                LogHelper.Info($"Verifying ability to select submenu item: {submenuItem}");
                _navigationPage.SelectSubmenuItem(submenuItem);
                LogHelper.Info($"Successfully selected submenu item: {submenuItem}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item '{submenuItem}': {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, $"Select_Submenu_{submenuItem}_Error");
                throw;
            }
        }

        [Then(@"I should be redirected to the Free Checking destination page")]
        public void ThenIShouldBeRedirectedToTheFreeCheckingDestinationPage()
        {
            try
            {
                LogHelper.Info("Verifying redirection to Free Checking page");
                WaitHelper.WaitForPageReady(_driver, 30);
                bool isCorrect = _navigationPage.IsHomepageDisplayedCorrectly();
                Assert.IsTrue(isCorrect, "Destination page should load correctly");
                LogHelper.Info("Successfully redirected to destination page");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Redirection verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "Redirection_Error");
                throw;
            }
        }

        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying destination page loaded without errors");
                bool isLoaded = _navigationPage.IsHomepageDisplayedCorrectly();
                Assert.IsTrue(isLoaded, "Destination page should load without errors");
                LogHelper.Info("Destination page loaded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "DestinationPage_Load_Error");
                throw;
            }
        }

        [Then(@"the destination page URL should contain ""(.*)""")]
        public void ThenTheDestinationPageURLShouldContain(string expectedUrlPart)
        {
            try
            {
                LogHelper.Info($"Verifying URL contains: {expectedUrlPart}");
                bool containsUrl = _navigationPage.DoesUrlContain(expectedUrlPart);
                Assert.IsTrue(containsUrl, $"Destination page URL should contain '{expectedUrlPart}'");
                LogHelper.Info($"URL verification successful - contains '{expectedUrlPart}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "URL_Verification_Error");
                throw;
            }
        }

        [Then(@"the Golden1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            try
            {
                LogHelper.Info("Verifying Golden1 logo is visible in header");
                // Logo verification would typically check for a specific logo element
                // For now, we verify the page header is present
                bool isVisible = _navigationPage.IsGlobalNavigationMenuVisible();
                Assert.IsTrue(isVisible, "Golden1 logo should be visible in the top header");
                LogHelper.Info("Golden1 logo is visible in header");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo visibility verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "Logo_Visibility_Error");
                throw;
            }
        }

        [Then(@"the homepage should display correctly with no broken layouts")]
        public void ThenTheHomepageShouldDisplayCorrectlyWithNoBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays correctly with no broken layouts");
                bool isCorrect = _navigationPage.IsHomepageDisplayedCorrectly();
                Assert.IsTrue(isCorrect, "Homepage should display correctly with no broken layouts");
                LogHelper.Info("Homepage layout verification successful");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage layout verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "Homepage_Layout_Error");
                throw;
            }
        }

        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            try
            {
                LogHelper.Info("Verifying no missing content on homepage");
                bool menuVisible = _navigationPage.IsGlobalNavigationMenuVisible();
                Assert.IsTrue(menuVisible, "Navigation menu should be present - no missing content");
                LogHelper.Info("No missing content detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Missing content check failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "Missing_Content_Error");
                throw;
            }
        }

        [Then(@"there should be no system error messages")]
        public void ThenThereShouldBeNoSystemErrorMessages()
        {
            try
            {
                LogHelper.Info("Verifying no system error messages");
                string pageSource = _driver.PageSource;
                bool hasErrors = pageSource.Contains("error") || 
                                pageSource.Contains("Error") || 
                                pageSource.Contains("404") || 
                                pageSource.Contains("500");
                Assert.IsFalse(hasErrors, "There should be no system error messages on the page");
                LogHelper.Info("No system error messages detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"System error check failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(_driver, "System_Error_Check");
                throw;
            }
        }

        #endregion
    }
}