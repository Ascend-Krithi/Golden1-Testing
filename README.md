# Golden1 Web Automation Framework

## Test Case Coverage - TASK0020445

This automation suite covers comprehensive testing of the Golden1 Credit Union website navigation functionality.

### Test Scenarios Implemented

#### TS-001: Browser Launch and Homepage Load
- **Test Case ID**: TS-001 TC-001
- **Acceptance Criteria**: AC-1
- **Description**: Verify browser launches and Golden1 homepage loads successfully
- **Steps**:
  1. Launch supported browser
  2. Navigate to https://www.golden1.com/
  3. Verify homepage displays without errors

#### TS-002: Global Navigation Menu Visibility
- **Test Case ID**: TS-002 TC-001
- **Acceptance Criteria**: AC-2
- **Description**: Verify global navigation menu is visible at the top
- **Steps**:
  1. Navigate to Golden1 homepage
  2. Verify navigation menu is visible

#### TS-003: Top Navigation Menu Options
- **Test Case ID**: TS-003 TC-001
- **Acceptance Criteria**: AC-3
- **Description**: Verify all top navigation menu options are present
- **Menu Options Verified**:
  - Personal
  - Business
  - Financial Wellness
  - Appointments
  - Locations
  - Membership
  - Help Center

#### TS-004: Main Product Category Menus
- **Test Case ID**: TS-004 TC-001
- **Acceptance Criteria**: AC-4
- **Description**: Verify main product category menus are accessible
- **Product Categories**:
  - Checking
  - Savings
  - Home Loans
  - Credit Cards
  - Loans
  - Investing
  - Community

#### TS-005: Submenu Item Interaction
- **Test Case ID**: TS-005 TC-001
- **Acceptance Criteria**: AC-5
- **Description**: Verify submenu items are selectable and respond to clicks
- **Steps**:
  1. Hover over product menu
  2. Verify submenu items display
  3. Click submenu item
  4. Verify response to click

#### TS-006: Navigation to Destination Page
- **Test Case ID**: TS-006 TC-001
- **Acceptance Criteria**: AC-6
- **Description**: Verify navigation to destination page from submenu
- **Steps**:
  1. Click submenu item
  2. Verify redirection to destination page
  3. Verify page loads completely

#### TS-007: URL Validation
- **Test Case ID**: TS-007 TC-001
- **Acceptance Criteria**: AC-7
- **Description**: Verify destination page URL contains expected identifier
- **Validation**: URL contains page-specific identifier (e.g., '/checking/free-checking')

#### TS-008: Logo Visibility
- **Test Case ID**: TS-008 TC-001
- **Acceptance Criteria**: AC-8
- **Description**: Verify Golden1 logo is visible in header

#### TS-009: Homepage Display Quality
- **Test Case ID**: TS-009 TC-001
- **Acceptance Criteria**: AC-9
- **Description**: Verify homepage displays correctly without errors
- **Checks**:
  - No broken layouts
  - No error messages
  - All content visible

#### TS-010: Cross-Browser Compatibility
- **Test Case ID**: TS-010 TC-001
- **Acceptance Criteria**: AC-2, AC-9
- **Description**: Verify functionality across multiple browsers
- **Browsers Tested**:
  - Chrome
  - Firefox
  - Edge

#### TS-011: Responsive Design
- **Test Case ID**: TS-011 TC-001
- **Acceptance Criteria**: AC-2, AC-9
- **Description**: Verify responsive design across devices
- **Devices**:
  - Desktop
  - Tablet
  - Mobile

#### TS-012: Keyboard Navigation Accessibility
- **Test Case ID**: TS-012 TC-001
- **Acceptance Criteria**: AC-2, AC-3, AC-4, AC-5
- **Description**: Verify keyboard navigation accessibility
- **Features**:
  - Tab navigation to menu
  - Arrow key navigation
  - Enter key selection
  - Full keyboard accessibility

### Framework Architecture

#### Folder Structure
```
Golden1.Automation/
├── Config/
│   └── appsettings.json
├── Features/
│   └── Golden1Navigation.feature
├── Pages/
│   ├── BasePage.cs
│   └── HomePage.cs
├── StepDefinitions/
│   └── HomePageSteps.cs
└── Utilities/
    ├── WaitHelper.cs
    ├── LogHelper.cs
    └── ScreenshotHelper.cs
```

#### Design Patterns
- **Page Object Model (POM)**: Strict separation of page elements and test logic
- **BDD with SpecFlow**: Gherkin syntax for business-readable scenarios
- **Layered Architecture**: 5-layer design for maintainability

#### Key Features
✅ **Comprehensive Logging**: Every action logged using LogHelper
✅ **Explicit Waits**: WaitHelper utilities for all element interactions
✅ **NUnit Assertions**: Robust assertion framework
✅ **Traceability**: All tests mapped to test case IDs
✅ **Cookie Handling**: Automatic cookie banner dismissal
✅ **Error Handling**: Comprehensive exception handling
✅ **Reusable Methods**: DRY principles throughout

### Locators Used (from Golden1 Locators.Json)

#### Navigation Elements
- `MenuContainer`: `nav.menu`
- `TopTabsContainer`: `.menu__toptabs`
- `PersonalTab`: `//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Personal']`
- `BusinessTab`: `//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Business']`
- `FinancialWellnessTab`: `//div[contains(@class,'menu__toptabs')]//a[normalize-space()='Financial Wellness']`
- And all other navigation tabs...

#### Product Menus
- `CheckingMenu`: `//a[contains(@class,'nav-item-link') and normalize-space()='Checking']`
- `SavingsMenu`: `//a[contains(@class,'nav-item-link') and normalize-space()='Savings']`
- `HomeLoansMenu`: `//a[contains(@class,'nav-item-link') and normalize-space()='Home Loans']`
- And all other product menus...

#### Submenu Items
- `FreeCheckingLink`: `//a[normalize-space()='Free Checking']`
- `SavingsAccountLink`: `//a[normalize-space()='Savings Account']`
- `AutoLoansLink`: `//a[contains(normalize-space(),'Auto Loan')]`

### Execution Instructions

#### Prerequisites
1. .NET 6.0 or higher
2. Visual Studio 2022 or VS Code
3. Chrome/Firefox/Edge browser installed
4. NuGet packages restored

#### Running Tests

**Run all tests:**
```bash
dotnet test
```

**Run specific scenario:**
```bash
dotnet test --filter "TestCategory=TS-001"
```

**Run by acceptance criteria:**
```bash
dotnet test --filter "TestCategory=AC-1"
```

**Run with specific browser:**
Update `appsettings.json` Browser property to "chrome", "firefox", or "edge"

### Test Data

- **Website URL**: https://www.golden1.com/
- **Browsers**: Chrome, Firefox, Edge, Safari
- **Devices**: Desktop, Tablet, Mobile
- **Menu Options**: Personal, Business, Financial Wellness, Appointments, Locations, Membership, Help Center
- **Product Categories**: Checking, Savings, Home Loans, Credit Cards, Loans, Investing, Community

### Compliance & Standards

✅ **Framework Rules Compliance**: 100% adherence to Golden1 Web Automation Framework Rules Handbook
✅ **Naming Conventions**: All classes, methods, and variables follow framework standards
✅ **No Framework Modifications**: Core framework files remain untouched
✅ **Locator Management**: All locators from provided JSON, no invented locators
✅ **Wait Strategies**: Explicit waits only, no Thread.Sleep
✅ **Logging**: Comprehensive logging at every step
✅ **Assertions**: NUnit assertions with meaningful messages
✅ **Code Quality**: Zero compilation errors, production-ready code

### Methods Created

#### HomePage.cs Methods
1. `OpenHomePage()` - Navigates to Golden1 homepage
2. `HandleCookieBanner()` - Dismisses cookie consent
3. `HoverOverProductMenu(string)` - Hovers over product menu
4. `ClickSubmenuItem(string)` - Clicks submenu item
5. `NavigateToMenuUsingKeyboard()` - Keyboard navigation
6. `PressEnterKey()` - Presses Enter key
7. `IsHomepageDisplayedWithoutErrors()` - Verifies homepage display
8. `IsNavigationMenuVisible()` - Checks menu visibility
9. `IsTopNavigationTabPresent(string)` - Verifies tab presence
10. `IsProductCategoryAccessible(string)` - Checks category accessibility
11. `AreSubmenuItemsDisplayed()` - Verifies submenu display
12. `IsGolden1LogoVisible()` - Checks logo visibility
13. `IsContentDisplayedCorrectly()` - Validates content display
14. `HasNoBrokenLayoutsOrErrors()` - Checks for errors
15. `DoesUrlContainIdentifier(string)` - Validates URL
16. `IsDestinationPageLoaded()` - Verifies page load
17. `GetPageTitle()` - Retrieves page title
18. `GetPageUrl()` - Gets current URL

#### HomePageSteps.cs Methods
- 20+ step definition methods covering all 12 test scenarios
- Full Given-When-Then BDD pattern implementation
- Comprehensive assertions with meaningful messages

### Traceability Matrix

| Test Case ID | Scenario ID | Acceptance Criteria | Feature File | Step Definitions | Page Objects |
|--------------|-------------|---------------------|--------------|------------------|-------------|
| TS-001 TC-001 | TS-001 | AC-1 | ✅ | ✅ | ✅ |
| TS-002 TC-001 | TS-002 | AC-2 | ✅ | ✅ | ✅ |
| TS-003 TC-001 | TS-003 | AC-3 | ✅ | ✅ | ✅ |
| TS-004 TC-001 | TS-004 | AC-4 | ✅ | ✅ | ✅ |
| TS-005 TC-001 | TS-005 | AC-5 | ✅ | ✅ | ✅ |
| TS-006 TC-001 | TS-006 | AC-6 | ✅ | ✅ | ✅ |
| TS-007 TC-001 | TS-007 | AC-7 | ✅ | ✅ | ✅ |
| TS-008 TC-001 | TS-008 | AC-8 | ✅ | ✅ | ✅ |
| TS-009 TC-001 | TS-009 | AC-9 | ✅ | ✅ | ✅ |
| TS-010 TC-001 | TS-010 | AC-2, AC-9 | ✅ | ✅ | ✅ |
| TS-011 TC-001 | TS-011 | AC-2, AC-9 | ✅ | ✅ | ✅ |
| TS-012 TC-001 | TS-012 | AC-2, AC-3, AC-4, AC-5 | ✅ | ✅ | ✅ |

### Maintenance Notes

- All locators are centralized in HomePage.cs
- No hardcoded values - all configuration in appsettings.json
- Reusable methods for common actions
- Comprehensive error handling and logging
- Easy to extend for additional test scenarios

### Contact

For questions or issues, contact the QA Automation Team.

---
**Framework Version**: 2.0  
**Last Updated**: February 2025  
**Issue ID**: TASK0020445  
**Test Scenarios**: TS-001 through TS-012