using System;
using OpenQA.Selenium;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    public class OverlayPage : BasePage
    {
        // CONSTRUCTOR
        public OverlayPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS - Based on Golden1 Locators.Json
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // SECTION 2: PAGE ACTIONS
        public void AcceptCookies()
        {
            LogHelper.Info("Attempting to accept cookies");
            try
            {
                if (IsCookieBannerDisplayed())
                {
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookies accepted successfully");
                }
                else
                {
                    LogHelper.Info("Cookie banner not displayed, skipping acceptance");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to accept cookies: {ex.Message}");
                throw;
            }
        }

        // SECTION 3: VERIFICATIONS
        public bool IsCookieBannerDisplayed()
        {
            LogHelper.Info("Checking if cookie banner is displayed");
            try
            {
                WaitHelper.WaitVisible(Driver, CookieBanner, 3);
                bool isDisplayed = IsDisplayed(CookieBanner);
                LogHelper.Info($"Cookie banner displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Cookie banner not displayed: {ex.Message}");
                return false;
            }
        }

        public bool IsCookieBannerNotVisible()
        {
            LogHelper.Info("Verifying cookie banner is not visible");
            try
            {
                WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                bool isInvisible = !IsDisplayed(CookieBanner);
                LogHelper.Info($"Cookie banner not visible: {isInvisible}");
                return isInvisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify cookie banner invisibility: {ex.Message}");
                return false;
            }
        }
    }
}