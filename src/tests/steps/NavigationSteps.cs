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

        [Given(@"I navigate to the Golden1 homepage")]
        public void GivenINavigateToTheGolden1Homepage()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            _driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
            WaitHelper.WaitForPageLoad(_driver);
        }

        [Then(@"the homepage should be displayed without errors")]
        public void ThenTheHomepageShouldBeDisplayedWithoutErrors()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains("golden1.com"), "Homepage URL does not contain expected domain");
            
            Assert.IsTrue(_navigationPage.IsLogoVisible(), "Golden 1 logo is not visible");
        }

        [Then(@"the main navigation menu should be visible at the top")]
        public void ThenTheMainNavigationMenuShouldBeVisibleAtTheTop()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            
            Assert.IsTrue(_navigationPage.IsTopNavBarVisible(), "Main navigation menu is not visible");
        }

        [Then(@"the ""(.*)"" menu option should be present")]
        public void ThenTheMenuOptionShouldBePresent(string menuOption)
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            
            bool isPresent = false;
            switch (menuOption)
            {
                case "Personal":
                    isPresent = _navigationPage.IsPersonalMenuVisible();
                    break;
                case "Business":
                    isPresent = _navigationPage.IsBusinessMenuVisible();
                    break;
                case "Financial Wellness":
                    isPresent = _navigationPage.IsFinancialWellnessMenuVisible();
                    break;
                case "Appointments":
                    isPresent = _navigationPage.IsAppointmentsMenuVisible();
                    break;
                case "Locations":
                    isPresent = _navigationPage.IsLocationsMenuVisible();
                    break;
                case "Membership":
                    isPresent = _navigationPage.IsMembershipMenuVisible();
                    break;
                case "Help Center":
                    isPresent = _navigationPage.IsHelpCenterMenuVisible();
                    break;
            }
            
            Assert.IsTrue(isPresent, $"{menuOption} menu option is not present");
        }

        [Then(@"the Golden 1 logo should be visible in the top section")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopSection()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            
            Assert.IsTrue(_navigationPage.IsLogoVisible(), "Golden 1 logo is not visible in the top section");
        }

        [Then(@"no error messages should be displayed")]
        public void ThenNoErrorMessagesShouldBeDisplayed()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            
            string pageSource = _driver.PageSource.ToLower();
            Assert.IsFalse(pageSource.Contains("error") || pageSource.Contains("404") || pageSource.Contains("500"), 
                "Error messages detected on the page");
        }

        [Then(@"the ""(.*)"" option should be visible")]
        public void ThenTheOptionShouldBeVisible(string option)
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            
            bool isVisible = false;
            if (option == "Open Account")
            {
                isVisible = _navigationPage.IsOpenAccountButtonVisible();
            }
            
            Assert.IsTrue(isVisible, $"{option} option is not visible");
        }

        [Then(@"the ""(.*)"" button should be visible")]
        public void ThenTheButtonShouldBeVisible(string button)
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            
            bool isVisible = false;
            if (button == "Login")
            {
                isVisible = _navigationPage.IsLoginButtonVisible();
            }
            
            Assert.IsTrue(isVisible, $"{button} button is not visible");
        }

        [Then(@"the main banner should be visible on the homepage")]
        public void ThenTheMainBannerShouldBeVisibleOnTheHomepage()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            
            Assert.IsTrue(_navigationPage.IsHeroBannerVisible(), "Main banner (hero section) is not visible");
        }
    }
}