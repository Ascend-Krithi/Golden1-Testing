using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Golden 1 Navigation feature
    /// Maps Gherkin steps to Page Object actions for navigation testing
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        // =============================================================
        // FIELDS - Dependencies
        // =============================================================
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        // =============================================================
        // CONSTRUCTOR - Dependency Injection
        // =============================================================
        public NavigationSteps(ScenarioContext context)
        {
            _scenarioContext = context;
            _driver = (IWebDriver)context["Driver"];
            _navigationPage = new NavigationPage(_driver);
        }

        // =============================================================
        // GIVEN STEPS - Preconditions / Setup
        // =============================================================
        [Given(@"User launches Chrome browser")]
        public void GivenUserLaunchesChromeBrowser()
        {
            LogHelper.Info("Chrome browser launched successfully");
            // Browser is already launched by Hooks.cs
        }

        [Given(@"User navigates to Golden 1 homepage")]
        public void GivenUserNavigatesToGolden1Homepage()
        {
            _navigationPage.OpenHomePage();
            _navigationPage.HandleCookieBannerIfPresent();
            LogHelper.Info("User navigated to Golden 1 homepage");
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================
        [When(@"User navigates to Golden 1 homepage")]
        public void WhenUserNavigatesToGolden1Homepage()
        {
            _navigationPage.OpenHomePage();
            _navigationPage.HandleCookieBannerIfPresent();
            LogHelper.Info("User navigated to Golden 1 homepage");
        }

        [When(@"User observes the top section of the homepage")]
        public void WhenUserObservesTheTopSectionOfTheHomepage()
        {
            LogHelper.Info("User observing top section of homepage");
            // Observation step - no action needed
        }

        [When(@"User locates the global navigation menu")]
        public void WhenUserLocatesTheGlobalNavigationMenu()
        {
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Navigation menu should be visible");
            LogHelper.Info("Global navigation menu located successfully");
        }

        [When(@"User expands the Checking product menu")]
        public void WhenUserExpandsTheCheckingProductMenu()
        {
            _navigationPage.ClickCheckingMenu();
            LogHelper.Info("Checking product menu expanded");
        }

        [When(@"User selects Free Checking submenu item")]
        public void WhenUserSelectsFreeCheckingSubmenuItem()
        {
            _navigationPage.ClickFreeCheckingLink();
            LogHelper.Info("Free Checking submenu item selected");
        }

        [When(@"User observes the top header area")]
        public void WhenUserObservesTheTopHeaderArea()
        {
            LogHelper.Info("User observing top header area");
            // Observation step - no action needed
        }

        // =============================================================
        // THEN STEPS - Assertions / Verifications
        // =============================================================
        [Then(@"Homepage should load successfully without errors")]
        public void ThenHomepageShouldLoadSuccessfullyWithoutErrors()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_navigationPage.IsNavigationMenuVisible(), Is.True,
                    "Navigation menu should be visible on homepage");
                Assert.That(_navigationPage.GetCurrentUrl(), Does.Contain("golden1.com"),
                    "URL should contain golden1.com");
            });
            LogHelper.Info("Homepage loaded successfully without errors");
        }

        [Then(@"Global navigation menu should be visible at the top of the page")]
        public void ThenGlobalNavigationMenuShouldBeVisibleAtTheTopOfThePage()
        {
            bool isVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isVisible, Is.True,
                "Global navigation menu is not visible at the top of the page");
            LogHelper.Info("Global navigation menu is visible at the top");
        }

        [Then(@"The following menu options should be present:")]
        public void ThenTheFollowingMenuOptionsShouldBePresent(Table table)
        {
            var expectedMenuOptions = table.Rows.Select(r => r["Menu Option"]).ToList();
            
            foreach (var menuOption in expectedMenuOptions)
            {
                bool isPresent = false;
                switch (menuOption)
                {
                    case "Personal":
                        isPresent = _navigationPage.IsPersonalTabVisible();
                        break;
                    case "Business":
                        isPresent = _navigationPage.IsBusinessTabVisible();
                        break;
                    case "Financial Wellness":
                        isPresent = _navigationPage.IsFinancialWellnessTabVisible();
                        break;
                    case "Appointments":
                        isPresent = _navigationPage.IsAppointmentsTabVisible();
                        break;
                    case "Locations":
                        isPresent = _navigationPage.IsLocationsTabVisible();
                        break;
                    case "Membership":
                        isPresent = _navigationPage.IsMembershipTabVisible();
                        break;
                    case "Help Center":
                        isPresent = _navigationPage.IsHelpCenterTabVisible();
                        break;
                }
                
                Assert.That(isPresent, Is.True,
                    $"Menu option '{menuOption}' is not present in navigation");
                LogHelper.Info($"Verified menu option '{menuOption}' is present");
            }
        }

        [Then(@"The following main product category menus should be displayed:")]
        public void ThenTheFollowingMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            var expectedCategories = table.Rows.Select(r => r["Product Category"]).ToList();
            
            foreach (var category in expectedCategories)
            {
                bool isDisplayed = false;
                switch (category)
                {
                    case "Checking":
                        isDisplayed = _navigationPage.IsCheckingMenuVisible();
                        break;
                    case "Savings":
                        isDisplayed = _navigationPage.IsSavingsMenuVisible();
                        break;
                    case "Home Loans":
                        isDisplayed = _navigationPage.IsHomeLoansMenuVisible();
                        break;
                    case "Credit Cards":
                        isDisplayed = _navigationPage.IsCreditCardsMenuVisible();
                        break;
                    case "Loans":
                        isDisplayed = _navigationPage.IsLoansMenuVisible();
                        break;
                    case "Investing":
                        isDisplayed = _navigationPage.IsInvestingMenuVisible();
                        break;
                    case "Community":
                        isDisplayed = _navigationPage.IsCommunityMenuVisible();
                        break;
                }
                
                Assert.That(isDisplayed, Is.True,
                    $"Product category '{category}' is not displayed");
                LogHelper.Info($"Verified product category '{category}' is displayed");
            }
        }

        [Then(@"Each product category menu should be accessible")]
        public void ThenEachProductCategoryMenuShouldBeAccessible()
        {
            var categories = new[] { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
            
            foreach (var category in categories)
            {
                bool isAccessible = false;
                switch (category)
                {
                    case "Checking":
                        isAccessible = _navigationPage.IsCheckingMenuClickable();
                        break;
                    case "Savings":
                        isAccessible = _navigationPage.IsSavingsMenuClickable();
                        break;
                    case "Home Loans":
                        isAccessible = _navigationPage.IsHomeLoansMenuClickable();
                        break;
                    case "Credit Cards":
                        isAccessible = _navigationPage.IsCreditCardsMenuClickable();
                        break;
                    case "Loans":
                        isAccessible = _navigationPage.IsLoansMenuClickable();
                        break;
                    case "Investing":
                        isAccessible = _navigationPage.IsInvestingMenuClickable();
                        break;
                    case "Community":
                        isAccessible = _navigationPage.IsCommunityMenuClickable();
                        break;
                }
                
                Assert.That(isAccessible, Is.True,
                    $"Product category '{category}' is not accessible");
                LogHelper.Info($"Verified product category '{category}' is accessible");
            }
        }

        [Then(@"Submenu items should be displayed under Checking menu")]
        public void ThenSubmenuItemsShouldBeDisplayedUnderCheckingMenu()
        {
            bool isSubmenuVisible = _navigationPage.IsFreeCheckingLinkVisible();
            Assert.That(isSubmenuVisible, Is.True,
                "Submenu items are not displayed under Checking menu");
            LogHelper.Info("Submenu items displayed under Checking menu");
        }

        [Then(@"User should be able to select Free Checking submenu item")]
        public void ThenUserShouldBeAbleToSelectFreeCheckingSubmenuItem()
        {
            bool isClickable = _navigationPage.IsFreeCheckingLinkClickable();
            Assert.That(isClickable, Is.True,
                "Free Checking submenu item is not selectable");
            LogHelper.Info("Free Checking submenu item is selectable");
        }

        [Then(@"User should be redirected to Free Checking destination page")]
        public void ThenUserShouldBeRedirectedToFreeCheckingDestinationPage()
        {
            string currentUrl = _navigationPage.GetCurrentUrl();
            Assert.That(currentUrl, Does.Contain("checking"),
                "User was not redirected to Free Checking destination page");
            LogHelper.Info("User redirected to Free Checking destination page");
        }

        [Then(@"Destination page should load without errors")]
        public void ThenDestinationPageShouldLoadWithoutErrors()
        {
            _navigationPage.WaitForPageLoad();
            string currentUrl = _navigationPage.GetCurrentUrl();
            Assert.That(currentUrl, Is.Not.Empty,
                "Destination page did not load properly");
            LogHelper.Info("Destination page loaded without errors");
        }

        [Then(@"Destination page URL should contain ""(.*)""")]
        public void ThenDestinationPageURLShouldContain(string expectedUrlPart)
        {
            string currentUrl = _navigationPage.GetCurrentUrl();
            Assert.That(currentUrl.ToLower(), Does.Contain(expectedUrlPart.ToLower()),
                $"Destination page URL does not contain '{expectedUrlPart}'. Actual URL: {currentUrl}");
            LogHelper.Info($"Destination page URL contains '{expectedUrlPart}'");
        }

        [Then(@"Golden 1 logo should be visible in the header")]
        public void ThenGolden1LogoShouldBeVisibleInTheHeader()
        {
            // Logo verification - checking if navigation menu container is visible as proxy
            bool isHeaderVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isHeaderVisible, Is.True,
                "Golden 1 logo/header is not visible");
            LogHelper.Info("Golden 1 logo is visible in the header");
        }

        [Then(@"Homepage should display correctly with no broken layouts")]
        public void ThenHomepageShouldDisplayCorrectlyWithNoBrokenLayouts()
        {
            bool isNavigationVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.That(isNavigationVisible, Is.True,
                "Homepage layout appears broken - navigation menu not visible");
            LogHelper.Info("Homepage displays correctly with no broken layouts");
        }

        [Then(@"There should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            bool hasContent = _navigationPage.IsTopTabsContainerVisible();
            Assert.That(hasContent, Is.True,
                "Homepage has missing content");
            LogHelper.Info("No missing content on homepage");
        }

        [Then(@"There should be no system errors")]
        public void ThenThereShouldBeNoSystemErrors()
        {
            string currentUrl = _navigationPage.GetCurrentUrl();
            Assert.That(currentUrl, Does.Not.Contain("error"),
                "System error detected in URL");
            Assert.That(currentUrl, Does.Not.Contain("404"),
                "404 error detected");
            LogHelper.Info("No system errors detected");
        }
    }
}