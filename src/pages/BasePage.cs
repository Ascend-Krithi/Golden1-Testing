using OpenQA.Selenium;
using Golden1.Automation.Framework.Core;

namespace Golden1.Automation.Framework.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver => DriverManager.GetDriver();

        protected BasePage()
        {
        }
    }
}