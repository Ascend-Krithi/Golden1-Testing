@TASK0020445 @Regression @Smoke
Feature: TASK0020445 - Golden1 Credit Union Website Navigation
  As a user of Golden 1 Credit Union website
  I want to navigate through the website
  So that I can access different banking products and services

  Background: 
    Given the browser is launched

  @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully
    When the user navigates to the Golden1 homepage
    Then the browser should open successfully
    And the Golden 1 homepage should load successfully
    And there should be no error messages or loading issues

  @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    When the user navigates to the Golden1 homepage
    Then the global navigation menu should be visible at the top of the page

  @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all menu options are present
    When the user navigates to the Golden1 homepage
    And the navigation menu is visible
    Then all menu options should be present
      | MenuOption          |
      | Personal            |
      | Business            |
      | Financial Wellness  |
      | Appointments        |
      | Locations           |
      | Membership          |
      | Help Center         |

  @TS-004 @TC-001
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    When the user navigates to the Golden1 homepage
    And the navigation menu is visible
    Then all main product category menus should be displayed
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |
    And each main product category menu should be accessible

  @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    When the user navigates to the Golden1 homepage
    And the navigation menu is visible
    And the user expands the "Checking" menu
    Then submenu items should be displayed
    And the user should be able to select the "Free Checking" submenu item

  @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    When the user navigates to the Golden1 homepage
    And the navigation menu is visible
    And the user expands the "Checking" menu
    And the user selects the "Free Checking" submenu item
    Then the user should be redirected to the Free Checking destination page
    And the destination page should load without errors

  @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains correct identifier
    When the user navigates to the Golden1 homepage
    And the navigation menu is visible
    And the user expands the "Checking" menu
    And the user selects the "Free Checking" submenu item
    Then the destination page URL should contain "/checking/free-checking"

  @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    When the user navigates to the Golden1 homepage
    Then the Golden 1 logo should be visible in the top header

  @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    When the user navigates to the Golden1 homepage
    Then the homepage should display correctly
    And there should be no broken layouts
    And there should be no missing content
    And there should be no system errors