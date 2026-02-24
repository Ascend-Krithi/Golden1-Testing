Feature: Golden1 Website Navigation
  As a user of Golden 1 Credit Union website
  I want to navigate through the website menus
  So that I can access different banking products and services

  Background:
    Given the user opens a supported browser

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify Golden 1 homepage loads successfully
    When the user navigates to the Golden 1 website
    Then the Golden 1 homepage should load successfully
    And there should be no error messages or loading issues

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    When the user navigates to the Golden 1 website
    Then the global navigation menu should be visible at the top of the page

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all menu options are present in navigation
    When the user navigates to the Golden 1 website
    And the user locates the global navigation menu
    Then the following menu options should be present:
      | Personal            |
      | Business            |
      | Financial Wellness  |
      | Appointments        |
      | Locations           |
      | Membership          |
      | Help Center         |

  @TASK0020445 @TS-004 @TC-001
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    When the user navigates to the Golden 1 website
    And the user locates the global navigation menu
    Then the following main product category menus should be displayed:
      | Checking      |
      | Savings       |
      | Home Loans    |
      | Credit Cards  |
      | Loans         |
      | Investing     |
      | Community     |
    And each main product category menu should be accessible

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    When the user navigates to the Golden 1 website
    And the user locates the main product category menus
    And the user expands the "Checking" menu
    Then submenu items should be displayed under the main product menu
    When the user clicks on the "Free Checking" submenu item
    Then the submenu item should respond to user interaction

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page from submenu
    When the user navigates to the Golden 1 website
    And the user expands the "Checking" menu
    And the user selects the "Free Checking" submenu item
    Then the user should be redirected to the destination page
    And the destination page should load without errors

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    When the user navigates to the Golden 1 website
    And the user expands the "Checking" menu
    And the user selects the "Free Checking" submenu item
    Then the destination page URL should contain "/checking/free-checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible in header
    When the user navigates to the Golden 1 website
    Then the Golden 1 logo should be visible in the top header

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    When the user navigates to the Golden 1 website
    Then the homepage should display correctly with no broken layouts
    And there should be no missing content or system errors