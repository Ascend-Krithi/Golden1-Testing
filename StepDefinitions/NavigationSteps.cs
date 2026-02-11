using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for navigation-related scenarios
    /// Maps Gherkin steps to Page Object methods
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        // =============================================================
        // CONSTRUCTOR - Dependency Injection
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
        
        [Given(@"User opens the Golden1 homepage")]
        public void GivenUserOpensTheGolden1Homepage()
        {
            LogHelper.Info("Step: User opens the Golden1 homepage");
            _navigationPage.OpenHomePage();
        }
        
        [Given(@"User is on the Golden1 homepage")]
        public void GivenUserIsOnTheGolden1Homepage()
        {
            LogHelper.Info("Step: User is on the Golden1 homepage");
            _navigationPage.OpenHomePage();
        }

        // =============================================================
        // WHEN STEPS - Actions
        // =============================================================
        
        // Top Tab Navigation
        [When(@"User clicks on the Personal tab")]
        public void WhenUserClicksOnThePersonalTab()
        {
            LogHelper.Info("Step: User clicks on the Personal tab");
            _navigationPage.ClickPersonalTab();
        }
        
        [When(@"User clicks on the Business tab")]
        public void WhenUserClicksOnTheBusinessTab()
        {
            LogHelper.Info("Step: User clicks on the Business tab");
            _navigationPage.ClickBusinessTab();
        }
        
        [When(@"User clicks on the Financial Wellness tab")]
        public void WhenUserClicksOnTheFinancialWellnessTab()
        {
            LogHelper.Info("Step: User clicks on the Financial Wellness tab");
            _navigationPage.ClickFinancialWellnessTab();
        }
        
        [When(@"User clicks on the Appointments tab")]
        public void WhenUserClicksOnTheAppointmentsTab()
        {
            LogHelper.Info("Step: User clicks on the Appointments tab");
            _navigationPage.ClickAppointmentsTab();
        }
        
        [When(@"User clicks on the Locations tab")]
        public void WhenUserClicksOnTheLocationsTab()
        {
            LogHelper.Info("Step: User clicks on the Locations tab");
            _navigationPage.ClickLocationsTab();
        }
        
        [When(@"User clicks on the Membership tab")]
        public void WhenUserClicksOnTheMembershipTab()
        {
            LogHelper.Info("Step: User clicks on the Membership tab");
            _navigationPage.ClickMembershipTab();
        }
        
        [When(@"User clicks on the Help Center tab")]
        public void WhenUserClicksOnTheHelpCenterTab()
        {
            LogHelper.Info("Step: User clicks on the Help Center tab");
            _navigationPage.ClickHelpCenterTab();
        }
        
        // Main Menu Navigation
        [When(@"User clicks on the Checking menu")]
        public void WhenUserClicksOnTheCheckingMenu()
        {
            LogHelper.Info("Step: User clicks on the Checking menu");
            _navigationPage.ClickCheckingMenu();
        }
        
        [When(@"User clicks on the Savings menu")]
        public void WhenUserClicksOnTheSavingsMenu()
        {
            LogHelper.Info("Step: User clicks on the Savings menu");
            _navigationPage.ClickSavingsMenu();
        }
        
        [When(@"User clicks on the Home Loans menu")]
        public void WhenUserClicksOnTheHomeLoansMenu()
        {
            LogHelper.Info("Step: User clicks on the Home Loans menu");
            _navigationPage.ClickHomeLoansMenu();
        }
        
        [When(@"User clicks on the Credit Cards menu")]
        public void WhenUserClicksOnTheCreditCardsMenu()
        {
            LogHelper.Info("Step: User clicks on the Credit Cards menu");
            _navigationPage.ClickCreditCardsMenu();
        }
        
        [When(@"User clicks on the Loans menu")]
        public void WhenUserClicksOnTheLoansMenu()
        {
            LogHelper.Info("Step: User clicks on the Loans menu");
            _navigationPage.ClickLoansMenu();
        }
        
        [When(@"User clicks on the Investing menu")]
        public void WhenUserClicksOnTheInvestingMenu()
        {
            LogHelper.Info("Step: User clicks on the Investing menu");
            _navigationPage.ClickInvestingMenu();
        }
        
        [When(@"User clicks on the Community menu")]
        public void WhenUserClicksOnTheCommunityMenu()
        {
            LogHelper.Info("Step: User clicks on the Community menu");
            _navigationPage.ClickCommunityMenu();
        }
        
        // Submenu Navigation
        [When(@"User clicks on the Free Checking link")]
        public void WhenUserClicksOnTheFreeCheckingLink()
        {
            LogHelper.Info("Step: User clicks on the Free Checking link");
            _navigationPage.ClickFreeCheckingLink();
        }
        
        [When(@"User clicks on the Savings Account link")]
        public void WhenUserClicksOnTheSavingsAccountLink()
        {
            LogHelper.Info("Step: User clicks on the Savings Account link");
            _navigationPage.ClickSavingsAccountLink();
        }
        
        [When(@"User clicks on the Auto Loans link")]
        public void WhenUserClicksOnTheAutoLoansLink()
        {
            LogHelper.Info("Step: User clicks on the Auto Loans link");
            _navigationPage.ClickAutoLoansLink();
        }
        
        // Combined Navigation Flows
        [When(@"User navigates to Free Checking page")]
        public void WhenUserNavigatesToFreeCheckingPage()
        {
            LogHelper.Info("Step: User navigates to Free Checking page");
            _navigationPage.NavigateToFreeCheckingPage();
        }
        
        [When(@"User navigates to Savings Account page")]
        public void WhenUserNavigatesToSavingsAccountPage()
        {
            LogHelper.Info("Step: User navigates to Savings Account page");
            _navigationPage.NavigateToSavingsAccountPage();
        }
        
        [When(@"User navigates to Auto Loans page")]
        public void WhenUserNavigatesToAutoLoansPage()
        {
            LogHelper.Info("Step: User navigates to Auto Loans page");
            _navigationPage.NavigateToAutoLoansPage();
        }

        // =============================================================
        // THEN STEPS - Assertions
        // =============================================================
        
        [Then(@"The homepage should load successfully")]
        public void ThenTheHomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("Step: Verifying homepage loaded successfully");
            string currentUrl = _navigationPage.GetCurrentPageUrl();
            Assert.That(currentUrl, Does.Contain("golden1.com"), 
                "Homepage URL should contain 'golden1.com'");
            LogHelper.Info("Homepage loaded successfully");
        }
        
        [Then(@"The main menu should be visible")]
        public void ThenTheMainMenuShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying main menu is visible");
            bool isVisible = _navigationPage.IsMenuContainerVisible();
            Assert.That(isVisible, Is.True, 
                "Main menu container should be visible");
            LogHelper.Info("Main menu is visible");
        }
        
        [Then(@"The top tabs should be visible")]
        public void ThenTheTopTabsShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying top tabs are visible");
            bool isVisible = _navigationPage.IsTopTabsContainerVisible();
            Assert.That(isVisible, Is.True, 
                "Top tabs container should be visible");
            LogHelper.Info("Top tabs are visible");
        }
        
        [Then(@"The Personal tab should be visible")]
        public void ThenThePersonalTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Personal tab is visible");
            bool isVisible = _navigationPage.IsPersonalTabVisible();
            Assert.That(isVisible, Is.True, 
                "Personal tab should be visible");
            LogHelper.Info("Personal tab is visible");
        }
        
        [Then(@"The Checking menu should be visible")]
        public void ThenTheCheckingMenuShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Checking menu is visible");
            bool isVisible = _navigationPage.IsCheckingMenuVisible();
            Assert.That(isVisible, Is.True, 
                "Checking menu should be visible");
            LogHelper.Info("Checking menu is visible");
        }
        
        [Then(@"The page URL should contain ""(.*)""")]
        public void ThenThePageUrlShouldContain(string expectedUrlPart)
        {
            LogHelper.Info($"Step: Verifying page URL contains '{expectedUrlPart}'");
            string currentUrl = _navigationPage.GetCurrentPageUrl();
            Assert.That(currentUrl, Does.Contain(expectedUrlPart), 
                $"Page URL should contain '{expectedUrlPart}'");
            LogHelper.Info($"Page URL contains '{expectedUrlPart}'");
        }
        
        [Then(@"The page title should contain ""(.*)""")]
        public void ThenThePageTitleShouldContain(string expectedTitlePart)
        {
            LogHelper.Info($"Step: Verifying page title contains '{expectedTitlePart}'");
            string pageTitle = _navigationPage.GetPageTitle();
            Assert.That(pageTitle, Does.Contain(expectedTitlePart), 
                $"Page title should contain '{expectedTitlePart}'");
            LogHelper.Info($"Page title contains '{expectedTitlePart}'");
        }
        
        [Then(@"The Free Checking page should be displayed")]
        public void ThenTheFreeCheckingPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Free Checking page is displayed");
            string currentUrl = _navigationPage.GetCurrentPageUrl();
            Assert.That(currentUrl, Does.Contain("checking").IgnoreCase, 
                "URL should contain 'checking' for Free Checking page");
            LogHelper.Info("Free Checking page is displayed");
        }
        
        [Then(@"The Savings Account page should be displayed")]
        public void ThenTheSavingsAccountPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Savings Account page is displayed");
            string currentUrl = _navigationPage.GetCurrentPageUrl();
            Assert.That(currentUrl, Does.Contain("savings").IgnoreCase, 
                "URL should contain 'savings' for Savings Account page");
            LogHelper.Info("Savings Account page is displayed");
        }
        
        [Then(@"The Auto Loans page should be displayed")]
        public void ThenTheAutoLoansPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Auto Loans page is displayed");
            string currentUrl = _navigationPage.GetCurrentPageUrl();
            Assert.That(currentUrl, Does.Contain("auto").IgnoreCase.Or.Contains("loan").IgnoreCase, 
                "URL should contain 'auto' or 'loan' for Auto Loans page");
            LogHelper.Info("Auto Loans page is displayed");
        }
    }
}