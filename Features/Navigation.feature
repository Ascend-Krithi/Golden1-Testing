@Navigation @Regression @TASK0020445
Feature: TASK0020445 - Golden1 Website Navigation
  As a user of Golden1 website
  I want to navigate through different sections
  So that I can access various banking services

  Background:
    Given I navigate to Golden1 homepage
    And I accept cookies if banner is displayed

  @Smoke @Critical @P1 @TC001
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage loads successfully
    Then the homepage should be displayed
    And the main menu should be visible

  @Smoke @Critical @P1 @TC002
  Scenario: TASK0020445 TS-001 TC-002 - Verify top navigation tabs are visible
    Then the Personal tab should be visible
    And the Business tab should be visible
    And the Financial Wellness tab should be visible
    And the Appointments tab should be visible
    And the Locations tab should be visible
    And the Membership tab should be visible
    And the Help Center tab should be visible

  @Functional @P1 @TC003
  Scenario: TASK0020445 TS-002 TC-001 - Verify navigation to Checking menu
    When I hover over the Checking menu
    Then the Checking submenu should be displayed

  @Functional @P1 @TC004
  Scenario: TASK0020445 TS-002 TC-002 - Verify navigation to Free Checking page
    When I hover over the Checking menu
    And I click on Free Checking link
    Then the Free Checking page should be displayed

  @Functional @P1 @TC005
  Scenario: TASK0020445 TS-003 TC-001 - Verify navigation to Savings Account
    When I hover over the Savings menu
    And I click on Savings Account link
    Then the Savings Account page should be displayed

  @Functional @P1 @TC006
  Scenario: TASK0020445 TS-004 TC-001 - Verify navigation to Auto Loans
    When I hover over the Loans menu
    And I click on Auto Loans link
    Then the Auto Loans page should be displayed

  @Functional @P2 @TC007
  Scenario Outline: TASK0020445 TS-005 TC-001 - Verify all main menu items are clickable - <MenuName>
    When I hover over the <MenuName> menu
    Then the <MenuName> submenu should be displayed

    Examples:
      | MenuName      |
      | Checking      |
      | Savings       |
      | Home Loans    |
      | Credit Cards  |
      | Loans         |
      | Investing     |
      | Community     |