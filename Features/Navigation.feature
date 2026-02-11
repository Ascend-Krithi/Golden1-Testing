@Navigation @Regression
Feature: Golden1 Website Navigation
  As a user of Golden1 Credit Union website
  I want to navigate through different sections
  So that I can access various banking services and information

  Background:
    Given User opens the Golden1 homepage
    And User accepts cookies if banner is displayed

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully
    Then User should see the main navigation menu
    And User should see the top navigation tabs

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify top navigation tabs are visible
    Then User should see "Personal" tab in top navigation
    And User should see "Business" tab in top navigation
    And User should see "Financial Wellness" tab in top navigation
    And User should see "Appointments" tab in top navigation
    And User should see "Locations" tab in top navigation
    And User should see "Membership" tab in top navigation
    And User should see "Help Center" tab in top navigation

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify main menu options are visible
    Then User should see "Checking" menu option
    And User should see "Savings" menu option
    And User should see "Home Loans" menu option
    And User should see "Credit Cards" menu option
    And User should see "Loans" menu option
    And User should see "Investing" menu option
    And User should see "Community" menu option

  @TASK0020445 @TS-004 @TC-001
  Scenario: TASK0020445 TS-004 TC-001 - Navigate to Checking page
    When User clicks on "Checking" menu
    Then User should see Free Checking link

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Navigate to Free Checking page
    When User clicks on "Checking" menu
    And User clicks on "Free Checking" link
    Then User should be on Free Checking page

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Navigate to Savings page
    When User clicks on "Savings" menu
    Then User should see Savings Account link

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Navigate to Savings Account page
    When User clicks on "Savings" menu
    And User clicks on "Savings Account" link
    Then User should be on Savings Account page

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Navigate to Loans section and verify Auto Loans
    When User clicks on "Loans" menu
    Then User should see Auto Loans link

  @TASK0020445 @TS-009 @TC-001
  Scenario Outline: TASK0020445 TS-009 TC-001 - Verify navigation to different top tabs
    When User clicks on "<TabName>" top tab
    Then User should be on "<TabName>" section

    Examples:
      | TabName            |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |