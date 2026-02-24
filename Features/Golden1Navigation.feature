@Navigation @Golden1 @TASK0020445
Feature: Golden1 Website Navigation
  As a user of Golden1 website
  I want to navigate through different sections
  So that I can access various banking services

  Background:
    Given the browser is launched

  @TASK0020445 @TS-001 @TC-001 @Smoke
  Scenario: TASK0020445 TS-001 TC-001 - Verify browser launches and homepage loads successfully
    When I navigate to the Golden1 homepage
    Then the homepage should load without errors

  @TASK0020445 @TS-002 @TC-001 @Smoke
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible at the top of the page

  @TASK0020445 @TS-003 @TC-001 @Regression
  Scenario: TASK0020445 TS-003 TC-001 - Verify presence of all menu options
    When I navigate to the Golden1 homepage
    And I locate the global navigation menu
    Then the following top menu options should be present:
      | MenuOption         |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @TASK0020445 @TS-004 @TC-001 @Regression
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    When I navigate to the Golden1 homepage
    And I locate the global navigation menu
    Then the following main product category menus should be displayed:
      | ProductMenu  |
      | Checking     |
      | Savings      |
      | Home Loans   |
      | Credit Cards |
      | Loans        |
      | Investing    |
      | Community    |
    And each main product category menu should be accessible

  @TASK0020445 @TS-005 @TC-001 @Regression
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    When I navigate to the Golden1 homepage
    And I expand the "Checking" main product menu
    Then the submenu items should be displayed
    And I should be able to select the "Free Checking" submenu item

  @TASK0020445 @TS-006 @TC-001 @Smoke
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    When I navigate to the Golden1 homepage
    And I expand the "Checking" main product menu
    And I select the "Free Checking" submenu item
    Then I should be redirected to the Free Checking destination page
    And the destination page should load without errors

  @TASK0020445 @TS-007 @TC-001 @Regression
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    When I navigate to the Golden1 homepage
    And I expand the "Checking" main product menu
    And I select the "Free Checking" submenu item
    Then the destination page URL should contain "/checking/free-checking"

  @TASK0020445 @TS-008 @TC-001 @Smoke
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden1 logo is visible in header
    When I navigate to the Golden1 homepage
    Then the Golden1 logo should be visible in the top header

  @TASK0020445 @TS-009 @TC-001 @Smoke
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    When I navigate to the Golden1 homepage
    Then the homepage should display correctly with no broken layouts
    And there should be no missing content
    And there should be no system error messages