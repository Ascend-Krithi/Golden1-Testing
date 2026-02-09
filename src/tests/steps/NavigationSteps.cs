using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using AutomationFramework.Pages;
using AutomationFramework.Utilities;

namespace AutomationFramework.Steps
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
            _driver = (IWebDriver)_scenarioContext["Driver"];
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains("golden1.com"), "Homepage URL validation failed");
        }

        [Then(@"the top navigation menu should be visible")]
        public void ThenTheTopNavigationMenuShouldBeVisible()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsTopNavBarVisible(), "Top navigation menu is not visible");
        }

        [Then(@"the ""(.*?)"" menu option should be visible in the navigation")]
        public void ThenTheMenuOptionShouldBeVisibleInTheNavigation(string menuOption)
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsMenuOptionVisible(menuOption), $"{menuOption} menu option is not visible");
        }

        [Then(@"the Golden 1 logo should be visible")]
        public void ThenTheGolden1LogoShouldBeVisible()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsLogoVisible(), "Golden 1 logo is not visible");
        }

        [Then(@"the homepage should load without errors")]
        public void ThenTheHomepageShouldLoadWithoutErrors()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains("golden1.com"), "Homepage did not load correctly");
            
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsTopNavBarVisible(), "Navigation menu is not visible - possible broken page");
            Assert.IsTrue(_navigationPage.IsLogoVisible(), "Logo is not visible - possible broken page");
        }
    }
}