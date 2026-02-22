# Golden1 Web Automation Framework

## Overview
This is a production-ready C# Selenium automation framework using SpecFlow and Page Object Model (POM) design pattern.

## Framework Structure
```
Golden1.Automation/
├── src/
│   ├── Golden1.AutomationFramework/
│   │   ├── Pages/
│   │   │   ├── BasePage.cs
│   │   │   ├── HomePage.cs
│   │   │   └── CheckingPage.cs
│   │   ├── Utilities/
│   │   │   ├── DriverFactory.cs
│   │   │   ├── WaitHelper.cs
│   │   │   ├── ConfigReader.cs
│   │   │   └── LogHelper.cs
│   │   └── Config/
│   │       ├── appsettings.json
│   │       └── NLog.config
│   └── Golden1.AutomationTests/
│       ├── Features/
│       │   └── CheckingAccountNavigation.feature
│       ├── StepDefinitions/
│       │   └── NavigationSteps.cs
│       └── Hooks/
│           └── TestHooks.cs
└── README.md
```

## Key Features
- **Page Object Model**: Clean separation of page objects and test logic
- **SpecFlow BDD**: Behavior-driven development with Gherkin syntax
- **Reusable Utilities**: WaitHelper, ConfigReader, LogHelper
- **NLog Integration**: Comprehensive logging
- **NUnit Assertions**: Robust test validations
- **Screenshot on Failure**: Automatic screenshot capture
- **Configuration Management**: Centralized config via appsettings.json

## Design Principles
1. **No locators in step definitions** - All locators in Page classes
2. **Explicit waits** - Using WaitHelper for all element interactions
3. **Logging** - Every action is logged
4. **Assertions** - Using NUnit Assert methods
5. **No Thread.Sleep** - Only framework-approved waits

## Running Tests
```bash
dotnet test --filter "TestCategory=Smoke"
```

## Configuration
Update `appsettings.json` to change:
- Base URL
- Browser type
- Wait times
- Environment

## Note
**This framework structure was generated based on standard best practices due to inability to access the specific input files (test cases, locators, screen flow, and framework rules) from the provided directory.**

**To complete the implementation:**
1. Verify file accessibility and permissions
2. Load actual test cases from test_cases.json
3. Load locators from locators.json
4. Follow screen_flow.txt for navigation logic
5. Apply specific rules from golden1webautomationframeworkrules.txt

**Current Status:** Framework template provided. Requires actual test case data to generate specific test implementations.