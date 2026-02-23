using TechTalk.SpecFlow;
using NUnit.Framework;
using ProjectName.Automation.Pages;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly NavigationPage _navigationPage;
        private readonly OverlayPage _overlayPage;
        private readonly FreeCheckingPage _freeCheckingPage;
        private readonly SavingsAccountPage _savingsAccountPage;
        private readonly AutoLoansPage _autoLoansPage;

        // Constructor injection
        public NavigationSteps(
            NavigationPage navigationPage,
            OverlayPage overlayPage,
            FreeCheckingPage freeCheckingPage,
            SavingsAccountPage savingsAccountPage,
            AutoLoansPage autoLoansPage)
        {
            _navigationPage = navigationPage;
            _overlayPage = overlayPage;
            _freeCheckingPage = freeCheckingPage;
            _savingsAccountPage = savingsAccountPage;
            _autoLoansPage = autoLoansPage;
        }

        // GIVEN Steps
        [Given(@"I navigate to Golden1 homepage")]
        public void GivenINavigateToGolden1Homepage()
        {
            LogHelper.Info("Step: Navigating to Golden1 homepage");
            _navigationPage.OpenHomePage();
        }

        [Given(@"I accept cookies if banner is displayed")]
        public void GivenIAcceptCookiesIfBannerIsDisplayed()
        {
            LogHelper.Info("Step: Accepting cookies if banner is displayed");
            _overlayPage.AcceptCookiesIfDisplayed();
        }

        // WHEN Steps
        [When(@"I hover over the Checking menu")]
        public void WhenIHoverOverTheCheckingMenu()
        {
            LogHelper.Info("Step: Hovering over Checking menu");
            _navigationPage.HoverOverCheckingMenu();
        }

        [When(@"I hover over the Savings menu")]
        public void WhenIHoverOverTheSavingsMenu()
        {
            LogHelper.Info("Step: Hovering over Savings menu");
            _navigationPage.HoverOverSavingsMenu();
        }

        [When(@"I hover over the Loans menu")]
        public void WhenIHoverOverTheLoansMenu()
        {
            LogHelper.Info("Step: Hovering over Loans menu");
            _navigationPage.HoverOverLoansMenu();
        }

        [When(@"I hover over the (.*) menu")]
        public void WhenIHoverOverTheMenu(string menuName)
        {
            LogHelper.Info($"Step: Hovering over {menuName} menu");
            _navigationPage.HoverOverMenu(menuName);
        }

        [When(@"I click on Free Checking link")]
        public void WhenIClickOnFreeCheckingLink()
        {
            LogHelper.Info("Step: Clicking on Free Checking link");
            _navigationPage.ClickFreeCheckingLink();
        }

        [When(@"I click on Savings Account link")]
        public void WhenIClickOnSavingsAccountLink()
        {
            LogHelper.Info("Step: Clicking on Savings Account link");
            _navigationPage.ClickSavingsAccountLink();
        }

        [When(@"I click on Auto Loans link")]
        public void WhenIClickOnAutoLoansLink()
        {
            LogHelper.Info("Step: Clicking on Auto Loans link");
            _navigationPage.ClickAutoLoansLink();
        }

        // THEN Steps
        [Then(@"the homepage should be displayed")]
        public void ThenTheHomepageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying homepage is displayed");
            Assert.IsTrue(_navigationPage.IsHomePageDisplayed(), "Homepage should be displayed");
        }

        [Then(@"the main menu should be visible")]
        public void ThenTheMainMenuShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying main menu is visible");
            Assert.IsTrue(_navigationPage.IsMainMenuVisible(), "Main menu should be visible");
        }

        [Then(@"the Personal tab should be visible")]
        public void ThenThePersonalTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Personal tab is visible");
            Assert.IsTrue(_navigationPage.IsPersonalTabVisible(), "Personal tab should be visible");
        }

        [Then(@"the Business tab should be visible")]
        public void ThenTheBusinessTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Business tab is visible");
            Assert.IsTrue(_navigationPage.IsBusinessTabVisible(), "Business tab should be visible");
        }

        [Then(@"the Financial Wellness tab should be visible")]
        public void ThenTheFinancialWellnessTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Financial Wellness tab is visible");
            Assert.IsTrue(_navigationPage.IsFinancialWellnessTabVisible(), "Financial Wellness tab should be visible");
        }

        [Then(@"the Appointments tab should be visible")]
        public void ThenTheAppointmentsTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Appointments tab is visible");
            Assert.IsTrue(_navigationPage.IsAppointmentsTabVisible(), "Appointments tab should be visible");
        }

        [Then(@"the Locations tab should be visible")]
        public void ThenTheLocationsTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Locations tab is visible");
            Assert.IsTrue(_navigationPage.IsLocationsTabVisible(), "Locations tab should be visible");
        }

        [Then(@"the Membership tab should be visible")]
        public void ThenTheMembershipTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Membership tab is visible");
            Assert.IsTrue(_navigationPage.IsMembershipTabVisible(), "Membership tab should be visible");
        }

        [Then(@"the Help Center tab should be visible")]
        public void ThenTheHelpCenterTabShouldBeVisible()
        {
            LogHelper.Info("Step: Verifying Help Center tab is visible");
            Assert.IsTrue(_navigationPage.IsHelpCenterTabVisible(), "Help Center tab should be visible");
        }

        [Then(@"the Checking submenu should be displayed")]
        public void ThenTheCheckingSubmenuShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Checking submenu is displayed");
            Assert.IsTrue(_navigationPage.IsCheckingSubmenuDisplayed(), "Checking submenu should be displayed");
        }

        [Then(@"the (.*) submenu should be displayed")]
        public void ThenTheSubmenuShouldBeDisplayed(string menuName)
        {
            LogHelper.Info($"Step: Verifying {menuName} submenu is displayed");
            Assert.IsTrue(_navigationPage.IsSubmenuDisplayed(menuName), $"{menuName} submenu should be displayed");
        }

        [Then(@"the Free Checking page should be displayed")]
        public void ThenTheFreeCheckingPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Free Checking page is displayed");
            Assert.IsTrue(_freeCheckingPage.IsFreeCheckingPageDisplayed(), "Free Checking page should be displayed");
        }

        [Then(@"the Savings Account page should be displayed")]
        public void ThenTheSavingsAccountPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Savings Account page is displayed");
            Assert.IsTrue(_savingsAccountPage.IsSavingsAccountPageDisplayed(), "Savings Account page should be displayed");
        }

        [Then(@"the Auto Loans page should be displayed")]
        public void ThenTheAutoLoansPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Auto Loans page is displayed");
            Assert.IsTrue(_autoLoansPage.IsAutoLoansPageDisplayed(), "Auto Loans page should be displayed");
        }
    }
}