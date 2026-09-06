using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;
using System.Linq;
using Golden1.Automation.Pages;
using Golden1.Automation.Helpers;
using OpenQA.Selenium;

namespace Golden1.Automation.Steps
{
    [Binding]
    public class Golden1HomepageSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly NavigationPage _navigationPage;
        private readonly CheckingPage _checkingPage;
        private readonly SavingsPage _savingsPage;
        private readonly LoansPage _loansPage;
        private readonly LoginPage _loginPage;
        private readonly OpenAccountPage _openAccountPage;
        private readonly ScenarioContext _scenarioContext;

        public Golden1HomepageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _homePage = new HomePage(_driver);
            _navigationPage = new NavigationPage(_driver);
            _checkingPage = new CheckingPage(_driver);
            _savingsPage = new SavingsPage(_driver);
            _loansPage = new LoansPage(_driver);
            _loginPage = new LoginPage(_driver);
            _openAccountPage = new OpenAccountPage(_driver);
        }

        [Given(@"I launch the browser and navigate to Golden1 homepage")]
        public void GivenILaunchTheBrowserAndNavigateToGolden1Homepage()
        {
            LogHelper.Info("Launching browser and navigating to Golden1 homepage");
            string url = ConfigReader.GetValue("ApplicationURL");
            _driver.Navigate().GoToUrl(url);
            _homePage.HandleCookieBanner();
            LogHelper.Info($"Successfully navigated to {url}");
        }

        [Given(@"I am on the Golden1 homepage")]
        public void GivenIAmOnTheGolden1Homepage()
        {
            LogHelper.Info("Verifying user is on Golden1 homepage");
            string url = ConfigReader.GetValue("ApplicationURL");
            if (!_driver.Url.Contains("golden1.com"))
            {
                _driver.Navigate().GoToUrl(url);
                _homePage.HandleCookieBanner();
            }
            LogHelper.Info("User is on Golden1 homepage");
        }

        [When(@"the homepage loads")]
        public void WhenTheHomepageLoads()
        {
            LogHelper.Info("Waiting for homepage to load completely");
            WaitHelper.WaitForPageLoad(_driver);
            LogHelper.Info("Homepage loaded successfully");
        }

        [Then(@"I should see the Golden1 logo")]
        public void ThenIShouldSeeTheGolden1Logo()
        {
            LogHelper.Info("Verifying Golden1 logo is displayed");
            bool isLogoDisplayed = _homePage.IsLogoDisplayed();
            Assert.IsTrue(isLogoDisplayed, "Golden1 logo is not displayed on the homepage");
            LogHelper.Info("Golden1 logo is displayed successfully");
        }

        [Then(@"I should see the top navigation menu")]
        public void ThenIShouldSeeTheTopNavigationMenu()
        {
            LogHelper.Info("Verifying top navigation menu is displayed");
            bool isMenuDisplayed = _navigationPage.IsTopNavigationMenuDisplayed();
            Assert.IsTrue(isMenuDisplayed, "Top navigation menu is not displayed");
            LogHelper.Info("Top navigation menu is displayed successfully");
        }

        [Then(@"I should see Login and Open Account options")]
        public void ThenIShouldSeeLoginAndOpenAccountOptions()
        {
            LogHelper.Info("Verifying Login and Open Account options are displayed");
            bool isLoginDisplayed = _homePage.IsLoginButtonDisplayed();
            bool isOpenAccountDisplayed = _homePage.IsOpenAccountButtonDisplayed();
            Assert.IsTrue(isLoginDisplayed, "Login button is not displayed");
            Assert.IsTrue(isOpenAccountDisplayed, "Open Account button is not displayed");
            LogHelper.Info("Login and Open Account options are displayed successfully");
        }

        [Then(@"I should see the main banner")]
        public void ThenIShouldSeeTheMainBanner()
        {
            LogHelper.Info("Verifying main banner is displayed");
            bool isBannerDisplayed = _homePage.IsMainBannerDisplayed();
            Assert.IsTrue(isBannerDisplayed, "Main banner is not displayed on the homepage");
            LogHelper.Info("Main banner is displayed successfully");
        }

        [When(@"I view the top navigation menu")]
        public void WhenIViewTheTopNavigationMenu()
        {
            LogHelper.Info("Viewing the top navigation menu");
            _navigationPage.WaitForNavigationMenuToLoad();
            LogHelper.Info("Top navigation menu is visible");
        }

        [Then(@"I should see the following navigation options:")]
        public void ThenIShouldSeeTheFollowingNavigationOptions(Table table)
        {
            LogHelper.Info("Verifying all navigation options are present");
            var expectedOptions = table.Rows.Select(row => row[0]).ToList();
            
            foreach (var option in expectedOptions)
            {
                LogHelper.Info($"Checking for navigation option: {option}");
                bool isOptionDisplayed = _navigationPage.IsNavigationOptionDisplayed(option);
                Assert.IsTrue(isOptionDisplayed, $"Navigation option '{option}' is not displayed");
                LogHelper.Info($"Navigation option '{option}' is displayed");
            }
            
            LogHelper.Info("All navigation options are present");
        }

        [When(@"I click on the Personal tab in the top navigation menu")]
        [When(@"I click on the Personal tab")]
        public void WhenIClickOnThePersonalTabInTheTopNavigationMenu()
        {
            LogHelper.Info("Clicking on Personal tab in the top navigation menu");
            _navigationPage.ClickPersonalTab();
            LogHelper.Info("Clicked on Personal tab successfully");
        }

        [Then(@"the Personal section page should load successfully")]
        public void ThenThePersonalSectionPageShouldLoadSuccessfully()
        {
            LogHelper.Info("Verifying Personal section page loaded successfully");
            WaitHelper.WaitForPageLoad(_driver);
            bool isPersonalSectionDisplayed = _navigationPage.IsPersonalSectionDisplayed();
            Assert.IsTrue(isPersonalSectionDisplayed, "Personal section page did not load successfully");
            LogHelper.Info("Personal section page loaded successfully");
        }

        [When(@"I select Checking from the submenu")]
        public void WhenISelectCheckingFromTheSubmenu()
        {
            LogHelper.Info("Selecting Checking from the submenu");
            _navigationPage.ClickCheckingMenu();
            LogHelper.Info("Clicked on Checking submenu successfully");
        }

        [Then(@"the Checking page should open with correct content")]
        public void ThenTheCheckingPageShouldOpenWithCorrectContent()
        {
            LogHelper.Info("Verifying Checking page opened with correct content");
            WaitHelper.WaitForPageLoad(_driver);
            bool isCheckingPageDisplayed = _checkingPage.IsCheckingPageDisplayed();
            Assert.IsTrue(isCheckingPageDisplayed, "Checking page did not open correctly");
            LogHelper.Info("Checking page opened with correct content");
        }

        [When(@"I navigate back to homepage")]
        public void WhenINavigateBackToHomepage()
        {
            LogHelper.Info("Navigating back to homepage");
            string url = ConfigReader.GetValue("ApplicationURL");
            _driver.Navigate().GoToUrl(url);
            WaitHelper.WaitForPageLoad(_driver);
            LogHelper.Info("Navigated back to homepage successfully");
        }

        [When(@"I select Savings from the submenu")]
        public void WhenISelectSavingsFromTheSubmenu()
        {
            LogHelper.Info("Selecting Savings from the submenu");
            _navigationPage.ClickSavingsMenu();
            LogHelper.Info("Clicked on Savings submenu successfully");
        }

        [Then(@"the Savings page should open with correct content")]
        public void ThenTheSavingsPageShouldOpenWithCorrectContent()
        {
            LogHelper.Info("Verifying Savings page opened with correct content");
            WaitHelper.WaitForPageLoad(_driver);
            bool isSavingsPageDisplayed = _savingsPage.IsSavingsPageDisplayed();
            Assert.IsTrue(isSavingsPageDisplayed, "Savings page did not open correctly");
            LogHelper.Info("Savings page opened with correct content");
        }

        [When(@"I select Loans from the submenu")]
        public void WhenISelectLoansFromTheSubmenu()
        {
            LogHelper.Info("Selecting Loans from the submenu");
            _navigationPage.ClickLoansMenu();
            LogHelper.Info("Clicked on Loans submenu successfully");
        }

        [Then(@"the Loans page should open with correct content")]
        public void ThenTheLoansPageShouldOpenWithCorrectContent()
        {
            LogHelper.Info("Verifying Loans page opened with correct content");
            WaitHelper.WaitForPageLoad(_driver);
            bool isLoansPageDisplayed = _loansPage.IsLoansPageDisplayed();
            Assert.IsTrue(isLoansPageDisplayed, "Loans page did not open correctly");
            LogHelper.Info("Loans page opened with correct content");
        }

        [Then(@"I should see the page heading")]
        public void ThenIShouldSeeThePageHeading()
        {
            LogHelper.Info("Verifying page heading is displayed");
            bool isHeadingDisplayed = _checkingPage.IsPageHeadingDisplayed();
            Assert.IsTrue(isHeadingDisplayed, "Page heading is not displayed");
            LogHelper.Info("Page heading is displayed successfully");
        }

        [Then(@"I should see the section content")]
        public void ThenIShouldSeeTheSectionContent()
        {
            LogHelper.Info("Verifying section content is displayed");
            bool isContentDisplayed = _checkingPage.IsSectionContentDisplayed();
            Assert.IsTrue(isContentDisplayed, "Section content is not displayed");
            LogHelper.Info("Section content is displayed successfully");
        }

        [Then(@"I should see product or service information")]
        public void ThenIShouldSeeProductOrServiceInformation()
        {
            LogHelper.Info("Verifying product or service information is displayed");
            bool isProductInfoDisplayed = _checkingPage.IsProductInformationDisplayed();
            Assert.IsTrue(isProductInfoDisplayed, "Product or service information is not displayed");
            LogHelper.Info("Product or service information is displayed successfully");
        }

        [When(@"I click on Log In button")]
        public void WhenIClickOnLogInButton()
        {
            LogHelper.Info("Clicking on Log In button");
            _homePage.ClickLoginButton();
            LogHelper.Info("Clicked on Log In button successfully");
        }

        [Then(@"the online banking login page should be displayed")]
        public void ThenTheOnlineBankingLoginPageShouldBeDisplayed()
        {
            LogHelper.Info("Verifying online banking login page is displayed");
            WaitHelper.WaitForPageLoad(_driver);
            bool isLoginPageDisplayed = _loginPage.IsLoginPageDisplayed();
            Assert.IsTrue(isLoginPageDisplayed, "Online banking login page is not displayed");
            LogHelper.Info("Online banking login page is displayed successfully");
        }

        [When(@"I click on Open Account button")]
        public void WhenIClickOnOpenAccountButton()
        {
            LogHelper.Info("Clicking on Open Account button");
            _homePage.ClickOpenAccountButton();
            LogHelper.Info("Clicked on Open Account button successfully");
        }

        [Then(@"the account opening page should be initiated")]
        public void ThenTheAccountOpeningPageShouldBeInitiated()
        {
            LogHelper.Info("Verifying account opening page is initiated");
            WaitHelper.WaitForPageLoad(_driver);
            bool isOpenAccountPageDisplayed = _openAccountPage.IsOpenAccountPageDisplayed();
            Assert.IsTrue(isOpenAccountPageDisplayed, "Account opening page is not initiated");
            LogHelper.Info("Account opening page is initiated successfully");
        }

        [When(@"I scroll to the bottom of the page")]
        public void WhenIScrollToTheBottomOfThePage()
        {
            LogHelper.Info("Scrolling to the bottom of the page");
            _homePage.ScrollToFooter();
            LogHelper.Info("Scrolled to the bottom of the page successfully");
        }

        [Then(@"I should see the footer section")]
        public void ThenIShouldSeeTheFooterSection()
        {
            LogHelper.Info("Verifying footer section is displayed");
            bool isFooterDisplayed = _homePage.IsFooterDisplayed();
            Assert.IsTrue(isFooterDisplayed, "Footer section is not displayed");
            LogHelper.Info("Footer section is displayed successfully");
        }

        [Then(@"the footer should contain contact information")]
        public void ThenTheFooterShouldContainContactInformation()
        {
            LogHelper.Info("Verifying footer contains contact information");
            bool hasContactInfo = _homePage.FooterContainsContactInformation();
            Assert.IsTrue(hasContactInfo, "Footer does not contain contact information");
            LogHelper.Info("Footer contains contact information");
        }

        [Then(@"the footer should contain privacy policy link")]
        public void ThenTheFooterShouldContainPrivacyPolicyLink()
        {
            LogHelper.Info("Verifying footer contains privacy policy link");
            bool hasPrivacyPolicy = _homePage.FooterContainsPrivacyPolicy();
            Assert.IsTrue(hasPrivacyPolicy, "Footer does not contain privacy policy link");
            LogHelper.Info("Footer contains privacy policy link");
        }

        [Then(@"the footer should contain terms and conditions link")]
        public void ThenTheFooterShouldContainTermsAndConditionsLink()
        {
            LogHelper.Info("Verifying footer contains terms and conditions link");
            bool hasTermsAndConditions = _homePage.FooterContainsTermsAndConditions();
            Assert.IsTrue(hasTermsAndConditions, "Footer does not contain terms and conditions link");
            LogHelper.Info("Footer contains terms and conditions link");
        }
    }
}