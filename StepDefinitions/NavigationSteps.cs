using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Project1.Automation.Pages;
using Project1.Automation.Utilities;
using NUnit.Framework;

namespace Project1.Automation.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver Driver;
        private readonly HomePage homePage;
        private readonly PersonalPage personalPage;
        private readonly CheckingPage checkingPage;
        private readonly FooterPage footerPage;

        public NavigationSteps(IWebDriver driver)
        {
            Driver = driver;
            homePage = new HomePage(Driver);
            personalPage = new PersonalPage(Driver);
            checkingPage = new CheckingPage(Driver);
            footerPage = new FooterPage(Driver);
        }

        [Given(@"the user opens the Golden 1 website")]
        public void GivenTheUserOpensTheGolden1Website()
        {
            LogHelper.Info("Step: User opens the Golden 1 website");
            homePage.NavigateToHomePage();
        }

        [Then(@"the homepage should load successfully")]
        public void ThenTheHomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("Step: Verifying homepage loaded successfully");
            homePage.VerifyHomePageLoaded();
        }

        [Then(@"the user should see the top navigation menu")]
        public void ThenTheUserShouldSeeTheTopNavigationMenu()
        {
            LogHelper.Info("Step: Verifying top navigation menu is visible");
            bool isVisible = homePage.IsTopNavigationMenuVisible();
            Assert.That(isVisible, Is.True, "Top navigation menu is not visible");
        }

        [When(@"the user clicks on the Personal menu")]
        public void WhenTheUserClicksOnThePersonalMenu()
        {
            LogHelper.Info("Step: User clicks on Personal menu");
            homePage.ClickPersonalMenu();
        }

        [Then(@"the Personal section page should load")]
        public void ThenThePersonalSectionPageShouldLoad()
        {
            LogHelper.Info("Step: Verifying Personal section page loaded");
            personalPage.VerifyPersonalPageLoaded();
        }

        [Then(@"the user should see submenu options")]
        public void ThenTheUserShouldSeeSubmenuOptions()
        {
            LogHelper.Info("Step: Verifying submenu options are visible");
            bool areVisible = personalPage.AreSubmenuOptionsVisible();
            Assert.That(areVisible, Is.True, "Submenu options are not visible");
        }

        [When(@"the user selects the Checking submenu")]
        public void WhenTheUserSelectsTheCheckingSubmenu()
        {
            LogHelper.Info("Step: User selects Checking submenu");
            personalPage.ClickCheckingSubmenu();
        }

        [Then(@"the Checking page should open")]
        public void ThenTheCheckingPageShouldOpen()
        {
            LogHelper.Info("Step: Verifying Checking page opened");
            checkingPage.VerifyCheckingPageLoaded();
        }

        [Then(@"the page should display the page heading")]
        public void ThenThePageShouldDisplayThePageHeading()
        {
            LogHelper.Info("Step: Verifying page heading is displayed");
            string heading = checkingPage.GetPageHeading();
            Assert.That(string.IsNullOrEmpty(heading), Is.False, "Page heading is not displayed");
        }

        [Then(@"the page should display section content")]
        public void ThenThePageShouldDisplaySectionContent()
        {
            LogHelper.Info("Step: Verifying section content is displayed");
            checkingPage.VerifyPageContentDisplayed();
        }

        [Then(@"the page should display product information")]
        public void ThenThePageShouldDisplayProductInformation()
        {
            LogHelper.Info("Step: Verifying product information is displayed");
            bool isVisible = checkingPage.IsProductInformationVisible();
            Assert.That(isVisible, Is.True, "Product information is not visible");
        }

        [When(@"the user clicks Log In button")]
        public void WhenTheUserClicksLogInButton()
        {
            LogHelper.Info("Step: User clicks Log In button");
            homePage.ClickLoginButton();
        }

        [When(@"the user clicks Open Account button")]
        public void WhenTheUserClicksOpenAccountButton()
        {
            LogHelper.Info("Step: User clicks Open Account button");
            homePage.ClickOpenAccountButton();
        }

        [Then(@"the user should see the footer section")]
        public void ThenTheUserShouldSeeTheFooterSection()
        {
            LogHelper.Info("Step: Verifying footer section is visible");
            footerPage.VerifyFooterSectionVisible();
        }

        [Then(@"the footer should contain contact information")]
        public void ThenTheFooterShouldContainContactInformation()
        {
            LogHelper.Info("Step: Verifying contact information in footer");
            bool isVisible = footerPage.IsContactInformationVisible();
            Assert.That(isVisible, Is.True, "Contact information is not visible in footer");
        }
    }
}