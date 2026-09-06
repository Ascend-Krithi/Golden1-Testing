# Golden1 Web Automation Framework

## Overview
This is a C# Selenium BDD automation framework for testing the Golden1 website using SpecFlow and Page Object Model design pattern.

## Framework Structure

```
Golden1.WebAutomation/
├── src/
│   ├── pages/
│   │   ├── BasePage.cs
│   │   ├── HomePage.cs
│   │   ├── NavigationPage.cs
│   │   └── OverlayPage.cs
│   ├── tests/
│   │   ├── features/
│   │   │   ├── HomePage.feature
│   │   │   └── Navigation.feature
│   │   └── steps/
│   │       ├── HomePageSteps.cs
│   │       └── NavigationSteps.cs
│   ├── helpers/
│   │   ├── ConfigReader.cs
│   │   ├── LogHelper.cs
│   │   └── WaitHelper.cs
│   ├── hooks/
│   │   └── Hooks.cs
│   └── config/
│       └── App.config
├── Logs/
├── Screenshots/
└── Reports/
```

## Key Features

### 1. Page Object Model (POM)
- **BasePage.cs**: Abstract base class with common page methods
- **HomePage.cs**: Home page specific elements and methods
- **NavigationPage.cs**: Navigation menu elements and methods
- **OverlayPage.cs**: Cookie banner and overlay handling

### 2. BDD with SpecFlow
- Feature files written in Gherkin syntax
- Step definitions map Gherkin steps to C# code
- Supports tags for test categorization (@Smoke, @Regression)

### 3. Utilities
- **WaitHelper**: Explicit waits for elements and page loads
- **LogHelper**: Centralized logging to console and file
- **ConfigReader**: Read configuration from App.config

### 4. Hooks
- BeforeScenario: Initialize WebDriver
- AfterScenario: Cleanup and screenshot on failure
- AfterStep: Log step failures

## Locators Used

All locators are defined in the Page Objects based on Golden1 Locators.Json:

### Navigation Elements
- Personal Tab
- Business Tab
- Financial Wellness Tab
- Appointments Tab
- Locations Tab
- Membership Tab
- Help Center Tab
- Checking Menu
- Savings Menu
- Home Loans Menu
- Credit Cards Menu
- Loans Menu
- Investing Menu
- Community Menu
- Free Checking Link
- Savings Account Link
- Auto Loans Link

### Overlay Elements
- Cookie Banner
- Accept Cookies Button

## Configuration

Edit `App.config` to customize:

```xml
<add key="ApplicationUrl" value="https://www.golden1.com/" />
<add key="Browser" value="Chrome" />
<add key="ImplicitWait" value="10" />
<add key="ExplicitWait" value="20" />
<add key="PageLoadTimeout" value="30" />
<add key="HeadlessMode" value="false" />
```

## Running Tests

### Run All Tests
```bash
dotnet test
```

### Run Specific Tags
```bash
dotnet test --filter "TestCategory=Smoke"
dotnet test --filter "TestCategory=Regression"
```

### Run Specific Feature
```bash
dotnet test --filter "FullyQualifiedName~Navigation"
```

## Test Scenarios Included

### HomePage.feature
1. Verify homepage loads successfully
2. Verify homepage main elements
3. Verify hero banner is displayed
4. Verify all homepage elements are visible
5. Click on Login button
6. Click on Open Account button

### Navigation.feature
1. Verify main navigation menu is displayed
2. Navigate to Personal tab
3. Navigate to Business tab
4. Navigate to Financial Wellness tab
5. Navigate to Checking from Personal
6. Navigate to Free Checking page
7. Navigate to Savings from Personal
8. Navigate to Savings Account page
9. Navigate to Loans section
10. Navigate to Auto Loans page
11. Navigate to Home Loans
12. Navigate to Credit Cards
13. Navigate to Investing
14. Navigate to Community
15. Navigate to Appointments tab
16. Navigate to Locations tab
17. Navigate to Membership tab
18. Navigate to Help Center tab

## Design Principles Followed

1. **Page Object Model**: All locators and page methods in Page classes
2. **No locators in Step Definitions**: Step definitions only call Page methods
3. **Explicit Waits**: All element interactions use WaitHelper
4. **Logging**: Every action is logged using LogHelper
5. **NUnit Assertions**: All verifications use NUnit Assert
6. **Configuration Management**: URLs and settings from ConfigReader
7. **Screenshot on Failure**: Automatic screenshot capture on test failure
8. **Reusability**: Common methods in BasePage
9. **Maintainability**: Locators defined once in Page Objects
10. **Scalability**: Easy to add new pages and scenarios

## Dependencies Required

```xml
<PackageReference Include="Selenium.WebDriver" Version="4.x.x" />
<PackageReference Include="Selenium.Support" Version="4.x.x" />
<PackageReference Include="DotNetSeleniumExtras.WaitHelpers" Version="3.11.0" />
<PackageReference Include="SpecFlow" Version="3.x.x" />
<PackageReference Include="SpecFlow.NUnit" Version="3.x.x" />
<PackageReference Include="NUnit" Version="3.x.x" />
<PackageReference Include="NUnit3TestAdapter" Version="4.x.x" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.x.x" />
```

## Logging

Logs are generated in the `Logs/` folder with timestamp:
- Format: `TestLog_yyyyMMdd_HHmmss.log`
- Levels: INFO, WARNING, ERROR, DEBUG
- Console and file output

## Screenshots

Screenshots are captured on test failure in the `Screenshots/` folder:
- Format: `ScenarioName_yyyyMMdd_HHmmss.png`
- Automatically triggered by Hooks

## Best Practices Implemented

✅ Page Object Model architecture
✅ BDD with SpecFlow
✅ Explicit waits for all interactions
✅ Centralized logging
✅ Configuration management
✅ Screenshot on failure
✅ No hardcoded values
✅ Reusable methods
✅ Clear naming conventions
✅ Proper exception handling
✅ Test data separation
✅ Tag-based test execution

## Support

For issues or questions, please refer to the framework documentation or contact the automation team.

---
**Framework Version**: 1.0
**Last Updated**: 2024
**Maintained By**: Senior Automation Framework Engineer
