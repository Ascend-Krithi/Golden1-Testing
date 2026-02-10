Feature: Golden 1 Homepage Navigation
  As a visitor to the Golden 1 website
  I want to see the main navigation menu at the top of the homepage
  So that I can easily identify the major sections of the site

  Background:
    Given I navigate to the Golden 1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: Verify that the homepage opens successfully
    Then the page title should contain "Golden 1"
    And the homepage content should be displayed without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: Verify that the main navigation menu is visible
    Then the main navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: Verify that the Personal menu option is present
    Then the main navigation menu should be visible at the top
    And the "Personal" menu option should be displayed

  @TASK0020445 @TS-004 @TC-001
  Scenario: Verify that the Business menu option is present
    Then the main navigation menu should be visible at the top
    And the "Business" menu option should be displayed

  @TASK0020445 @TS-005 @TC-001
  Scenario: Verify that the Financial Wellness menu option is present
    Then the main navigation menu should be visible at the top
    And the "Financial Wellness" menu option should be displayed

  @TASK0020445 @TS-006 @TC-001
  Scenario: Verify that the Appointments menu option is present
    Then the main navigation menu should be visible at the top
    And the "Appointments" menu option should be displayed

  @TASK0020445 @TS-007 @TC-001
  Scenario: Verify that the Locations menu option is present
    Then the main navigation menu should be visible at the top
    And the "Locations" menu option should be displayed

  @TASK0020445 @TS-008 @TC-001
  Scenario: Verify that the Membership menu option is present
    Then the main navigation menu should be visible at the top
    And the "Membership" menu option should be displayed

  @TASK0020445 @TS-009 @TC-001
  Scenario: Verify that the Help Center menu option is present
    Then the main navigation menu should be visible at the top
    And the "Help Center" menu option should be displayed

  @TASK0020445 @TS-010 @TC-001
  Scenario: Verify that the Golden 1 logo is visible
    Then the Golden 1 logo should be visible in the top section

  @TASK0020445 @TS-011 @TC-001
  Scenario: Verify that the homepage loads without errors
    Then the homepage should load completely without broken sections
    And no error messages should be displayed