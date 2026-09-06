using OpenQA.Selenium;
using System;

namespace Golden1.WebAutomation.Pages
{
    public class OverlayPage : BasePage
    {
        private readonly IWebDriver _driver;

        // Overlay Locators from Golden1 Locators.Json
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        public OverlayPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public bool IsCookieBannerDisplayed()
        {
            LogHelper.Info("Checking if Cookie Banner is displayed");
            try
            {
                WaitHelper.WaitForElementToBeVisible(_driver, CookieBanner, 5);
                bool isDisplayed = _driver.FindElement(CookieBanner).Displayed;
                LogHelper.Info($"Cookie Banner displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Cookie Banner not displayed: {ex.Message}");
                return false;
            }
        }

        public void AcceptCookies()
        {
            LogHelper.Info("Attempting to accept cookies");
            try
            {
                if (IsCookieBannerDisplayed())
                {
                    WaitHelper.WaitForElementToBeClickable(_driver, AcceptCookiesButton, 5);
                    _driver.FindElement(AcceptCookiesButton).Click();
                    LogHelper.Info("Cookies accepted successfully");
                    WaitHelper.WaitForElementToBeInvisible(_driver, CookieBanner, 5);
                }
                else
                {
                    LogHelper.Info("Cookie Banner not present, skipping accept action");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Could not accept cookies: {ex.Message}");
            }
        }

        public void HandleAllOverlays()
        {
            LogHelper.Info("Handling all overlays");
            AcceptCookies();
            LogHelper.Info("All overlays handled");
        }
    }
}