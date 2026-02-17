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
    /// Step definitions for Golden1 website navigation scenarios
    /// Test Cases: TASK0020445 TS-001 through TS-009
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _navigationPage = new NavigationPage(_driver);
        }

        // ================================================================
        // GIVEN STEPS - Preconditions
        // ================================================================

        /// <summary>
        /// Test Case: TASK0020445 TS-001 TC-001 Step 1
        /// Verifies browser is launched successfully
        /// </summary>
        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("[TASK0020445] Verifying browser is launched");
            try
            {
                Assert.That(_driver, Is.Not.Null, "Browser driver should be initialized");
                LogHelper.Info("Browser launched successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Browser launch verification failed: {ex.Message}");
                throw;
            }
        }

        // ================================================================
        // WHEN STEPS - Actions
        // ================================================================

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001 Step 2, TS-002 TC-001 Step 1
        /// Navigates to Golden1 homepage
        /// </summary>
        [When(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("[TASK0020445] Navigating to Golden1 homepage");
            try
            {
                _navigationPage.OpenHomePage();
                _navigationPage.HandleCookieBanner();
                LogHelper.Info("Successfully navigated to Golden1 homepage");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation to homepage failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Navigation_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-003 TC-001 Step 2
        /// Locates the global navigation menu
        /// </summary>
        [When(@"I locate the global navigation menu")]
        public void WhenILocateTheGlobalNavigationMenu()
        {
            LogHelper.Info("[TASK0020445 TS-003] Locating global navigation menu");
            try
            {
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                Assert.That(isVisible, Is.True, "Navigation menu should be visible");
                LogHelper.Info("Global navigation menu located successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to locate navigation menu: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Navigation_Menu_Not_Found");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001 Step 2, TS-006 TC-001 Step 2, TS-007 TC-001 Step 2
        /// Expands a main product menu
        /// </summary>
        [When(@"I expand the ""(.*?)"" menu")]
        public void WhenIExpandTheMenu(string menuName)
        {
            LogHelper.Info($"[TASK0020445] Expanding {menuName} menu");
            try
            {
                _navigationPage.ClickMainProductMenu(menuName);
                _scenarioContext["ExpandedMenu"] = menuName;
                LogHelper.Info($"{menuName} menu expanded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand {menuName} menu: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"{menuName}_Menu_Expand_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001 Step 4, TS-006 TC-001 Step 3, TS-007 TC-001 Step 3
        /// Selects a submenu item
        /// </summary>
        [When(@"I select the ""(.*?)"" submenu item")]
        public void WhenISelectTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"[TASK0020445] Selecting submenu item: {submenuItem}");
            try
            {
                _navigationPage.ClickSubmenuItem(submenuItem);
                _scenarioContext["SelectedSubmenu"] = submenuItem;
                LogHelper.Info($"Submenu item {submenuItem} selected successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item {submenuItem}: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"{submenuItem}_Selection_Failed");
                throw;
            }
        }

        // ================================================================
        // THEN STEPS - Assertions
        // ================================================================

        /// <summary>
        /// Test Case: TASK0020445 TS-001 TC-001 Step 2 Expected Result
        /// Verifies homepage loads successfully
        /// </summary>
        [Then(@"the Golden1 homepage should load successfully")]
        public void ThenTheGolden1HomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("[TASK0020445 TS-001] Verifying homepage loaded successfully");
            try
            {
                bool isLoaded = _navigationPage.IsHomePageLoaded();
                Assert.That(isLoaded, Is.True, "Homepage should load successfully");
                
                string currentUrl = _navigationPage.GetCurrentUrl();
                LogHelper.Info($"Homepage loaded successfully. Current URL: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Load_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-001 TC-001 Step 3 Expected Result
        /// Verifies no error messages or loading issues
        /// </summary>
        [Then(@"there should be no error messages or loading issues")]
        public void ThenThereShouldBeNoErrorMessagesOrLoadingIssues()
        {
            LogHelper.Info("[TASK0020445 TS-001] Verifying no error messages or loading issues");
            try
            {
                bool hasErrors = _navigationPage.HasErrorMessages();
                Assert.That(hasErrors, Is.False, "Page should not have error messages");
                
                bool isPageReady = _navigationPage.IsPageReady();
                Assert.That(isPageReady, Is.True, "Page should be fully loaded");
                
                LogHelper.Info("No error messages or loading issues detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Error_Check_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-002 TC-001 Step 2 Expected Result
        /// Verifies global navigation menu is visible
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top of the page")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfThePage()
        {
            LogHelper.Info("[TASK0020445 TS-002] Verifying global navigation menu visibility");
            try
            {
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top");
                
                bool isAtTop = _navigationPage.IsNavigationMenuAtTop();
                Assert.That(isAtTop, Is.True, "Navigation menu should be positioned at the top of the page");
                
                LogHelper.Info("Global navigation menu is visible at the top of the page");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu visibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Navigation_Menu_Visibility_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-003 TC-001 Step 3 Expected Result
        /// Verifies all specified menu options are present
        /// </summary>
        [Then(@"the following menu options should be present:")]
        public void ThenTheFollowingMenuOptionsShouldBePresent(Table table)
        {
            LogHelper.Info("[TASK0020445 TS-003] Verifying menu options are present");
            try
            {
                var expectedMenus = table.Rows.Select(row => row["MenuOption"]).ToList();
                LogHelper.Info($"Expected menu options: {string.Join(", ", expectedMenus)}");

                foreach (var menuOption in expectedMenus)
                {
                    bool isPresent = _navigationPage.IsTopMenuOptionPresent(menuOption);
                    Assert.That(isPresent, Is.True, $"Menu option '{menuOption}' should be present");
                    LogHelper.Info($"Menu option '{menuOption}' is present");
                }

                LogHelper.Info("All specified menu options are present");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu options verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Menu_Options_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-004 TC-001 Step 3 Expected Result
        /// Verifies main product category menus are displayed
        /// </summary>
        [Then(@"the following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            LogHelper.Info("[TASK0020445 TS-004] Verifying main product category menus");
            try
            {
                var expectedProducts = table.Rows.Select(row => row["ProductMenu"]).ToList();
                LogHelper.Info($"Expected product menus: {string.Join(", ", expectedProducts)}");

                foreach (var productMenu in expectedProducts)
                {
                    bool isDisplayed = _navigationPage.IsMainProductMenuDisplayed(productMenu);
                    Assert.That(isDisplayed, Is.True, $"Product menu '{productMenu}' should be displayed");
                    LogHelper.Info($"Product menu '{productMenu}' is displayed");
                }

                LogHelper.Info("All main product category menus are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Product_Menu_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-004 TC-001 Step 4 Expected Result
        /// Verifies each product menu is clickable and expands
        /// </summary>
        [Then(@"each product menu should be clickable and expand as expected")]
        public void ThenEachProductMenuShouldBeClickableAndExpandAsExpected()
        {
            LogHelper.Info("[TASK0020445 TS-004] Verifying product menus are clickable and expandable");
            try
            {
                var productMenus = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };

                foreach (var menu in productMenus)
                {
                    bool isClickable = _navigationPage.IsMainProductMenuClickable(menu);
                    Assert.That(isClickable, Is.True, $"Product menu '{menu}' should be clickable");
                    LogHelper.Info($"Product menu '{menu}' is clickable");
                }

                LogHelper.Info("All product menus are clickable and expand as expected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product menu clickability verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Product_Menu_Clickability_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-005 TC-001 Step 3 Expected Result
        /// Verifies submenu items are displayed
        /// </summary>
        [Then(@"submenu items should be displayed")]
        public void ThenSubmenuItemsShouldBeDisplayed()
        {
            LogHelper.Info("[TASK0020445 TS-005] Verifying submenu items are displayed");
            try
            {
                bool hasSubmenuItems = _navigationPage.HasSubmenuItems();
                Assert.That(hasSubmenuItems, Is.True, "Submenu items should be displayed after expanding menu");
                
                LogHelper.Info("Submenu items are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Submenu_Items_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-005 TC-001 Step 4 Expected Result
        /// Verifies submenu item is selectable
        /// </summary>
        [Then(@"I should be able to select the ""(.*?)"" submenu item")]
        public void ThenIShouldBeAbleToSelectTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"[TASK0020445 TS-005] Verifying {submenuItem} submenu item is selectable");
            try
            {
                bool isSelectable = _navigationPage.IsSubmenuItemSelectable(submenuItem);
                Assert.That(isSelectable, Is.True, $"Submenu item '{submenuItem}' should be selectable");
                
                LogHelper.Info($"Submenu item '{submenuItem}' is selectable");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item selectability verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"{submenuItem}_Selectability_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-006 TC-001 Step 2 Expected Result
        /// Verifies redirection to destination page
        /// </summary>
        [Then(@"I should be redirected to the Free Checking destination page")]
        public void ThenIShouldBeRedirectedToTheFreeCheckingDestinationPage()
        {
            LogHelper.Info("[TASK0020445 TS-006] Verifying redirection to Free Checking page");
            try
            {
                string currentUrl = _navigationPage.GetCurrentUrl();
                Assert.That(currentUrl, Does.Contain("checking").IgnoreCase, 
                    "Should be redirected to a checking-related page");
                
                LogHelper.Info($"Successfully redirected to destination page: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Redirection verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Redirection_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-006 TC-001 Step 3 Expected Result
        /// Verifies destination page loads without errors
        /// </summary>
        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            LogHelper.Info("[TASK0020445 TS-006] Verifying destination page loads without errors");
            try
            {
                bool isPageReady = _navigationPage.IsPageReady();
                Assert.That(isPageReady, Is.True, "Destination page should be fully loaded");
                
                bool hasErrors = _navigationPage.HasErrorMessages();
                Assert.That(hasErrors, Is.False, "Destination page should not have error messages");
                
                LogHelper.Info("Destination page loaded successfully without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Destination_Page_Load_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-007 TC-001 Step 3 Expected Result
        /// Verifies destination page URL contains expected identifier
        /// </summary>
        [Then(@"the destination page URL should contain ""(.*?)""")]
        public void ThenTheDestinationPageURLShouldContain(string expectedUrlPart)
        {
            LogHelper.Info($"[TASK0020445 TS-007] Verifying URL contains: {expectedUrlPart}");
            try
            {
                string currentUrl = _navigationPage.GetCurrentUrl();
                Assert.That(currentUrl, Does.Contain(expectedUrlPart).IgnoreCase,
                    $"URL should contain '{expectedUrlPart}'. Actual URL: {currentUrl}");
                
                LogHelper.Info($"URL verification successful. Current URL: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "URL_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-008 TC-001 Step 2 Expected Result
        /// Verifies Golden1 logo is visible
        /// </summary>
        [Then(@"the Golden1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            LogHelper.Info("[TASK0020445 TS-008] Verifying Golden1 logo visibility");
            try
            {
                bool isLogoVisible = _navigationPage.IsLogoVisible();
                Assert.That(isLogoVisible, Is.True, "Golden1 logo should be visible in the top header");
                
                LogHelper.Info("Golden1 logo is visible in the top header");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo visibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Logo_Visibility_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-009 TC-001 Step 2 Expected Result
        /// Verifies homepage displays correctly
        /// </summary>
        [Then(@"the homepage should display correctly")]
        public void ThenTheHomepageShouldDisplayCorrectly()
        {
            LogHelper.Info("[TASK0020445 TS-009] Verifying homepage displays correctly");
            try
            {
                bool isDisplayedCorrectly = _navigationPage.IsHomePageDisplayedCorrectly();
                Assert.That(isDisplayedCorrectly, Is.True, "Homepage should display correctly");
                
                LogHelper.Info("Homepage displays correctly");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage display verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Display_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-009 TC-001 Step 2 Expected Result
        /// Verifies no broken layouts
        /// </summary>
        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            LogHelper.Info("[TASK0020445 TS-009] Verifying no broken layouts");
            try
            {
                bool hasBrokenLayout = _navigationPage.HasBrokenLayout();
                Assert.That(hasBrokenLayout, Is.False, "Page should not have broken layouts");
                
                LogHelper.Info("No broken layouts detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Layout_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-009 TC-001 Step 2 Expected Result
        /// Verifies no missing content
        /// </summary>
        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            LogHelper.Info("[TASK0020445 TS-009] Verifying no missing content");
            try
            {
                bool hasMissingContent = _navigationPage.HasMissingContent();
                Assert.That(hasMissingContent, Is.False, "Page should not have missing content");
                
                LogHelper.Info("No missing content detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Content verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Content_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Case: TASK0020445 TS-009 TC-001 Step 2 Expected Result
        /// Verifies no system errors
        /// </summary>
        [Then(@"there should be no system errors")]
        public void ThenThereShouldBeNoSystemErrors()
        {
            LogHelper.Info("[TASK0020445 TS-009] Verifying no system errors");
            try
            {
                bool hasSystemErrors = _navigationPage.HasSystemErrors();
                Assert.That(hasSystemErrors, Is.False, "Page should not have system errors");
                
                LogHelper.Info("No system errors detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"System error verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "System_Error_Verification_Failed");
                throw;
            }
        }
    }
}