using TechTalk.SpecFlow;
using NUnit.Framework;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step Definitions for Golden1 Navigation scenarios
    /// Test Cases: TASK0020445 TS-001 to TS-008
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly NavigationPage _navigationPage;
        private readonly CheckingPage _checkingPage;
        private readonly FreeCheckingPage _freeCheckingPage;
        private readonly SavingsAccountPage _savingsAccountPage;

        public NavigationSteps(NavigationPage navigationPage, CheckingPage checkingPage, 
            FreeCheckingPage freeCheckingPage, SavingsAccountPage savingsAccountPage)
        {
            _navigationPage = navigationPage;
            _checkingPage = checkingPage;
            _freeCheckingPage = freeCheckingPage;
            _savingsAccountPage = savingsAccountPage;
        }

        [Given(@"I am on the Golden1 homepage")]
        public void GivenIAmOnTheGolden1Homepage()
        {
            LogHelper.Info("Step: Navigating to Golden1 homepage");
            _navigationPage.OpenHomepage();
        }

        [When(@"I click on the Personal tab")]
        public void WhenIClickOnThePersonalTab()
        {
            LogHelper.Info("Step: Clicking on Personal tab");
            _navigationPage.ClickPersonalTab();
        }

        [When(@"I click on the Business tab")]
        public void WhenIClickOnTheBusinessTab()
        {
            LogHelper.Info("Step: Clicking on Business tab");
            _navigationPage.ClickBusinessTab();
        }

        [When(@"I click on the Checking menu")]
        public void WhenIClickOnTheCheckingMenu()
        {
            LogHelper.Info("Step: Clicking on Checking menu");
            _navigationPage.ClickCheckingMenu();
        }

        [When(@"I click on the Savings menu")]
        public void WhenIClickOnTheSavingsMenu()
        {
            LogHelper.Info("Step: Clicking on Savings menu");
            _navigationPage.ClickSavingsMenu();
        }

        [When(@"I click on the Free Checking link")]
        public void WhenIClickOnTheFreeCheckingLink()
        {
            LogHelper.Info("Step: Clicking on Free Checking link");
            _navigationPage.ClickFreeCheckingLink();
        }

        [When(@"I click on the Savings Account link")]
        public void WhenIClickOnTheSavingsAccountLink()
        {
            LogHelper.Info("Step: Clicking on Savings Account link");
            _navigationPage.ClickSavingsAccountLink();
        }

        [When(@"the cookie banner is displayed")]
        public void WhenTheCookieBannerIsDisplayed()
        {
            LogHelper.Info("Step: Checking if cookie banner is displayed");
            // This is a conditional check, no action needed
        }

        [Then(@"I accept the cookies")]
        public void ThenIAcceptTheCookies()
        {
            LogHelper.Info("Step: Accepting cookies");
            _navigationPage.AcceptCookies();
        }

        [Then(@"the homepage should load successfully")]
        public void ThenTheHomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("Step: Verifying homepage loaded successfully");
            string currentUrl = _navigationPage.GetPageUrl();
            Assert.That(currentUrl, Does.Contain("golden1"), 
                "Homepage URL should contain 'golden1'");
        }

        [Then(@"the main navigation menu should be visible")]
        public void ThenTheMainNavigationMenuShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying main navigation menu is visible");
            Assert.IsTrue(_navigationPage.IsNavigationMenuVisible(), 
                "Main navigation menu should be visible");
        }

        [Then(@"the Personal section should be displayed")]
        public void ThenThePersonalSectionShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Personal section is displayed");
            Assert.IsTrue(_navigationPage.IsCheckingMenuVisible(), 
                "Personal section with Checking menu should be displayed");
        }

        [Then(@"the Checking menu option should be visible")]
        public void ThenTheCheckingMenuOptionShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Checking menu option is visible");
            Assert.IsTrue(_navigationPage.IsCheckingMenuVisible(), 
                "Checking menu option should be visible");
        }

        [Then(@"the Checking page should be displayed")]
        public void ThenTheCheckingPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Checking page is displayed");
            Assert.IsTrue(_checkingPage.IsCheckingPageDisplayed(), 
                "Checking page should be displayed");
        }

        [Then(@"the Free Checking link should be visible")]
        public void ThenTheFreeCheckingLinkShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Free Checking link is visible");
            Assert.IsTrue(_checkingPage.IsFreeCheckingLinkVisible(), 
                "Free Checking link should be visible");
        }

        [Then(@"the Free Checking page should be displayed")]
        public void ThenTheFreeCheckingPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Free Checking page is displayed");
            Assert.IsTrue(_freeCheckingPage.IsFreeCheckingPageDisplayed(), 
                "Free Checking page should be displayed");
        }

        [Then(@"the Savings Account page should be displayed")]
        public void ThenTheSavingsAccountPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Savings Account page is displayed");
            Assert.IsTrue(_savingsAccountPage.IsSavingsAccountPageDisplayed(), 
                "Savings Account page should be displayed");
        }

        [Then(@"the Personal tab should be visible")]
        public void ThenThePersonalTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Personal tab is visible");
            Assert.IsTrue(_navigationPage.IsPersonalTabVisible(), 
                "Personal tab should be visible");
        }

        [Then(@"the Business tab should be visible")]
        public void ThenTheBusinessTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Business tab is visible");
            Assert.IsTrue(_navigationPage.IsBusinessTabVisible(), 
                "Business tab should be visible");
        }

        [Then(@"the Financial Wellness tab should be visible")]
        public void ThenTheFinancialWellnessTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Financial Wellness tab is visible");
            Assert.IsTrue(_navigationPage.IsFinancialWellnessTabVisible(), 
                "Financial Wellness tab should be visible");
        }

        [Then(@"the Appointments tab should be visible")]
        public void ThenTheAppointmentsTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Appointments tab is visible");
            Assert.IsTrue(_navigationPage.IsAppointmentsTabVisible(), 
                "Appointments tab should be visible");
        }

        [Then(@"the Locations tab should be visible")]
        public void ThenTheLocationsTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Locations tab is visible");
            Assert.IsTrue(_navigationPage.IsLocationsTabVisible(), 
                "Locations tab should be visible");
        }

        [Then(@"the Membership tab should be visible")]
        public void ThenTheMembershipTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Membership tab is visible");
            Assert.IsTrue(_navigationPage.IsMembershipTabVisible(), 
                "Membership tab should be visible");
        }

        [Then(@"the Help Center tab should be visible")]
        public void ThenTheHelpCenterTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Help Center tab is visible");
            Assert.IsTrue(_navigationPage.IsHelpCenterTabVisible(), 
                "Help Center tab should be visible");
        }

        [Then(@"the current URL should contain 