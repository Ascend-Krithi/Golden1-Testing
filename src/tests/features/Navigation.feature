Feature: Golden 1 Top Header Navigation Menu
  As a visitor to the Golden 1 website
  I want to see the main navigation menu at the top of the homepage
  So that I can easily identify the major sections of the site

  Background:
    Given I navigate to the Golden 1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: Verify that the Golden 1 homepage opens successfully
    Then the homepage should load successfully

  @TASK0020445 @TS-002 @TC-001
  Scenario: Verify that the main navigation menu is visible at the top of the homepage
    Then the main navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: Verify that the Personal menu option is present in the top navigation menu
    Then the "Personal" menu option should be visible in the top navigation

  @TASK0020445 @TS-004 @TC-001
  Scenario: Verify that the Business menu option is present in the top navigation menu
    Then the "Business" menu option should be visible in the top navigation

  @TASK0020445 @TS-005 @TC-001
  Scenario: Verify that the Financial Wellness menu option is present in the top navigation menu
    Then the "Financial Wellness" menu option should be visible in the top navigation

  @TASK0020445 @TS-006 @TC-001
  Scenario: Verify that the Appointments menu option is present in the top navigation menu
    Then the "Appointments" menu option should be visible in the top navigation

  @TASK0020445 @TS-007 @TC-001
  Scenario: Verify that the Locations menu option is present in the top navigation menu
    Then the "Locations" menu option should be visible in the top navigation

  @TASK0020445 @TS-009 @TC-001
  Scenario: Verify that the Help Center menu option is present in the top navigation menu
    Then the "Help Center" menu option should be visible in the top navigation

  @TASK0020445 @TS-010 @TC-001
  Scenario: Verify that the Golden 1 logo is visible in the top section of the homepage
    Then the Golden 1 logo should be visible in the top section