using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Golden1 Navigation scenarios
    /// Test Cases: TASK0020445 TS-001 through TS-009
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly HomePage _homePage;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        // Constructor injection
        public NavigationSteps(HomePage homePage, NavigationPage navigationPage, ScenarioContext scenarioContext)
        {
            _homePage = homePage;
            _navigationPage = navigationPage;
            _scenarioContext = scenarioContext;
        }

        // GIVEN STEPS

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001 through TS-009 TC-001
        /// </summary>
        [Given(@"I launch the browser")]
        public void GivenILaunchTheBrowser()
        {
            LogHelper.Info("Browser launched via Hooks - BeforeScenario");
            // Browser is already launched in Hooks.cs BeforeScenario
        }

        // WHEN STEPS

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001 through TS-009 TC-001
        /// </summary>
        [When(@"I navigate to the Golden1 homepage")]
        [When(@"I navigate to the Golden(\d+) homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            _homePage.OpenHomePage();
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001, TASK0020445 TS-006 TC-001, TASK0020445 TS-007 TC-001
        /// </summary>
        [When(@"I click on the ""([^""]*)"" menu")]
        public void WhenIClickOnTheMenu(string menuName)
        {
            _navigationPage.ClickProductMenu(menuName);
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001, TASK0020445 TS-006 TC-001, TASK0020445 TS-007 TC-001
        /// </summary>
        [When(@"I select ""([^""]*)"" from the submenu")]
        public void WhenISelectFromTheSubmenu(string submenuName)
        {
            _navigationPage.SelectSubmenuItem(submenuName);
        }

        // THEN STEPS

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"the homepage should load successfully")]
        public void ThenTheHomepageShouldLoadSuccessfully()
        {
            bool isLoaded = _homePage.IsPageLoaded();
            Assert.IsTrue(isLoaded, "Homepage did not load successfully");
            LogHelper.Info("Homepage loaded successfully - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-001 TC-001, TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no error messages")]
        public void ThenThereShouldBeNoErrorMessages()
        {
            bool noErrors = _homePage.IsPageWithoutErrors();
            Assert.IsTrue(noErrors, "Error messages were found on the page");
            LogHelper.Info("No error messages found - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"the global navigation menu should be visible at the top")]
        [Then(@"the global navigation menu should be visible")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.IsTrue(isVisible, "Global navigation menu is not visible");
            LogHelper.Info("Global navigation menu is visible - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"the following top menu options should be present:")]
        public void ThenTheFollowingTopMenuOptionsShouldBePresent(Table table)
        {
            var expectedMenuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
            
            LogHelper.Info($"Verifying {expectedMenuOptions.Count} top menu options are present");
            
            foreach (var menuOption in expectedMenuOptions)
            {
                bool isPresent = _navigationPage.IsTopMenuOptionPresent(menuOption);
                Assert.IsTrue(isPresent, $"Top menu option '{menuOption}' is not present");
                LogHelper.Info($"Top menu option '{menuOption}' is present");
            }
            
            LogHelper.Info("All expected top menu options are present - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"the following main product menus should be displayed:")]
        public void ThenTheFollowingMainProductMenusShouldBeDisplayed(Table table)
        {
            var expectedProductMenus = table.Rows.Select(row => row["ProductMenu"]).ToList();
            
            LogHelper.Info($"Verifying {expectedProductMenus.Count} product menus are displayed");
            
            foreach (var productMenu in expectedProductMenus)
            {
                bool isDisplayed = _navigationPage.IsProductMenuDisplayed(productMenu);
                Assert.IsTrue(isDisplayed, $"Product menu '{productMenu}' is not displayed");
                LogHelper.Info($"Product menu '{productMenu}' is displayed");
            }
            
            LogHelper.Info("All expected product menus are displayed - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"each product menu should be clickable")]
        public void ThenEachProductMenuShouldBeClickable()
        {
            var productMenus = new List<string> 
            { 
                "Checking", "Savings", "Home Loans", "Credit Cards", 
                "Loans", "Investing", "Community" 
            };
            
            LogHelper.Info("Verifying all product menus are clickable");
            
            foreach (var menu in productMenus)
            {
                bool isClickable = _navigationPage.IsProductMenuClickable(menu);
                Assert.IsTrue(isClickable, $"Product menu '{menu}' is not clickable");
                LogHelper.Info($"Product menu '{menu}' is clickable");
            }
            
            LogHelper.Info("All product menus are clickable - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"the submenu should display")]
        public void ThenTheSubmenuShouldDisplay()
        {
            bool isDisplayed = _navigationPage.IsSubmenuDisplayed();
            Assert.IsTrue(isDisplayed, "Submenu did not display after clicking product menu");
            LogHelper.Info("Submenu is displayed - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-005 TC-001
        /// </summary>
        [Then(@"I should be able to select ""([^""]*)"" from the submenu")]
        public void ThenIShouldBeAbleToSelectFromTheSubmenu(string submenuName)
        {
            try
            {
                _navigationPage.SelectSubmenuItem(submenuName);
                LogHelper.Info($"Successfully selected '{submenuName}' from submenu - Assertion passed");
                Assert.Pass($"Submenu item '{submenuName}' was selectable");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to select submenu item '{submenuName}': {ex.Message}");
            }
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"I should be redirected to the Free Checking page")]
        public void ThenIShouldBeRedirectedToTheFreeCheckingPage()
        {
            bool urlContainsChecking = _navigationPage.DoesUrlContainIdentifier("checking");
            Assert.IsTrue(urlContainsChecking, "URL does not contain 'checking' - redirection failed");
            LogHelper.Info("Redirected to Free Checking page - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            bool isLoaded = _homePage.IsPageLoaded();
            bool noErrors = _homePage.IsPageWithoutErrors();
            
            Assert.IsTrue(isLoaded, "Destination page did not load");
            Assert.IsTrue(noErrors, "Destination page loaded with errors");
            LogHelper.Info("Destination page loaded without errors - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-007 TC-001
        /// </summary>
        [Then(@"the page URL should contain ""([^""]*)""")]
        public void ThenThePageURLShouldContain(string urlIdentifier)
        {
            bool containsIdentifier = _navigationPage.DoesUrlContainIdentifier(urlIdentifier);
            Assert.IsTrue(containsIdentifier, $"Page URL does not contain '{urlIdentifier}'");
            LogHelper.Info($"Page URL contains '{urlIdentifier}' - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"the Golden 1 logo should be visible in the header")]
        [Then(@"the Golden (\d+) logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            bool isLogoVisible = _homePage.IsLogoVisible();
            Assert.IsTrue(isLogoVisible, "Golden 1 logo is not visible in the header");
            LogHelper.Info("Golden 1 logo is visible - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"the homepage should display correctly")]
        public void ThenTheHomepageShouldDisplayCorrectly()
        {
            bool isDisplayedCorrectly = _homePage.IsPageDisplayedCorrectly();
            Assert.IsTrue(isDisplayedCorrectly, "Homepage is not displaying correctly");
            LogHelper.Info("Homepage displays correctly - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            bool isDisplayedCorrectly = _homePage.IsPageDisplayedCorrectly();
            Assert.IsTrue(isDisplayedCorrectly, "Page has broken layouts");
            LogHelper.Info("No broken layouts detected - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            bool isDisplayedCorrectly = _homePage.IsPageDisplayedCorrectly();
            Assert.IsTrue(isDisplayedCorrectly, "Page has missing content");
            LogHelper.Info("No missing content detected - Assertion passed");
        }

        /// <summary>
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"there should be no system errors")]
        public void ThenThereShouldBeNoSystemErrors()
        {
            bool noErrors = _homePage.IsPageWithoutErrors();
            Assert.IsTrue(noErrors, "System errors were detected on the page");
            LogHelper.Info("No system errors detected - Assertion passed");
        }
    }
}