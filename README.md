# Golden1 Web Automation Framework

## Overview
This is a C# Selenium automation framework using SpecFlow (BDD) and Page Object Model design pattern for testing the Golden1 Credit Union website.

## Framework Structure

```
Golden1.Automation.Framework/
├── src/
│   ├── config/
│   │   └── appsettings.json
│   ├── core/
│   │   └── DriverManager.cs
│   ├── hooks/
│   │   └── TestHooks.cs
│   ├── pages/
│   │   ├── BasePage.cs
│   │   ├── HomePage.cs
│   │   └── CheckingPage.cs
│   ├── tests/
│   │   ├── features/
│   │   │   └── Golden1Navigation.feature
│   │   └── steps/
│   │       └── Golden1NavigationSteps.cs
│   └── utilities/
│       ├── ConfigReader.cs
│       ├── LogHelper.cs
│       ├── NavigationHelper.cs
│       └── WaitHelper.cs
├── Reports/
├── Screenshots/
└── Logs/
```

## Key Components

### 1. Core Components
- **DriverManager**: Manages WebDriver initialization and lifecycle
- **TestHooks**: Handles before/after scenario and test run operations

### 2. Page Objects
- **BasePage**: Base class for all page objects with common functionality
- **HomePage**: Page object for Golden1 homepage with navigation methods
- **CheckingPage**: Page object for Checking page

### 3. Utilities
- **ConfigReader**: Reads configuration from appsettings.json
- **LogHelper**: Provides logging functionality using NLog
- **WaitHelper**: Manages explicit waits for elements
- **NavigationHelper**: Handles browser navigation operations

### 4. Test Components
- **Feature Files**: Gherkin syntax BDD scenarios
- **Step Definitions**: C# implementation of Gherkin steps

## Test Coverage

The framework includes automated tests for the following scenarios:

1. **TS-001**: Verify Golden1 homepage loads successfully
2. **TS-002**: Verify global navigation menu visibility
3. **TS-003**: Verify all navigation options are present
4. **TS-004**: Verify main product menus display on hover
5. **TS-005**: Verify submenu items are selectable
6. **TS-006**: Verify navigation to Checking page
7. **TS-007**: Verify navigation to all mapped submenu pages
8. **TS-008**: Verify Golden1 logo visibility
9. **TS-009**: Verify homepage displays without visual defects

## Configuration

Update `appsettings.json` to configure:
- Base URL
- Browser type (Chrome, Firefox, Edge)
- Timeout values
- Paths for screenshots, reports, and logs

## Running Tests

### Prerequisites
- .NET 6.0 or higher
- Visual Studio 2022 or VS Code
- NuGet packages:
  - Selenium.WebDriver
  - SpecFlow
  - NUnit
  - NLog

### Execution
```bash
# Run all tests
dotnet test

# Run specific tag
dotnet test --filter "TestCategory=@TS-001"

# Run with specific browser
dotnet test -- Browser=Chrome
```

## Reporting
- Screenshots are saved in `./Screenshots` folder on test failure
- Logs are generated using NLog in `./Logs` folder
- SpecFlow generates HTML reports in `./Reports` folder

## Best Practices Followed

1. ✅ Page Object Model for maintainability
2. ✅ Explicit waits using WaitHelper
3. ✅ Configuration management via ConfigReader
4. ✅ Comprehensive logging using LogHelper
5. ✅ NUnit assertions for validations
6. ✅ BDD approach with SpecFlow
7. ✅ Screenshot capture on failure
8. ✅ Proper driver lifecycle management
9. ✅ Reusable utility methods
10. ✅ Clear separation of concerns

## Maintenance

### Adding New Tests
1. Add scenario in `.feature` file
2. Implement step definitions in `*Steps.cs`
3. Add page methods in appropriate page object
4. Update locators as needed

### Adding New Pages
1. Create new page class inheriting from `BasePage`
2. Define locators as private fields
3. Implement page-specific methods
4. Use WaitHelper for all element interactions

## Contact
For questions or issues, please contact the QA Automation team.