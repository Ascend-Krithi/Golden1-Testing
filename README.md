# Golden1 Web Automation Framework

## Overview
This is a production-ready C# Selenium automation framework using SpecFlow + Page Object Model for testing the Golden1 Credit Union website.

## Framework Structure
```
Golden1.Automation.Framework/
├── src/
│   ├── core/
│   │   ├── DriverManager.cs
│   │   └── Hooks.cs
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
├── App.config
├── Golden1.Automation.Framework.csproj
└── README.md
```

## Key Features
- **SpecFlow BDD Framework**: Behavior-Driven Development using Gherkin syntax
- **Page Object Model**: Separation of page elements and test logic
- **Reusable Utilities**: WaitHelper, LogHelper, ConfigReader, NavigationHelper
- **NUnit Assertions**: Comprehensive test validation
- **Cross-Browser Support**: Chrome, Firefox, Edge
- **Comprehensive Logging**: NLog integration for detailed test execution logs
- **Configuration Management**: Centralized configuration via App.config

## Test Coverage
The framework includes 9 test scenarios covering:
1. Homepage loading verification
2. Global navigation menu visibility
3. Navigation options presence validation
4. Main product menus display on hover
5. Submenu items selectability
6. Navigation to Checking page
7. All mapped submenu links redirection
8. Golden1 logo visibility
9. Homepage visual defects check

## Prerequisites
- .NET 6.0 SDK or higher
- Visual Studio 2022 or VS Code
- Chrome/Firefox/Edge browser
- NuGet Package Manager

## Installation
1. Clone the repository
2. Restore NuGet packages: `dotnet restore`
3. Build the solution: `dotnet build`

## Configuration
Update `App.config` to modify:
- Application URL
- Browser selection
- Wait timeouts
- Environment settings

## Running Tests

### Run all tests:
```bash
dotnet test
```

### Run specific scenario by tag:
```bash
dotnet test --filter "TestCategory=TS-001"
```

### Run from Visual Studio:
- Open Test Explorer
- Select and run desired tests

## Framework Design Principles
1. **Separation of Concerns**: Page objects, step definitions, and utilities are separated
2. **DRY Principle**: Reusable methods and utilities
3. **Explicit Waits**: All element interactions use WaitHelper
4. **Comprehensive Logging**: Every action is logged
5. **NUnit Assertions**: Consistent assertion pattern
6. **No Hard-coded Values**: Configuration-driven approach

## Page Object Methods

### HomePage
- `IsPageLoaded()`: Verify homepage is loaded
- `IsGlobalNavigationMenuVisible()`: Check navigation menu visibility
- `IsNavigationOptionPresent(string)`: Verify specific navigation option
- `HoverOverNavigationOption(string)`: Hover over navigation menu
- `ClickSubmenuItem(string)`: Click submenu item
- `IsLogoVisible()`: Check Golden1 logo visibility

### CheckingPage
- `IsPageLoaded()`: Verify Checking page is loaded
- `IsPageFullyLoaded()`: Check complete page load
- `HasErrorMessages()`: Verify no errors present

## Utilities

### WaitHelper
- `WaitForElementVisible()`: Wait for element visibility
- `WaitForElementClickable()`: Wait for element to be clickable
- `WaitForPageLoad()`: Wait for complete page load
- `HoverOverElement()`: Perform hover action

### LogHelper
- `LogInfo()`: Log informational messages
- `LogError()`: Log error messages with exceptions
- `LogWarning()`: Log warning messages

### ConfigReader
- `GetApplicationUrl()`: Retrieve application URL
- `GetBrowser()`: Get browser configuration
- `GetImplicitWait()`: Get implicit wait timeout

## Best Practices Followed
1. ✅ Page Object Model implementation
2. ✅ No locators in step definitions
3. ✅ Explicit waits before all interactions
4. ✅ Comprehensive logging
5. ✅ NUnit assertions only
6. ✅ Configuration-driven design
7. ✅ Reusable utility methods
8. ✅ Clear naming conventions
9. ✅ Exception handling
10. ✅ Zero syntax errors

## Reporting
Test results are generated in:
- Console output with detailed logs
- NUnit test results XML
- SpecFlow living documentation

## Maintenance
- Update locators in Page Objects when UI changes
- Add new page methods for new functionality
- Extend step definitions for new test scenarios
- Keep utilities generic and reusable

## Support
For issues or questions, please contact the QA Automation team.

## Version
1.0.0 - Initial Release