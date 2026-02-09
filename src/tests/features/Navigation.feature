Feature: Golden 1 Homepage Navigation
  As a visitor to the Golden 1 website
  I want to see the main navigation menu at the top of the homepage
  So that I can easily identify the major sections of the site

  Background:
    Given I navigate to the Golden 1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: Verify that the Golden 1 homepage loads successfully
    Then the Golden 1 homepage should be displayed

  @TASK0020445 @TS-002 @TC-001
  Scenario: Verify that the main navigation menu is visible at the top of the homepage
    Then the top navigation menu should be visible

  @TASK0020445 @TS-003 @TC-001
  Scenario: Verify that the Personal menu option is present in the top navigation menu
    Then the "Personal" menu option should be visible in the navigation

  @TASK0020445 @TS-004 @TC-001
  Scenario: Verify that the Business menu option is present in the top navigation menu
    Then the "Business" menu option should be visible in the navigation

  @TASK0020445 @TS-005 @TC-001
  Scenario: Verify that the Financial Wellness menu option is present in the top navigation menu
    Then the "Financial Wellness" menu option should be visible in the navigation

  @TASK0020445 @TS-006 @TC-001
  Scenario: Verify that the Appointments menu option is present in the top navigation menu
    Then the "Appointments" menu option should be visible in the navigation

  @TASK0020445 @TS-007 @TC-001
  Scenario: Verify that the Locations menu option is present in the top navigation menu
    Then the "Locations" menu option should be visible in the navigation

  @TASK0020445 @TS-008 @TC-001
  Scenario: Verify that the Membership menu option is present in the top navigation menu
    Then the "Membership" menu option should be visible in the navigation

  @TASK0020445 @TS-009 @TC-001
  Scenario: Verify that the Help Center menu option is present in the top navigation menu
    Then the "Help Center" menu option should be visible in the navigation

  @TASK0020445 @TS-010 @TC-001
  Scenario: Verify that the Golden 1 logo is visible in the top section of the homepage
    Then the Golden 1 logo should be visible

  @TASK0020445 @TS-011 @TC-001
  Scenario: Verify that the homepage loads without displaying broken sections or error messages
    Then the homepage should load without errors