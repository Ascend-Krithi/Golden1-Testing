using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using AutomationFramework.Pages;
using AutomationFramework.Utilities;

namespace AutomationFramework.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private NavigationPage _navigationPage;
        private HomePage _homePage;

        public NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to the Golden1 homepage")]
        public void GivenINavigateToTheGolden1Homepage()
        {
            _driver = (IWebDriver)_scenarioContext["Driver"];
            _navigationPage = new NavigationPage(_driver);
            _homePage = new HomePage(_driver);
            
            string baseUrl = ConfigReader.BaseUrl;
            _driver.Navigate().GoToUrl(baseUrl);
            WaitHelper.WaitForPageLoad(_driver);
        }

        [Then(@"the Golden1 homepage should be displayed")]
        public void ThenTheGolden1HomepageShouldBeDisplayed()
        {
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains("golden1.com"), "Homepage URL validation failed");
        }

        [Then(@"the main navigation menu should be visible")]
        public void ThenTheMainNavigationMenuShouldBeVisible()
        {
            Assert.IsTrue(_navigationPage.IsTopNavBarVisible(), "Main navigation menu is not visible");
        }

        [Then(@"the ""(.*)"" menu option should be visible")]
        public void ThenTheMenuOptionShouldBeVisible(string menuOption)
        {
            Assert.IsTrue(_navigationPage.IsMenuOptionVisible(menuOption), $"{menuOption} menu option is not visible");
        }

        [Then(@"the Golden1 logo should be visible")]
        public void ThenTheGolden1LogoShouldBeVisible()
        {
            Assert.IsTrue(_navigationPage.IsLogoVisible(), "Golden1 logo is not visible");
        }

        [Then(@"the homepage should load without broken sections")]
        public void ThenTheHomepageShouldLoadWithoutBrokenSections()
        {
            Assert.IsTrue(_homePage.IsHeroBannerDisplayed(), "Hero banner is not displayed - possible broken section");
            Assert.IsTrue(_homePage.IsFeaturedProductSectionDisplayed(), "Featured product section is not displayed - possible broken section");
        }

        [Then(@"no error messages should be displayed")]
        public void ThenNoErrorMessagesShouldBeDisplayed()
        {
            Assert.IsTrue(_homePage.NoErrorMessagesPresent(), "Error messages are displayed on the page");
        }

        [When(@"I click on the ""(.*)"" menu option")]
        public void WhenIClickOnTheMenuOption(string menuOption)
        {
            _navigationPage.ClickMenuOption(menuOption);
            WaitHelper.WaitForPageLoad(_driver);
        }

        [Then(@"the URL should contain ""(.*)""")]
        public void ThenTheURLShouldContain(string expectedUrlPart)
        {
            string currentUrl = _driver.Url.ToLower();
            Assert.That(currentUrl.Contains(expectedUrlPart.ToLower()), $"URL does not contain expected part: {expectedUrlPart}");
        }

        [Then(@"I navigate back to the homepage")]
        public void ThenINavigateBackToTheHomepage()
        {
            _navigationPage.ClickLogo();
            WaitHelper.WaitForPageLoad(_driver);
        }

        [Then(@"the hero banner should be displayed")]
        public void ThenTheHeroBannerShouldBeDisplayed()
        {
            Assert.IsTrue(_homePage.IsHeroBannerDisplayed(), "Hero banner is not displayed");
        }

        [Then(@"the featured product section should be displayed")]
        public void ThenTheFeaturedProductSectionShouldBeDisplayed()
        {
            Assert.IsTrue(_homePage.IsFeaturedProductSectionDisplayed(), "Featured product section is not displayed");
        }
    }
}