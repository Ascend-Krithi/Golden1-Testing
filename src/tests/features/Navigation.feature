Feature: Golden 1 Homepage Navigation
  As a visitor to the Golden 1 website
  I want to see the main navigation menu at the top of the homepage
  So that I can easily identify the major sections of the site

  Background:
    Given I navigate to the Golden 1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: Verify that the Golden 1 homepage opens successfully
    Then the Golden 1 homepage should be displayed
    And the page should load without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: Verify that the main navigation menu is visible
    Then the top navigation menu should be visible

  @TASK0020445 @TS-003 @TC-001
  Scenario: Verify that all menu options are present in the top navigation
    Then the "Personal" menu option should be visible
    And the "Business" menu option should be visible
    And the "Financial Wellness" menu option should be visible
    And the "Appointments" menu option should be visible
    And the "Locations" menu option should be visible
    And the "Membership" menu option should be visible
    And the "Help Center" menu option should be visible

  @TASK0020445 @TS-004 @TC-001
  Scenario: Verify that the Golden 1 logo is visible
    Then the Golden 1 logo should be visible in the top section

  @TASK0020445 @TS-005 @TC-001
  Scenario: Verify that the homepage loads without broken sections or errors
    Then the homepage should load without broken sections
    And no error messages should be displayed