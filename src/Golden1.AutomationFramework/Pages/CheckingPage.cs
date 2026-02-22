using OpenQA.Selenium;
using Golden1.AutomationFramework.Utilities;

namespace Golden1.AutomationFramework.Pages
{
    public class CheckingPage : BasePage
    {
        // Locators - These should be loaded from locators.json
        private readonly By _freeCheckingLinkLocator = By.XPath("//a[text()='Free Checking']");
        private readonly By _rewardsCheckingLinkLocator = By.XPath("//a[text()='Rewards Checking']");
        private readonly By _pageHeaderLocator = By.XPath("//h1[contains(text(),'Checking')]");

        public CheckingPage(IWebDriver driver) : base(driver)
        {
            LogHelper.LogInfo("CheckingPage initialized");
        }

        public void ClickFreeCheckingLink()
        {
            ClickElement(_freeCheckingLinkLocator, "Free Checking Link");
            LogHelper.LogInfo("Clicked on Free Checking Link");
        }

        public void ClickRewardsCheckingLink()
        {
            ClickElement(_rewardsCheckingLinkLocator, "Rewards Checking Link");
            LogHelper.LogInfo("Clicked on Rewards Checking Link");
        }

        public string GetPageHeader()
        {
            return GetElementText(_pageHeaderLocator, "Page Header");
        }

        public bool IsFreeCheckingLinkDisplayed()
        {
            return IsElementDisplayed(_freeCheckingLinkLocator, "Free Checking Link");
        }
    }
}