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
        
        [Given(@"I launch a supported browser")]
        [When(@"I launch a supported browser")]
        public void GivenILaunchASupportedBrowser()
        {
            try
            {
                LogHelper.Info("Browser launch step - Browser already initialized by DriverManager");
                Assert.That(Driver, Is.Not.Null, "Browser driver should be initialized");
                LogHelper.Info("Browser launched successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify browser launch: {ex.Message}");
                throw;
            }
        }
        
        [When(@"I navigate to the Golden 1 website '(.*)'")]
        [When(@"I enter the website URL '(.*)' and press Enter")]
        [Given(@"I navigate to the Golden 1 website '(.*)'")]
        public void WhenINavigateToTheGolden1Website(string url)
        {
            try
            {
                LogHelper.Info($"Navigating to Golden 1 website: {url}");
                homePage.NavigateToHomePage(url);
                scenarioContext["WebsiteURL"] = url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to website: {ex.Message}");
                throw;
            }
        }
        
        [Then(@"the browser should open successfully")]
        [Then(@"the browser launches successfully")]
        [Then(@"the browser is launched successfully")]
        public void ThenTheBrowserShouldOpenSuccessfully()
        {
            try
            {
                LogHelper.Info("Verifying browser opened successfully");
                Assert.That(Driver, Is.Not.Null, "Browser should be open");
                Assert.That(Driver.WindowHandles.Count, Is.GreaterThan(0), "Browser window should be available");
                LogHelper.Info("Browser opened successfully - Verified");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Browser verification failed: {ex.Message}");
                throw;
            }
        }
        
        [Then(@"the Golden 1 homepage should load")]
        [Then(@"the Golden 1 homepage loads")]
        [Then(@"the Golden 1 homepage loads successfully")]
        [Then(@"the Golden 1 homepage loads without errors")]
        [Then(@"the Golden 1 homepage loads without delay")]
        public void ThenTheGolden1HomepageShouldLoad()
        {
            try
            {
                LogHelper.Info("Verifying Golden 1 homepage loaded");
                bool isLoaded = homePage.IsHomePageLoadedWithoutErrors();
                Assert.That(isLoaded, Is.True, "Golden 1 homepage should load without errors");
                LogHelper.Info("Golden 1 homepage loaded successfully - Verified");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                throw;
            }
        }
        
        [Then(@"the homepage should be visible and accessible")]
        [Then(@"the homepage is visible and accessible")]
        [Then(@"the homepage is visible and fully loaded")]
        [Then(@"the homepage is displayed without errors")]
        public void ThenTheHomepageShouldBeVisibleAndAccessible()
        {
            try
            {
                LogHelper.Info("Verifying homepage is visible and accessible");
                bool isDisplayed = homePage.IsHomePageDisplayed();
                bool isFullyLoaded = homePage.IsPageFullyLoaded();
                
                Assert.That(isDisplayed, Is.True, "Homepage should be visible");
                Assert.That(isFullyLoaded, Is.True, "Homepage should be fully loaded");
                LogHelper.Info("Homepage is visible and accessible - Verified");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage visibility verification failed: {ex.Message}");
                throw;
            }
        }
        
        [Then(@"the URL should be entered in the address bar")]
        public void ThenTheURLShouldBeEnteredInTheAddressBar()
        {
            try
            {
                LogHelper.Info("Verifying URL is in address bar");
                string currentUrl = homePage.GetCurrentUrl();
                string expectedUrl = scenarioContext["WebsiteURL"].ToString();
                
                Assert.That(currentUrl, Does.Contain("golden1.com"), "URL should contain golden1.com");
                LogHelper.Info($"URL verified in address bar: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                throw;
            }
        }
        
        [Then(@"the homepage should load without errors")]
        [When(@"I press Enter to load the website")]
        public void ThenTheHomepageShouldLoadWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage loads without errors");
                bool isLoaded = homePage.IsHomePageLoadedWithoutErrors();
                Assert.That(isLoaded, Is.True, "Homepage should load without errors");
                LogHelper.Info("Homepage loaded without errors - Verified");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage error check failed: {ex.Message}");
                throw;
            }
        }
        
        [Then(@"the homepage should display all expected elements")]
        [Then(@"the homepage is displayed with all expected elements")]
        public void ThenTheHomepageShouldDisplayAllExpectedElements()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays all expected elements");
                bool elementsPresent = homePage.VerifyExpectedElements();
                Assert.That(elementsPresent, Is.True, "Homepage should display header, navigation menu, and logo");
                LogHelper.Info("All expected elements present - Verified");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Expected elements verification failed: {ex.Message}");
                throw;
            }
        }
        
        [Then(@"no error messages should be displayed")]
        [Then(@"no errors or broken sections are displayed")]
        public void ThenNoErrorMessagesShouldBeDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying no error messages are displayed");
                bool noErrors = homePage.IsHomePageLoadedWithoutErrors();
                Assert.That(noErrors, Is.True, "No error messages should be displayed on homepage");
                LogHelper.Info("No error messages displayed - Verified");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error message check failed: {ex.Message}");
                throw;
            }
        }
        
        [When(@"I observe the homepage for successful loading")]
        [When(@"I observe if the homepage is displayed without delay")]
        [When(@"I verify that the homepage is displayed without any errors")]
        [When(@"I observe the page for successful loading without errors")]
        [When(@"I observe the page for any loading errors or broken sections")]
        [When(@"I verify that the homepage displays expected content")]
        [When(@"I verify that the homepage is displayed without any loading errors")]
        [When(@"I observe the page load and verify that no error messages are displayed")]
        public void WhenIObserveTheHomepageForSuccessfulLoading()
        {
            try
            {
                LogHelper.Info("Observing homepage for successful loading");
                bool isLoaded = homePage.IsPageFullyLoaded();
                bool noErrors = homePage.IsHomePageLoadedWithoutErrors();
                
                scenarioContext["PageLoaded"] = isLoaded;
                scenarioContext["NoErrors"] = noErrors;
                LogHelper.Info($"Homepage observation complete - Loaded: {isLoaded}, No Errors: {noErrors}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage observation failed: {ex.Message}");
                throw;
            }
        }
    }
}