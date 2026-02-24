using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;
using System.Linq;

namespace Golden1.Automation.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly HomePage _homePage;
        private readonly NavigationPage _navigationPage;
        private readonly CheckingPage _checkingPage;

        public NavigationSteps()
        {
            _homePage = new HomePage();
            _navigationPage = new NavigationPage();
            _checkingPage = new CheckingPage();
        }

        [Given(@"the user launches the browser")]
        public void GivenTheUserLaunchesTheBrowser()
        {
            LogHelper.Info("Browser launched successfully via DriverManager");
            // Browser is already initialized by Hooks.cs
        }

        [Given(@"the user is on the Golden1 homepage")]
        [When(@"the user navigates to the Golden1 homepage")]
        public void WhenTheUserNavigatesToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden1 homepage");
            _homePage.NavigateToHomepage();
            _homePage.HandleCookieBanner();
            LogHelper.Info("Successfully navigated to Golden1 homepage");
        }

        [Then(@"the homepage should load successfully")]
        public void ThenTheHomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("Verifying homepage loaded successfully");
            bool isLogoVisible = _homePage.IsLogoVisible();
            Assert.IsTrue(isLogoVisible, "Homepage did not load successfully - logo not visible");
            LogHelper.Info("Homepage loaded successfully");
        }

        [Then(@"no error messages should be displayed")]
        public void ThenNoErrorMessagesShouldBeDisplayed()
        {
            LogHelper.Info("Verifying no error messages are displayed");
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.IsFalse(hasErrors, "Error messages were found on the homepage");
            LogHelper.Info("No error messages displayed");
        }

        [Then(@"the global navigation menu should be visible at the top of the page")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfThePage()
        {
            LogHelper.Info("Verifying global navigation menu is visible");
            bool isMenuVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.IsTrue(isMenuVisible, "Global navigation menu is not visible");
            LogHelper.Info("Global navigation menu is visible");
        }

        [Then(@"the navigation menu should be visible")]
        public void ThenTheNavigationMenuShouldBeVisible()
        {
            LogHelper.Info("Verifying navigation menu is visible");
            bool isMenuVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.IsTrue(isMenuVisible, "Navigation menu is not visible");
            LogHelper.Info("Navigation menu is visible");
        }

        [Then(@"the menu should contain the following options:")]
        public void ThenTheMenuShouldContainTheFollowingOptions(Table table)
        {
            LogHelper.Info("Verifying menu contains all expected options");
            var expectedMenuOptions = table.Rows.Select(row => row["MenuOption"]).ToList();
            
            foreach (var menuOption in expectedMenuOptions)
            {
                LogHelper.Info($"Checking for menu option: {menuOption}");
                bool isOptionPresent = _navigationPage.IsTopMenuOptionPresent(menuOption);
                Assert.IsTrue(isOptionPresent, $"Menu option '{menuOption}' is not present");
                LogHelper.Info($"Menu option '{menuOption}' is present");
            }
            
            LogHelper.Info("All expected menu options are present");
        }

        [Then(@"the ""(.*)"" product menu should be displayed")]
        public void ThenTheProductMenuShouldBeDisplayed(string productMenu)
        {
            LogHelper.Info($"Verifying '{productMenu}' product menu is displayed");
            bool isMenuDisplayed = _navigationPage.IsProductMenuDisplayed(productMenu);
            Assert.IsTrue(isMenuDisplayed, $"Product menu '{productMenu}' is not displayed");
            LogHelper.Info($"Product menu '{productMenu}' is displayed");
        }

        [When(@"the user clicks on the ""(.*)"" product menu")]
        public void WhenTheUserClicksOnTheProductMenu(string productMenu)
        {
            LogHelper.Info($"Clicking on '{productMenu}' product menu");
            _navigationPage.ClickProductMenu(productMenu);
            LogHelper.Info($"Clicked on '{productMenu}' product menu");
        }

        [Then(@"the ""(.*)"" menu should expand or display submenu items")]
        public void ThenTheMenuShouldExpandOrDisplaySubmenuItems(string productMenu)
        {
            LogHelper.Info($"Verifying '{productMenu}' menu expanded or displays submenu items");
            bool hasSubmenu = _navigationPage.HasSubmenuItems(productMenu);
            Assert.IsTrue(hasSubmenu, $"Menu '{productMenu}' did not expand or display submenu items");
            LogHelper.Info($"Menu '{productMenu}' expanded successfully");
        }

        [When(@"the user expands the ""(.*)"" menu")]
        public void WhenTheUserExpandsTheMenu(string menuName)
        {
            LogHelper.Info($"Expanding '{menuName}' menu");
            _navigationPage.ExpandMenu(menuName);
            LogHelper.Info($"Expanded '{menuName}' menu");
        }

        [When(@"the user clicks on the ""(.*)"" submenu item")]
        public void WhenTheUserClicksOnTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Clicking on '{submenuItem}' submenu item");
            _navigationPage.ClickSubmenuItem(submenuItem);
            LogHelper.Info($"Clicked on '{submenuItem}' submenu item");
        }

        [Then(@"the submenu item should be selectable")]
        public void ThenTheSubmenuItemShouldBeSelectable()
        {
            LogHelper.Info("Verifying submenu item was selectable (page navigation occurred)");
            string currentUrl = _homePage.GetCurrentUrl();
            Assert.IsNotNull(currentUrl, "Current URL is null");
            Assert.IsNotEmpty(currentUrl, "Current URL is empty");
            LogHelper.Info($"Submenu item was selectable - current URL: {currentUrl}");
        }

        [Then(@"the user should be redirected to the destination page")]
        public void ThenTheUserShouldBeRedirectedToTheDestinationPage()
        {
            LogHelper.Info("Verifying user was redirected to destination page");
            string currentUrl = _homePage.GetCurrentUrl();
            string baseUrl = ConfigReader.GetValue("BaseUrl");
            Assert.AreNotEqual(baseUrl, currentUrl, "User was not redirected - still on homepage");
            LogHelper.Info($"User successfully redirected to: {currentUrl}");
        }

        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            LogHelper.Info("Verifying destination page loaded without errors");
            _checkingPage.WaitForPageLoad();
            bool hasErrors = _checkingPage.HasErrorMessages();
            Assert.IsFalse(hasErrors, "Destination page has error messages");
            LogHelper.Info("Destination page loaded without errors");
        }

        [Then(@"the destination page URL should contain ""(.*)""")]
        public void ThenTheDestinationPageURLShouldContain(string expectedUrlPart)
        {
            LogHelper.Info($"Verifying destination page URL contains '{expectedUrlPart}'");
            string currentUrl = _homePage.GetCurrentUrl();
            Assert.IsTrue(currentUrl.Contains(expectedUrlPart), 
                $"URL does not contain expected identifier. Expected: '{expectedUrlPart}', Actual URL: '{currentUrl}'");
            LogHelper.Info($"Destination page URL contains expected identifier: {expectedUrlPart}");
        }

        [Then(@"the Golden 1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            LogHelper.Info("Verifying Golden 1 logo is visible in top header");
            bool isLogoVisible = _homePage.IsLogoVisible();
            Assert.IsTrue(isLogoVisible, "Golden 1 logo is not visible in the top header");
            LogHelper.Info("Golden 1 logo is visible in top header");
        }

        [Then(@"the homepage should display correctly with no broken layouts")]
        public void ThenTheHomepageShouldDisplayCorrectlyWithNoBrokenLayouts()
        {
            LogHelper.Info("Verifying homepage displays correctly with no broken layouts");
            bool isLayoutCorrect = _homePage.IsPageLayoutCorrect();
            Assert.IsTrue(isLayoutCorrect, "Homepage has broken layouts");
            LogHelper.Info("Homepage displays correctly with no broken layouts");
        }

        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            LogHelper.Info("Verifying there is no missing content");
            bool hasMissingContent = _homePage.HasMissingContent();
            Assert.IsFalse(hasMissingContent, "Homepage has missing content");
            LogHelper.Info("No missing content found");
        }

        [Then(@"there should be no system errors displayed")]
        public void ThenThereShouldBeNoSystemErrorsDisplayed()
        {
            LogHelper.Info("Verifying there are no system errors displayed");
            bool hasSystemErrors = _homePage.HasSystemErrors();
            Assert.IsFalse(hasSystemErrors, "System errors are displayed on the homepage");
            LogHelper.Info("No system errors displayed");
        }
    }
}