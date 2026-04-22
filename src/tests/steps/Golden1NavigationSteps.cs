using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Golden1.Automation.Framework.Pages;
using Golden1.Automation.Framework.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Golden1.Automation.Framework.Steps
{
    [Binding]
    public class Golden1NavigationSteps
    {
        private readonly HomePage _homePage;
        private readonly CheckingPage _checkingPage;
        private readonly NavigationHelper _navigationHelper;
        private readonly LogHelper _logHelper;
        private readonly ConfigReader _configReader;

        public Golden1NavigationSteps()
        {
            _homePage = new HomePage();
            _checkingPage = new CheckingPage();
            _navigationHelper = new NavigationHelper();
            _logHelper = new LogHelper();
            _configReader = new ConfigReader();
        }

        [Given(@"I launch the Golden1 website")]
        public void GivenILaunchTheGolden1Website()
        {
            _logHelper.LogInfo("Launching Golden1 website");
            string url = _configReader.GetApplicationUrl();
            _navigationHelper.NavigateToUrl(url);
            _logHelper.LogInfo($"Navigated to URL: {url}");
        }

        [Then(@"the Golden1 homepage should load successfully")]
        public void ThenTheGolden1HomepageShouldLoadSuccessfully()
        {
            _logHelper.LogInfo("Verifying Golden1 homepage loads successfully");
            Assert.IsTrue(_homePage.IsPageLoaded(), "Golden1 homepage did not load successfully");
            _logHelper.LogInfo("Golden1 homepage loaded successfully");
        }

        [Then(@"no error messages or loading issues should be present")]
        public void ThenNoErrorMessagesOrLoadingIssuesShouldBePresent()
        {
            _logHelper.LogInfo("Checking for error messages or loading issues");
            Assert.IsFalse(_homePage.HasErrorMessages(), "Error messages are present on the homepage");
            Assert.IsTrue(_homePage.IsPageFullyLoaded(), "Page has loading issues");
            _logHelper.LogInfo("No error messages or loading issues found");
        }

        [Then(@"the global navigation menu should be visible at the top")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTop()
        {
            _logHelper.LogInfo("Verifying global navigation menu visibility");
            Assert.IsTrue(_homePage.IsGlobalNavigationMenuVisible(), "Global navigation menu is not visible");
            _logHelper.LogInfo("Global navigation menu is visible");
        }

        [Then(@"the global navigation menu should be visible")]
        public void ThenTheGlobalNavigationMenuShouldBeVisible()
        {
            _logHelper.LogInfo("Verifying global navigation menu is visible");
            Assert.IsTrue(_homePage.IsGlobalNavigationMenuVisible(), "Global navigation menu is not visible");
            _logHelper.LogInfo("Global navigation menu is visible");
        }

        [Then(@"all navigation options should be present")]
        public void ThenAllNavigationOptionsShouldBePresent(Table table)
        {
            _logHelper.LogInfo("Verifying all navigation options are present");
            var expectedOptions = table.Rows.Select(row => row["NavigationOption"]).ToList();
            
            foreach (var option in expectedOptions)
            {
                Assert.IsTrue(_homePage.IsNavigationOptionPresent(option), 
                    $"Navigation option '{option}' is not present");
                _logHelper.LogInfo($"Navigation option '{option}' is present");
            }
            
            _logHelper.LogInfo("All navigation options are present");
        }

        [When(@"I hover over each top navigation option")]
        public void WhenIHoverOverEachTopNavigationOption()
        {
            _logHelper.LogInfo("Hovering over each top navigation option");
            var navigationOptions = new List<string> 
            { 
                "Personal", "Business", "Financial Wellness", 
                "Appointments", "Locations", "Membership", "Help Center" 
            };
            
            foreach (var option in navigationOptions)
            {
                _homePage.HoverOverNavigationOption(option);
                _logHelper.LogInfo($"Hovered over navigation option: {option}");
            }
        }

        [Then(@"the main product menus should be displayed on hover")]
        public void ThenTheMainProductMenusShouldBeDisplayedOnHover()
        {
            _logHelper.LogInfo("Verifying main product menus are displayed on hover");
            Assert.IsTrue(_homePage.AreMainProductMenusDisplayed(), 
                "Main product menus are not displayed on hover");
            _logHelper.LogInfo("Main product menus are displayed on hover");
        }

        [When(@"I hover over each main product menu")]
        public void WhenIHoverOverEachMainProductMenu()
        {
            _logHelper.LogInfo("Hovering over each main product menu");
            var productMenus = new List<string> 
            { 
                "Checking", "Savings", "Home Loans", 
                "Credit Cards", "Loans", "Investing", "Community" 
            };
            
            foreach (var menu in productMenus)
            {
                _homePage.HoverOverProductMenu(menu);
                _logHelper.LogInfo($"Hovered over product menu: {menu}");
            }
        }

        [Then(@"submenu items should be displayed")]
        public void ThenSubmenuItemsShouldBeDisplayed()
        {
            _logHelper.LogInfo("Verifying submenu items are displayed");
            Assert.IsTrue(_homePage.AreSubmenuItemsDisplayed(), 
                "Submenu items are not displayed");
            _logHelper.LogInfo("Submenu items are displayed");
        }

        [Then(@"each submenu item should be clickable")]
        public void ThenEachSubmenuItemShouldBeClickable()
        {
            _logHelper.LogInfo("Verifying each submenu item is clickable");
            Assert.IsTrue(_homePage.AreSubmenuItemsClickable(), 
                "Not all submenu items are clickable");
            _logHelper.LogInfo("All submenu items are clickable");
        }

        [When(@"I hover over the ""(.*?)"" menu")]
        public void WhenIHoverOverTheMenu(string menuName)
        {
            _logHelper.LogInfo($"Hovering over the '{menuName}' menu");
            _homePage.HoverOverNavigationOption(menuName);
            _logHelper.LogInfo($"Hovered over '{menuName}' menu");
        }

        [When(@"I click on the ""(.*?)"" submenu item")]
        public void WhenIClickOnTheSubmenuItem(string submenuItem)
        {
            _logHelper.LogInfo($"Clicking on the '{submenuItem}' submenu item");
            _homePage.ClickSubmenuItem(submenuItem);
            _logHelper.LogInfo($"Clicked on '{submenuItem}' submenu item");
        }

        [Then(@"I should be redirected to the Checking page")]
        public void ThenIShouldBeRedirectedToTheCheckingPage()
        {
            _logHelper.LogInfo("Verifying redirection to Checking page");
            Assert.IsTrue(_checkingPage.IsPageLoaded(), 
                "User was not redirected to the Checking page");
            _logHelper.LogInfo("Successfully redirected to Checking page");
        }

        [Then(@"the Checking page should load completely without errors")]
        public void ThenTheCheckingPageShouldLoadCompletelyWithoutErrors()
        {
            _logHelper.LogInfo("Verifying Checking page loads completely without errors");
            Assert.IsTrue(_checkingPage.IsPageFullyLoaded(), 
                "Checking page did not load completely");
            Assert.IsFalse(_checkingPage.HasErrorMessages(), 
                "Error messages are present on the Checking page");
            _logHelper.LogInfo("Checking page loaded completely without errors");
        }

        [When(@"I navigate through all mapped submenu links")]
        public void WhenINavigateThroughAllMappedSubmenuLinks()
        {
            _logHelper.LogInfo("Navigating through all mapped submenu links");
            var submenuLinks = _homePage.GetAllMappedSubmenuLinks();
            
            foreach (var link in submenuLinks)
            {
                _homePage.NavigateToSubmenuLink(link);
                _logHelper.LogInfo($"Navigated to submenu link: {link}");
            }
        }

        [Then(@"each submenu link should redirect to the correct destination page")]
        public void ThenEachSubmenuLinkShouldRedirectToTheCorrectDestinationPage()
        {
            _logHelper.LogInfo("Verifying each submenu link redirects correctly");
            Assert.IsTrue(_homePage.AreAllSubmenuLinksRedirectingCorrectly(), 
                "Not all submenu links are redirecting correctly");
            _logHelper.LogInfo("All submenu links redirect correctly");
        }

        [Then(@"the destination URL should contain the expected identifier")]
        public void ThenTheDestinationURLShouldContainTheExpectedIdentifier()
        {
            _logHelper.LogInfo("Verifying destination URL contains expected identifier");
            Assert.IsTrue(_homePage.DoesUrlContainExpectedIdentifier(), 
                "Destination URL does not contain the expected identifier");
            _logHelper.LogInfo("Destination URL contains expected identifier");
        }

        [Then(@"the Golden1 logo should be visible in the top header area")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeaderArea()
        {
            _logHelper.LogInfo("Verifying Golden1 logo is visible in top header area");
            Assert.IsTrue(_homePage.IsLogoVisible(), 
                "Golden1 logo is not visible in the top header area");
            _logHelper.LogInfo("Golden1 logo is visible in top header area");
        }

        [Then(@"no broken layouts should be present")]
        public void ThenNoBrokenLayoutsShouldBePresent()
        {
            _logHelper.LogInfo("Checking for broken layouts");
            Assert.IsFalse(_homePage.HasBrokenLayouts(), 
                "Broken layouts are present on the homepage");
            _logHelper.LogInfo("No broken layouts found");
        }

        [Then(@"no missing images should be present")]
        public void ThenNoMissingImagesShouldBePresent()
        {
            _logHelper.LogInfo("Checking for missing images");
            Assert.IsFalse(_homePage.HasMissingImages(), 
                "Missing images are present on the homepage");
            _logHelper.LogInfo("No missing images found");
        }

        [Then(@"no misplaced elements should be present")]
        public void ThenNoMisplacedElementsShouldBePresent()
        {
            _logHelper.LogInfo("Checking for misplaced elements");
            Assert.IsFalse(_homePage.HasMisplacedElements(), 
                "Misplaced elements are present on the homepage");
            _logHelper.LogInfo("No misplaced elements found");
        }

        [Then(@"no error messages should be displayed")]
        public void ThenNoErrorMessagesShouldBeDisplayed()
        {
            _logHelper.LogInfo("Checking for error messages");
            Assert.IsFalse(_homePage.HasErrorMessages(), 
                "Error messages are displayed on the homepage");
            _logHelper.LogInfo("No error messages displayed");
        }
    }
}