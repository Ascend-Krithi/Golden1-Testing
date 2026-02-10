using NUnit.Framework;
using OpenQA.Selenium;
using Project1.Automation.Drivers;
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
        private readonly ScenarioContext _scenarioContext;

        public HomePageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Driver = DriverManager.GetDriver();
            homePage = new HomePage(Driver);
        }

        [Given(@"I launch a supported browser")]
        [Given(@"I launch a compatible browser")]
        [Given(@"I launch a supported web browser")]
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

        [When(@"I enter the website URL '(.*)' in the address bar and press Enter")]
        [When(@"I enter the URL (.*) in the address bar and press Enter")]
        [When(@"I enter https://www.golden1.com/ in the address bar and press Enter")]
        [When(@"I enter the website URL https://www.golden1.com/ in the address bar")]
        public void WhenIEnterTheWebsiteURL(string url)
        {
            try
            {
                LogHelper.Info($"Navigating to URL: {url}");
                homePage.NavigateToHomePage(url);
                _scenarioContext["NavigatedURL"] = url;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to navigate to URL: {ex.Message}");
                throw;
            }
        }

        [When(@"I press Enter to load the website")]
        public void WhenIPressEnterToLoadTheWebsite()
        {
            try
            {
                LogHelper.Info("Waiting for page to load after pressing Enter");
                WaitHelper.WaitForPageLoad(Driver);
                LogHelper.Info("Page loaded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed while waiting for page load: {ex.Message}");
                throw;
            }
        }

        [Then(@"Browser opens successfully")]
        [Then(@"Browser launches successfully")]
        [Then(@"Browser is launched successfully")]
        public void ThenBrowserOpensSuccessfully()
        {
            try
            {
                LogHelper.Info("Verifying browser opened successfully");
                Assert.That(Driver, Is.Not.Null, "Browser should be open and driver should not be null");
                Assert.That(Driver.WindowHandles.Count, Is.GreaterThan(0), "At least one browser window should be open");
                LogHelper.Info("Browser verification successful");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Browser verification failed: {ex.Message}");
                throw;
            }
        }

        [Then(@"Golden 1 homepage loads")]
        [Then(@"Golden 1 homepage loads without delay")]
        [Then(@"Golden 1 homepage loads successfully")]
        [Then(@"Golden 1 homepage loads without errors")]
        public void ThenGolden1HomepageLoads()
        {
            try
            {
                LogHelper.Info("Verifying Golden 1 homepage loads");
                WaitHelper.WaitForPageLoad(Driver);
                
                string currentUrl = homePage.GetCurrentUrl();
                Assert.That(currentUrl, Does.Contain("golden1.com"), "URL should contain golden1.com");
                
                bool isDisplayed = homePage.IsHomePageDisplayed();
                Assert.That(isDisplayed, Is.True, "Homepage should be displayed");
                
                LogHelper.Info("Golden 1 homepage loaded successfully");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage load verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "Homepage_Load_Failed");
                throw;
            }
        }

        [Then(@"Homepage is visible and accessible")]
        [Then(@"Homepage is visible and fully loaded")]
        [Then(@"Homepage is displayed without errors")]
        [Then(@"Homepage is displayed without any loading errors")]
        public void ThenHomepageIsVisibleAndAccessible()
        {
            try
            {
                LogHelper.Info("Verifying homepage is visible and accessible");
                
                bool isDisplayed = homePage.IsHomePageDisplayed();
                Assert.That(isDisplayed, Is.True, "Homepage should be visible");
                
                bool noErrors = homePage.IsHomePageLoadedWithoutErrors();
                Assert.That(noErrors, Is.True, "Homepage should load without errors");
                
                LogHelper.Info("Homepage is visible and accessible");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage visibility verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "Homepage_Visibility_Failed");
                throw;
            }
        }

        [Then(@"URL is entered in the address bar")]
        public void ThenURLIsEnteredInTheAddressBar()
        {
            try
            {
                LogHelper.Info("Verifying URL is entered in address bar");
                string currentUrl = homePage.GetCurrentUrl();
                Assert.That(currentUrl, Is.Not.Null.And.Not.Empty, "URL should be present in address bar");
                LogHelper.Info($"URL verified in address bar: {currentUrl}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"URL verification failed: {ex.Message}");
                throw;
            }
        }

        [Then(@"Homepage loads without errors")]
        public void ThenHomepageLoadsWithoutErrors()
        {
            try
            {
                LogHelper.Info("Verifying homepage loads without errors");
                WaitHelper.WaitForPageLoad(Driver);
                
                bool noErrors = homePage.VerifyNoLoadingErrors();
                Assert.That(noErrors, Is.True, "Homepage should load without any errors");
                
                LogHelper.Info("Homepage loaded without errors");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "Homepage_Error_Check_Failed");
                throw;
            }
        }

        [Then(@"Homepage is displayed with all expected elements")]
        public void ThenHomepageIsDisplayedWithAllExpectedElements()
        {
            try
            {
                LogHelper.Info("Verifying homepage displays all expected elements");
                
                bool elementsPresent = homePage.VerifyHomePageElements();
                Assert.That(elementsPresent, Is.True, "All expected homepage elements should be present");
                
                LogHelper.Info("All expected elements verified on homepage");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage elements verification failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "Homepage_Elements_Failed");
                throw;
            }
        }

        [Then(@"No errors or broken sections are displayed")]
        [Then(@"No error messages are displayed; homepage is visible")]
        [Then(@"Homepage is displayed without delays or loading errors")]
        public void ThenNoErrorsOrBrokenSectionsAreDisplayed()
        {
            try
            {
                LogHelper.Info("Verifying no errors or broken sections are displayed");
                
                bool noErrors = homePage.VerifyNoLoadingErrors();
                Assert.That(noErrors, Is.True, "No error messages should be displayed");
                
                bool isDisplayed = homePage.IsHomePageDisplayed();
                Assert.That(isDisplayed, Is.True, "Homepage should be visible without broken sections");
                
                LogHelper.Info("No errors or broken sections found");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Error/broken section check failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "Error_Check_Failed");
                throw;
            }
        }

        [When(@"I observe if the homepage is displayed without delay")]
        [When(@"I verify that the homepage is displayed without any errors")]
        [When(@"I observe the page for successful loading without errors")]
        [When(@"I observe the page load and verify that no error messages are displayed")]
        [When(@"I verify that the homepage is displayed without errors")]
        [When(@"I observe the page loading process")]
        [When(@"I observe the page for any loading errors or broken sections")]
        [When(@"I verify that the homepage displays expected content \(header, navigation menu, logo, etc.\)")]
        [When(@"I observe the page load process")]
        public void WhenIObserveHomepageDisplay()
        {
            try
            {
                LogHelper.Info("Observing homepage display and verifying load status");
                WaitHelper.WaitForPageLoad(Driver);
                
                bool isLoaded = homePage.IsHomePageLoadedWithoutErrors();
                _scenarioContext["HomepageLoadedSuccessfully"] = isLoaded;
                
                LogHelper.Info($"Homepage observation complete. Load status: {isLoaded}");
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Homepage observation failed: {ex.Message}");
                throw;
            }
        }
    }
}