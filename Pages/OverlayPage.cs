using System;
using OpenQA.Selenium;
using ProjectName.Automation.Utilities;

namespace ProjectName.Automation.Pages
{
    public class OverlayPage : BasePage
    {
        // Constructor
        public OverlayPage(IWebDriver driver) : base(driver) { }

        // SECTION 1: LOCATORS (Private, Read-only Properties)
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");

        // SECTION 2: PAGE ACTIONS (Public Methods)
        public void AcceptCookiesIfDisplayed()
        {
            try
            {
                LogHelper.Info("Checking if cookie banner is displayed");
                if (IsCookieBannerDisplayed())
                {
                    LogHelper.Info("Cookie banner is displayed, accepting cookies");
                    WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 5);
                    Click(AcceptCookiesButton);
                    WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                    LogHelper.Info("Cookies accepted successfully");
                }
                else
                {
                    LogHelper.Info("Cookie banner not displayed, skipping");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"Cookie banner handling: {ex.Message}");
                // Don't throw - cookie banner is optional
            }
        }

        // SECTION 3: VERIFICATIONS (Public Methods returning bool)
        public bool IsCookieBannerDisplayed()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, CookieBanner, 3);
                bool isDisplayed = IsDisplayed(CookieBanner);
                LogHelper.Info($"Cookie banner displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}