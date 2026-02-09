using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using G1AutomationFramework.Pages;
using G1AutomationFramework.Utilities;

namespace G1AutomationFramework.Steps
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

        [Then(@"the homepage should load successfully")]
        public void ThenTheHomepageShouldLoadSuccessfully()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains("golden1.com"), "Homepage did not load successfully");
        }

        [Then(@"the main navigation menu should be visible at the top")]
        public void ThenTheMainNavigationMenuShouldBeVisibleAtTheTop()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsTopNavBarVisible(), "Main navigation menu is not visible");
        }

        [Then(@"the ""(.*?)"" menu option should be visible in the top navigation")]
        public void ThenTheMenuOptionShouldBeVisibleInTheTopNavigation(string menuOption)
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            bool isVisible = false;

            switch (menuOption)
            {
                case "Personal":
                    isVisible = _navigationPage.IsPersonalMenuVisible();
                    break;
                case "Business":
                    isVisible = _navigationPage.IsBusinessMenuVisible();
                    break;
                case "Financial Wellness":
                    isVisible = _navigationPage.IsFinancialWellnessMenuVisible();
                    break;
                case "Appointments":
                    isVisible = _navigationPage.IsAppointmentsMenuVisible();
                    break;
                case "Locations":
                    isVisible = _navigationPage.IsLocationsMenuVisible();
                    break;
                case "Help Center":
                    isVisible = _navigationPage.IsHelpCenterMenuVisible();
                    break;
            }

            Assert.IsTrue(isVisible, $"{menuOption} menu option is not visible in the top navigation");
        }

        [Then(@"the Golden 1 logo should be visible in the top section")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopSection()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            Assert.IsTrue(_navigationPage.IsLogoVisible(), "Golden 1 logo is not visible");
        }
    }
}