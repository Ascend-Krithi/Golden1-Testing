@Regression @Navigation
Feature: Golden1 Website Navigation Functionality
    As a user of Golden1 Credit Union website
    I want to navigate through different sections and pages
    So that I can access various banking products and services

Background:
    Given the user is on the Golden1 homepage

@Smoke @TASK0020445
Scenario: TASK0020445 TS-001 TC-001 - Verify homepage loads successfully
    When the user opens the Golden1 application
    Then the homepage should be displayed
    And the main menu container should be visible

@TASK0020445
Scenario: TASK0020445 TS-002 TC-001 - Verify top navigation tabs are displayed
    Then the following top navigation tabs should be visible
      | TabName            |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

@TASK0020445 @Smoke
Scenario Outline: TASK0020445 TS-003 TC-001 - Verify navigation to main menu sections
    When the user clicks on the "<MainMenu>" menu option
    Then the "<MainMenu>" section should be displayed

Examples:
    | MainMenu      |
    | Checking      |
    | Savings       |
    | Home Loans    |
    | Credit Cards  |
    | Loans         |
    | Investing     |
    | Community     |

@TASK0020445
Scenario: TASK0020445 TS-004 TC-001 - Verify navigation to Free Checking page
    When the user clicks on the "Checking" menu option
    And the user clicks on the "Free Checking" link
    Then the Free Checking page should be displayed

@TASK0020445
Scenario: TASK0020445 TS-005 TC-001 - Verify navigation to Savings Account page
    When the user clicks on the "Savings" menu option
    And the user clicks on the "Savings Account" link
    Then the Savings Account page should be displayed

@TASK0020445
Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to Auto Loans page
    When the user clicks on the "Loans" menu option
    And the user clicks on the "Auto Loans" link
    Then the Auto Loans page should be displayed

@TASK0020445
Scenario Outline: TASK0020445 TS-007 TC-001 - Verify top tab navigation
    When the user clicks on the "<TabName>" top tab
    Then the "<TabName>" section should be displayed

Examples:
    | TabName            |
    | Personal           |
    | Business           |
    | Financial Wellness |
    | Appointments       |
    | Locations          |
    | Help Center        |

@TASK0020445
Scenario: TASK0020445 TS-008 TC-001 - Verify cookie banner acceptance
    Given the cookie banner is displayed
    When the user accepts cookies
    Then the cookie banner should not be visible