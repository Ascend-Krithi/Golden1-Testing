using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.WebAutomation.Pages;
using System;

namespace Golden1.WebAutomation.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;
        private readonly HomePage _homePage;
        private readonly OverlayPage _overlayPage;
        private readonly ScenarioContext _scenarioContext;

        public NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _navigationPage = new NavigationPage(_driver);
            _homePage = new HomePage(_driver);
            _overlayPage = new OverlayPage(_driver);
        }

        [Given(@"I am on the Golden1 homepage")]
        public void GivenIAmOnTheGolden1Homepage()
        {
            LogHelper.Info("Step: Given I am on the Golden1 homepage");
            _homePage.NavigateToHomePage();
            _overlayPage.HandleAllOverlays();
            Assert.IsTrue(_homePage.IsLogoDisplayed(), "Golden1 homepage did not load correctly");
            LogHelper.Info("Successfully navigated to Golden1 homepage");
        }

        [Given(@"I navigate to the Golden1 website")]
        public void GivenINavigateToTheGolden1Website()
        {
            LogHelper.Info("Step: Given I navigate to the Golden1 website");
            _homePage.NavigateToHomePage();
            _overlayPage.HandleAllOverlays();
            LogHelper.Info("Successfully navigated to Golden1 website");
        }

        [When(@"I click on the Personal tab")]
        public void WhenIClickOnThePersonalTab()
        {
            LogHelper.Info("Step: When I click on the Personal tab");
            _navigationPage.ClickPersonalTab();
            LogHelper.Info("Personal tab clicked");
        }

        [When(@"I click on the Business tab")]
        public void WhenIClickOnTheBusinessTab()
        {
            LogHelper.Info("Step: When I click on the Business tab");
            _navigationPage.ClickBusinessTab();
            LogHelper.Info("Business tab clicked");
        }

        [When(@"I click on the Financial Wellness tab")]
        public void WhenIClickOnTheFinancialWellnessTab()
        {
            LogHelper.Info("Step: When I click on the Financial Wellness tab");
            _navigationPage.ClickFinancialWellnessTab();
            LogHelper.Info("Financial Wellness tab clicked");
        }

        [When(@"I click on the Appointments tab")]
        public void WhenIClickOnTheAppointmentsTab()
        {
            LogHelper.Info("Step: When I click on the Appointments tab");
            _navigationPage.ClickAppointmentsTab();
            LogHelper.Info("Appointments tab clicked");
        }

        [When(@"I click on the Locations tab")]
        public void WhenIClickOnTheLocationsTab()
        {
            LogHelper.Info("Step: When I click on the Locations tab");
            _navigationPage.ClickLocationsTab();
            LogHelper.Info("Locations tab clicked");
        }

        [When(@"I click on the Membership tab")]
        public void WhenIClickOnTheMembershipTab()
        {
            LogHelper.Info("Step: When I click on the Membership tab");
            _navigationPage.ClickMembershipTab();
            LogHelper.Info("Membership tab clicked");
        }

        [When(@"I click on the Help Center tab")]
        public void WhenIClickOnTheHelpCenterTab()
        {
            LogHelper.Info("Step: When I click on the Help Center tab");
            _navigationPage.ClickHelpCenterTab();
            LogHelper.Info("Help Center tab clicked");
        }

        [When(@"I click on the Checking menu")]
        public void WhenIClickOnTheCheckingMenu()
        {
            LogHelper.Info("Step: When I click on the Checking menu");
            _navigationPage.ClickCheckingMenu();
            LogHelper.Info("Checking menu clicked");
        }

        [When(@"I click on the Savings menu")]
        public void WhenIClickOnTheSavingsMenu()
        {
            LogHelper.Info("Step: When I click on the Savings menu");
            _navigationPage.ClickSavingsMenu();
            LogHelper.Info("Savings menu clicked");
        }

        [When(@"I click on the Home Loans menu")]
        public void WhenIClickOnTheHomeLoansMenu()
        {
            LogHelper.Info("Step: When I click on the Home Loans menu");
            _navigationPage.ClickHomeLoansMenu();
            LogHelper.Info("Home Loans menu clicked");
        }

        [When(@"I click on the Credit Cards menu")]
        public void WhenIClickOnTheCreditCardsMenu()
        {
            LogHelper.Info("Step: When I click on the Credit Cards menu");
            _navigationPage.ClickCreditCardsMenu();
            LogHelper.Info("Credit Cards menu clicked");
        }

        [When(@"I click on the Loans menu")]
        public void WhenIClickOnTheLoansMenu()
        {
            LogHelper.Info("Step: When I click on the Loans menu");
            _navigationPage.ClickLoansMenu();
            LogHelper.Info("Loans menu clicked");
        }

        [When(@"I click on the Investing menu")]
        public void WhenIClickOnTheInvestingMenu()
        {
            LogHelper.Info("Step: When I click on the Investing menu");
            _navigationPage.ClickInvestingMenu();
            LogHelper.Info("Investing menu clicked");
        }

        [When(@"I click on the Community menu")]
        public void WhenIClickOnTheCommunityMenu()
        {
            LogHelper.Info("Step: When I click on the Community menu");
            _navigationPage.ClickCommunityMenu();
            LogHelper.Info("Community menu clicked");
        }

        [When(@"I click on Free Checking link")]
        public void WhenIClickOnFreeCheckingLink()
        {
            LogHelper.Info("Step: When I click on Free Checking link");
            _navigationPage.ClickFreeCheckingLink();
            LogHelper.Info("Free Checking link clicked");
        }

        [When(@"I click on Savings Account link")]
        public void WhenIClickOnSavingsAccountLink()
        {
            LogHelper.Info("Step: When I click on Savings Account link");
            _navigationPage.ClickSavingsAccountLink();
            LogHelper.Info("Savings Account link clicked");
        }

        [When(@"I click on Auto Loans link")]
        public void WhenIClickOnAutoLoansLink()
        {
            LogHelper.Info("Step: When I click on Auto Loans link");
            _navigationPage.ClickAutoLoansLink();
            LogHelper.Info("Auto Loans link clicked");
        }

        [When(@"I navigate to Checking from Personal")]
        public void WhenINavigateToCheckingFromPersonal()
        {
            LogHelper.Info("Step: When I navigate to Checking from Personal");
            _navigationPage.NavigateToCheckingFromPersonal();
            LogHelper.Info("Navigated to Checking from Personal");
        }

        [When(@"I navigate to Free Checking page")]
        public void WhenINavigateToFreeCheckingPage()
        {
            LogHelper.Info("Step: When I navigate to Free Checking page");
            _navigationPage.NavigateToFreeChecking();
            LogHelper.Info("Navigated to Free Checking page");
        }

        [When(@"I navigate to Savings Account page")]
        public void WhenINavigateToSavingsAccountPage()
        {
            LogHelper.Info("Step: When I navigate to Savings Account page");
            _navigationPage.NavigateToSavingsAccount();
            LogHelper.Info("Navigated to Savings Account page");
        }

        [When(@"I navigate to Auto Loans page")]
        public void WhenINavigateToAutoLoansPage()
        {
            LogHelper.Info("Step: When I navigate to Auto Loans page");
            _navigationPage.NavigateToAutoLoans();
            LogHelper.Info("Navigated to Auto Loans page");
        }

        [Then(@"the navigation menu should be displayed")]
        public void ThenTheNavigationMenuShouldBeDisplayed()
        {
            LogHelper.Info("Step: Then the navigation menu should be displayed");
            Assert.IsTrue(_navigationPage.IsMenuContainerDisplayed(), "Navigation menu is not displayed");
            LogHelper.Info("Navigation menu is displayed");
        }

        [Then(@"the top tabs should be visible")]
        public void ThenTheTopTabsShouldBeVisible()
        {
            LogHelper.Info("Step: Then the top tabs should be visible");
            Assert.IsTrue(_navigationPage.IsTopTabsContainerDisplayed(), "Top tabs are not visible");
            LogHelper.Info("Top tabs are visible");
        }

        [Then(@"I should see the main menu options")]
        public void ThenIShouldSeeTheMainMenuOptions()
        {
            LogHelper.Info("Step: Then I should see the main menu options");
            Assert.IsTrue(_navigationPage.IsMenuContainerDisplayed(), "Main menu options are not visible");
            Assert.IsTrue(_navigationPage.IsTopTabsContainerDisplayed(), "Top tabs are not visible");
            LogHelper.Info("Main menu options are visible");
        }

        [Then(@"the page title should contain ""(.*)""")]
        public void ThenThePageTitleShouldContain(string expectedTitle)
        {
            LogHelper.Info($"Step: Then the page title should contain '{expectedTitle}'");
            string actualTitle = _homePage.GetPageTitle();
            Assert.IsTrue(actualTitle.Contains(expectedTitle), 
                $"Expected title to contain '{expectedTitle}', but got '{actualTitle}'");
            LogHelper.Info($"Page title contains '{expectedTitle}'");
        }

        [Then(@"the URL should contain ""(.*)""")]
        public void ThenTheURLShouldContain(string expectedUrlPart)
        {
            LogHelper.Info($"Step: Then the URL should contain '{expectedUrlPart}'");
            string actualUrl = _homePage.GetCurrentUrl();
            Assert.IsTrue(actualUrl.Contains(expectedUrlPart), 
                $"Expected URL to contain '{expectedUrlPart}', but got '{actualUrl}'");
            LogHelper.Info($"URL contains '{expectedUrlPart}'");
        }
    }
}