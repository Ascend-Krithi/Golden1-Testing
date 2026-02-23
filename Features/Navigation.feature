Feature: Golden1 Website Navigation
  As a user of Golden1 website
  I want to navigate through different sections
  So that I can access various banking services

  Background:
    Given I am on the Golden1 homepage

  @smoke @regression
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully
    Then the homepage should load successfully
    And the main navigation menu should be visible

  @regression
  Scenario: TASK0020445 TS-002 TC-001 - Verify Personal tab navigation
    When I click on the Personal tab
    Then the Personal section should be displayed
    And the Checking menu option should be visible

  @regression
  Scenario: TASK0020445 TS-003 TC-001 - Navigate to Checking page
    When I click on the Personal tab
    And I click on the Checking menu
    Then the Checking page should be displayed
    And the Free Checking link should be visible

  @regression
  Scenario: TASK0020445 TS-004 TC-001 - Navigate to Free Checking page
    When I click on the Personal tab
    And I click on the Checking menu
    And I click on the Free Checking link
    Then the Free Checking page should be displayed

  @regression
  Scenario: TASK0020445 TS-005 TC-001 - Navigate to Savings Account page
    When I click on the Personal tab
    And I click on the Savings menu
    And I click on the Savings Account link
    Then the Savings Account page should be displayed

  @regression
  Scenario: TASK0020445 TS-006 TC-001 - Verify all top navigation tabs are visible
    Then the Personal tab should be visible
    And the Business tab should be visible
    And the Financial Wellness tab should be visible
    And the Appointments tab should be visible
    And the Locations tab should be visible
    And the Membership tab should be visible
    And the Help Center tab should be visible

  @regression
  Scenario: TASK0020445 TS-007 TC-001 - Verify URL contains expected identifier
    When I click on the Personal tab
    And I click on the Checking menu
    Then the current URL should contain "checking"

  @smoke
  Scenario: TASK0020445 TS-008 TC-001 - Accept cookie banner if present
    Given I am on the Golden1 homepage
    When the cookie banner is displayed
    Then I accept the cookies
    And the cookie banner should not be visible