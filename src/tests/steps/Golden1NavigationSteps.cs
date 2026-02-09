using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;

namespace Golden1.Tests.Steps
{
    [Binding]
    public class Golden1NavigationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private NavigationPage _navigationPage;

        public Golden1NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void InitializeDriver()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
        }

        [Given(@"I navigate to the Golden1 homepage")]
        public void GivenINavigateToTheGolden1Homepage()
        {
            string baseUrl = ConfigReader.BaseUrl;
            _driver.Navigate().GoToUrl(baseUrl);
            WaitHelper.WaitForPageLoad(_driver);
        }

        [Then(@"the Golden1 homepage should be displayed")]
        public void ThenTheGolden1HomepageShouldBeDisplayed()
        {
            WaitHelper.WaitForPageLoad(_driver);
            Assert.That(_driver.Url, Does.Contain("golden1.com").IgnoreCase);
        }

        [Then(@"the page URL should contain ""(.*)""")]
        public void ThenThePageURLShouldContain(string expectedUrlPart)
        {
            WaitHelper.WaitForPageLoad(_driver);
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl, Does.Contain(expectedUrlPart.ToLower()));
        }

        [Then(@"the top navigation menu should be visible")]
        public void ThenTheTopNavigationMenuShouldBeVisible()
        {
            Assert.IsTrue(_navigationPage.IsTopNavBarVisible(), "Top navigation menu is not visible");
        }

        [Then(@"the menu option ""(.*)"" should be present")]
        public void ThenTheMenuOptionShouldBePresent(string menuOption)
        {
            Assert.IsTrue(_navigationPage.IsMenuOptionPresent(menuOption), $"Menu option '{menuOption}' is not present");
        }

        [Then(@"the Golden1 logo should be visible")]
        public void ThenTheGolden1LogoShouldBeVisible()
        {
            Assert.IsTrue(_navigationPage.IsLogoVisible(), "Golden1 logo is not visible");
        }

        [Then(@"the hero banner should be visible")]
        public void ThenTheHeroBannerShouldBeVisible()
        {
            Assert.IsTrue(_navigationPage.IsHeroBannerVisible(), "Hero banner is not visible");
        }

        [When(@"I click on the ""(.*)"" menu option")]
        public void WhenIClickOnTheMenuOption(string menuOption)
        {
            _navigationPage.ClickMenuOption(menuOption);
            WaitHelper.WaitForPageLoad(_driver);
        }
    }
}