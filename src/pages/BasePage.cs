using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Golden1.Automation.Framework.Core;

namespace Golden1.Automation.Framework.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver => DriverManager.GetDriver();

        public BasePage()
        {
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }

        public string GetCurrentUrl()
        {
            return Driver.Url;
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public void NavigateForward()
        {
            Driver.Navigate().Forward();
        }
    }
}