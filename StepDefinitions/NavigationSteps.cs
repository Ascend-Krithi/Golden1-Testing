using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for Golden1 Navigation scenarios
    /// Test Cases: TASK0020445 TS-001 to TS-009
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _navigationPage = new NavigationPage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================

        /// <summary>
        /// Opens the Golden1 homepage
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Given(@"User opens the Golden1 homepage")]
        public void GivenUserOpensTheGolden1Homepage()
        {
            try
            {
                LogHelper.Info("Step: User opens the Golden1 homepage");
                _navigationPage.OpenHomePage();
                LogHelper.Info("Homepage opened successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open homepage: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Accepts cookies if banner is displayed
        /// Test Cases: All scenarios - Background step
        /// </summary>
        [Given(@"User accepts cookies if banner is displayed")]
        public void GivenUserAcceptsCookiesIfBannerIsDisplayed()
        {
            try
            {
                LogHelper.Info("Step: User accepts cookies if banner is displayed");
                _navigationPage.AcceptCookiesIfDisplayed();
                LogHelper.Info("Cookie handling completed");
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie handling issue: {ex.Message}");
                // Don't throw - cookies are optional
            }
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        /// <summary>
        /// Clicks on a top navigation tab
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [When(@"User clicks on ""(.*)"" top tab")]
        public void WhenUserClicksOnTopTab(string tabName)
        {
            try
            {
                LogHelper.Info($"Step: User clicks on '{tabName}' top tab");
                _navigationPage.ClickTopTab(tabName);
                _scenarioContext["ClickedTab"] = tabName;
                LogHelper.Info($"Successfully clicked on {tabName} tab");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click on {tabName} tab: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a main menu option
        /// Test Cases: TASK0020445 TS-004, TS-006, TS-008 TC-001
        /// </summary>
        [When(@"User clicks on ""(.*)"" menu")]
        public void WhenUserClicksOnMenu(string menuName)
        {
            try
            {
                LogHelper.Info($"Step: User clicks on '{menuName}' menu");
                _navigationPage.ClickMainMenu(menuName);
                _scenarioContext["ClickedMenu"] = menuName;
                LogHelper.Info($"Successfully clicked on {menuName} menu");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click on {menuName} menu: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu link
        /// Test Cases: TASK0020445 TS-005, TS-007 TC-001
        /// </summary>
        [When(@"User clicks on ""(.*)"" link")]
        public void WhenUserClicksOnLink(string linkName)
        {
            try
            {
                LogHelper.Info($"Step: User clicks on '{linkName}' link");
                _navigationPage.ClickSubmenuLink(linkName);
                _scenarioContext["ClickedLink"] = linkName;
                LogHelper.Info($"Successfully clicked on {linkName} link");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click on {linkName} link: {ex.Message}");
                throw;
            }
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================

        /// <summary>
        /// Verifies main navigation menu is visible
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"User should see the main navigation menu")]
        public void ThenUserShouldSeeTheMainNavigationMenu()
        {
            try
            {
                LogHelper.Info("Step: Verifying main navigation menu is visible");
                bool isVisible = _navigationPage.IsMainMenuVisible();
                Assert.That(isVisible, Is.True, "Main navigation menu should be visible");
                LogHelper.Info("Main navigation menu is visible - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - Main navigation menu not visible: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies top navigation tabs are visible
        /// Test Cases: TASK0020445 TS-001 TC-001
        /// </summary>
        [Then(@"User should see the top navigation tabs")]
        public void ThenUserShouldSeeTheTopNavigationTabs()
        {
            try
            {
                LogHelper.Info("Step: Verifying top navigation tabs are visible");
                bool isVisible = _navigationPage.IsTopTabsVisible();
                Assert.That(isVisible, Is.True, "Top navigation tabs should be visible");
                LogHelper.Info("Top navigation tabs are visible - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - Top navigation tabs not visible: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies a specific top tab is visible
        /// Test Cases: TASK0020445 TS-002 TC-001
        /// </summary>
        [Then(@"User should see ""(.*)"" tab in top navigation")]
        public void ThenUserShouldSeeTabInTopNavigation(string tabName)
        {
            try
            {
                LogHelper.Info($"Step: Verifying '{tabName}' tab is visible in top navigation");
                bool isVisible = _navigationPage.IsTopTabVisible(tabName);
                Assert.That(isVisible, Is.True, $"{tabName} tab should be visible in top navigation");
                LogHelper.Info($"{tabName} tab is visible - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - {tabName} tab not visible: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies a specific main menu option is visible
        /// Test Cases: TASK0020445 TS-003 TC-001
        /// </summary>
        [Then(@"User should see ""(.*)"" menu option")]
        public void ThenUserShouldSeeMenuOption(string menuName)
        {
            try
            {
                LogHelper.Info($"Step: Verifying '{menuName}' menu option is visible");
                bool isVisible = _navigationPage.IsMainMenuOptionVisible(menuName);
                Assert.That(isVisible, Is.True, $"{menuName} menu option should be visible");
                LogHelper.Info($"{menuName} menu option is visible - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - {menuName} menu option not visible: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies Free Checking link is visible
        /// Test Cases: TASK0020445 TS-004 TC-001
        /// </summary>
        [Then(@"User should see Free Checking link")]
        public void ThenUserShouldSeeFreeCheckingLink()
        {
            try
            {
                LogHelper.Info("Step: Verifying Free Checking link is visible");
                bool isVisible = _navigationPage.IsSubmenuLinkVisible("Free Checking");
                Assert.That(isVisible, Is.True, "Free Checking link should be visible");
                LogHelper.Info("Free Checking link is visible - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - Free Checking link not visible: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies Savings Account link is visible
        /// Test Cases: TASK0020445 TS-006 TC-001
        /// </summary>
        [Then(@"User should see Savings Account link")]
        public void ThenUserShouldSeeSavingsAccountLink()
        {
            try
            {
                LogHelper.Info("Step: Verifying Savings Account link is visible");
                bool isVisible = _navigationPage.IsSubmenuLinkVisible("Savings Account");
                Assert.That(isVisible, Is.True, "Savings Account link should be visible");
                LogHelper.Info("Savings Account link is visible - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - Savings Account link not visible: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies Auto Loans link is visible
        /// Test Cases: TASK0020445 TS-008 TC-001
        /// </summary>
        [Then(@"User should see Auto Loans link")]
        public void ThenUserShouldSeeAutoLoansLink()
        {
            try
            {
                LogHelper.Info("Step: Verifying Auto Loans link is visible");
                bool isVisible = _navigationPage.IsSubmenuLinkVisible("Auto Loans");
                Assert.That(isVisible, Is.True, "Auto Loans link should be visible");
                LogHelper.Info("Auto Loans link is visible - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - Auto Loans link not visible: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies user is on a specific page
        /// Test Cases: TASK0020445 TS-005, TS-007, TS-009 TC-001
        /// </summary>
        [Then(@"User should be on (.*) page")]
        public void ThenUserShouldBeOnPage(string pageName)
        {
            try
            {
                LogHelper.Info($"Step: Verifying user is on {pageName} page");
                bool isOnPage = _navigationPage.IsOnPage(pageName);
                Assert.That(isOnPage, Is.True, $"User should be on {pageName} page");
                LogHelper.Info($"User is on {pageName} page - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - User not on {pageName} page: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies user is on a specific section
        /// Test Cases: TASK0020445 TS-009 TC-001
        /// </summary>
        [Then(@"User should be on ""(.*)"" section")]
        public void ThenUserShouldBeOnSection(string sectionName)
        {
            try
            {
                LogHelper.Info($"Step: Verifying user is on {sectionName} section");
                bool isOnSection = _navigationPage.IsOnPage(sectionName);
                Assert.That(isOnSection, Is.True, $"User should be on {sectionName} section");
                LogHelper.Info($"User is on {sectionName} section - Assertion passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - User not on {sectionName} section: {ex.Message}");
                throw;
            }
        }
    }
}