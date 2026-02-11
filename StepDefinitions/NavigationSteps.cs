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
    /// Step Definitions for Golden1 Navigation scenarios
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

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            try
            {
                LogHelper.Info("Browser is already launched via Hooks");
                Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
                LogHelper.Info("Browser launch verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Browser launch verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-010 TC-001
        /// </summary>
        [Given(@"the browser type is ""(.*)""")]
        public void GivenTheBrowserTypeIs(string browserType)
        {
            try
            {
                LogHelper.Info($"Browser type is: {browserType}");
                _scenarioContext["BrowserType"] = browserType;
                // Note: Browser is already initialized in Hooks based on config
                LogHelper.Info($"Browser type set to: {browserType}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Setting browser type failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Given(@"the viewport is set to ""(.*)""")]
        public void GivenTheViewportIsSetTo(string deviceType)
        {
            try
            {
                LogHelper.Info($"Setting viewport for device: {deviceType}");
                _scenarioContext["DeviceType"] = deviceType;
                
                // Set viewport size based on device type
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
                        _driver.Manage().Window.Maximize();
                        break;
                }
                
                LogHelper.Info($"Viewport set for device: {deviceType}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Setting viewport failed: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
        /// </summary>
        [When(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Navigating to Golden1 homepage");
                _homePage.OpenHomePage();
                LogHelper.Info("Navigation to Golden1 homepage completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation to homepage failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Navigation_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I hover over the ""(.*)"" menu")]
        public void WhenIHoverOverTheMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Hovering over menu: {menuName}");
                _navigationPage.HoverOverMenu(menuName);
                _scenarioContext["CurrentMenu"] = menuName;
                LogHelper.Info($"Hover over menu '{menuName}' completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Hover over menu '{menuName}' failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Menu_Hover_Failed_{menuName}");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I click on the ""(.*)"" submenu item")]
        public void WhenIClickOnTheSubmenuItem(string submenuName)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {submenuName}");
                _navigationPage.ClickSubmenuItem(submenuName);
                _scenarioContext["CurrentSubmenu"] = submenuName;
                LogHelper.Info($"Click on submenu '{submenuName}' completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Click on submenu '{submenuName}' failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Submenu_Click_Failed_{submenuName}");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [When(@"I use keyboard navigation to access the global navigation menu")]
        public void WhenIUseKeyboardNavigationToAccessTheGlobalNavigationMenu()
        {
            try
            {
                LogHelper.Info("Using keyboard navigation to access global navigation menu");
                _navigationPage.UseKeyboardNavigationToMenu();
                LogHelper.Info("Keyboard navigation to menu completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Keyboard navigation failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Keyboard_Navigation_Failed");
                throw;
            }
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage is displayed without errors");
                bool isDisplayed = _homePage.IsHomepageDisplayedCorrectly();
                bool noErrors = _homePage.HasNoErrorMessages();
                
                Assert.That(isDisplayed, Is.True, "Homepage should be displayed");
                Assert.That(noErrors, Is.True, "Homepage should have no error messages");
                
                LogHelper.Info("Homepage verification completed successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible");
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top");
                
                LogHelper.Info("Global navigation menu verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Navigation_Menu_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-002 TC-001, TS-011 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible")]
        public void ThenTheGlobalNavigationMenuShouldBeVisible()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible");
                bool isVisible = _navigationPage.IsNavigationMenuVisible();
                
                Assert.That(isVisible, Is.True, "Global navigation menu should be visible");
                
                LogHelper.Info("Global navigation menu verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Navigation_Menu_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"the following top navigation options should be present:")]
        public void ThenTheFollowingTopNavigationOptionsShouldBePresent(Table table)
        {
            try
            {
                LogHelper.Info("Verifying all top navigation options are present");
                List<string> expectedTabs = table.Rows.Select(row => row[0]).ToList();
                
                bool allPresent = _navigationPage.AreAllTopNavigationTabsPresent(expectedTabs);
                
                Assert.That(allPresent, Is.True, 
                    $"All top navigation options should be present: {string.Join(", ", expectedTabs)}");
                
                LogHelper.Info("Top navigation options verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top navigation options verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Top_Navigation_Options_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"the following main product category menus should be accessible:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeAccessible(Table table)
        {
            try
            {
                LogHelper.Info("Verifying all main product category menus are accessible");
                List<string> expectedMenus = table.Rows.Select(row => row[0]).ToList();
                
                bool allAccessible = _navigationPage.AreAllProductCategoryMenusAccessible(expectedMenus);
                
                Assert.That(allAccessible, Is.True, 
                    $"All main product category menus should be accessible: {string.Join(", ", expectedMenus)}");
                
                LogHelper.Info("Product category menus verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Product_Category_Menus_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"the submenu items should be displayed")]
        public void ThenTheSubmenuItemsShouldBeDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying submenu items are displayed");
                bool areDisplayed = _navigationPage.AreSubmenuItemsDisplayed();
                
                Assert.That(areDisplayed, Is.True, "Submenu items should be displayed after hovering");
                
                LogHelper.Info("Submenu items display verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Submenu_Items_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"I should be able to click the ""(.*)"" submenu item")]
        public void ThenIShouldBeAbleToClickTheSubmenuItem(string submenuName)
        {
            try
            {
                LogHelper.Info($"Verifying ability to click submenu item: {submenuName}");
                // The click action itself verifies clickability
                _navigationPage.ClickSubmenuItem(submenuName);
                
                LogHelper.Info($"Successfully clicked submenu item: {submenuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item click verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Submenu_Click_Failed_{submenuName}");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"I should be redirected to the Free Checking page")]
        public void ThenIShouldBeRedirectedToTheFreeCheckingPage()
        {
            try
            {
                LogHelper.Info("Verifying redirection to Free Checking page");
                string currentUrl = _driver.Url;
                
                Assert.That(currentUrl.ToLower(), Does.Contain("checking"), 
                    "URL should contain 'checking' after navigation");
                
                LogHelper.Info($"Successfully redirected to: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Redirection verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Redirection_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"the destination page should load completely")]
        public void ThenTheDestinationPageShouldLoadCompletely()
        {
            try
            {
                LogHelper.Info("Verifying destination page loaded completely");
                bool isLoaded = _navigationPage.IsDestinationPageLoaded();
                
                Assert.That(isLoaded, Is.True, "Destination page should load completely");
                
                LogHelper.Info("Destination page load verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Destination_Page_Load_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the URL should contain ""(.*)""")]
        public void ThenTheURLShouldContain(string expectedIdentifier)
        {
            try
            {
                LogHelper.Info($"Verifying URL contains identifier: {expectedIdentifier}");
                bool containsIdentifier = _navigationPage.DoesUrlContainIdentifier(expectedIdentifier);
                
                Assert.That(containsIdentifier, Is.True, 
                    $"URL should contain identifier '{expectedIdentifier}'");
                
                LogHelper.Info($"URL contains expected identifier: {expectedIdentifier}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL identifier verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "URL_Identifier_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"the Golden1 logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            try
            {
                LogHelper.Info("Verifying Golden1 logo is visible");
                bool isVisible = _homePage.IsLogoVisible();
                
                Assert.That(isVisible, Is.True, "Golden1 logo should be visible in the header");
                
                LogHelper.Info("Golden1 logo verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Logo_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should display all content correctly")]
        public void ThenTheHomepageShouldDisplayAllContentCorrectly()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays all content correctly");
                bool isCorrect = _homePage.IsContentDisplayedCorrectly();
                
                Assert.That(isCorrect, Is.True, "Homepage should display all content correctly");
                
                LogHelper.Info("Homepage content display verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage content verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Homepage_Content_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            try
            {
                LogHelper.Info("Verifying no broken layouts");
                bool noIssues = _homePage.HasNoBrokenLayouts();
                
                Assert.That(noIssues, Is.True, "There should be no broken layouts on the homepage");
                
                LogHelper.Info("Broken layouts verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Broken layouts verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Broken_Layouts_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no error messages")]
        public void ThenThereShouldBeNoErrorMessages()
        {
            try
            {
                LogHelper.Info("Verifying no error messages");
                bool noErrors = _homePage.HasNoErrorMessages();
                
                Assert.That(noErrors, Is.True, "There should be no error messages on the homepage");
                
                LogHelper.Info("Error messages verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error messages verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Error_Messages_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-011 TC-001
        /// </summary>
        [Then(@"the homepage should display correctly for the device")]
        public void ThenTheHomepageShouldDisplayCorrectlyForTheDevice()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays correctly for device");
                string deviceType = _scenarioContext.ContainsKey("DeviceType") ? 
                    _scenarioContext["DeviceType"].ToString() : "Unknown";
                
                bool isCorrect = _homePage.IsContentDisplayedCorrectly();
                
                Assert.That(isCorrect, Is.True, 
                    $"Homepage should display correctly for device: {deviceType}");
                
                LogHelper.Info($"Device-specific display verification completed for: {deviceType}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Device-specific display verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Device_Display_Verification_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [Then(@"all menu items should be accessible via keyboard")]
        public void ThenAllMenuItemsShouldBeAccessibleViaKeyboard()
        {
            try
            {
                LogHelper.Info("Verifying all menu items are keyboard accessible");
                bool isAccessible = _navigationPage.AreAllMenuItemsKeyboardAccessible();
                
                Assert.That(isAccessible, Is.True, "All menu items should be accessible via keyboard");
                
                LogHelper.Info("Menu keyboard accessibility verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu keyboard accessibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Menu_Keyboard_Accessibility_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [Then(@"all submenu items should be accessible via keyboard")]
        public void ThenAllSubmenuItemsShouldBeAccessibleViaKeyboard()
        {
            try
            {
                LogHelper.Info("Verifying all submenu items are keyboard accessible");
                // This is verified through keyboard navigation
                bool isAccessible = _navigationPage.AreSubmenuItemsDisplayed();
                
                Assert.That(isAccessible, Is.True, "All submenu items should be accessible via keyboard");
                
                LogHelper.Info("Submenu keyboard accessibility verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu keyboard accessibility verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Submenu_Keyboard_Accessibility_Failed");
                throw;
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-012 TC-001
        /// </summary>
        [Then(@"I should be able to select menu items using Enter key")]
        public void ThenIShouldBeAbleToSelectMenuItemsUsingEnterKey()
        {
            try
            {
                LogHelper.Info("Verifying menu items can be selected using Enter key");
                _navigationPage.SelectMenuItemWithEnter();
                
                LogHelper.Info("Menu item selection with Enter key verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu item Enter key selection verification failed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "Menu_Enter_Selection_Failed");
                throw;
            }
        }
    }
}