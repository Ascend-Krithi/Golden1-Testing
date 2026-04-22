using OpenQA.Selenium;
using Golden1.Automation.Framework.Utilities;

namespace Golden1.Automation.Framework.Pages
{
    public class CheckingPage : BasePage
    {
        private readonly WaitHelper _waitHelper;
        private readonly LogHelper _logHelper;

        // Locators
        private By PageTitle => By.XPath("//h1[contains(text(), 'Checking')]");
        private By CheckingAccountsContainer => By.XPath("//div[contains(@class, 'checking-accounts')]");
        private By ErrorMessage => By.XPath("//div[contains(@class, 'error-message')]");
        private By LoadingSpinner => By.XPath("//div[contains(@class, 'loading-spinner')]");
        private By FreeCheckingLink => By.XPath("//a[text()='Free Checking']");
        private By PlatinumCheckingLink => By.XPath("//a[text()='Platinum Checking']");

        public CheckingPage()
        {
            _waitHelper = new WaitHelper();
            _logHelper = new LogHelper();
        }

        public bool IsPageLoaded()
        {
            _logHelper.LogInfo("Checking if CheckingPage is loaded");
            _waitHelper.WaitForElementVisible(PageTitle, 30);
            return _waitHelper.IsElementPresent(PageTitle);
        }

        public bool IsPageFullyLoaded()
        {
            _logHelper.LogInfo("Checking if CheckingPage is fully loaded");
            _waitHelper.WaitForPageLoad();
            _waitHelper.WaitForElementVisible(CheckingAccountsContainer, 20);
            return !_waitHelper.IsElementPresent(LoadingSpinner) && 
                   _waitHelper.IsElementDisplayed(CheckingAccountsContainer);
        }

        public bool HasErrorMessages()
        {
            _logHelper.LogInfo("Checking for error messages on CheckingPage");
            return _waitHelper.IsElementPresent(ErrorMessage);
        }

        public void ClickFreeCheckingLink()
        {
            _logHelper.LogInfo("Clicking Free Checking link");
            _waitHelper.WaitForElementClickable(FreeCheckingLink, 10);
            _waitHelper.ClickElement(FreeCheckingLink);
        }

        public void ClickPlatinumCheckingLink()
        {
            _logHelper.LogInfo("Clicking Platinum Checking link");
            _waitHelper.WaitForElementClickable(PlatinumCheckingLink, 10);
            _waitHelper.ClickElement(PlatinumCheckingLink);
        }

        public string GetPageTitle()
        {
            _logHelper.LogInfo("Getting CheckingPage title");
            _waitHelper.WaitForElementVisible(PageTitle, 10);
            return _waitHelper.GetElementText(PageTitle);
        }
    }
}