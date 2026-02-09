using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;

namespace Golden1.Tests.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private NavigationPage _navigationPage;

        public NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to the Golden 1 homepage")]
        public void GivenINavigateToTheGolden1Homepage()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            _driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
            WaitHelper.WaitForPageLoad(_driver);
        }

        [Then(@"the Golden 1 homepage should be displayed")]
        public void ThenTheGolden1HomepageShouldBeDisplayed()
        {
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains("golden1.com"), "Homepage URL validation failed");
        }

        [Then(@"the page should load without errors")]
        public void ThenThePageShouldLoadWithoutErrors()
        {
            Assert.IsTrue(_navigationPage.IsPageLoadedSuccessfully(), "Page loaded with errors");
        }

        [Then(@"the top navigation menu should be visible")]
        public void ThenTheTopNavigationMenuShouldBeVisible()
        {
            Assert.IsTrue(_navigationPage.IsTopNavBarVisible(), "Top navigation menu is not visible");
        }

        [Then(@"the ""(.*)"" menu option should be visible")]
        public void ThenTheMenuOptionShouldBeVisible(string menuOption)
        {
            Assert.IsTrue(_navigationPage.IsMenuOptionVisible(menuOption), $"{menuOption} menu option is not visible");
        }

        [Then(@"the Golden 1 logo should be visible in the top section")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopSection()
        {
            Assert.IsTrue(_navigationPage.IsLogoVisible(), "Golden 1 logo is not visible");
        }

        [Then(@"the homepage should load without broken sections")]
        public void ThenTheHomepageShouldLoadWithoutBrokenSections()
        {
            Assert.IsTrue(_navigationPage.IsPageLoadedSuccessfully(), "Homepage has broken sections");
        }

        [Then(@"no error messages should be displayed")]
        public void ThenNoErrorMessagesShouldBeDisplayed()
        {
            Assert.IsFalse(_navigationPage.HasErrorMessages(), "Error messages are displayed on the page");
        }
    }
}