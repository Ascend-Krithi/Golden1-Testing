@TASK0020445
Feature: Golden 1 Homepage and Navigation Verification
  As a user
  I want to access the Golden 1 website
  So that I can navigate through different product categories

  Background:
    Given the browser is launched

  @TS-001 @AC-1
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage loads successfully
    When I navigate to the Golden 1 homepage
    Then the homepage should be displayed without errors

  @TS-002 @AC-2
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    When I navigate to the Golden 1 homepage
    Then the global navigation menu should be visible at the top

  @TS-003 @AC-3
  Scenario: TASK0020445 TS-003 TC-001 - Verify top navigation menu options
    When I navigate to the Golden 1 homepage
    Then the top navigation should contain the following options:
      | Personal            |
      | Business            |
      | Financial Wellness  |
      | Appointments        |
      | Locations           |
      | Membership          |
      | Help Center         |

  @TS-004 @AC-4
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    When I navigate to the Golden 1 homepage
    Then the following main product category menus should be accessible:
      | Checking      |
      | Savings       |
      | Home Loans    |
      | Credit Cards  |
      | Loans         |
      | Investing     |
      | Community     |

  @TS-005 @AC-5
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    When I navigate to the Golden 1 homepage
    And I hover over the "Checking" menu
    Then the submenu item "Free Checking" should be visible
    And I should be able to click the submenu item "Free Checking"

  @TS-006 @AC-6
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    When I navigate to the Golden 1 homepage
    And I hover over the "Checking" menu
    And I click the submenu item "Free Checking"
    Then the destination page should load completely without errors

  @TS-007 @AC-7
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    When I navigate to the Golden 1 homepage
    And I hover over the "Checking" menu
    And I click the submenu item "Free Checking"
    Then the URL should contain "/checking/free-checking"

  @TS-008 @AC-8
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    When I navigate to the Golden 1 homepage
    Then the Golden 1 logo should be visible in the header

  @TS-009 @AC-9
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    When I navigate to the Golden 1 homepage
    Then the homepage should display all content correctly
    And there should be no broken layouts
    And there should be no error messages

  @TS-010 @AC-2 @AC-9 @CrossBrowser
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify navigation across different browsers
    Given the browser "<Browser>" is launched
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly
    And the homepage elements should be consistent

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TS-011 @AC-2 @AC-9 @Responsive
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify navigation across different devices
    Given the device "<Device>" is configured
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly for "<Device>"
    And the homepage elements should be responsive

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |

  @TS-012 @AC-2 @AC-3 @AC-4 @AC-5 @Accessibility
  Scenario: TASK0020445 TS-012 TC-001 - Verify keyboard navigation accessibility
    When I navigate to the Golden 1 homepage
    And I use keyboard Tab key to navigate to the global navigation menu
    Then the menu should receive focus
    And I should be able to navigate through menu items using arrow keys
    And I should be able to select menu items using Enter key