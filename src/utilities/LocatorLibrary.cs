using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Golden1.Utilities
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
                        { "MembershipMenu", new LocatorInfo("xpath", "//nav//a[normalize-space()='Membership']") }
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
            if (_locators.ContainsKey(category) && _locators[category].ContainsKey(locatorName))
            {
                var locatorInfo = _locators[category][locatorName];
                return locatorInfo.Type.ToLower() == "css" 
                    ? By.CssSelector(locatorInfo.Value) 
                    : By.XPath(locatorInfo.Value);
            }
            throw new Exception($"Locator not found: {category}.{locatorName}");
        }
    }

    public class LocatorInfo
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