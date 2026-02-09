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
            _navigationPage.NavigateToHomepage();
        }

        [Then(@"the page URL should contain ""(.*)""")]
        public void ThenThePageURLShouldContain(string urlPart)
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            WaitHelper.WaitForPageLoad(_driver);
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains(urlPart.ToLower()), $"Expected URL to contain '{urlPart}' but was '{currentUrl}'");
        }

        [Then(@"the Golden 1 logo should be visible")]
        public void ThenTheGolden1LogoShouldBeVisible()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsLogoVisible(), "Golden 1 logo is not visible");
        }

        [Then(@"the top navigation menu should be visible")]
        public void ThenTheTopNavigationMenuShouldBeVisible()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsTopNavBarVisible(), "Top navigation menu is not visible");
        }

        [Then(@"the ""(.*)"" menu option should be visible")]
        public void ThenTheMenuOptionShouldBeVisible(string menuOption)
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsMenuOptionVisible(menuOption), $"Menu option '{menuOption}' is not visible");
        }
    }
}