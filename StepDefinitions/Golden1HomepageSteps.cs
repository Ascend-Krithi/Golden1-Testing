using NUnit.Framework;
using OpenQA.Selenium;
using Project1.Automation.Pages;
using Project1.Automation.Utilities;
using TechTalk.SpecFlow;

namespace Project1.Automation.StepDefinitions
{
    [Binding]
    public class Golden1HomepageSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        public Golden1HomepageSteps(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
        }

        [Given(@"I launch Chrome browser")]
        public void GivenILaunchChromeBrowser()
        {
            LogHelper.Info("Browser launched successfully");
            // Browser is already launched by Hooks, just log the action
        }

        [When(@"I navigate to the Golden 1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden 1 homepage");
            _homePage.NavigateToHomepage();
            LogHelper.Info("Navigation to Golden 1 homepage completed");
        }

        [Then(@"the homepage should be displayed without any loading errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutAnyLoadingErrors()
        {
            LogHelper.Info("Verifying homepage is displayed without loading errors");
            bool isDisplayed = _homePage.IsHomepageDisplayed();
            Assert.That(isDisplayed, Is.True, "Homepage is not displayed or has loading errors");
            LogHelper.Info("Homepage verified successfully - no loading errors");
        }

        [Then(@"the homepage should load successfully")]
        public void ThenTheHomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("Verifying homepage loads successfully");
            bool isLoaded = _homePage.IsHomepageDisplayed();
            Assert.That(isLoaded, Is.True, "Homepage did not load successfully");
            LogHelper.Info("Homepage loaded successfully");
        }

        [Then(@"no error messages or broken sections should be displayed")]
        public void ThenNoErrorMessagesOrBrokenSectionsShouldBeDisplayed()
        {
            LogHelper.Info("Verifying no error messages or broken sections are displayed");
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.That(hasErrors, Is.False, "Error messages or broken sections are displayed on homepage");
            LogHelper.Info("No error messages or broken sections found");
        }

        [Then(@"the Golden 1 homepage should load successfully")]
        public void ThenTheGolden1HomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("Verifying Golden 1 homepage loads successfully");
            bool isLoaded = _homePage.IsHomepageDisplayed();
            string currentUrl = _driver.Url;
            Assert.That(isLoaded, Is.True, "Golden 1 homepage did not load successfully");
            Assert.That(currentUrl.Contains("golden1.com"), Is.True, "URL does not contain golden1.com");
            LogHelper.Info("Golden 1 homepage loaded successfully");
        }

        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            LogHelper.Info("Verifying homepage is displayed without errors");
            bool isDisplayed = _homePage.IsHomepageDisplayed();
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.That(isDisplayed, Is.True, "Homepage is not displayed");
            Assert.That(hasErrors, Is.False, "Homepage has errors");
            LogHelper.Info("Homepage displayed without errors");
        }

        [Then(@"the homepage should be displayed without loading errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutLoadingErrors()
        {
            LogHelper.Info("Verifying homepage is displayed without loading errors");
            bool isDisplayed = _homePage.IsHomepageDisplayed();
            Assert.That(isDisplayed, Is.True, "Homepage is not displayed or has loading errors");
            LogHelper.Info("Homepage displayed without loading errors");
        }

        [Then(@"the homepage should be visible")]
        public void ThenTheHomepageShouldBeVisible()
        {
            LogHelper.Info("Verifying homepage is visible");
            bool isVisible = _homePage.IsHomepageDisplayed();
            Assert.That(isVisible, Is.True, "Homepage is not visible");
            LogHelper.Info("Homepage is visible");
        }

        [Then(@"the homepage should be displayed without any errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutAnyErrors()
        {
            LogHelper.Info("Verifying homepage is displayed without any errors");
            bool isDisplayed = _homePage.IsHomepageDisplayed();
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.That(isDisplayed, Is.True, "Homepage is not displayed");
            Assert.That(hasErrors, Is.False, "Homepage displays errors");
            LogHelper.Info("Homepage displayed without any errors");
        }

        [Then(@"the homepage should be visible with no errors shown")]
        public void ThenTheHomepageShouldBeVisibleWithNoErrorsShown()
        {
            LogHelper.Info("Verifying homepage is visible with no errors shown");
            bool isVisible = _homePage.IsHomepageDisplayed();
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.That(isVisible, Is.True, "Homepage is not visible");
            Assert.That(hasErrors, Is.False, "Errors are shown on homepage");
            LogHelper.Info("Homepage is visible with no errors shown");
        }
    }
}