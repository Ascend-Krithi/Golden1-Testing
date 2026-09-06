using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Golden1.WebAutomation.Pages
{
    public class NavigationPage : BasePage
    {
        private readonly IWebDriver _driver;

        // Locators from Golden1 Locators.Json
        private By MenuContainer => By.CssSelector("nav.menu");
        private By TopTabsContainer => By.CssSelector(".menu__toptabs");
        private By PersonalTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Personal']");
        private By BusinessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Business']");
        private By FinancialWellnessTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Financial Wellness']");
        private By AppointmentsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Appointments']");
        private By LocationsTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Locations']");
        private By MembershipTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Membership']");
        private By HelpCenterTab => By.XPath("//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Help Center']");
        private By CheckingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Checking']");
        private By SavingsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Savings']");
        private By HomeLoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Home Loans']");
        private By CreditCardsMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Credit Cards']");
        private By LoansMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Loans']");
        private By InvestingMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Investing']");
        private By CommunityMenu => By.XPath("//a[contains(@class,'nav-item-link') and normalize-space()='Community']");
        private By FreeCheckingLink => By.XPath("//a[normalize-space()='Free Checking']");
        private By SavingsAccountLink => By.XPath("//a[normalize-space()='Savings Account']");
        private By AutoLoansLink => By.XPath("//a[contains(normalize-space(),'Auto Loan')]");

        public NavigationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickPersonalTab()
        {
            LogHelper.Info("Clicking on Personal Tab");
            WaitHelper.WaitForElementToBeClickable(_driver, PersonalTab, 10);
            _driver.FindElement(PersonalTab).Click();
            LogHelper.Info("Personal Tab clicked successfully");
        }

        public void ClickBusinessTab()
        {
            LogHelper.Info("Clicking on Business Tab");
            WaitHelper.WaitForElementToBeClickable(_driver, BusinessTab, 10);
            _driver.FindElement(BusinessTab).Click();
            LogHelper.Info("Business Tab clicked successfully");
        }

        public void ClickFinancialWellnessTab()
        {
            LogHelper.Info("Clicking on Financial Wellness Tab");
            WaitHelper.WaitForElementToBeClickable(_driver, FinancialWellnessTab, 10);
            _driver.FindElement(FinancialWellnessTab).Click();
            LogHelper.Info("Financial Wellness Tab clicked successfully");
        }

        public void ClickAppointmentsTab()
        {
            LogHelper.Info("Clicking on Appointments Tab");
            WaitHelper.WaitForElementToBeClickable(_driver, AppointmentsTab, 10);
            _driver.FindElement(AppointmentsTab).Click();
            LogHelper.Info("Appointments Tab clicked successfully");
        }

        public void ClickLocationsTab()
        {
            LogHelper.Info("Clicking on Locations Tab");
            WaitHelper.WaitForElementToBeClickable(_driver, LocationsTab, 10);
            _driver.FindElement(LocationsTab).Click();
            LogHelper.Info("Locations Tab clicked successfully");
        }

        public void ClickMembershipTab()
        {
            LogHelper.Info("Clicking on Membership Tab");
            WaitHelper.WaitForElementToBeClickable(_driver, MembershipTab, 10);
            _driver.FindElement(MembershipTab).Click();
            LogHelper.Info("Membership Tab clicked successfully");
        }

        public void ClickHelpCenterTab()
        {
            LogHelper.Info("Clicking on Help Center Tab");
            WaitHelper.WaitForElementToBeClickable(_driver, HelpCenterTab, 10);
            _driver.FindElement(HelpCenterTab).Click();
            LogHelper.Info("Help Center Tab clicked successfully");
        }

        public void ClickCheckingMenu()
        {
            LogHelper.Info("Clicking on Checking Menu");
            WaitHelper.WaitForElementToBeClickable(_driver, CheckingMenu, 10);
            _driver.FindElement(CheckingMenu).Click();
            LogHelper.Info("Checking Menu clicked successfully");
        }

        public void ClickSavingsMenu()
        {
            LogHelper.Info("Clicking on Savings Menu");
            WaitHelper.WaitForElementToBeClickable(_driver, SavingsMenu, 10);
            _driver.FindElement(SavingsMenu).Click();
            LogHelper.Info("Savings Menu clicked successfully");
        }

        public void ClickHomeLoansMenu()
        {
            LogHelper.Info("Clicking on Home Loans Menu");
            WaitHelper.WaitForElementToBeClickable(_driver, HomeLoansMenu, 10);
            _driver.FindElement(HomeLoansMenu).Click();
            LogHelper.Info("Home Loans Menu clicked successfully");
        }

        public void ClickCreditCardsMenu()
        {
            LogHelper.Info("Clicking on Credit Cards Menu");
            WaitHelper.WaitForElementToBeClickable(_driver, CreditCardsMenu, 10);
            _driver.FindElement(CreditCardsMenu).Click();
            LogHelper.Info("Credit Cards Menu clicked successfully");
        }

        public void ClickLoansMenu()
        {
            LogHelper.Info("Clicking on Loans Menu");
            WaitHelper.WaitForElementToBeClickable(_driver, LoansMenu, 10);
            _driver.FindElement(LoansMenu).Click();
            LogHelper.Info("Loans Menu clicked successfully");
        }

        public void ClickInvestingMenu()
        {
            LogHelper.Info("Clicking on Investing Menu");
            WaitHelper.WaitForElementToBeClickable(_driver, InvestingMenu, 10);
            _driver.FindElement(InvestingMenu).Click();
            LogHelper.Info("Investing Menu clicked successfully");
        }

        public void ClickCommunityMenu()
        {
            LogHelper.Info("Clicking on Community Menu");
            WaitHelper.WaitForElementToBeClickable(_driver, CommunityMenu, 10);
            _driver.FindElement(CommunityMenu).Click();
            LogHelper.Info("Community Menu clicked successfully");
        }

        public void ClickFreeCheckingLink()
        {
            LogHelper.Info("Clicking on Free Checking Link");
            WaitHelper.WaitForElementToBeClickable(_driver, FreeCheckingLink, 10);
            _driver.FindElement(FreeCheckingLink).Click();
            LogHelper.Info("Free Checking Link clicked successfully");
        }

        public void ClickSavingsAccountLink()
        {
            LogHelper.Info("Clicking on Savings Account Link");
            WaitHelper.WaitForElementToBeClickable(_driver, SavingsAccountLink, 10);
            _driver.FindElement(SavingsAccountLink).Click();
            LogHelper.Info("Savings Account Link clicked successfully");
        }

        public void ClickAutoLoansLink()
        {
            LogHelper.Info("Clicking on Auto Loans Link");
            WaitHelper.WaitForElementToBeClickable(_driver, AutoLoansLink, 10);
            _driver.FindElement(AutoLoansLink).Click();
            LogHelper.Info("Auto Loans Link clicked successfully");
        }

        public bool IsMenuContainerDisplayed()
        {
            LogHelper.Info("Verifying Menu Container is displayed");
            WaitHelper.WaitForElementToBeVisible(_driver, MenuContainer, 10);
            bool isDisplayed = _driver.FindElement(MenuContainer).Displayed;
            LogHelper.Info($"Menu Container displayed: {isDisplayed}");
            return isDisplayed;
        }

        public bool IsTopTabsContainerDisplayed()
        {
            LogHelper.Info("Verifying Top Tabs Container is displayed");
            WaitHelper.WaitForElementToBeVisible(_driver, TopTabsContainer, 10);
            bool isDisplayed = _driver.FindElement(TopTabsContainer).Displayed;
            LogHelper.Info($"Top Tabs Container displayed: {isDisplayed}");
            return isDisplayed;
        }

        public void NavigateToCheckingFromPersonal()
        {
            LogHelper.Info("Navigating to Checking from Personal Tab");
            ClickPersonalTab();
            ClickCheckingMenu();
            LogHelper.Info("Navigation to Checking completed");
        }

        public void NavigateToFreeChecking()
        {
            LogHelper.Info("Navigating to Free Checking Page");
            ClickPersonalTab();
            ClickCheckingMenu();
            ClickFreeCheckingLink();
            LogHelper.Info("Navigation to Free Checking completed");
        }

        public void NavigateToSavingsAccount()
        {
            LogHelper.Info("Navigating to Savings Account Page");
            ClickPersonalTab();
            ClickSavingsMenu();
            ClickSavingsAccountLink();
            LogHelper.Info("Navigation to Savings Account completed");
        }

        public void NavigateToAutoLoans()
        {
            LogHelper.Info("Navigating to Auto Loans Page");
            ClickPersonalTab();
            ClickLoansMenu();
            ClickAutoLoansLink();
            LogHelper.Info("Navigation to Auto Loans completed");
        }
    }
}