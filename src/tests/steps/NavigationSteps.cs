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
        public void SetupDriver()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
        }

        [Given(@"I navigate to the Golden 1 homepage")]
        public void GivenINavigateToTheGolden1Homepage()
        {
            string baseUrl = ConfigReader.BaseUrl;
            _driver.Navigate().GoToUrl(baseUrl);
            WaitHelper.WaitForPageLoad(_driver);
        }

        [Then(@"the Golden 1 homepage should be displayed")]
        public void ThenTheGolden1HomepageShouldBeDisplayed()
        {
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains("golden1.com"), "Homepage URL validation failed");
        }

        [Then(@"the main navigation menu should be visible at the top")]
        public void ThenTheMainNavigationMenuShouldBeVisibleAtTheTop()
        {
            bool isNavVisible = _navigationPage.IsTopNavBarVisible();
            Assert.IsTrue(isNavVisible, "Main navigation menu is not visible");
        }

        [Then(@"the Golden 1 logo should be visible in the header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheHeader()
        {
            bool isLogoVisible = _navigationPage.IsLogoVisible();
            Assert.IsTrue(isLogoVisible, "Golden 1 logo is not visible");
        }

        [Then(@"the ""(.*?)"" menu option should be visible in navigation")]
        public void ThenTheMenuOptionShouldBeVisibleInNavigation(string menuOption)
        {
            bool isMenuVisible = _navigationPage.IsMenuItemVisible(menuOption);
            Assert.IsTrue(isMenuVisible, $"{menuOption} menu option is not visible");
        }

        [Then(@"the homepage should display without broken sections or error messages")]
        public void ThenTheHomepageShouldDisplayWithoutBrokenSectionsOrErrorMessages()
        {
            bool hasErrors = _navigationPage.HasPageErrors();
            Assert.IsFalse(hasErrors, "Homepage has errors or broken sections");
            
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains("golden1.com"), "Homepage URL validation failed");
        }
    }
}