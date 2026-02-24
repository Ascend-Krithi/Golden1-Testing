using System;
using OpenQA.Selenium;
using Golden1.Automation.Config;
using Golden1.Automation.Utilities;

namespace Golden1.Automation.Pages
{
    /// <summary>
    /// Page Object for handling overlay elements like cookie banners, popups, etc.
    /// </summary>
    public class OverlayPage : BasePage
    {
        #region Constructor
        
        public OverlayPage(IWebDriver driver) : base(driver) { }
        
        #endregion

        #region Locators
        
        private By CookieBanner => By.Id("onetrust-banner-sdk");
        private By AcceptCookiesButton => By.Id("onetrust-accept-btn-handler");
        
        #endregion

        #region Page Actions
        
        /// <summary>
        /// Clicks the Accept Cookies button on the cookie consent banner
        /// </summary>
        public void ClickAcceptCookiesButton()
        {
            try
            {
                LogHelper.Info("Clicking Accept Cookies button");
                WaitHelper.WaitClickable(Driver, AcceptCookiesButton, 10);
                Click(AcceptCookiesButton);
                LogHelper.Info("Accept Cookies button clicked successfully");
                
                // Wait for banner to disappear
                WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to click Accept Cookies button: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(Driver, "AcceptCookies_ClickFailed");
                throw;
            }
        }
        
        #endregion

        #region Verifications
        
        /// <summary>
        /// Verifies if the cookie consent banner is visible
        /// </summary>
        /// <returns>True if banner is visible, false otherwise</returns>
        public bool IsCookieBannerVisible()
        {
            try
            {
                WaitHelper.WaitVisible(Driver, CookieBanner, 10);
                bool isVisible = IsDisplayed(CookieBanner);
                LogHelper.Info($"Cookie banner visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Cookie banner not visible: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the cookie consent banner has disappeared
        /// </summary>
        /// <returns>True if banner is not visible, false otherwise</returns>
        public bool IsCookieBannerDismissed()
        {
            try
            {
                WaitHelper.WaitInvisible(Driver, CookieBanner, 5);
                bool isInvisible = !IsDisplayed(CookieBanner);
                LogHelper.Info($"Cookie banner dismissed: {isInvisible}");
                return isInvisible;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"Failed to verify cookie banner dismissal: {ex.Message}");
                return false;
            }
        }
        
        #endregion
    }
}