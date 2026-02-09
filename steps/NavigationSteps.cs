using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;

namespace Golden1.Automation.Steps
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

        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            Assert.That(_driver.Url.ToLower().Contains("golden1.com"), Is.True, "Homepage URL is not correct");
        }

        [Then(@"the main navigation menu should be visible at the top")]
        public void ThenTheMainNavigationMenuShouldBeVisibleAtTheTop()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsTopNavBarVisible(), "Main navigation menu is not visible");
        }

        [Then(@"the ""([^""]*)