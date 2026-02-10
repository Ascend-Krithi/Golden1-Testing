using OpenQA.Selenium;
using Project1.Automation.Utilities;

namespace Project1.Automation.Pages
{
    public class CheckingPage
    {
        private readonly IWebDriver Driver;

        // Locators - TO BE POPULATED FROM LOCATOR DEFINITIONS FILE
        private By PageHeading => By.XPath("[LOCATOR_NEEDED]");
        private By PageContent => By.XPath("[LOCATOR_NEEDED]");
        private By ProductInformation => By.XPath("[LOCATOR_NEEDED]");

        public CheckingPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void VerifyCheckingPageLoaded()
        {
            LogHelper.Info("Verifying Checking Page is loaded");
            WaitHelper.WaitVisible(Driver, PageHeading, 10);
            Assert.That(Driver.FindElement(PageHeading).Displayed, Is.True, "Checking Page heading is not visible");
            LogHelper.Info("Checking Page loaded successfully");
        }

        public void VerifyPageContentDisplayed()
        {
            LogHelper.Info("Verifying page content is displayed");
            WaitHelper.WaitVisible(Driver, PageContent, 10);
            Assert.That(Driver.FindElement(PageContent).Displayed, Is.True, "Page content is not visible");
            LogHelper.Info("Page content verification completed");
        }

        public string GetPageHeading()
        {
            LogHelper.Info("Getting page heading text");
            WaitHelper.WaitVisible(Driver, PageHeading, 10);
            string headingText = Driver.FindElement(PageHeading).Text;
            LogHelper.Info($"Page heading: {headingText}");
            return headingText;
        }

        public bool IsProductInformationVisible()
        {
            LogHelper.Info("Checking if product information is visible");
            WaitHelper.WaitVisible(Driver, ProductInformation, 10);
            return Driver.FindElement(ProductInformation).Displayed;
        }
    }
}