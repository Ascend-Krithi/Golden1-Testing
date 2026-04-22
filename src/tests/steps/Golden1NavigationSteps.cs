using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Golden1.Automation.Framework.Pages;
using Golden1.Automation.Framework.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Golden1.Automation.Framework.Steps
{
    [Binding]
    public class Golden1NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly NavigationPage _navigationPage;
        private readonly ScenarioContext _scenarioContext;

        public Golden1NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _homePage = new HomePage(_driver);
            _navigationPage = new NavigationPage(_driver);
        }

        [Given(@"I launch the web browser")]
        public void GivenILaunchTheWebBrowser()
        {
            LogHelper.Info("Browser launched successfully");
            Assert.IsNotNull(_driver, "WebDriver should be initialized");
        }

        [When(@"I navigate to the Golden1 homepage")]
        public void WhenINavigateToTheGolden1Homepage()
        {
            string url = ConfigReader.GetValue("BaseUrl");
            LogHelper.Info($"Navigating to Golden1 homepage: {url}");
            _homePage.NavigateToHomePage(url);
            WaitHelper.WaitForPageLoad(_driver);
        }

        [Then(@"the homepage should load completely without errors")]
        public void ThenTheHomepageShouldLoadCompletelyWithoutErrors()
        {
            LogHelper.Info("Verifying homepage loaded completely");
            WaitHelper.WaitForElementToBeVisible(_driver, _homePage.GetHomePageLoadedIndicator(), 30);
            Assert.IsTrue(_homePage.IsHomePageLoaded(), "Homepage should load completely without errors");
            LogHelper.Pass("Homepage loaded successfully");
        }

        [Then(@"no error messages or loading issues should be present")]
        public void ThenNoErrorMessagesOrLoadingIssuesShouldBePresent()
        {
            LogHelper.Info("Checking for error messages or loading issues");
            Assert.IsFalse(_homePage.HasErrorMessages(), "No error messages should be present");
            Assert.IsFalse(_homePage.HasLoadingIssues(), "No loading issues should be present");
            LogHelper.Pass("No error messages or loading issues found");
        }

        [Then(@"the global navigation menu should be visible at the top of the page")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfThePage()
        {
            LogHelper.Info("Verifying global navigation menu visibility");
            WaitHelper.WaitForElementToBeVisible(_driver, _navigationPage.GetGlobalNavigationMenu(), 10);
            Assert.IsTrue(_navigationPage.IsGlobalNavigationMenuVisible(), "Global navigation menu should be visible");
            LogHelper.Pass("Global navigation menu is visible");
        }

        [When(@"I locate the global navigation menu")]
        public void WhenILocateTheGlobalNavigationMenu()
        {
            LogHelper.Info("Locating global navigation menu");
            WaitHelper.WaitForElementToBeVisible(_driver, _navigationPage.GetGlobalNavigationMenu(), 10);
            Assert.IsTrue(_navigationPage.IsGlobalNavigationMenuVisible(), "Global navigation menu should be present");
        }

        [Then(@"the following navigation options should be visible:")]
        public void ThenTheFollowingNavigationOptionsShouldBeVisible(Table table)
        {
            LogHelper.Info("Verifying all navigation options are visible");
            var expectedOptions = table.Rows.Select(row => row["NavigationOption"]).ToList();
            
            foreach (var option in expectedOptions)
            {
                LogHelper.Info($"Checking navigation option: {option}");
                Assert.IsTrue(_navigationPage.IsNavigationOptionVisible(option), 
                    $"Navigation option '{option}' should be visible");
            }
            
            LogHelper.Pass($"All {expectedOptions.Count} navigation options are visible and correctly labeled");
        }

        [Then(@"hovering over each main product menu should display corresponding submenu:")]
        public void ThenHoveringOverEachMainProductMenuShouldDisplayCorrespondingSubmenu(Table table)
        {
            LogHelper.Info("Verifying submenus display on hover for product menus");
            var productMenus = table.Rows.Select(row => row["ProductMenu"]).ToList();
            
            foreach (var menu in productMenus)
            {
                LogHelper.Info($"Hovering over product menu: {menu}");
                _navigationPage.HoverOverProductMenu(menu);
                WaitHelper.WaitForElementToBeVisible(_driver, _navigationPage.GetSubmenuForProductMenu(menu), 5);
                
                Assert.IsTrue(_navigationPage.IsSubmenuDisplayed(menu), 
                    $"Submenu should be displayed for '{menu}' menu");
                LogHelper.Info($"Submenu displayed for {menu}");
            }
            
            LogHelper.Pass("All product menu submenus display correctly on hover");
        }

        [When(@"I hover over each main product menu to display submenu")]
        public void WhenIHoverOverEachMainProductMenuToDisplaySubmenu()
        {
            LogHelper.Info("Hovering over main product menus");
            var productMenus = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
            
            foreach (var menu in productMenus)
            {
                _navigationPage.HoverOverProductMenu(menu);
                WaitHelper.WaitForElementToBeVisible(_driver, _navigationPage.GetSubmenuForProductMenu(menu), 5);
            }
            
            _scenarioContext["ProductMenus"] = productMenus;
        }

        [Then(@"each submenu item should be selectable and clickable")]
        public void ThenEachSubmenuItemShouldBeSelectableAndClickable()
        {
            LogHelper.Info("Verifying submenu items are selectable and clickable");
            var productMenus = (List<string>)_scenarioContext["ProductMenus"];
            
            foreach (var menu in productMenus)
            {
                _navigationPage.HoverOverProductMenu(menu);
                WaitHelper.WaitForElementToBeVisible(_driver, _navigationPage.GetSubmenuForProductMenu(menu), 5);
                
                var submenuItems = _navigationPage.GetAllSubmenuItems(menu);
                LogHelper.Info($"Found {submenuItems.Count} submenu items for {menu}");
                
                foreach (var item in submenuItems)
                {
                    Assert.IsTrue(_navigationPage.IsSubmenuItemClickable(item), 
                        $"Submenu item '{item.Text}' should be clickable");
                }
            }
            
            LogHelper.Pass("All submenu items are selectable and clickable");
        }

        [When(@"I click on each submenu item")]
        public void WhenIClickOnEachSubmenuItem()
        {
            LogHelper.Info("Clicking on submenu items");
            var productMenus = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
            var visitedUrls = new List<string>();
            
            foreach (var menu in productMenus)
            {
                _navigationPage.HoverOverProductMenu(menu);
                WaitHelper.WaitForElementToBeVisible(_driver, _navigationPage.GetSubmenuForProductMenu(menu), 5);
                
                var submenuItems = _navigationPage.GetAllSubmenuItems(menu);
                
                foreach (var item in submenuItems)
                {
                    string itemText = item.Text;
                    LogHelper.Info($"Clicking submenu item: {itemText}");
                    _navigationPage.ClickSubmenuItem(menu, itemText);
                    WaitHelper.WaitForPageLoad(_driver);
                    visitedUrls.Add(_driver.Url);
                    _driver.Navigate().Back();
                    WaitHelper.WaitForPageLoad(_driver);
                }
            }
            
            _scenarioContext["VisitedUrls"] = visitedUrls;
        }

        [Then(@"I should be redirected to the expected destination page")]
        public void ThenIShouldBeRedirectedToTheExpectedDestinationPage()
        {
            LogHelper.Info("Verifying redirection to destination pages");
            var visitedUrls = (List<string>)_scenarioContext["VisitedUrls"];
            
            foreach (var url in visitedUrls)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(url) && url.Contains("golden1.com"), 
                    $"Should be redirected to Golden1 domain. URL: {url}");
            }
            
            LogHelper.Pass("All submenu items redirect to expected destination pages");
        }

        [Then(@"the destination page should load completely without errors")]
        public void ThenTheDestinationPageShouldLoadCompletelyWithoutErrors()
        {
            LogHelper.Info("Verifying destination pages load without errors");
            WaitHelper.WaitForPageLoad(_driver);
            
            Assert.IsFalse(_homePage.HasErrorMessages(), "Destination page should not have error messages");
            Assert.IsTrue(_driver.Url.Contains("golden1.com"), "Should be on Golden1 domain");
            
            LogHelper.Pass("Destination pages load completely without errors");
        }

        [When(@"I click on each submenu item to navigate to destination page")]
        public void WhenIClickOnEachSubmenuItemToNavigateToDestinationPage()
        {
            LogHelper.Info("Navigating to destination pages via submenu items");
            var urlMappings = new Dictionary<string, string>();
            var productMenus = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
            
            foreach (var menu in productMenus)
            {
                _navigationPage.HoverOverProductMenu(menu);
                WaitHelper.WaitForElementToBeVisible(_driver, _navigationPage.GetSubmenuForProductMenu(menu), 5);
                
                var submenuItems = _navigationPage.GetAllSubmenuItems(menu);
                
                foreach (var item in submenuItems)
                {
                    string itemText = item.Text;
                    _navigationPage.ClickSubmenuItem(menu, itemText);
                    WaitHelper.WaitForPageLoad(_driver);
                    urlMappings[itemText] = _driver.Url;
                    _driver.Navigate().Back();
                    WaitHelper.WaitForPageLoad(_driver);
                }
            }
            
            _scenarioContext["UrlMappings"] = urlMappings;
        }

        [Then(@"each URL should contain the correct identifier as per mapping")]
        public void ThenEachURLShouldContainTheCorrectIdentifierAsPerMapping()
        {
            LogHelper.Info("Verifying URL identifiers match expected mappings");
            var urlMappings = (Dictionary<string, string>)_scenarioContext["UrlMappings"];
            
            // Expected URL identifier mappings based on test data
            var expectedIdentifiers = new Dictionary<string, string>
            {
                { "Free Checking", "free-checking" },
                { "Dividend Checking", "dividend-checking" },
                { "Savings", "savings" },
                { "Money Market", "money-market" },
                { "Home Loans", "home-loans" },
                { "Credit Cards", "credit-cards" },
                { "Personal Loans", "personal-loans" },
                { "Investing", "investing" },
                { "Community", "community" }
            };
            
            foreach (var mapping in urlMappings)
            {
                string menuItem = mapping.Key;
                string actualUrl = mapping.Value;
                
                if (expectedIdentifiers.ContainsKey(menuItem))
                {
                    string expectedIdentifier = expectedIdentifiers[menuItem];
                    Assert.IsTrue(actualUrl.ToLower().Contains(expectedIdentifier.ToLower()), 
                        $"URL for '{menuItem}' should contain identifier '{expectedIdentifier}'. Actual URL: {actualUrl}");
                    LogHelper.Info($"URL for {menuItem} contains correct identifier: {expectedIdentifier}");
                }
            }
            
            LogHelper.Pass("All URLs contain correct identifiers as per mapping");
        }

        [Then(@"the Golden1 logo should be visible in the top header area")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeaderArea()
        {
            LogHelper.Info("Verifying Golden1 logo visibility in header");
            WaitHelper.WaitForElementToBeVisible(_driver, _homePage.GetGolden1Logo(), 10);
            
            Assert.IsTrue(_homePage.IsGolden1LogoVisible(), "Golden1 logo should be visible in top header area");
            LogHelper.Pass("Golden1 logo is visible in the top header area");
        }

        [When(@"I wait for the homepage to load fully")]
        public void WhenIWaitForTheHomepageToLoadFully()
        {
            LogHelper.Info("Waiting for homepage to load fully");
            WaitHelper.WaitForPageLoad(_driver);
            WaitHelper.WaitForElementToBeVisible(_driver, _homePage.GetHomePageLoadedIndicator(), 30);
        }

        [Then(@"no broken layouts or error messages should be present on the homepage")]
        public void ThenNoBrokenLayoutsOrErrorMessagesShouldBePresentOnTheHomepage()
        {
            LogHelper.Info("Inspecting homepage for broken layouts or error messages");
            
            Assert.IsFalse(_homePage.HasErrorMessages(), "No error messages should be present");
            Assert.IsFalse(_homePage.HasBrokenLayout(), "No broken layouts should be present");
            Assert.IsTrue(_homePage.AreKeyElementsDisplayed(), "All key homepage elements should be displayed");
            
            LogHelper.Pass("Homepage displays without broken layouts or error messages");
        }
    }
}