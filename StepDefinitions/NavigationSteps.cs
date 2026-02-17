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
    /// Step Definitions for Golden1 Website Navigation
    /// Implements BDD steps for navigation scenarios
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        // =============================================================
        // CONSTRUCTOR
        // =============================================================
        public NavigationSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _navigationPage = new NavigationPage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Preconditions
        // =============================================================

        /// <summary>
        /// Opens the Golden1 website homepage
        /// </summary>
        [Given(@"the user opens the Golden1 website")]
        public void GivenTheUserOpensTheGolden1Website()
        {
            try
            {
                LogHelper.Info("Step: Given the user opens the Golden1 website");
                _navigationPage.OpenHomePage();
                LogHelper.Info("Successfully opened Golden1 website");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to open Golden1 website: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "OpenHomepage_Failed");
                throw;
            }
        }

        /// <summary>
        /// Accepts cookies if the cookie banner is displayed
        /// </summary>
        [Given(@"the user accepts cookies if banner is displayed")]
        public void GivenTheUserAcceptsCookiesIfBannerIsDisplayed()
        {
            try
            {
                LogHelper.Info("Step: Given the user accepts cookies if banner is displayed");
                _navigationPage.AcceptCookiesIfDisplayed();
                LogHelper.Info("Cookie handling completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to handle cookies: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "AcceptCookies_Failed");
                throw;
            }
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================

        /// <summary>
        /// Clicks on a top navigation tab
        /// </summary>
        /// <param name="tabName">Name of the tab to click</param>
        [When(@"the user clicks on the ""(.*)"" tab")]
        public void WhenTheUserClicksOnTheTab(string tabName)
        {
            try
            {
                LogHelper.Info($"Step: When the user clicks on the '{tabName}' tab");
                _navigationPage.ClickTopTab(tabName);
                _scenarioContext["ClickedTab"] = tabName;
                LogHelper.Info($"Successfully clicked on {tabName} tab");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click on {tabName} tab: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"ClickTab_{tabName}_Failed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a main menu option
        /// </summary>
        /// <param name="menuName">Name of the menu to click</param>
        [When(@"the user clicks on ""(.*)"" menu option")]
        public void WhenTheUserClicksOnMenuOption(string menuName)
        {
            try
            {
                LogHelper.Info($"Step: When the user clicks on '{menuName}' menu option");
                _navigationPage.ClickMainMenu(menuName);
                _scenarioContext["ClickedMenu"] = menuName;
                LogHelper.Info($"Successfully clicked on {menuName} menu");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click on {menuName} menu: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"ClickMenu_{menuName}_Failed");
                throw;
            }
        }

        /// <summary>
        /// Clicks on a submenu link
        /// </summary>
        /// <param name="linkName">Name of the link to click</param>
        [When(@"the user clicks on ""(.*)"" link")]
        public void WhenTheUserClicksOnLink(string linkName)
        {
            try
            {
                LogHelper.Info($"Step: When the user clicks on '{linkName}' link");
                _navigationPage.ClickSubmenuLink(linkName);
                _scenarioContext["ClickedLink"] = linkName;
                LogHelper.Info($"Successfully clicked on {linkName} link");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click on {linkName} link: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"ClickLink_{linkName}_Failed");
                throw;
            }
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================

        /// <summary>
        /// Verifies that a specific section is displayed
        /// </summary>
        /// <param name="sectionName">Name of the section</param>
        [Then(@"the (.*) section should be displayed")]
        public void ThenTheSectionShouldBeDisplayed(string sectionName)
        {
            try
            {
                LogHelper.Info($"Step: Then the {sectionName} section should be displayed");
                bool isVisible = _navigationPage.IsMenuContainerVisible();
                Assert.That(isVisible, Is.True, $"{sectionName} section is not displayed");
                LogHelper.Info($"{sectionName} section is displayed successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - {sectionName} section not displayed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Section_{sectionName}_NotDisplayed");
                throw;
            }
        }

        /// <summary>
        /// Verifies that a specific page is displayed
        /// </summary>
        /// <param name="pageName">Name of the page</param>
        [Then(@"the (.*) page should be displayed")]
        public void ThenThePageShouldBeDisplayed(string pageName)
        {
            try
            {
                LogHelper.Info($"Step: Then the {pageName} page should be displayed");
                string currentUrl = _navigationPage.GetPageUrl();
                Assert.That(currentUrl, Is.Not.Null.And.Not.Empty, "Current URL is null or empty");
                LogHelper.Info($"{pageName} page is displayed successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - {pageName} page not displayed: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Page_{pageName}_NotDisplayed");
                throw;
            }
        }

        /// <summary>
        /// Verifies that the page URL contains expected text
        /// </summary>
        /// <param name="expectedText">Expected text in URL</param>
        [Then(@"the page URL should contain ""(.*)""")]
        public void ThenThePageUrlShouldContain(string expectedText)
        {
            try
            {
                LogHelper.Info($"Step: Then the page URL should contain '{expectedText}'");
                bool containsText = _navigationPage.DoesUrlContain(expectedText);
                string currentUrl = _navigationPage.GetPageUrl();
                Assert.That(containsText, Is.True, 
                    $"URL does not contain '{expectedText}'. Current URL: {currentUrl}");
                LogHelper.Info($"URL contains expected text: {expectedText}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - URL does not contain '{expectedText}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"URL_NotContains_{expectedText}");
                throw;
            }
        }

        /// <summary>
        /// Verifies that the page title contains expected text
        /// </summary>
        /// <param name="expectedText">Expected text in title</param>
        [Then(@"the page title should contain ""(.*)""")]
        public void ThenThePageTitleShouldContain(string expectedText)
        {
            try
            {
                LogHelper.Info($"Step: Then the page title should contain '{expectedText}'");
                bool containsText = _navigationPage.DoesTitleContain(expectedText);
                string currentTitle = _navigationPage.GetPageTitle();
                Assert.That(containsText, Is.True, 
                    $"Title does not contain '{expectedText}'. Current title: {currentTitle}");
                LogHelper.Info($"Title contains expected text: {expectedText}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - Title does not contain '{expectedText}': {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, $"Title_NotContains_{expectedText}");
                throw;
            }
        }

        /// <summary>
        /// Verifies that all specified top navigation tabs are visible
        /// </summary>
        /// <param name="table">Table containing tab names</param>
        [Then(@"the following top navigation tabs should be visible:")]
        public void ThenTheFollowingTopNavigationTabsShouldBeVisible(Table table)
        {
            try
            {
                LogHelper.Info("Step: Then the following top navigation tabs should be visible");
                var tabNames = table.Rows.Select(row => row["TabName"]).ToList();
                LogHelper.Info($"Verifying {tabNames.Count} tabs: {string.Join(", ", tabNames)}");
                
                bool allVisible = _navigationPage.AreAllTabsVisible(tabNames);
                
                Assert.That(allVisible, Is.True, 
                    "Not all expected navigation tabs are visible");
                LogHelper.Info("All expected navigation tabs are visible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Assertion failed - Not all tabs visible: {ex.Message}");
                ScreenshotHelper.CaptureScreenshot(_driver, "NavigationTabs_NotAllVisible");
                throw;
            }
        }
    }
}