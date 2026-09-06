using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.WebAutomation.Pages;
using System;

namespace Golden1.WebAutomation.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly OverlayPage _overlayPage;
        private readonly ScenarioContext _scenarioContext;

        public HomePageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _homePage = new HomePage(_driver);
            _overlayPage = new OverlayPage(_driver);
        }

        [Given(@"the homepage is loaded")]
        public void GivenTheHomepageIsLoaded()
        {
            LogHelper.Info("Step: Given the homepage is loaded");
            _homePage.NavigateToHomePage();
            _overlayPage.HandleAllOverlays();
            Assert.IsTrue(_homePage.IsLogoDisplayed(), "Homepage did not load correctly");
            LogHelper.Info("Homepage loaded successfully");
        }

        [When(@"I view the homepage")]
        public void WhenIViewTheHomepage()
        {
            LogHelper.Info("Step: When I view the homepage");
            WaitHelper.WaitForPageLoad(_driver, 10);
            LogHelper.Info("Viewing homepage");
        }

        [When(@"I click on the Login button")]
        public void WhenIClickOnTheLoginButton()
        {
            LogHelper.Info("Step: When I click on the Login button");
            _homePage.ClickLoginButton();
            LogHelper.Info("Login button clicked");
        }

        [When(@"I click on the Open Account button")]
        public void WhenIClickOnTheOpenAccountButton()
        {
            LogHelper.Info("Step: When I click on the Open Account button");
            _homePage.ClickOpenAccountButton();
            LogHelper.Info("Open Account button clicked");
        }

        [Then(@"the Golden1 logo should be displayed")]
        public void ThenTheGolden1LogoShouldBeDisplayed()
        {
            LogHelper.Info("Step: Then the Golden1 logo should be displayed");
            Assert.IsTrue(_homePage.IsLogoDisplayed(), "Golden1 logo is not displayed");
            LogHelper.Info("Golden1 logo is displayed");
        }

        [Then(@"the Login button should be visible")]
        public void ThenTheLoginButtonShouldBeVisible()
        {
            LogHelper.Info("Step: Then the Login button should be visible");
            Assert.IsTrue(_homePage.IsLoginButtonDisplayed(), "Login button is not visible");
            LogHelper.Info("Login button is visible");
        }

        [Then(@"the Open Account button should be visible")]
        public void ThenTheOpenAccountButtonShouldBeVisible()
        {
            LogHelper.Info("Step: Then the Open Account button should be visible");
            Assert.IsTrue(_homePage.IsOpenAccountButtonDisplayed(), "Open Account button is not visible");
            LogHelper.Info("Open Account button is visible");
        }

        [Then(@"the hero banner should be displayed")]
        public void ThenTheHeroBannerShouldBeDisplayed()
        {
            LogHelper.Info("Step: Then the hero banner should be displayed");
            Assert.IsTrue(_homePage.IsHeroBannerDisplayed(), "Hero banner is not displayed");
            LogHelper.Info("Hero banner is displayed");
        }

        [Then(@"all homepage elements should be visible")]
        public void ThenAllHomepageElementsShouldBeVisible()
        {
            LogHelper.Info("Step: Then all homepage elements should be visible");
            Assert.IsTrue(_homePage.IsLogoDisplayed(), "Logo is not displayed");
            Assert.IsTrue(_homePage.IsLoginButtonDisplayed(), "Login button is not displayed");
            Assert.IsTrue(_homePage.IsOpenAccountButtonDisplayed(), "Open Account button is not displayed");
            LogHelper.Info("All homepage elements are visible");
        }
    }
}