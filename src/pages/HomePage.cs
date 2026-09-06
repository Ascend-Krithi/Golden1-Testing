using OpenQA.Selenium;
using System;

namespace Golden1.WebAutomation.Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver _driver;
        private readonly NavigationPage _navigationPage;

        // Home Page Specific Locators
        private By Logo => By.CssSelector(".logo, .header-logo, img[alt*='Golden 1']");
        private By LoginButton => By.XPath("//a[contains(text(),'Log In') or contains(text(),'Login')]");
        private By OpenAccountButton => By.XPath("//a[contains(text(),'Open Account')]");
        private By HeroBanner => By.CssSelector(".hero, .banner, .hero-section");

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _navigationPage = new NavigationPage(driver);
        }

        public void NavigateToHomePage()
        {
            string url = ConfigReader.GetApplicationUrl();
            LogHelper.Info($"Navigating to Home Page: {url}");
            _driver.Navigate().GoToUrl(url);
            WaitHelper.WaitForPageLoad(_driver, 15);
            LogHelper.Info("Home Page loaded successfully");
        }

        public bool IsLogoDisplayed()
        {
            LogHelper.Info("Verifying Logo is displayed");
            try
            {
                WaitHelper.WaitForElementToBeVisible(_driver, Logo, 10);
                bool isDisplayed = _driver.FindElement(Logo).Displayed;
                LogHelper.Info($"Logo displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Logo not found: {ex.Message}");
                return false;
            }
        }

        public bool IsLoginButtonDisplayed()
        {
            LogHelper.Info("Verifying Login Button is displayed");
            try
            {
                WaitHelper.WaitForElementToBeVisible(_driver, LoginButton, 10);
                bool isDisplayed = _driver.FindElement(LoginButton).Displayed;
                LogHelper.Info($"Login Button displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Login Button not found: {ex.Message}");
                return false;
            }
        }

        public bool IsOpenAccountButtonDisplayed()
        {
            LogHelper.Info("Verifying Open Account Button is displayed");
            try
            {
                WaitHelper.WaitForElementToBeVisible(_driver, OpenAccountButton, 10);
                bool isDisplayed = _driver.FindElement(OpenAccountButton).Displayed;
                LogHelper.Info($"Open Account Button displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Open Account Button not found: {ex.Message}");
                return false;
            }
        }

        public bool IsHeroBannerDisplayed()
        {
            LogHelper.Info("Verifying Hero Banner is displayed");
            try
            {
                WaitHelper.WaitForElementToBeVisible(_driver, HeroBanner, 10);
                bool isDisplayed = _driver.FindElement(HeroBanner).Displayed;
                LogHelper.Info($"Hero Banner displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Hero Banner not found: {ex.Message}");
                return false;
            }
        }

        public void ClickLoginButton()
        {
            LogHelper.Info("Clicking Login Button");
            WaitHelper.WaitForElementToBeClickable(_driver, LoginButton, 10);
            _driver.FindElement(LoginButton).Click();
            LogHelper.Info("Login Button clicked successfully");
        }

        public void ClickOpenAccountButton()
        {
            LogHelper.Info("Clicking Open Account Button");
            WaitHelper.WaitForElementToBeClickable(_driver, OpenAccountButton, 10);
            _driver.FindElement(OpenAccountButton).Click();
            LogHelper.Info("Open Account Button clicked successfully");
        }

        public string GetPageTitle()
        {
            LogHelper.Info("Getting Page Title");
            string title = _driver.Title;
            LogHelper.Info($"Page Title: {title}");
            return title;
        }

        public NavigationPage GetNavigationPage()
        {
            return _navigationPage;
        }
    }
}