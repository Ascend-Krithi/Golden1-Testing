using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly HomePage _homePage;
        private readonly NavigationPage _navigationPage;

        public NavigationSteps(HomePage homePage, NavigationPage navigationPage)
        {
            _homePage = homePage;
            _navigationPage = navigationPage;
        }

        [Given(@"the browser is launched")]
        public void GivenTheBrowserIsLaunched()
        {
            LogHelper.Info("Browser has been launched via Hooks");
            // Browser initialization is handled in Hooks.cs
        }

        [When(@"the user navigates to the Golden1 homepage")]
        public void WhenTheUserNavigatesToTheGolden1Homepage()
        {
            LogHelper.Info("Navigating to Golden1 homepage");
            _homePage.OpenHomePage();
        }

        [Then(@"the browser should open successfully")]
        public void ThenTheBrowserShouldOpenSuccessfully()
        {
            LogHelper.Info("Verifying browser opened successfully");
            bool isBrowserOpen = _homePage.IsBrowserOpen();
            Assert.IsTrue(isBrowserOpen, "Browser did not open successfully");
            LogHelper.Info("Browser opened successfully: " + isBrowserOpen);
        }

        [Then(@"the Golden 1 homepage should load successfully")]
        public void ThenTheGolden1HomepageShouldLoadSuccessfully()
        {
            LogHelper.Info("Verifying Golden1 homepage loaded successfully");
            bool isHomePageLoaded = _homePage.IsHomePageLoaded();
            Assert.IsTrue(isHomePageLoaded, "Golden1 homepage did not load successfully");
            LogHelper.Info("Homepage loaded successfully: " + isHomePageLoaded);
        }

        [Then(@"there should be no error messages or loading issues")]
        public void ThenThereShouldBeNoErrorMessagesOrLoadingIssues()
        {
            LogHelper.Info("Verifying no error messages or loading issues");
            bool hasErrors = _homePage.HasErrorMessages();
            Assert.IsFalse(hasErrors, "Error messages or loading issues detected on homepage");
            LogHelper.Info("No error messages detected: " + !hasErrors);
        }

        [Then(@"the global navigation menu should be visible at the top of the page")]
        public void ThenTheGlobalNavigationMenuShouldBeVisibleAtTheTopOfThePage()
        {
            LogHelper.Info("Verifying global navigation menu visibility");
            bool isMenuVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.IsTrue(isMenuVisible, "Global navigation menu is not visible");
            LogHelper.Info("Navigation menu visible: " + isMenuVisible);
        }

        [When(@"the navigation menu is visible")]
        public void WhenTheNavigationMenuIsVisible()
        {
            LogHelper.Info("Checking navigation menu visibility");
            bool isMenuVisible = _navigationPage.IsNavigationMenuVisible();
            Assert.IsTrue(isMenuVisible, "Navigation menu is not visible");
        }

        [Then(@"all menu options should be present")]
        public void ThenAllMenuOptionsShouldBePresent(Table table)
        {
            LogHelper.Info("Verifying all menu options are present");
            var menuOptions = table.CreateSet<MenuOption>();
            
            foreach (var option in menuOptions)
            {
                bool isPresent = _navigationPage.IsTopMenuOptionPresent(option.MenuOption);
                Assert.IsTrue(isPresent, $"Menu option '{option.MenuOption}' is not present");
                LogHelper.Info($"Menu option '{option.MenuOption}' is present: {isPresent}");
            }
        }

        [Then(@"all main product category menus should be displayed")]
        public void ThenAllMainProductCategoryMenusShouldBeDisplayed(Table table)
        {
            LogHelper.Info("Verifying all main product category menus are displayed");
            var productCategories = table.CreateSet<ProductCategory>();
            
            foreach (var category in productCategories)
            {
                bool isDisplayed = _navigationPage.IsProductCategoryMenuDisplayed(category.ProductCategory);
                Assert.IsTrue(isDisplayed, $"Product category '{category.ProductCategory}' is not displayed");
                LogHelper.Info($"Product category '{category.ProductCategory}' is displayed: {isDisplayed}");
            }
        }

        [Then(@"each main product category menu should be accessible")]
        public void ThenEachMainProductCategoryMenuShouldBeAccessible()
        {
            LogHelper.Info("Verifying each main product category menu is accessible");
            List<string> categories = new List<string> { "Checking", "Savings", "Home Loans", "Credit Cards", "Loans", "Investing", "Community" };
            
            foreach (var category in categories)
            {
                bool isAccessible = _navigationPage.IsProductCategoryMenuAccessible(category);
                Assert.IsTrue(isAccessible, $"Product category menu '{category}' is not accessible");
                LogHelper.Info($"Product category menu '{category}' is accessible: {isAccessible}");
            }
        }

        [When(@"the user expands the ""(.*?)"" menu")]
        public void WhenTheUserExpandsTheMenu(string menuName)
        {
            LogHelper.Info($"Expanding the '{menuName}' menu");
            bool expanded = _navigationPage.ExpandProductCategoryMenu(menuName);
            Assert.IsTrue(expanded, $"Failed to expand '{menuName}' menu");
        }

        [Then(@"submenu items should be displayed")]
        public void ThenSubmenuItemsShouldBeDisplayed()
        {
            LogHelper.Info("Verifying submenu items are displayed");
            bool areSubmenuItemsDisplayed = _navigationPage.AreSubmenuItemsDisplayed();
            Assert.IsTrue(areSubmenuItemsDisplayed, "Submenu items are not displayed");
            LogHelper.Info("Submenu items displayed: " + areSubmenuItemsDisplayed);
        }

        [Then(@"the user should be able to select the ""(.*?)"" submenu item")]
        public void ThenTheUserShouldBeAbleToSelectTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Verifying user can select '{submenuItem}' submenu item");
            bool isSelectable = _navigationPage.IsSubmenuItemSelectable(submenuItem);
            Assert.IsTrue(isSelectable, $"Submenu item '{submenuItem}' is not selectable");
            LogHelper.Info($"Submenu item '{submenuItem}' is selectable: {isSelectable}");
        }

        [When(@"the user selects the ""(.*?)"" submenu item")]
        public void WhenTheUserSelectsTheSubmenuItem(string submenuItem)
        {
            LogHelper.Info($"Selecting '{submenuItem}' submenu item");
            bool selected = _navigationPage.SelectSubmenuItem(submenuItem);
            Assert.IsTrue(selected, $"Failed to select '{submenuItem}' submenu item");
        }

        [Then(@"the user should be redirected to the Free Checking destination page")]
        public void ThenTheUserShouldBeRedirectedToTheFreeCheckingDestinationPage()
        {
            LogHelper.Info("Verifying redirection to Free Checking destination page");
            bool isRedirected = _navigationPage.IsOnDestinationPage("Free Checking");
            Assert.IsTrue(isRedirected, "User was not redirected to Free Checking destination page");
            LogHelper.Info("Redirected to Free Checking page: " + isRedirected);
        }

        [Then(@"the destination page should load without errors")]
        public void ThenTheDestinationPageShouldLoadWithoutErrors()
        {
            LogHelper.Info("Verifying destination page loaded without errors");
            bool hasErrors = _navigationPage.HasPageErrors();
            Assert.IsFalse(hasErrors, "Destination page has errors");
            LogHelper.Info("Destination page loaded without errors: " + !hasErrors);
        }

        [Then(@"the destination page URL should contain ""(.*?)""")]
        public void ThenTheDestinationPageURLShouldContain(string urlIdentifier)
        {
            LogHelper.Info($"Verifying destination page URL contains '{urlIdentifier}'");
            bool containsIdentifier = _navigationPage.DoesUrlContain(urlIdentifier);
            Assert.IsTrue(containsIdentifier, $"Destination page URL does not contain '{urlIdentifier}'");
            LogHelper.Info($"URL contains '{urlIdentifier}': {containsIdentifier}");
        }

        [Then(@"the Golden 1 logo should be visible in the top header")]
        public void ThenTheGolden1LogoShouldBeVisibleInTheTopHeader()
        {
            LogHelper.Info("Verifying Golden 1 logo visibility in top header");
            bool isLogoVisible = _homePage.IsLogoVisible();
            Assert.IsTrue(isLogoVisible, "Golden 1 logo is not visible in top header");
            LogHelper.Info("Logo visible: " + isLogoVisible);
        }

        [Then(@"the homepage should display correctly")]
        public void ThenTheHomepageShouldDisplayCorrectly()
        {
            LogHelper.Info("Verifying homepage displays correctly");
            bool displaysCorrectly = _homePage.IsHomePageDisplayedCorrectly();
            Assert.IsTrue(displaysCorrectly, "Homepage does not display correctly");
            LogHelper.Info("Homepage displays correctly: " + displaysCorrectly);
        }

        [Then(@"there should be no broken layouts")]
        public void ThenThereShouldBeNoBrokenLayouts()
        {
            LogHelper.Info("Verifying no broken layouts");
            bool hasBrokenLayouts = _homePage.HasBrokenLayouts();
            Assert.IsFalse(hasBrokenLayouts, "Broken layouts detected on homepage");
            LogHelper.Info("No broken layouts: " + !hasBrokenLayouts);
        }

        [Then(@"there should be no missing content")]
        public void ThenThereShouldBeNoMissingContent()
        {
            LogHelper.Info("Verifying no missing content");
            bool hasMissingContent = _homePage.HasMissingContent();
            Assert.IsFalse(hasMissingContent, "Missing content detected on homepage");
            LogHelper.Info("No missing content: " + !hasMissingContent);
        }

        [Then(@"there should be no system errors")]
        public void ThenThereShouldBeNoSystemErrors()
        {
            LogHelper.Info("Verifying no system errors");
            bool hasSystemErrors = _homePage.HasSystemErrors();
            Assert.IsFalse(hasSystemErrors, "System errors detected on homepage");
            LogHelper.Info("No system errors: " + !hasSystemErrors);
        }

        // Helper classes for table data
        public class MenuOption
        {
            public string MenuOption { get; set; }
        }

        public class ProductCategory
        {
            public string ProductCategory { get; set; }
        }
    }
}