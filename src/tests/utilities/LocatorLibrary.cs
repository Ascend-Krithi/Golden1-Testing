using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Golden1.Tests.Utilities
{
    public class LocatorLibrary
    {
        private readonly Dictionary<string, Dictionary<string, LocatorInfo>> _locators;

        public LocatorLibrary()
        {
            _locators = new Dictionary<string, Dictionary<string, LocatorInfo>>
            {
                {
                    "NavigationLocators", new Dictionary<string, LocatorInfo>
                    {
                        { "TopNavBar", new LocatorInfo("css", "header nav") },
                        { "Logo", new LocatorInfo("css", "header .logo img") },
                        { "OpenAccountButton", new LocatorInfo("xpath", "//a[normalize-space()='Open Account']") },
                        { "LoginButton", new LocatorInfo("xpath", "//button[contains(., 'Log In') or contains(., 'Login')]") },
                        { "PersonalMenu", new LocatorInfo("xpath", "//nav//a[normalize-space()='Personal']") },
                        { "BusinessMenu", new LocatorInfo("xpath", "//nav//a[normalize-space()='Business']") },
                        { "FinancialWellnessMenu", new LocatorInfo("xpath", "//nav//a[normalize-space()='Financial Wellness']") },
                        { "AppointmentsMenu", new LocatorInfo("xpath", "//nav//a[normalize-space()='Appointments']") },
                        { "LocationsMenu", new LocatorInfo("xpath", "//nav//a[normalize-space()='Locations']") },
                        { "HelpCenterMenu", new LocatorInfo("xpath", "//nav//a[normalize-space()='Help Center']") },
                        { "MobileDepositLink", new LocatorInfo("xpath", "//a[contains(normalize-space(),'Mobile Deposit')]") },
                        { "OnlineBankingLink", new LocatorInfo("xpath", "//a[contains(normalize-space(),'Online Banking')]") },
                        { "BillPayLink", new LocatorInfo("xpath", "//a[contains(normalize-space(),'Bill Pay')]") }
                    }
                },
                {
                    "FooterLocators", new Dictionary<string, LocatorInfo>
                    {
                        { "FooterSection", new LocatorInfo("css", "footer") },
                        { "PrivacyPolicyLink", new LocatorInfo("xpath", "//footer//a[contains(text(),'Privacy')]") },
                        { "TermsConditionsLink", new LocatorInfo("xpath", "//footer//a[contains(normalize-space(),'Terms & Conditions')]") },
                        { "ContactUsLink", new LocatorInfo("xpath", "//footer//a[contains(normalize-space(),'Contact Us')]") }
                    }
                },
                {
                    "HomePageLocators", new Dictionary<string, LocatorInfo>
                    {
                        { "HeroBanner", new LocatorInfo("css", "section.hero") },
                        { "FeaturedProductSection", new LocatorInfo("css", "section.products") },
                        { "SearchInput", new LocatorInfo("css", "input[type='search']") }
                    }
                },
                {
                    "OverlayLocators", new Dictionary<string, LocatorInfo>
                    {
                        { "CookieAccept", new LocatorInfo("xpath", "//button[contains(translate(text(),'ACCEPT','accept'),'accept')]") },
                        { "ModalClose", new LocatorInfo("css", "button.close, button[aria-label*='Close']") }
                    }
                }
            };
        }

        public By GetLocator(string category, string locatorName)
        {
            if (!_locators.ContainsKey(category))
            {
                throw new ArgumentException($"Category '{category}' not found in locator library");
            }

            if (!_locators[category].ContainsKey(locatorName))
            {
                throw new ArgumentException($"Locator '{locatorName}' not found in category '{category}'");
            }

            var locatorInfo = _locators[category][locatorName];
            
            switch (locatorInfo.Type.ToLower())
            {
                case "css":
                    return By.CssSelector(locatorInfo.Value);
                case "xpath":
                    return By.XPath(locatorInfo.Value);
                case "id":
                    return By.Id(locatorInfo.Value);
                case "name":
                    return By.Name(locatorInfo.Value);
                default:
                    throw new ArgumentException($"Unsupported locator type: {locatorInfo.Type}");
            }
        }

        private class LocatorInfo
        {
            public string Type { get; set; }
            public string Value { get; set; }

            public LocatorInfo(string type, string value)
            {
                Type = type;
                Value = value;
            }
        }
    }
}