using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Golden1.Automation.Pages;
using System.Linq;

namespace Golden1.Automation.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;

        public NavigationSteps(ScenarioContext context)
        {
            _driver = (IWebDriver)context["Driver"];
            _navigationPage = new NavigationPage(_driver);
        }

        [Given(@"User is on Golden1 homepage")]
        public void GivenUserIsOnGolden1Homepage()
        {
            _navigationPage.OpenHome();
        }

        [When(@"User navigates to ""(.*)"" under ""(.*)""")]
        public void WhenUserNavigatesToUnder(string subMenu, string mainMenu)
        {
            _navigationPage.NavigateToSubMenu(mainMenu, subMenu);
        }

        [Then(@"User should be on ""(.*)"" page")]
        public void ThenUserShouldBeOnPage(string urlPart)
        {
            Assert.That(_navigationPage.VerifyUrlContains(urlPart), Is.True);
        }

        // ✅ Global nav visibility
        [Then(@"Navigation should be visible")]
        public void ThenNavigationShouldBeVisible()
        {
            Assert.That(_navigationPage.IsTopNavigationVisible(), Is.True,
                "Top navigation is not visible.");
        }

        // ✅ Top tab menu validation
        [Then(@"The following menu options should be present in top navigation:")]
        public void ThenTheFollowingMenuOptionsShouldBePresentInTopNavigation(Table table)
        {
            var expectedMenus = table.Rows.Select(r => r["Menu"]).ToList();

            foreach (var menu in expectedMenus)
            {
                var locator = By.XPath($"//div[contains(@class,'menu__toptabs')]//a[normalize-space()='{menu}']");
                Assert.That(_driver.FindElement(locator).Displayed,
                    $"Menu option '{menu}' not visible in top navigation.");
            }
        }

        // 🚀 FINAL STEP — Main menu validation (TC_NAV_010)
        [Then(@"The main menu should display the following items:")]
        public void ThenTheMainMenuShouldDisplayTheFollowingItems(Table table)
        {
            var expectedMenus = table.Rows.Select(r => r["Main Menu"]).ToList();
            var actualMenus = _navigationPage.GetMainMenuItems();

            foreach (var menu in expectedMenus)
            {
                Assert.That(actualMenus.Contains(menu),
                    $"Main menu item '{menu}' was not found. Actual menus: {string.Join(", ", actualMenus)}");
            }
        }
    }
}
