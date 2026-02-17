using System;
using System.Collections.Generic;
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
        /// Launch the browser
        /// Test Cases: All TASK0020445 test cases
        /// </summary>
        [Given(@"I launch the browser")]
        public void GivenILaunchTheBrowser()
        {
            try
            {
                LogHelper.Info("Browser launched successfully");
                Assert.That(_driver, Is.Not.Null, "WebDriver should be initialized");
                LogHelper.Info("Browser verification completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to launch browser: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        /// <summary>
        /// Navigate to Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001, TS-002 TC-001, TS-003 TC-001
        /// </summary>
        [When(@"I navigate to Golden1 homepage")]
        public void WhenINavigateToGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Navigating to Golden1 homepage");
                _homePage.OpenHomePage();
                LogHelper.Info("Successfully navigated to Golden1 homepage");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to Golden1 homepage: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Expand a product category menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I expand the ""(.*)"" menu")]
        public void WhenIExpandTheMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding menu: {menuName}");
                _homePage.ExpandProductCategoryMenu(menuName);
                _scenarioContext["ExpandedMenu"] = menuName;
                LogHelper.Info($"Successfully expanded menu: {menuName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Click on a submenu item
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I click on ""(.*)"" submenu item")]
        public void WhenIClickOnSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Clicking submenu item: {submenuItemName}");
                _homePage.ClickSubmenuItem(submenuItemName);
                _scenarioContext["ClickedSubmenuItem"] = submenuItemName;
                LogHelper.Info($"Successfully clicked submenu item: {submenuItemName}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click submenu item '{submenuItemName}': {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================

        /// <summary>
        /// Verify homepage loads successfully without errors
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the homepage should load successfully without errors")]
        public void ThenTheHomepageShouldLoadSuccessfullyWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage loaded successfully");
                
                bool isLoaded = _homePage.IsHomePageLoaded();
                Assert.That(isLoaded, Is.True, "Homepage should load successfully");
                
                bool hasNoErrors = _homePage.HasNoErrorMessages();
                Assert.That(hasNoErrors, Is.True, "Homepage should not display any error messages");
                
                LogHelper.Info("Homepage loaded successfully without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify global navigation menu is visible at the top
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            try
            {
                LogHelper.Info("Verifying global navigation menu is visible");
                
                bool isVisible = _homePage.IsNavigationMenuVisible();
                Assert.That(isVisible, Is.True, "Global navigation menu should be visible at the top of the page");
                
                LogHelper.Info("Global navigation menu is visible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation menu verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify all top menu options are present
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"the navigation menu should display all top menu options")]
        public void ThenTheNavigationMenuShouldDisplayAllTopMenuOptions(Table table)
        {
            try
            {
                LogHelper.Info("Verifying all top menu options are present");
                
                bool topTabsVisible = _homePage.IsTopTabsContainerVisible();
                Assert.That(topTabsVisible, Is.True, "Top tabs container should be visible");
                
                var menuOptions = table.CreateSet<MenuOptionData>();
                foreach (var option in menuOptions)
                {
                    LogHelper.Info($"Checking menu option: {option.MenuOption}");
                    bool isPresent = _homePage.IsTopMenuTabPresent(option.MenuOption);
                    Assert.That(isPresent, Is.True, $"Menu option '{option.MenuOption}' should be present");
                }
                
                LogHelper.Info("All top menu options are present");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Top menu options verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify all main product category menus are displayed
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"all main product category menus should be displayed")]
        public void ThenAllMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            try
            {
                LogHelper.Info("Verifying all main product category menus are displayed");
                
                var productCategories = table.CreateSet<ProductCategoryData>();
                foreach (var category in productCategories)
                {
                    LogHelper.Info($"Checking product category: {category.ProductCategory}");
                    bool isDisplayed = _homePage.IsProductCategoryMenuDisplayed(category.ProductCategory);
                    Assert.That(isDisplayed, Is.True, $"Product category menu '{category.ProductCategory}' should be displayed");
                }
                
                LogHelper.Info("All main product category menus are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify each product category menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"each product category menu should be clickable")]
        public void ThenEachProductCategoryMenuShouldBeClickable()
        {
            try
            {
                LogHelper.Info("Verifying each product category menu is clickable");
                
                var categories = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
                
                foreach (var category in categories)
                {
                    LogHelper.Info($"Checking if category '{category}' is clickable");
                    bool isClickable = _homePage.IsProductCategoryMenuClickable(category);
                    Assert.That(isClickable, Is.True, $"Product category menu '{category}' should be clickable");
                }
                
                LogHelper.Info("All product category menus are clickable");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menu clickability verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"submenu items should be displayed")]
        public void ThenSubmenuItemsShouldBeDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying submenu items are displayed");
                
                bool areDisplayed = _homePage.AreSubmenuItemsDisplayed();
                Assert.That(areDisplayed, Is.True, "Submenu items should be displayed after expanding menu");
                
                LogHelper.Info("Submenu items are displayed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify submenu item is selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"I should be able to select ""(.*)"" submenu item")]
        public void ThenIShouldBeAbleToSelectSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Verifying submenu item '{submenuItemName}' is selectable");
                
                bool isSelectable = _homePage.IsSubmenuItemSelectable(submenuItemName);
                Assert.That(isSelectable, Is.True, $"Submenu item '{submenuItemName}' should be selectable");
                
                LogHelper.Info($"Submenu item '{submenuItemName}' is selectable");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item selectability verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify redirection to destination page
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"I should be redirected to the Free Checking page")]
        public void ThenIShouldBeRedirectedToTheFreeCheckingPage()
        {
            try
            {
                LogHelper.Info("Verifying redirection to Free Checking page");
                
                string currentUrl = _homePage.GetCurrentPageUrl();
                Assert.That(currentUrl, Does.Contain("checking").IgnoreCase, "URL should contain 'checking' indicating navigation to Checking section");
                
                LogHelper.Info("Successfully redirected to Free Checking page");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Redirection verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify destination page loads without errors
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying destination page loaded without errors");
                
                bool hasNoErrors = _homePage.HasNoErrorMessages();
                Assert.That(hasNoErrors, Is.True, "Destination page should not display any error messages");
                
                LogHelper.Info("Destination page loaded without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the page URL should contain ""(.*)""")]
        public void ThenThePageURLShouldContain(string expectedIdentifier)
        {
            try
            {
                LogHelper.Info($"Verifying URL contains '{expectedIdentifier}'");
                
                bool containsIdentifier = _homePage.DoesUrlContain(expectedIdentifier);
                Assert.That(containsIdentifier, Is.True, $"URL should contain '{expectedIdentifier}'");
                
                string currentUrl = _homePage.GetCurrentPageUrl();
                LogHelper.Info($"Current URL: {currentUrl}");
                LogHelper.Info($"URL contains expected identifier '{expectedIdentifier}'");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify Golden1 logo is visible in header
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
                
                LogHelper.Info("Golden1 logo is visible in the header");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify homepage displays without layout issues
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should display without layout issues")]
        public void ThenTheHomepageShouldDisplayWithoutLayoutIssues()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays without layout issues");
                
                bool isLoaded = _homePage.IsHomePageLoaded();
                Assert.That(isLoaded, Is.True, "Homepage should be properly loaded");
                
                bool isMenuVisible = _homePage.IsNavigationMenuVisible();
                Assert.That(isMenuVisible, Is.True, "Navigation menu should be visible");
                
                bool isLogoVisible = _homePage.IsLogoVisible();
                Assert.That(isLogoVisible, Is.True, "Logo should be visible");
                
                LogHelper.Info("Homepage displays without layout issues");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Layout verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify there are no error messages
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no error messages")]
        public void ThenThereShouldBeNoErrorMessages()
        {
            try
            {
                LogHelper.Info("Verifying no error messages are displayed");
                
                bool hasNoErrors = _homePage.HasNoErrorMessages();
                Assert.That(hasNoErrors, Is.True, "Page should not display any error messages");
                
                LogHelper.Info("No error messages found");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error message verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verify there is no missing content
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            try
            {
                LogHelper.Info("Verifying no missing content");
                
                bool isMenuVisible = _homePage.IsNavigationMenuVisible();
                Assert.That(isMenuVisible, Is.True, "Navigation menu should be present");
                
                bool isLogoVisible = _homePage.IsLogoVisible();
                Assert.That(isLogoVisible, Is.True, "Logo should be present");
                
                LogHelper.Info("No missing content detected");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Missing content verification failed: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // HELPER CLASSES FOR TABLE DATA
        // =============================================================

        private class MenuOptionData
        {
            public string MenuOption { get; set; }
        }

        private class ProductCategoryData
        {
            public string ProductCategory { get; set; }
        }
    }
}