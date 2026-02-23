using System;
using System.Collections.Generic;
using NUnit.Framework;
using Golden1.Automation.Pages;
using Golden1.Automation.Utilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Golden1.Automation.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly NavigationPage _navigationPage;
        private readonly OverlayPage _overlayPage;

        // CONSTRUCTOR INJECTION
        public NavigationSteps(NavigationPage navigationPage, OverlayPage overlayPage)
        {
            _navigationPage = navigationPage;
            _overlayPage = overlayPage;
        }

        // GIVEN STEPS - Setup/Preconditions
        [Given(@"the user is on the Golden1 homepage")]
        public void GivenUserIsOnGolden1Homepage()
        {
            LogHelper.Info("Step: Given the user is on the Golden1 homepage");
            _navigationPage.OpenHomePage();
            
            // Handle cookie banner if present
            if (_overlayPage.IsCookieBannerDisplayed())
            {
                _overlayPage.AcceptCookies();
            }
        }

        [Given(@"the cookie banner is displayed")]
        public void GivenCookieBannerIsDisplayed()
        {
            LogHelper.Info("Step: Given the cookie banner is displayed");
            bool isDisplayed = _overlayPage.IsCookieBannerDisplayed();
            Assert.IsTrue(isDisplayed, "Cookie banner should be displayed");
        }

        // WHEN STEPS - Actions
        [When(@"the user opens the Golden1 application")]
        public void WhenUserOpensGolden1Application()
        {
            LogHelper.Info("Step: When the user opens the Golden1 application");
            _navigationPage.OpenHomePage();
        }

        [When(@"the user clicks on the ""(.*?)"" menu option")]
        public void WhenUserClicksOnMenuOption(string menuOption)
        {
            LogHelper.Info($"Step: When the user clicks on the '{menuOption}' menu option");
            _navigationPage.ClickMenuOption(menuOption);
        }

        [When(@"the user clicks on the ""(.*?)"" link")]
        public void WhenUserClicksOnLink(string linkName)
        {
            LogHelper.Info($"Step: When the user clicks on the '{linkName}' link");
            _navigationPage.ClickSubMenuLink(linkName);
        }

        [When(@"the user clicks on the ""(.*?)"" top tab")]
        public void WhenUserClicksOnTopTab(string tabName)
        {
            LogHelper.Info($"Step: When the user clicks on the '{tabName}' top tab");
            _navigationPage.ClickTopTab(tabName);
        }

        [When(@"the user accepts cookies")]
        public void WhenUserAcceptsCookies()
        {
            LogHelper.Info("Step: When the user accepts cookies");
            _overlayPage.AcceptCookies();
        }

        // THEN STEPS - Assertions
        [Then(@"the homepage should be displayed")]
        public void ThenHomepageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Then the homepage should be displayed");
            bool isDisplayed = _navigationPage.IsPageDisplayed("Home");
            Assert.IsTrue(isDisplayed, "Homepage should be displayed");
            LogHelper.Info("Homepage verified as displayed");
        }

        [Then(@"the main menu container should be visible")]
        public void ThenMainMenuContainerShouldBeVisible()
        {
            LogHelper.Info("Step: Then the main menu container should be visible");
            bool isVisible = _navigationPage.IsMenuContainerVisible();
            Assert.IsTrue(isVisible, "Main menu container should be visible");
            LogHelper.Info("Main menu container verified as visible");
        }

        [Then(@"the following top navigation tabs should be visible")]
        public void ThenFollowingTopNavigationTabsShouldBeVisible(Table table)
        {
            LogHelper.Info("Step: Then the following top navigation tabs should be visible");
            var tabs = table.CreateSet<TabData>();
            
            foreach (var tab in tabs)
            {
                bool isVisible = _navigationPage.IsTopTabVisible(tab.TabName);
                Assert.IsTrue(isVisible, $"Top navigation tab '{tab.TabName}' should be visible");
                LogHelper.Info($"Top tab '{tab.TabName}' verified as visible");
            }
        }

        [Then(@"the ""(.*?)"" section should be displayed")]
        public void ThenSectionShouldBeDisplayed(string sectionName)
        {
            LogHelper.Info($"Step: Then the '{sectionName}' section should be displayed");
            bool isDisplayed = _navigationPage.IsPageDisplayed(sectionName);
            Assert.IsTrue(isDisplayed, $"The '{sectionName}' section should be displayed");
            LogHelper.Info($"Section '{sectionName}' verified as displayed");
        }

        [Then(@"the Free Checking page should be displayed")]
        public void ThenFreeCheckingPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Then the Free Checking page should be displayed");
            bool isDisplayed = _navigationPage.IsPageDisplayed("Free Checking");
            Assert.IsTrue(isDisplayed, "Free Checking page should be displayed");
            LogHelper.Info("Free Checking page verified as displayed");
        }

        [Then(@"the Savings Account page should be displayed")]
        public void ThenSavingsAccountPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Then the Savings Account page should be displayed");
            bool isDisplayed = _navigationPage.IsPageDisplayed("Savings Account");
            Assert.IsTrue(isDisplayed, "Savings Account page should be displayed");
            LogHelper.Info("Savings Account page verified as displayed");
        }

        [Then(@"the Auto Loans page should be displayed")]
        public void ThenAutoLoansPageShouldBeDisplayed()
        {
            LogHelper.Info("Step: Then the Auto Loans page should be displayed");
            bool isDisplayed = _navigationPage.IsPageDisplayed("Auto Loans");
            Assert.IsTrue(isDisplayed, "Auto Loans page should be displayed");
            LogHelper.Info("Auto Loans page verified as displayed");
        }

        [Then(@"the cookie banner should not be visible")]
        public void ThenCookieBannerShouldNotBeVisible()
        {
            LogHelper.Info("Step: Then the cookie banner should not be visible");
            bool isNotVisible = _overlayPage.IsCookieBannerNotVisible();
            Assert.IsTrue(isNotVisible, "Cookie banner should not be visible");
            LogHelper.Info("Cookie banner verified as not visible");
        }

        // HELPER CLASS FOR TABLE DATA
        private class TabData
        {
            public string TabName { get; set; }
        }
    }
}