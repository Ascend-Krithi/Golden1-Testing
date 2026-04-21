using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using [ProjectNamespace].Pages;
using [ProjectNamespace].Utilities;

namespace [ProjectNamespace].Steps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly CheckingPage _checkingPage;
        private readonly FreeCheckingPage _freeCheckingPage;
        
        public NavigationSteps(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
            _checkingPage = new CheckingPage(_driver);
            _freeCheckingPage = new FreeCheckingPage(_driver);
        }
        
        [Given(@"I am on the Golden1 homepage")]
        public void GivenIAmOnTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden1 homepage");
            string baseUrl = ConfigReader.GetValue("BaseUrl");
            _driver.Navigate().GoToUrl(baseUrl);
            WaitHelper.WaitForPageLoad(_driver);
            LogHelper.Info("Successfully loaded homepage");
        }
        
        [When(@"I click on Checking menu")]
        public void WhenIClickOnCheckingMenu()
        {
            LogHelper.Info("Clicking on Checking menu");
            _homePage.ClickCheckingMenu();
            LogHelper.Info("Checking menu clicked");
        }
        
        [When(@"I click on Free Checking link")]
        public void WhenIClickOnFreeCheckingLink()
        {
            LogHelper.Info("Clicking on Free Checking link");
            _checkingPage.ClickFreeCheckingLink();
            LogHelper.Info("Free Checking link clicked");
        }
        
        [Then(@"I should see the Free Checking page")]
        public void ThenIShouldSeeTheFreeCheckingPage()
        {
            LogHelper.Info("Verifying Free Checking page is displayed");
            WaitHelper.WaitForPageLoad(_driver);
            bool isDisplayed = _freeCheckingPage.IsFreeCheckingPageDisplayed();
            Assert.IsTrue(isDisplayed, "Free Checking page was not displayed");
            LogHelper.Info("Free Checking page verified successfully");
        }
    }
}