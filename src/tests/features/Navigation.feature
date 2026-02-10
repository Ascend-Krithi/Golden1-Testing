Feature: Golden1 Homepage Navigation
  As a visitor to the Golden 1 website
  I want to see the main navigation menu at the top of the homepage
  So that I can easily identify the major sections of the site

  Background:
    Given I navigate to the Golden1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: Verify homepage opens successfully
    Then the homepage should be displayed without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: Verify main navigation menu is visible
    Then the main navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: Verify all menu options are present in navigation
    Then the main navigation menu should be visible at the top
    And the "Personal" menu option should be present
    And the "Business" menu option should be present
    And the "Financial Wellness" menu option should be present
    And the "Appointments" menu option should be present
    And the "Locations" menu option should be present
    And the "Membership" menu option should be present
    And the "Help Center" menu option should be present

  @TASK0020445 @TS-004 @TC-001
  Scenario: Verify Golden 1 logo is visible
    Then the Golden 1 logo should be visible in the top section

  @TASK0020445 @TS-005 @TC-001
  Scenario: Verify homepage loads without broken sections
    Then the homepage should be displayed without errors
    And no error messages should be displayed

  @TASK0020445 @TS-006 @TC-001
  Scenario: Verify Login and Open Account options are visible
    Then the "Open Account" option should be visible
    And the "Login" button should be visible

  @TASK0020445 @TS-007 @TC-001
  Scenario: Verify main banner is displayed correctly
    Then the main banner should be visible on the homepage