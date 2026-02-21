@NavigationTests
Feature: Golden1 Navigation Tests
  As a user of Golden1 website
  I want to navigate through the website
  So that I can access different product pages

  Background:
    Given I launch the Golden 1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully
    When I enter the website URL in the address bar
    Then the Golden 1 homepage should load successfully
    And the homepage should be displayed without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Then the global navigation menu should be visible at the top of the homepage

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify top navigation menu contains all required options
    When I locate the global navigation menu
    Then the menu should contain the following options:
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @TASK0020445 @TS-004 @TC-001
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are displayed and accessible
    When I locate the global navigation menu
    Then the following main product category menus should be displayed:
      | Checking     |
      | Savings      |
      | Home Loans   |
      | Credit Cards |
      | Loans        |
      | Investing    |
      | Community    |
    And each main product category menu should be accessible

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items can be selected
    When I expand the "Checking" main product category menu
    Then submenu items should be displayed
    And I should be able to select the "Free Checking" submenu item

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify submenu selection redirects to correct destination page
    When I expand the "Checking" main product category menu
    And I select the "Free Checking" submenu item
    Then I should be redirected to the destination page for "Free Checking"

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    When I expand the "Checking" main product category menu
    And I select the "Free Checking" submenu item
    Then the destination page URL should contain "/checking/free-checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    Then the Golden 1 logo should be visible in the top header area

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage loads without errors
    Then the homepage should display all content correctly
    And there should be no broken layouts
    And there should be no missing content
    And there should be no error messages