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

        [BeforeScenario]
        public void BeforeScenario()
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

        [Given(@"browser cache is cleared")]
        public void GivenBrowserCacheIsCleared()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
        }

        [When(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            string baseUrl = ConfigReader.BaseUrl;
            _driver.Navigate().GoToUrl(baseUrl);
            WaitHelper.WaitForPageLoad(_driver);
        }

        [When(@"I click on the ""([^""]*)