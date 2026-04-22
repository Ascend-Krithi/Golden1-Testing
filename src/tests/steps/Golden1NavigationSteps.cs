using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Golden1.Automation.Framework.Pages;
using Golden1.Automation.Framework.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Golden1.Automation.Framework.Tests.Steps
{
    [Binding]
    public class Golden1NavigationSteps
    {
        private readonly HomePage _homePage;
        private readonly CheckingPage _checkingPage;
        private readonly NavigationHelper _navigationHelper;
        private readonly LogHelper _logHelper;
        private readonly WaitHelper _waitHelper;
        
        public Golden1NavigationSteps()
        {
            _homePage = new HomePage();
            _checkingPage = new CheckingPage();
            _navigationHelper = new NavigationHelper();
            _logHelper = new LogHelper();
            _waitHelper = new WaitHelper();
        }

        [Given(@"I launch the Golden1 website")]
        public void GivenILaunchTheGolden1Website()
        {
            _logHelper.LogInfo("Launching Golden1 website");
            string url = ConfigReader.GetValue("BaseURL");
            _navigationHelper.NavigateToUrl(url);
            _logHelper.LogInfo($"Navigated to URL: {url}");
        }

        [Then(@"the Golden1 homepage should load successfully")]
        public void ThenTheGolden1HomepageShouldLoadSuccessfully()
        {
            _logHelper.LogInfo("Verifying Golden1 homepage loads successfully");
            _waitHelper.WaitForPageLoad();
            bool isLogoDisplayed = _homePage.IsLogoDisplayed();
            Assert.IsTrue(isLogoDisplayed, "Golden1 homepage did not load successfully - logo not visible");
            _logHelper.LogInfo("Golden1 homepage loaded successfully");
        }

        [Then(@"no error messages or loading issues should be present")]
        public void ThenNoErrorMessagesOrLoadingIssuesShouldBePresent()
        {
            _logHelper.LogInfo("Checking for error messages or loading issues");
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.IsFalse(hasErrors, "Error messages or loading issues detected on homepage");
            _logHelper.LogInfo("No error messages or loading issues found");
        }

        [Then(@"the global navigation menu should be visible at the top of the homepage")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfTheHomepage()
        {
            _logHelper.LogInfo("Verifying global navigation menu visibility");
            _waitHelper.WaitForElementVisible(_homePage.GetGlobalNavigationMenuLocator());
            bool isVisible = _homePage.IsGlobalNavigationMenuVisible();
            Assert.IsTrue(isVisible, "Global navigation menu is not visible at the top of the homepage");
            _logHelper.LogInfo("Global navigation menu is visible");
        }

        [Then(@"the global navigation menu should be visible")]
        public void ThenTheGlobalNavigationMenuShouldBeVisible()
        {
            ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfTheHomepage();
        }

        [Then(@"the following navigation options should be present:")]
        public void ThenTheFollowingNavigationOptionsShouldBePresent(Table table)
        {
            _logHelper.LogInfo("Verifying all navigation options are present");
            var expectedOptions = table.Rows.Select(row => row["NavigationOption"]).ToList();
            
            foreach (var option in expectedOptions)
            {
                _logHelper.LogInfo($"Checking for navigation option: {option}");
                bool isPresent = _homePage.IsNavigationOptionPresent(option);
                Assert.IsTrue(isPresent, $"Navigation option '{option}' is not present");
                _logHelper.LogInfo($"Navigation option '{option}' is present");
            }
            
            _logHelper.LogInfo($"All {expectedOptions.Count} navigation options are present");
        }

        [When(@"I hover over the ""(.*)"" navigation option")]
        public void WhenIHoverOverTheNavigationOption(string navigationOption)
        {
            _logHelper.LogInfo($"Hovering over navigation option: {navigationOption}");
            _waitHelper.WaitForElementVisible(_homePage.GetNavigationOptionLocator(navigationOption));
            _homePage.HoverOverNavigationOption(navigationOption);
            _logHelper.LogInfo($"Hovered over navigation option: {navigationOption}");
        }

        [Then(@"the main product menus should be displayed")]
        public void ThenTheMainProductMenusShouldBeDisplayed()
        {
            _logHelper.LogInfo("Verifying main product menus are displayed");
            _waitHelper.WaitForElementVisible(_homePage.GetProductMenuContainerLocator());
            bool isDisplayed = _homePage.AreProductMenusDisplayed();
            Assert.IsTrue(isDisplayed, "Main product menus are not displayed");
            _logHelper.LogInfo("Main product menus are displayed");
        }

        [Then(@"the following product menus should be visible:")]
        public void ThenTheFollowingProductMenusShouldBeVisible(Table table)
        {
            _logHelper.LogInfo("Verifying all product menus are visible");
            var expectedMenus = table.Rows.Select(row => row["ProductMenu"]).ToList();
            
            foreach (var menu in expectedMenus)
            {
                _logHelper.LogInfo($"Checking for product menu: {menu}");
                _waitHelper.WaitForElementVisible(_homePage.GetProductMenuLocator(menu));
                bool isVisible = _homePage.IsProductMenuVisible(menu);
                Assert.IsTrue(isVisible, $"Product menu '{menu}' is not visible");
                _logHelper.LogInfo($"Product menu '{menu}' is visible");
            }
            
            _logHelper.LogInfo($"All {expectedMenus.Count} product menus are visible");
        }

        [When(@"I hover over the ""(.*)"" product menu")]
        public void WhenIHoverOverTheProductMenu(string productMenu)
        {
            _logHelper.LogInfo($"Hovering over product menu: {productMenu}");
            _waitHelper.WaitForElementVisible(_homePage.GetProductMenuLocator(productMenu));
            _homePage.HoverOverProductMenu(productMenu);
            _logHelper.LogInfo($"Hovered over product menu: {productMenu}");
        }

        [Then(@"the submenu items under ""(.*)"" should be displayed")]
        public void ThenTheSubmenuItemsUnderShouldBeDisplayed(string productMenu)
        {
            _logHelper.LogInfo($"Verifying submenu items are displayed under: {productMenu}");
            _waitHelper.WaitForElementVisible(_homePage.GetSubmenuContainerLocator(productMenu));
            bool isDisplayed = _homePage.AreSubmenuItemsDisplayed(productMenu);
            Assert.IsTrue(isDisplayed, $"Submenu items under '{productMenu}' are not displayed");
            _logHelper.LogInfo($"Submenu items under '{productMenu}' are displayed");
        }

        [Then(@"all submenu items should be clickable")]
        public void ThenAllSubmenuItemsShouldBeClickable()
        {
            _logHelper.LogInfo("Verifying all submenu items are clickable");
            bool areClickable = _homePage.AreAllSubmenuItemsClickable();
            Assert.IsTrue(areClickable, "Not all submenu items are clickable");
            _logHelper.LogInfo("All submenu items are clickable");
        }

        [When(@"I click on the ""(.*)"" submenu item")]
        public void WhenIClickOnTheSubmenuItem(string submenuItem)
        {
            _logHelper.LogInfo($"Clicking on submenu item: {submenuItem}");
            _waitHelper.WaitForElementClickable(_homePage.GetSubmenuItemLocator(submenuItem));
            _homePage.ClickSubmenuItem(submenuItem);
            _logHelper.LogInfo($"Clicked on submenu item: {submenuItem}");
        }

        [Then(@"I should be redirected to the Checking page")]
        public void ThenIShouldBeRedirectedToTheCheckingPage()
        {
            _logHelper.LogInfo("Verifying redirection to Checking page");
            _waitHelper.WaitForPageLoad();
            bool isOnCheckingPage = _checkingPage.IsOnCheckingPage();
            Assert.IsTrue(isOnCheckingPage, "User was not redirected to the Checking page");
            _logHelper.LogInfo("Successfully redirected to Checking page");
        }

        [Then(@"the Checking page should load completely without errors")]
        public void ThenTheCheckingPageShouldLoadCompletelyWithoutErrors()
        {
            _logHelper.LogInfo("Verifying Checking page loads without errors");
            _waitHelper.WaitForPageLoad();
            bool hasErrors = _checkingPage.HasErrorMessages();
            Assert.IsFalse(hasErrors, "Checking page has errors");
            bool isContentDisplayed = _checkingPage.IsPageContentDisplayed();
            Assert.IsTrue(isContentDisplayed, "Checking page content is not displayed");
            _logHelper.LogInfo("Checking page loaded completely without errors");
        }

        [When(@"I navigate to ""(.*)"" from ""(.*)""")]
        public void WhenINavigateToFrom(string submenuItem, string mainMenu)
        {
            _logHelper.LogInfo($"Navigating to '{submenuItem}' from '{mainMenu}'");
            _waitHelper.WaitForElementVisible(_homePage.GetNavigationOptionLocator(mainMenu));
            _homePage.HoverOverNavigationOption(mainMenu);
            _waitHelper.WaitForElementVisible(_homePage.GetSubmenuItemLocator(submenuItem));
            _homePage.ClickSubmenuItem(submenuItem);
            _logHelper.LogInfo($"Navigated to '{submenuItem}' from '{mainMenu}'");
        }

        [Then(@"I should be redirected to the ""(.*)""")]
        public void ThenIShouldBeRedirectedToThe(string destinationPage)
        {
            _logHelper.LogInfo($"Verifying redirection to: {destinationPage}");
            _waitHelper.WaitForPageLoad();
            string currentUrl = _navigationHelper.GetCurrentUrl();
            Assert.IsNotEmpty(currentUrl, "Current URL is empty");
            _logHelper.LogInfo($"Redirected to: {currentUrl}");
        }

        [Then(@"the destination URL should contain ""(.*)""")]
        public void ThenTheDestinationURLShouldContain(string urlIdentifier)
        {
            _logHelper.LogInfo($"Verifying URL contains: {urlIdentifier}");
            string currentUrl = _navigationHelper.GetCurrentUrl();
            bool containsIdentifier = currentUrl.ToLower().Contains(urlIdentifier.ToLower());
            Assert.IsTrue(containsIdentifier, $"URL '{currentUrl}' does not contain identifier '{urlIdentifier}'");
            _logHelper.LogInfo($"URL contains expected identifier: {urlIdentifier}");
        }

        [Then(@"the Golden1 logo should be visible in the top header area")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeaderArea()
        {
            _logHelper.LogInfo("Verifying Golden1 logo is visible in header");
            _waitHelper.WaitForElementVisible(_homePage.GetLogoLocator());
            bool isLogoVisible = _homePage.IsLogoDisplayed();
            Assert.IsTrue(isLogoVisible, "Golden1 logo is not visible in the top header area");
            _logHelper.LogInfo("Golden1 logo is visible in the top header area");
        }

        [Then(@"no broken layouts should be present")]
        public void ThenNoBrokenLayoutsShouldBePresent()
        {
            _logHelper.LogInfo("Checking for broken layouts");
            bool hasBrokenLayouts = _homePage.HasBrokenLayouts();
            Assert.IsFalse(hasBrokenLayouts, "Broken layouts detected on homepage");
            _logHelper.LogInfo("No broken layouts detected");
        }

        [Then(@"no missing images should be present")]
        public void ThenNoMissingImagesShouldBePresent()
        {
            _logHelper.LogInfo("Checking for missing images");
            bool hasMissingImages = _homePage.HasMissingImages();
            Assert.IsFalse(hasMissingImages, "Missing images detected on homepage");
            _logHelper.LogInfo("No missing images detected");
        }

        [Then(@"no misplaced elements should be present")]
        public void ThenNoMisplacedElementsShouldBePresent()
        {
            _logHelper.LogInfo("Checking for misplaced elements");
            bool hasMisplacedElements = _homePage.HasMisplacedElements();
            Assert.IsFalse(hasMisplacedElements, "Misplaced elements detected on homepage");
            _logHelper.LogInfo("No misplaced elements detected");
        }

        [Then(@"no error messages should be displayed")]
        public void ThenNoErrorMessagesShouldBeDisplayed()
        {
            _logHelper.LogInfo("Checking for error messages");
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.IsFalse(hasErrors, "Error messages detected on homepage");
            _logHelper.LogInfo("No error messages detected");
        }
    }
}