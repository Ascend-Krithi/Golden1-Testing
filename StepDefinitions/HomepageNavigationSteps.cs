using NUnit.Framework;
using Project1.Automation.Pages;
using Project1.Automation.Utilities;
using TechTalk.SpecFlow;

namespace Project1.Automation.StepDefinitions
{
    [Binding]
    public class HomepageNavigationSteps
    {
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public HomepageNavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _homePage = new HomePage(DriverManager.Driver);
        }

        [Given(@"I launch a supported browser")]
        public void GivenILaunchASupportedBrowser()
        {
            LogHelper.Info("Browser launched successfully via Hooks");
            Assert.That(DriverManager.Driver, Is.Not.Null, "Browser driver should be initialized");
        }

        [When(@"I navigate to the Golden 1 website")]
        public void WhenINavigateToTheGolden1Website()
        {
            LogHelper.Info("Navigating to Golden 1 website");
            _homePage.NavigateToHomePage();
            LogHelper.Info("Successfully navigated to Golden 1 homepage");
        }

        [Then(@"the Golden 1 homepage should load successfully")]
        public void ThenTheGolden1HomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("Verifying homepage loaded successfully");
            bool isHomePageLoaded = _homePage.IsHomePageLoaded();
            Assert.That(isHomePageLoaded, Is.True, "Golden 1 homepage should load successfully");
            LogHelper.Info("Homepage loaded successfully");
        }

        [Then(@"the homepage should display without any errors")]
        public void ThenTheHomepageShouldDisplayWithoutAnyErrors()
        {
            LogHelper.Info("Verifying homepage displays without errors");
            bool hasNoErrors = _homePage.VerifyNoErrorsDisplayed();
            Assert.That(hasNoErrors, Is.True, "Homepage should display without any errors");
            
            string currentUrl = _homePage.GetCurrentUrl();
            Assert.That(currentUrl, Does.Contain("golden1.com"), "URL should contain golden1.com");
            LogHelper.Info($"Current URL verified: {currentUrl}");
        }
    }
}