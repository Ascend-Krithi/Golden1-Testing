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
    /// Step definitions for Golden1 Navigation Menu interactions
    /// Test Cases: TASK0020445 TS-003 through TS-007
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _navigationPage = new NavigationPage(_driver);
            _homePage = new HomePage(_driver);
        }

        /// <summary>
        /// Step: Locate the global navigation menu
        /// Test Cases: TASK0020445 TS-003 TC-001, TS-004 TC-001
        /// </summary>
        [When(@"I locate the global navigation menu")]
        public void WhenILocateTheGlobalNavigationMenu()
        {
            try
            {
                LogHelper.Info("Locating the global navigation menu");
                _navigationPage.LocateGlobalNavigationMenu();
                LogHelper.Info("Global navigation menu located successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to locate global navigation menu: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify menu options are present from table
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"the following menu options should be present")]
        public void ThenTheFollowingMenuOptionsShouldBePresent(Table table)
        {
            try
            {
                LogHelper.Info("Verifying menu options are present");
                
                List<string> menuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
                
                foreach (string menuOption in menuOptions)
                {
                    LogHelper.Info($"Checking menu option: {menuOption}");
                    bool isPresent = _navigationPage.IsMenuOptionPresent(menuOption);
                    Assert.That(isPresent, Is.True, 
                        $"Menu option '{menuOption}' should be present in the navigation menu");
                }
                
                LogHelper.Info($"All {menuOptions.Count} menu options are present - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu options verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify main product category menus are displayed from table
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"the following main product category menus should be displayed")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            try
            {
                LogHelper.Info("Verifying main product category menus are displayed");
                
                List<string> productCategories = table.Rows.Select(row => row["ProductCategory"]).ToList();
                
                foreach (string category in productCategories)
                {
                    LogHelper.Info($"Checking product category: {category}");
                    bool isDisplayed = _navigationPage.IsProductCategoryDisplayed(category);
                    Assert.That(isDisplayed, Is.True, 
                        $"Product category '{category}' should be displayed in the navigation menu");
                }
                
                LogHelper.Info($"All {productCategories.Count} product category menus are displayed - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Product category menus verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify each main product category menu is clickable
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"each main product category menu should be clickable")]
        public void ThenEachMainProductCategoryMenuShouldBeClickable()
        {
            try
            {
                LogHelper.Info("Verifying each main product category menu is clickable");
                
                List<string> productCategories = new List<string> 
                { 
                    "Checking", "Savings", "Home Loans", "Credit Cards", 
                    "Loans", "Investing", "Community" 
                };
                
                foreach (string category in productCategories)
                {
                    LogHelper.Info($"Checking if '{category}' menu is clickable");
                    bool isClickable = _navigationPage.IsMenuClickable(category);
                    Assert.That(isClickable, Is.True, 
                        $"Product category menu '{category}' should be clickable");
                    
                    // Click to verify it expands
                    _navigationPage.ClickMainProductMenu(category);
                    LogHelper.Info($"Menu '{category}' clicked successfully");
                }
                
                LogHelper.Info("All main product category menus are clickable - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Menu clickability verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Expand a main product menu
        /// Test Cases: TASK0020445 TS-005 TC-001, TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I expand the ""(.*)"" main product menu")]
        public void WhenIExpandTheMainProductMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Expanding the '{menuName}' main product menu");
                _navigationPage.ExpandMainProductMenu(menuName);
                LogHelper.Info($"Main product menu '{menuName}' expanded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to expand menu '{menuName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify submenu items are displayed
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"submenu items should be displayed under the menu")]
        public void ThenSubmenuItemsShouldBeDisplayedUnderTheMenu()
        {
            try
            {
                LogHelper.Info("Verifying submenu items are displayed");
                
                bool areDisplayed = _navigationPage.AreSubmenuItemsDisplayed();
                Assert.That(areDisplayed, Is.True, 
                    "Submenu items should be displayed under the main product menu");
                
                LogHelper.Info("Submenu items are displayed - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu items display verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify submenu items are selectable
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"I should be able to select submenu items")]
        public void ThenIShouldBeAbleToSelectSubmenuItems()
        {
            try
            {
                LogHelper.Info("Verifying submenu items are selectable");
                
                // Verify at least one submenu item is selectable
                // Using Free Checking as an example
                bool isSelectable = _navigationPage.IsSubmenuItemSelectable("Free Checking");
                Assert.That(isSelectable, Is.True, 
                    "Submenu items should be selectable");
                
                LogHelper.Info("Submenu items are selectable - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Submenu item selectability verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Select a submenu item
        /// Test Cases: TASK0020445 TS-006 TC-001, TS-007 TC-001
        /// </summary>
        [When(@"I select the ""(.*)"" submenu item")]
        public void WhenISelectTheSubmenuItem(string submenuItemName)
        {
            try
            {
                LogHelper.Info($"Selecting submenu item: {submenuItemName}");
                _navigationPage.SelectSubmenuItem(submenuItemName);
                LogHelper.Info($"Submenu item '{submenuItemName}' selected successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to select submenu item '{submenuItemName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify redirected to destination page
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"I should be redirected to the destination page")]
        public void ThenIShouldBeRedirectedToTheDestinationPage()
        {
            try
            {
                LogHelper.Info("Verifying redirection to destination page");
                
                bool isRedirected = _navigationPage.IsDestinationPageLoadedSuccessfully();
                Assert.That(isRedirected, Is.True, 
                    "User should be redirected to the destination page");
                
                LogHelper.Info("Successfully redirected to destination page - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page redirection verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify destination page loads without errors
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying destination page loads without errors");
                
                bool isLoaded = _navigationPage.IsDestinationPageLoadedSuccessfully();
                Assert.That(isLoaded, Is.True, 
                    "Destination page should load without errors");
                
                bool hasNoErrors = _homePage.HasNoErrorMessages();
                Assert.That(hasNoErrors, Is.True, 
                    "Destination page should not display any error messages");
                
                LogHelper.Info("Destination page loaded without errors - PASSED");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Destination page load verification failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Step: Verify destination page URL contains expected identifier
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the destination page URL should contain ""(.*)""")]
        public void ThenTheDestinationPageUrlShouldContain(string expectedIdentifier)
        {
            try
            {
                LogHelper.Info($"Verifying destination page URL contains: {expectedIdentifier}");
                
                bool containsIdentifier = _navigationPage.DoesUrlContainIdentifier(expectedIdentifier);
                Assert.That(containsIdentifier, Is.True, 
                    $"Destination page URL should contain the identifier '{expectedIdentifier}'");
                
                string currentUrl = _homePage.GetPageUrl();
                LogHelper.Info($"URL verification passed. Current URL: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL identifier verification failed: {ex.Message}");
                throw;
            }
        }
    }
}