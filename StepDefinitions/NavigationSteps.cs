using TechTalk.SpecFlow;
using NUnit.Framework;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.StepDefinitions
{
    /// <summary>
    /// Step definitions for Golden1 website navigation scenarios
    /// </summary>
    [Binding]
    public class NavigationSteps
    {
        private readonly NavigationPage _navigationPage;
        private readonly OverlayPage _overlayPage;

        /// <summary>
        /// Constructor with dependency injection for page objects
        /// </summary>
        public NavigationSteps(NavigationPage navigationPage, OverlayPage overlayPage)
        {
            _navigationPage = navigationPage;
            _overlayPage = overlayPage;
        }

        #region Given Steps

        [Given(@"User is on the Golden1 homepage")]
        public void GivenUserIsOnTheGolden1Homepage()
        {
            LogHelper.Info("Step: User is on the Golden1 homepage");
            _navigationPage.OpenHomePage();
            LogHelper.Info("User successfully navigated to Golden1 homepage");
        }

        #endregion

        #region When Steps - Tab Navigation

        [When(@"User clicks on Personal tab")]
        public void WhenUserClicksOnPersonalTab()
        {
            LogHelper.Info("Step: User clicks on Personal tab");
            _navigationPage.ClickPersonalTab();
            LogHelper.Info("Personal tab clicked successfully");
        }

        [When(@"User clicks on Business tab")]
        public void WhenUserClicksOnBusinessTab()
        {
            LogHelper.Info("Step: User clicks on Business tab");
            _navigationPage.ClickBusinessTab();
            LogHelper.Info("Business tab clicked successfully");
        }

        [When(@"User clicks on ""(.*)"" tab")]
        public void WhenUserClicksOnTab(string tabName)
        {
            LogHelper.Info($"Step: User clicks on {tabName} tab");
            _navigationPage.ClickTabByName(tabName);
            LogHelper.Info($"{tabName} tab clicked successfully");
        }

        #endregion

        #region When Steps - Menu Navigation

        [When(@"User clicks on Checking menu")]
        public void WhenUserClicksOnCheckingMenu()
        {
            LogHelper.Info("Step: User clicks on Checking menu");
            _navigationPage.ClickCheckingMenu();
            LogHelper.Info("Checking menu clicked successfully");
        }

        [When(@"User clicks on Savings menu")]
        public void WhenUserClicksOnSavingsMenu()
        {
            LogHelper.Info("Step: User clicks on Savings menu");
            _navigationPage.ClickSavingsMenu();
            LogHelper.Info("Savings menu clicked successfully");
        }

        [When(@"User clicks on ""(.*)"" menu")]
        public void WhenUserClicksOnMenu(string menuName)
        {
            LogHelper.Info($"Step: User clicks on {menuName} menu");
            _navigationPage.ClickMenuByName(menuName);
            LogHelper.Info($"{menuName} menu clicked successfully");
        }

        #endregion

        #region When Steps - Submenu Links

        [When(@"User clicks on Free Checking link")]
        public void WhenUserClicksOnFreeCheckingLink()
        {
            LogHelper.Info("Step: User clicks on Free Checking link");
            _navigationPage.ClickFreeCheckingLink();
            LogHelper.Info("Free Checking link clicked successfully");
        }

        [When(@"User clicks on Savings Account link")]
        public void WhenUserClicksOnSavingsAccountLink()
        {
            LogHelper.Info("Step: User clicks on Savings Account link");
            _navigationPage.ClickSavingsAccountLink();
            LogHelper.Info("Savings Account link clicked successfully");
        }

        #endregion

        #region When Steps - Cookie Banner

        [When(@"User clicks Accept Cookies button")]
        public void WhenUserClicksAcceptCookiesButton()
        {
            LogHelper.Info("Step: User clicks Accept Cookies button");
            _overlayPage.ClickAcceptCookiesButton();
            LogHelper.Info("Accept Cookies button clicked successfully");
        }

        #endregion

        #region Then Steps - Navigation Verification

        [Then(@"User should see the main navigation menu")]
        public void ThenUserShouldSeeTheMainNavigationMenu()
        {
            LogHelper.Info("Step: Verifying main navigation menu is visible");
            bool isVisible = _navigationPage.IsMenuVisible();
            Assert.IsTrue(isVisible, "Main navigation menu is not visible");
            LogHelper.Info("Main navigation menu verified successfully");
        }

        [Then(@"User should see the top tabs container")]
        public void ThenUserShouldSeeTheTopTabsContainer()
        {
            LogHelper.Info("Step: Verifying top tabs container is visible");
            bool isVisible = _navigationPage.IsTopTabsContainerVisible();
            Assert.IsTrue(isVisible, "Top tabs container is not visible");
            LogHelper.Info("Top tabs container verified successfully");
        }

        [Then(@"User should see the main menu options")]
        public void ThenUserShouldSeeTheMainMenuOptions()
        {
            LogHelper.Info("Step: Verifying main menu options are visible");
            bool isVisible = _navigationPage.IsMenuVisible();
            Assert.IsTrue(isVisible, "Main menu options are not visible");
            LogHelper.Info("Main menu options verified successfully");
        }

        #endregion

        #region Then Steps - Tab Verification

        [Then(@"Personal tab should be active")]
        public void ThenPersonalTabShouldBeActive()
        {
            LogHelper.Info("Step: Verifying Personal tab is active");
            bool isActive = _navigationPage.IsTabActive("Personal");
            Assert.IsTrue(isActive, "Personal tab is not active");
            LogHelper.Info("Personal tab verified as active");
        }

        [Then(@"Business tab should be active")]
        public void ThenBusinessTabShouldBeActive()
        {
            LogHelper.Info("Step: Verifying Business tab is active");
            bool isActive = _navigationPage.IsTabActive("Business");
            Assert.IsTrue(isActive, "Business tab is not active");
            LogHelper.Info("Business tab verified as active");
        }

        [Then(@""(.*)"" tab should be active")]
        public void ThenTabShouldBeActive(string tabName)
        {
            LogHelper.Info($"Step: Verifying {tabName} tab is active");
            bool isActive = _navigationPage.IsTabActive(tabName);
            Assert.IsTrue(isActive, $"{tabName} tab is not active");
            LogHelper.Info($"{tabName} tab verified as active");
        }

        [Then(@"User should see relevant content for ""(.*)""")]
        public void ThenUserShouldSeeRelevantContentFor(string tabName)
        {
            LogHelper.Info($"Step: Verifying relevant content is displayed for {tabName}");
            bool isMenuVisible = _navigationPage.IsMenuVisible();
            Assert.IsTrue(isMenuVisible, $"Relevant content for {tabName} is not displayed");
            LogHelper.Info($"Relevant content for {tabName} verified successfully");
        }

        #endregion

        #region Then Steps - Submenu Verification

        [Then(@"Checking submenu should be displayed")]
        public void ThenCheckingSubmenuShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Checking submenu is displayed");
            bool isDisplayed = _navigationPage.IsCheckingSubmenuDisplayed();
            Assert.IsTrue(isDisplayed, "Checking submenu is not displayed");
            LogHelper.Info("Checking submenu verified successfully");
        }

        [Then(@"Savings submenu should be displayed")]
        public void ThenSavingsSubmenuShouldBeDisplayed()
        {
            LogHelper.Info("Step: Verifying Savings submenu is displayed");
            bool isDisplayed = _navigationPage.IsSavingsSubmenuDisplayed();
            Assert.IsTrue(isDisplayed, "Savings submenu is not displayed");
            LogHelper.Info("Savings submenu verified successfully");
        }

        [Then(@""(.*)"" submenu should be displayed")]
        public void ThenSubmenuShouldBeDisplayed(string menuName)
        {
            LogHelper.Info($"Step: Verifying {menuName} submenu is displayed");
            bool isDisplayed = _navigationPage.IsSubmenuDisplayed(menuName);
            Assert.IsTrue(isDisplayed, $"{menuName} submenu is not displayed");
            LogHelper.Info($"{menuName} submenu verified successfully");
        }

        #endregion

        #region Then Steps - Page Navigation Verification

        [Then(@"User should be navigated to Free Checking page")]
        public void ThenUserShouldBeNavigatedToFreeCheckingPage()
        {
            LogHelper.Info("Step: Verifying navigation to Free Checking page");
            string currentUrl = _navigationPage.GetCurrentUrl();
            Assert.That(currentUrl.ToLower(), Does.Contain("checking"), 
                $"User is not on Free Checking page. Current URL: {currentUrl}");
            LogHelper.Info("Navigation to Free Checking page verified successfully");
        }

        [Then(@"User should be navigated to Savings Account page")]
        public void ThenUserShouldBeNavigatedToSavingsAccountPage()
        {
            LogHelper.Info("Step: Verifying navigation to Savings Account page");
            string currentUrl = _navigationPage.GetCurrentUrl();
            Assert.That(currentUrl.ToLower(), Does.Contain("savings"), 
                $"User is not on Savings Account page. Current URL: {currentUrl}");
            LogHelper.Info("Navigation to Savings Account page verified successfully");
        }

        [Then(@"Page heading should contain ""(.*)""")]
        public void ThenPageHeadingShouldContain(string expectedText)
        {
            LogHelper.Info($"Step: Verifying page heading contains '{expectedText}'");
            string pageTitle = _navigationPage.GetPageTitle();
            Assert.That(pageTitle, Does.Contain(expectedText).IgnoreCase, 
                $"Page heading does not contain '{expectedText}'. Actual title: {pageTitle}");
            LogHelper.Info($"Page heading verified to contain '{expectedText}'");
        }

        #endregion

        #region Then Steps - Cookie Banner Verification

        [Then(@"User should see the cookie consent banner")]
        public void ThenUserShouldSeeTheCookieConsentBanner()
        {
            LogHelper.Info("Step: Verifying cookie consent banner is visible");
            bool isVisible = _overlayPage.IsCookieBannerVisible();
            Assert.IsTrue(isVisible, "Cookie consent banner is not visible");
            LogHelper.Info("Cookie consent banner verified successfully");
        }

        [Then(@"Cookie banner should disappear")]
        public void ThenCookieBannerShouldDisappear()
        {
            LogHelper.Info("Step: Verifying cookie banner has disappeared");
            bool isDismissed = _overlayPage.IsCookieBannerDismissed();
            Assert.IsTrue(isDismissed, "Cookie banner is still visible");
            LogHelper.Info("Cookie banner dismissal verified successfully");
        }

        #endregion
    }
}