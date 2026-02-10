using NUnit.Framework;
using OpenQA.Selenium;
using Project1.Automation.Pages;
using Project1.Automation.Utilities;
using TechTalk.SpecFlow;
using System;

namespace Project1.Automation.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver Driver;
        private readonly HomePage homePage;
        private readonly ScenarioContext scenarioContext;

        public HomePageSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            Driver = driver;
            this.scenarioContext = scenarioContext;
            homePage = new HomePage(Driver);
        }

        [Given(@"I launch a browser")]
        [Given(@"I launch a supported browser")]
        [Given(@"I launch a compatible browser")]
        public void GivenILaunchABrowser()
        {
            try
            {
                LogHelper.Info("Browser launch step - Browser already initialized by Hooks");
                Assert.That(Driver, Is.Not.Null, "Browser driver should be initialized");
                LogHelper.Info("Browser launched successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Browser launch verification failed: {ex.Message}");
                throw;
            }
        }

        [When(@"I enter the URL ""(.*)"" in the address bar and press Enter")]
        [When(@"I enter the website URL ""(.*)"" in the address bar and press Enter")]
        public void WhenIEnterTheURLInTheAddressBar(string url)
        {
            try
            {
                LogHelper.Info($"Navigating to URL: {url}");
                homePage.NavigateToHomePage(url);
                scenarioContext["NavigatedUrl"] = url;
                LogHelper.Info("URL navigation completed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Navigation failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "NavigationFailure");
                throw;
            }
        }

        [Then(@"Browser launches successfully")]
        [Then(@"Browser opens successfully")]
        public void ThenBrowserLaunchesSuccessfully()
        {
            try
            {
                LogHelper.Info("Verifying browser launched successfully");
                Assert.That(Driver, Is.Not.Null, "Browser driver should not be null");
                Assert.That(Driver.WindowHandles.Count, Is.GreaterThan(0), "Browser should have at least one window open");
                LogHelper.Info("Browser launch verification passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Browser launch verification failed: {ex.Message}");
                throw;
            }
        }

        [Then(@"Golden 1 homepage loads")]
        [Then(@"Golden 1 homepage loads successfully")]
        [Then(@"Homepage loads successfully")]
        [Then(@"Golden 1 homepage begins to load")]
        public void ThenGolden1HomepageLoads()
        {
            try
            {
                LogHelper.Info("Verifying Golden 1 homepage loads");
                bool isLoaded = homePage.IsHomePageLoadedWithoutErrors();
                Assert.That(isLoaded, Is.True, "Golden 1 homepage should load successfully");
                LogHelper.Info("Homepage loaded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomePageLoadFailure");
                throw;
            }
        }

        [Then(@"Homepage is visible and fully loaded")]
        [Then(@"Homepage is displayed without errors")]
        [Then(@"Homepage is displayed without loading errors")]
        public void ThenHomepageIsVisibleAndFullyLoaded()
        {
            try
            {
                LogHelper.Info("Verifying homepage is visible and fully loaded");
                bool isDisplayed = homePage.IsHomePageDisplayed();
                bool isLoadedWithoutErrors = homePage.IsHomePageLoadedWithoutErrors();
                
                Assert.That(isDisplayed, Is.True, "Homepage should be visible");
                Assert.That(isLoadedWithoutErrors, Is.True, "Homepage should be loaded without errors");
                LogHelper.Info("Homepage visibility and load verification passed");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage visibility verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomePageVisibilityFailure");
                throw;
            }
        }

        [When(@"I verify that the homepage is displayed without any loading errors")]
        [When(@"I observe the homepage for any error messages or broken sections")]
        [When(@"I observe the homepage for successful loading")]
        [When(@"I wait for the homepage to fully load")]
        public void WhenIVerifyHomepageDisplayedWithoutErrors()
        {
            try
            {
                LogHelper.Info("Checking homepage for errors");
                bool isLoadedWithoutErrors = homePage.IsHomePageLoadedWithoutErrors();
                scenarioContext["HomePageLoadStatus"] = isLoadedWithoutErrors;
                LogHelper.Info($"Homepage load status: {isLoadedWithoutErrors}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage error check failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "HomePageErrorCheck");
                throw;
            }
        }

        [Then(@"No error messages or broken sections are displayed")]
        public void ThenNoErrorMessagesOrBrokenSectionsAreDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying no error messages or broken sections");
                bool loadStatus = scenarioContext.ContainsKey("HomePageLoadStatus") ? 
                                  (bool)scenarioContext["HomePageLoadStatus"] : 
                                  homePage.IsHomePageLoadedWithoutErrors();
                
                Assert.That(loadStatus, Is.True, "Homepage should not display error messages or broken sections");
                LogHelper.Info("No errors or broken sections found");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error message verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "ErrorMessageCheck");
                throw;
            }
        }
    }
}