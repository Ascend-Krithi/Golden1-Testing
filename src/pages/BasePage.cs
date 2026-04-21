using OpenQA.Selenium;
using [ProjectNamespace].Utilities;

namespace [ProjectNamespace].Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        
        protected void WaitForPageLoad()
        {
            WaitHelper.WaitForPageLoad(Driver);
        }
    }
}