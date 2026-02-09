Feature: Golden 1 Homepage Navigation
  As a visitor to the Golden 1 website
  I want to see the main navigation menu at the top of the homepage
  So that I can easily identify the major sections of the site

  Background:
    Given I navigate to the Golden 1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: Verify that the homepage opens successfully
    Then the homepage should be displayed without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: Verify that the main navigation menu is visible
    Then the main navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: Verify that the Personal menu option is present
    Then the "Personal" menu option should be visible in the top navigation

  @TASK0020445 @TS-004 @TC-001
  Scenario: Verify that the Business menu option is present
    Then the "Business" menu option should be visible in the top navigation

  @TASK0020445 @TS-005 @TC-001
  Scenario: Verify that the Financial Wellness menu option is present
    Then the "Financial Wellness" menu option should be visible in the top navigation

  @TASK0020445 @TS-006 @TC-001
  Scenario: Verify that the Appointments menu option is present
    Then the "Appointments" menu option should be visible in the top navigation

  @TASK0020445 @TS-007 @TC-001
  Scenario: Verify that the Locations menu option is present
    Then the "Locations" menu option should be visible in the top navigation

  @TASK0020445 @TS-009 @TC-001
  Scenario: Verify that the Help Center menu option is present
    Then the "Help Center" menu option should be visible in the top navigation

  @TASK0020445 @TS-010 @TC-001
  Scenario: Verify that the Golden 1 logo is visible
    Then the Golden 1 logo should be visible in the top section

  @TASK0020445 @TS-011 @TC-001
  Scenario: Verify that the homepage loads without broken sections or errors
    Then the homepage should load without displaying broken sections or error messages

  @TASK0020445 @TS-012 @TC-001
  Scenario: Verify that all top navigation menu options are clickable
    When I click on the "Personal" menu option
    Then the navigation should not result in errors
    When I navigate to the Golden 1 homepage
    When I click on the "Business" menu option
    Then the navigation should not result in errors
    When I navigate to the Golden 1 homepage
    When I click on the "Financial Wellness" menu option
    Then the navigation should not result in errors
    When I navigate to the Golden 1 homepage
    When I click on the "Appointments" menu option
    Then the navigation should not result in errors
    When I navigate to the Golden 1 homepage
    When I click on the "Locations" menu option
    Then the navigation should not result in errors
    When I navigate to the Golden 1 homepage
    When I click on the "Help Center" menu option
    Then the navigation should not result in errors