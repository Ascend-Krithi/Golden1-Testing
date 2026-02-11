# Golden1 Web Automation Framework

## Overview
This is a production-ready C# Selenium automation framework using SpecFlow (BDD) and Page Object Model pattern for testing the Golden1 Credit Union website.

## Technology Stack
- **Language**: C# (.NET 6.0+)
- **Automation Tool**: Selenium WebDriver 4.x
- **BDD Framework**: SpecFlow 3.x
- **Test Framework**: NUnit 3.x
- **Design Pattern**: Page Object Model (POM)

## Project Structure
```
Golden1.Automation/
├── Config/
│   ├── appsettings.json
│   └── ConfigReader.cs
├── Drivers/
│   └── DriverManager.cs
├── Features/
│   └── Navigation.feature
├── Hooks/
│   └── Hooks.cs
├── Pages/
│   ├── BasePage.cs
│   └── NavigationPage.cs
├── StepDefinitions/
│   └── NavigationSteps.cs
└── Utilities/
    ├── WaitHelper.cs
    ├── LogHelper.cs
    └── ScreenshotHelper.cs
```

## Test Scenarios Covered

### TASK0020445 - Golden1 Website Navigation
- **TS-001 TC-001**: Verify homepage opens successfully
- **TS-002 TC-001**: Verify top navigation tabs are visible
- **TS-003 TC-001**: Verify main menu options are visible
- **TS-004 TC-001**: Navigate to Checking page
- **TS-005 TC-001**: Navigate to Free Checking page
- **TS-006 TC-001**: Navigate to Savings page
- **TS-007 TC-001**: Navigate to Savings Account page
- **TS-008 TC-001**: Navigate to Loans section and verify Auto Loans
- **TS-009 TC-001**: Verify navigation to different top tabs

## Setup Instructions

### Prerequisites
1. .NET 6.0 SDK or higher
2. Visual Studio 2022 or VS Code
3. Chrome/Firefox/Edge browser
4. NuGet Package Manager

### Required NuGet Packages
```bash
dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
dotnet add package Selenium.Support
dotnet add package SpecFlow
dotnet add package SpecFlow.NUnit
dotnet add package SpecFlow.Tools.MsBuild.Generation
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package DotNetSeleniumExtras.WaitHelpers
```

### Configuration
Update `Config/appsettings.json` with your settings:
```json
{
  "BaseUrl": "https://www.golden1.com/",
  "Browser": "chrome",
  "Headless": false,
  "ImplicitWait": 10,
  "ExplicitWait": 30,
  "PageLoadTimeout": 60
}
```

## Running Tests

### Run all tests
```bash
dotnet test
```

### Run specific tag
```bash
dotnet test --filter "TestCategory=Navigation"
```

### Run specific scenario
```bash
dotnet test --filter "TestCategory=TASK0020445"
```

## Framework Features

### 1. Page Object Model
- Separation of test logic from page interactions
- Reusable page methods
- Maintainable locator management

### 2. BDD with SpecFlow
- Human-readable test scenarios
- Gherkin syntax
- Business-friendly documentation

### 3. Comprehensive Logging
- All actions logged with timestamps
- Error tracking with stack traces
- Log files stored in `Logs/` directory

### 4. Screenshot on Failure
- Automatic screenshot capture on test failure
- Screenshots saved in `Screenshots/` directory
- Timestamped file names

### 5. Explicit Waits
- Framework-level wait utilities
- No Thread.Sleep() usage
- Configurable timeout values

### 6. Multi-Browser Support
- Chrome, Firefox, Edge
- Headless mode support
- Configurable via appsettings.json

## Locators Used

All locators are defined in `NavigationPage.cs` based on the provided locator definitions:

### Top Navigation Tabs
- Personal, Business, Financial Wellness
- Appointments, Locations, Membership
- Help Center

### Main Menu Items
- Checking, Savings, Home Loans
- Credit Cards, Loans, Investing
- Community

### Submenu Links
- Free Checking
- Savings Account
- Auto Loans

## Reporting

Test results are available in:
1. **Console Output**: Real-time test execution logs
2. **Log Files**: Detailed logs in `Logs/` directory
3. **Screenshots**: Failure screenshots in `Screenshots/` directory
4. **NUnit Test Results**: XML reports for CI/CD integration

## Best Practices Followed

✅ Page Object Model pattern
✅ Explicit waits (no Thread.Sleep)
✅ Comprehensive logging
✅ NUnit assertions with meaningful messages
✅ ConfigReader for environment values
✅ No hardcoded values
✅ Framework utilities (WaitHelper, LogHelper)
✅ Screenshot capture on failure
✅ Proper exception handling
✅ Test case traceability

## Maintenance

### Adding New Tests
1. Add scenario to `.feature` file
2. Implement step definitions in `*Steps.cs`
3. Add page methods to appropriate `*Page.cs`
4. Use existing utilities and helpers

### Adding New Pages
1. Create new page class inheriting from `BasePage`
2. Define locators as properties
3. Implement page methods
4. Add logging and waits

## Contact
For questions or issues, contact the QA Automation Team.

## Version
**Framework Version**: 2.0  
**Last Updated**: February 2025  
**Based On**: Golden1 Credit Union Automation Framework