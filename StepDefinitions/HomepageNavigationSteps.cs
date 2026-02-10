using NUnit.Framework;
using OpenQA.Selenium;
using Project1.Automation.Pages;
using Project1.Automation.Utilities;
using TechTalk.SpecFlow;

namespace Project1.Automation.StepDefinitions
{
    [Binding]
    public class HomepageNavigationSteps
    {
        private readonly IWebDriver Driver;
        private readonly HomePage _homePage;

        public HomepageNavigationSteps(IWebDriver driver)
        {
            Driver = driver;
            _homePage = new HomePage(Driver);
        }

        [Given(@"I launch the browser")]
        public void GivenILaunchTheBrowser()
        {
            LogHelper.Info("Browser launched successfully via Hooks");
            Assert.That(Driver, Is.Not.Null, "Driver should be initialized");
            LogHelper.Info("Browser is ready for test execution");
        }

        [When(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            LogHelper.Info("Executing step: Navigate to Golden1 homepage");
            _homePage.NavigateToHomepage();
            LogHelper.Info("Navigation to homepage completed");
        }

        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            LogHelper.Info("Verifying homepage is displayed without errors");
            
            bool isDisplayed = _homePage.IsHomepageDisplayed();
            Assert.That(isDisplayed, Is.True, "Homepage should be displayed");
            
            bool hasErrors = _homePage.AreErrorMessagesDisplayed();
            Assert.That(hasErrors, Is.False, "No error messages should be displayed on homepage");
            
            LogHelper.Info("Homepage is displayed without errors - Assertion passed");
        }

        [Then(@"the homepage should be fully loaded")]
        public void ThenTheHomepageShouldBeFullyLoaded()
        {
            LogHelper.Info("Verifying homepage is fully loaded");
            
            bool isFullyLoaded = _homePage.IsPageFullyLoaded();
            Assert.That(isFullyLoaded, Is.True, "Homepage should be fully loaded with all elements visible");
            
            LogHelper.Info("Homepage is fully loaded - Assertion passed");
        }

        [Then(@"the homepage should load without delay")]
        public void ThenTheHomepageShouldLoadWithoutDelay()
        {
            LogHelper.Info("Verifying homepage loads without delay");
            
            bool isDisplayed = _homePage.IsHomepageDisplayed();
            Assert.That(isDisplayed, Is.True, "Homepage should load and be displayed");
            
            bool isTitleCorrect = _homePage.IsPageTitleCorrect();
            Assert.That(isTitleCorrect, Is.True, "Page title should be correct");
            
            LogHelper.Info("Homepage loaded without delay - Assertion passed");
        }

        [Then(@"the homepage should be visible and fully loaded")]
        public void ThenTheHomepageShouldBeVisibleAndFullyLoaded()
        {
            LogHelper.Info("Verifying homepage is visible and fully loaded");
            
            bool isDisplayed = _homePage.IsHomepageDisplayed();
            Assert.That(isDisplayed, Is.True, "Homepage should be visible");
            
            bool isFullyLoaded = _homePage.IsPageFullyLoaded();
            Assert.That(isFullyLoaded, Is.True, "Homepage should be fully loaded");
            
            LogHelper.Info("Homepage is visible and fully loaded - Assertion passed");
        }

        [Then(@"the homepage should load without errors")]
        public void ThenTheHomepageShouldLoadWithoutErrors()
        {
            LogHelper.Info("Verifying homepage loads without errors");
            
            bool isDisplayed = _homePage.IsHomepageDisplayed();
            Assert.That(isDisplayed, Is.True, "Homepage should be displayed");
            
            bool hasErrors = _homePage.AreErrorMessagesDisplayed();
            Assert.That(hasErrors, Is.False, "No errors should be present on homepage");
            
            LogHelper.Info("Homepage loaded without errors - Assertion passed");
        }

        [Then(@"no errors or broken sections should be displayed")]
        public void ThenNoErrorsOrBrokenSectionsShouldBeDisplayed()
        {
            LogHelper.Info("Verifying no errors or broken sections are displayed");
            
            bool hasErrors = _homePage.AreErrorMessagesDisplayed();
            Assert.That(hasErrors, Is.False, "No error messages should be displayed");
            
            bool isFullyLoaded = _homePage.IsPageFullyLoaded();
            Assert.That(isFullyLoaded, Is.True, "All sections should be loaded without breaks");
            
            LogHelper.Info("No errors or broken sections found - Assertion passed");
        }

        [Then(@"the homepage should display all expected elements")]
        public void ThenTheHomepageShouldDisplayAllExpectedElements()
        {
            LogHelper.Info("Verifying all expected elements are displayed on homepage");
            
            bool allElementsPresent = _homePage.AreAllExpectedElementsPresent();
            Assert.That(allElementsPresent, Is.True, "All expected elements (header, navigation, logo) should be present");
            
            LogHelper.Info("All expected elements are displayed - Assertion passed");
        }

        [Then(@"no error messages should be displayed")]
        public void ThenNoErrorMessagesShouldBeDisplayed()
        {
            LogHelper.Info("Verifying no error messages are displayed");
            
            bool hasErrors = _homePage.AreErrorMessagesDisplayed();
            Assert.That(hasErrors, Is.False, "No error messages should be visible on the page");
            
            LogHelper.Info("No error messages displayed - Assertion passed");
        }

        [Then(@"the homepage should be visible")]
        public void ThenTheHomepageShouldBeVisible()
        {
            LogHelper.Info("Verifying homepage is visible");
            
            bool isDisplayed = _homePage.IsHomepageDisplayed();
            Assert.That(isDisplayed, Is.True, "Homepage should be visible to the user");
            
            LogHelper.Info("Homepage is visible - Assertion passed");
        }
    }
}