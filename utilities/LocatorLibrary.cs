using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Golden1.Automation.Utilities
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
                        { "TopNavBar", new LocatorInfo { Type = "css", Value = "header nav" } },
                        { "Logo", new LocatorInfo { Type = "css", Value = "header .logo img" } },
                        { "OpenAccountButton", new LocatorInfo { Type = "xpath", Value = "//a[normalize-space()='Open Account']" } },
                        { "LoginButton", new LocatorInfo { Type = "xpath", Value = "//button[contains(., 'Log In') or contains(., 'Login')]" } },
                        { "PersonalMenu", new LocatorInfo { Type = "xpath", Value = "//nav//a[normalize-space()='Personal']" } },
                        { "BusinessMenu", new LocatorInfo { Type = "xpath", Value = "//nav//a[normalize-space()='Business']" } },
                        { "FinancialWellnessMenu", new LocatorInfo { Type = "xpath", Value = "//nav//a[normalize-space()='Financial Wellness']" } },
                        { "AppointmentsMenu", new LocatorInfo { Type = "xpath", Value = "//nav//a[normalize-space()='Appointments']" } },
                        { "LocationsMenu", new LocatorInfo { Type = "xpath", Value = "//nav//a[normalize-space()='Locations']" } },
                        { "HelpCenterMenu", new LocatorInfo { Type = "xpath", Value = "//nav//a[normalize-space()='Help Center']" } },
                        { "MobileDepositLink", new LocatorInfo { Type = "xpath", Value = "//a[contains(normalize-space(),'Mobile Deposit')]" } },
                        { "OnlineBankingLink", new LocatorInfo { Type = "xpath", Value = "//a[contains(normalize-space(),'Online Banking')]" } },
                        { "BillPayLink", new LocatorInfo { Type = "xpath", Value = "//a[contains(normalize-space(),'Bill Pay')]" } }
                    }
                },
                {
                    "FooterLocators", new Dictionary<string, LocatorInfo>
                    {
                        { "FooterSection", new LocatorInfo { Type = "css", Value = "footer" } },
                        { "PrivacyPolicyLink", new LocatorInfo { Type = "xpath", Value = "//footer//a[contains(text(),'Privacy')]" } },
                        { "TermsConditionsLink", new LocatorInfo { Type = "xpath", Value = "//footer//a[contains(normalize-space(),'Terms & Conditions')]" } },
                        { "ContactUsLink", new LocatorInfo { Type = "xpath", Value = "//footer//a[contains(normalize-space(),'Contact Us')]" } }
                    }
                },
                {
                    "HomePageLocators", new Dictionary<string, LocatorInfo>
                    {
                        { "HeroBanner", new LocatorInfo { Type = "css", Value = "section.hero" } },
                        { "FeaturedProductSection", new LocatorInfo { Type = "css", Value = "section.products" } },
                        { "SearchInput", new LocatorInfo { Type = "css", Value = "input[type='search']" } }
                    }
                },
                {
                    "OverlayLocators", new Dictionary<string, LocatorInfo>
                    {
                        { "CookieAccept", new LocatorInfo { Type = "xpath", Value = "//button[contains(translate(text(),'ACCEPT','accept'),'accept')]" } },
                        { "ModalClose", new LocatorInfo { Type = "css", Value = "button.close, button[aria-label*='Close']" } }
                    }
                }
            };
        }

        public By GetLocator(string category, string locatorName)
        {
            if (!_locators.ContainsKey(category))
                throw new ArgumentException($"Category '{category}' not found in locator library");

            if (!_locators[category].ContainsKey(locatorName))
                throw new ArgumentException($"Locator '{locatorName}' not found in category '{category}'");

            var locatorInfo = _locators[category][locatorName];

            return locatorInfo.Type.ToLower() switch
            {
                "css" => By.CssSelector(locatorInfo.Value),
                "xpath" => By.XPath(locatorInfo.Value),
                "id" => By.Id(locatorInfo.Value),
                "name" => By.Name(locatorInfo.Value),
                _ => throw new ArgumentException($"Unsupported locator type: {locatorInfo.Type}")
            };
        }

        private class LocatorInfo
        {
            public string Type { get; set; }
            public string Value { get; set; }
        }
    }
}