using OpenQA.Selenium;
using Project1.Automation.Utilities;

namespace Project1.Automation.Pages
{
    public class FooterPage
    {
        private readonly IWebDriver Driver;

        // Locators - TO BE POPULATED FROM LOCATOR DEFINITIONS FILE
        private By ContactInformation => By.XPath("[LOCATOR_NEEDED]");
        private By PrivacyPolicyLink => By.XPath("[LOCATOR_NEEDED]");
        private By TermsLink => By.XPath("[LOCATOR_NEEDED]");
        private By FooterSection => By.XPath("[LOCATOR_NEEDED]");

        public FooterPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void VerifyFooterSectionVisible()
        {
            LogHelper.Info("Verifying footer section is visible");
            WaitHelper.WaitVisible(Driver, FooterSection, 10);
            Assert.That(Driver.FindElement(FooterSection).Displayed, Is.True, "Footer section is not visible");
            LogHelper.Info("Footer section verification completed");
        }

        public void ClickPrivacyPolicyLink()
        {
            LogHelper.Info("Clicking Privacy Policy link");
            WaitHelper.WaitVisible(Driver, PrivacyPolicyLink, 10);
            WaitHelper.WaitClickable(Driver, PrivacyPolicyLink, 10);
            Driver.FindElement(PrivacyPolicyLink).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Privacy Policy link clicked successfully");
        }

        public void ClickTermsLink()
        {
            LogHelper.Info("Clicking Terms link");
            WaitHelper.WaitVisible(Driver, TermsLink, 10);
            WaitHelper.WaitClickable(Driver, TermsLink, 10);
            Driver.FindElement(TermsLink).Click();
            WaitHelper.WaitForPageLoad(Driver);
            LogHelper.Info("Terms link clicked successfully");
        }

        public bool IsContactInformationVisible()
        {
            LogHelper.Info("Checking if contact information is visible");
            WaitHelper.WaitVisible(Driver, ContactInformation, 10);
            return Driver.FindElement(ContactInformation).Displayed;
        }
    }
}