using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Golden1.AutomationFramework.Pages;
using Golden1.AutomationFramework.Utilities;
using NUnit.Framework;

namespace Golden1.AutomationTests.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly CheckingPage _checkingPage;
        private readonly LogHelper _logHelper;

        public NavigationSteps()
        {
            _driver = DriverFactory.GetDriver();
            _homePage = new HomePage(_driver);
            _checkingPage = new CheckingPage(_driver);
            _logHelper = new LogHelper();
        }

        [Given(@"I navigate to the Golden1 homepage")]
        public void GivenINavigateToTheGolden1Homepage()
        {
            _logHelper.LogInfo("Step: Navigating to Golden1 homepage");
            _homePage.NavigateToHomePage();
        }

        [When(@"I click on the Checking menu")]
        public void WhenIClickOnTheCheckingMenu()
        {
            _logHelper.LogInfo("Step: Clicking on Checking menu");
            _homePage.ClickCheckingMenu();
        }

        [When(@"I click on the Free Checking link")]
        public void WhenIClickOnTheFreeCheckingLink()
        {
            _logHelper.LogInfo("Step: Clicking on Free Checking link");
            _checkingPage.ClickFreeCheckingLink();
        }

        [Then(@"I should see the Checking page")]
        public void ThenIShouldSeeTheCheckingPage()
        {
            _logHelper.LogInfo("Step: Verifying Checking page is displayed");
            string pageHeader = _checkingPage.GetPageHeader();
            Assert.That(pageHeader, Does.Contain("Checking"), "Checking page header not found");
            _logHelper.LogInfo("Verification passed: Checking page is displayed");
        }

        [Then(@"I should see the Free Checking link")]
        public void ThenIShouldSeeTheFreeCheckingLink()
        {
            _logHelper.LogInfo("Step: Verifying Free Checking link is displayed");
            bool isDisplayed = _checkingPage.IsFreeCheckingLinkDisplayed();
            Assert.IsTrue(isDisplayed, "Free Checking link is not displayed");
            _logHelper.LogInfo("Verification passed: Free Checking link is displayed");
        }
    }
}