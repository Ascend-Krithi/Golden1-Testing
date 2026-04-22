using OpenQA.Selenium;
using Golden1.Automation.Framework.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Golden1.Automation.Framework.Pages
{
    public class HomePage : BasePage
    {
        private readonly WaitHelper _waitHelper;
        private readonly LogHelper _logHelper;

        // Locators
        private By _logoLocator = By.XPath("//a[@class='logo']//img | //img[@alt='Golden 1 Credit Union']");
        private By _globalNavigationMenuLocator = By.XPath("//nav[@class='global-navigation'] | //div[@class='main-navigation']");
        private By _errorMessageLocator = By.XPath("//div[contains(@class, 'error')] | //div[contains(@class, 'alert')]");
        private By _productMenuContainerLocator = By.XPath("//div[@class='product-menu'] | //ul[@class='submenu']");

        public HomePage()
        {
            _waitHelper = new WaitHelper();
            _logHelper = new LogHelper();
        }

        public bool IsLogoDisplayed()
        {
            try
            {
                _waitHelper.WaitForElementVisible(_logoLocator);
                return Driver.FindElement(_logoLocator).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                _logHelper.LogError($"Logo not found: {ex.Message}");
                return false;
            }
        }

        public bool HasErrorMessages()
        {
            try
            {
                var errorElements = Driver.FindElements(_errorMessageLocator);
                return errorElements.Any(e => e.Displayed);
            }
            catch
            {
                return false;
            }
        }

        public bool IsGlobalNavigationMenuVisible()
        {
            try
            {
                _waitHelper.WaitForElementVisible(_globalNavigationMenuLocator);
                return Driver.FindElement(_globalNavigationMenuLocator).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                _logHelper.LogError($"Global navigation menu not found: {ex.Message}");
                return false;
            }
        }

        public bool IsNavigationOptionPresent(string navigationOption)
        {
            try
            {
                By locator = By.XPath($"//nav//a[contains(text(), '{navigationOption}')] | //div[@class='main-navigation']//a[contains(text(), '{navigationOption}')]");
                _waitHelper.WaitForElementVisible(locator);
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                _logHelper.LogError($"Navigation option '{navigationOption}' not found: {ex.Message}");
                return false;
            }
        }

        public void HoverOverNavigationOption(string navigationOption)
        {
            try
            {
                By locator = GetNavigationOptionLocator(navigationOption);
                _waitHelper.WaitForElementVisible(locator);
                IWebElement element = Driver.FindElement(locator);
                Actions actions = new Actions(Driver);
                actions.MoveToElement(element).Perform();
                _logHelper.LogInfo($"Hovered over navigation option: {navigationOption}");
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to hover over navigation option '{navigationOption}': {ex.Message}");
                throw;
            }
        }

        public bool AreProductMenusDisplayed()
        {
            try
            {
                _waitHelper.WaitForElementVisible(_productMenuContainerLocator);
                return Driver.FindElement(_productMenuContainerLocator).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                _logHelper.LogError($"Product menu container not found: {ex.Message}");
                return false;
            }
        }

        public bool IsProductMenuVisible(string productMenu)
        {
            try
            {
                By locator = GetProductMenuLocator(productMenu);
                _waitHelper.WaitForElementVisible(locator);
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                _logHelper.LogError($"Product menu '{productMenu}' not found: {ex.Message}");
                return false;
            }
        }

        public void HoverOverProductMenu(string productMenu)
        {
            try
            {
                By locator = GetProductMenuLocator(productMenu);
                _waitHelper.WaitForElementVisible(locator);
                IWebElement element = Driver.FindElement(locator);
                Actions actions = new Actions(Driver);
                actions.MoveToElement(element).Perform();
                _logHelper.LogInfo($"Hovered over product menu: {productMenu}");
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to hover over product menu '{productMenu}': {ex.Message}");
                throw;
            }
        }

        public bool AreSubmenuItemsDisplayed(string productMenu)
        {
            try
            {
                By locator = GetSubmenuContainerLocator(productMenu);
                _waitHelper.WaitForElementVisible(locator);
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                _logHelper.LogError($"Submenu items for '{productMenu}' not found: {ex.Message}");
                return false;
            }
        }

        public bool AreAllSubmenuItemsClickable()
        {
            try
            {
                var submenuItems = Driver.FindElements(By.XPath("//div[@class='submenu']//a | //ul[@class='submenu']//a"));
                foreach (var item in submenuItems)
                {
                    if (!item.Enabled || !item.Displayed)
                    {
                        return false;
                    }
                }
                return submenuItems.Count > 0;
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to check submenu items clickability: {ex.Message}");
                return false;
            }
        }

        public void ClickSubmenuItem(string submenuItem)
        {
            try
            {
                By locator = GetSubmenuItemLocator(submenuItem);
                _waitHelper.WaitForElementClickable(locator);
                IWebElement element = Driver.FindElement(locator);
                element.Click();
                _logHelper.LogInfo($"Clicked on submenu item: {submenuItem}");
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to click submenu item '{submenuItem}': {ex.Message}");
                throw;
            }
        }

        public bool HasBrokenLayouts()
        {
            try
            {
                // Check for elements with zero or negative dimensions
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                var result = (bool)js.ExecuteScript(
                    "var elements = document.querySelectorAll('*');" +
                    "for(var i=0; i<elements.length; i++){" +
                    "  var rect = elements[i].getBoundingClientRect();" +
                    "  if(rect.width < 0 || rect.height < 0) return true;" +
                    "}" +
                    "return false;"
                );
                return result;
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to check for broken layouts: {ex.Message}");
                return false;
            }
        }

        public bool HasMissingImages()
        {
            try
            {
                var images = Driver.FindElements(By.TagName("img"));
                foreach (var img in images)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    var naturalWidth = (long)js.ExecuteScript("return arguments[0].naturalWidth;", img);
                    if (naturalWidth == 0)
                    {
                        _logHelper.LogWarning($"Missing image detected: {img.GetAttribute("src")}");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to check for missing images: {ex.Message}");
                return false;
            }
        }

        public bool HasMisplacedElements()
        {
            try
            {
                // Check for elements positioned outside viewport
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                var result = (bool)js.ExecuteScript(
                    "var elements = document.querySelectorAll('*');" +
                    "var viewportWidth = window.innerWidth;" +
                    "var viewportHeight = window.innerHeight;" +
                    "for(var i=0; i<elements.length; i++){" +
                    "  var rect = elements[i].getBoundingClientRect();" +
                    "  if(rect.left < -1000 || rect.top < -1000) return true;" +
                    "}" +
                    "return false;"
                );
                return result;
            }
            catch (Exception ex)
            {
                _logHelper.LogError($"Failed to check for misplaced elements: {ex.Message}");
                return false;
            }
        }

        // Locator getter methods
        public By GetLogoLocator()
        {
            return _logoLocator;
        }

        public By GetGlobalNavigationMenuLocator()
        {
            return _globalNavigationMenuLocator;
        }

        public By GetNavigationOptionLocator(string navigationOption)
        {
            return By.XPath($"//nav//a[contains(text(), '{navigationOption}')] | //div[@class='main-navigation']//a[contains(text(), '{navigationOption}')]");
        }

        public By GetProductMenuContainerLocator()
        {
            return _productMenuContainerLocator;
        }

        public By GetProductMenuLocator(string productMenu)
        {
            return By.XPath($"//div[@class='product-menu']//a[contains(text(), '{productMenu}')] | //ul[@class='submenu']//a[contains(text(), '{productMenu}')]");
        }

        public By GetSubmenuContainerLocator(string productMenu)
        {
            return By.XPath($"//div[@class='submenu-container'] | //div[contains(@class, 'submenu')]");
        }

        public By GetSubmenuItemLocator(string submenuItem)
        {
            return By.XPath($"//div[@class='submenu']//a[contains(text(), '{submenuItem}')] | //ul[@class='submenu']//a[contains(text(), '{submenuItem}')]");
        }
    }
}