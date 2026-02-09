using OpenQA.Selenium;
using AutomationFramework.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace AutomationFramework.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly Dictionary<string, By> _locators;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _locators = new Dictionary<string, By>
            {
                { "HeroBanner", By.CssSelector("section.hero") },
                { "FeaturedProductSection", By.CssSelector("section.products") }
            };
        }

        public bool IsHeroBannerDisplayed()
        {
            try
            {
                WaitHelper.WaitForElementVisible(_driver, _locators["HeroBanner"]);
                return _driver.FindElement(_locators["HeroBanner"]).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsFeaturedProductSectionDisplayed()
        {
            try
            {
                WaitHelper.WaitForElementVisible(_driver, _locators["FeaturedProductSection"]);
                return _driver.FindElement(_locators["FeaturedProductSection"]).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool NoErrorMessagesPresent()
        {
            try
            {
                var errorElements = _driver.FindElements(By.XPath("//*[contains(translate(text(), 'ERROR', 'error'), 'error')]"));
                return errorElements.Count == 0;
            }
            catch
            {
                return true;
            }
        }
    }
}