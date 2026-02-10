using NUnit.Framework;
using Project1.Automation.Pages;
using Project1.Automation.Utilities;
using TechTalk.SpecFlow;

namespace Project1.Automation.StepDefinitions
{
    [Binding]
    public class Golden1HomepageSteps
    {
        private readonly HomePage _homePage;
        private readonly ScenarioContext _scenarioContext;

        public Golden1HomepageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _homePage = new HomePage(DriverManager.Driver);
        }

        [Given(@"I launch the Chrome browser")]
        public void GivenILaunchTheChromeBrowser()
        {
            LogHelper.Info("Browser launched successfully - Chrome");
            // Browser initialization is handled in Hooks.cs
        }

        [Given(@"I launch the ""(.*?)"" browser")]
        public void GivenILaunchTheBrowser(string browserType)
        {
            LogHelper.Info($"Browser launched successfully - {browserType}");
            // Browser initialization is handled in Hooks.cs with browser type from config
        }

        [When(@"I navigate to the Golden 1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden 1 homepage");
            _homePage.NavigateToHomepage();
            LogHelper.Info("Successfully navigated to Golden 1 homepage");
        }

        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            LogHelper.Info("Verifying homepage is displayed without errors");
            bool isHomepageDisplayed = _homePage.IsHomepageLoaded();
            Assert.That(isHomepageDisplayed, Is.True, "Homepage did not load successfully");
            LogHelper.Info("Homepage verified successfully - No errors found");
        }

        [Then(@"the page title should contain ""(.*?)""")]
        public void ThenThePageTitleShouldContain(string expectedTitleText)
        {
            LogHelper.Info($"Verifying page title contains: {expectedTitleText}");
            string actualTitle = _homePage.GetPageTitle();
            Assert.That(actualTitle, Does.Contain(expectedTitleText), 
                $"Page title '{actualTitle}' does not contain expected text '{expectedTitleText}'");
            LogHelper.Info($"Page title verified successfully: {actualTitle}");
        }

        [Then(@"no error messages should be visible")]
        public void ThenNoErrorMessagesShouldBeVisible()
        {
            LogHelper.Info("Verifying no error messages are displayed");
            bool hasErrors = _homePage.AreErrorMessagesDisplayed();
            Assert.That(hasErrors, Is.False, "Error messages were found on the homepage");
            LogHelper.Info("Verified - No error messages displayed");
        }
    }
}