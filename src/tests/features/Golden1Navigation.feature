Feature: Golden1 Top Header Navigation Menu
  As a visitor to the Golden 1 website
  I want to see the main navigation menu at the top of the homepage
  So that I can easily identify the major sections of the site

  Background:
    Given I navigate to the Golden1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: Verify Golden1 homepage loads successfully
    Then the Golden1 homepage should be displayed
    And the page URL should contain "golden1.com"

  @TASK0020445 @TS-002 @TC-001
  Scenario: Validate main navigation menu visibility
    Then the top navigation menu should be visible

  @TASK0020445 @TS-003 @TC-001
  Scenario: Verify all menu options are present
    Then the top navigation menu should be visible
    And the menu option "Personal" should be present
    And the menu option "Business" should be present
    And the menu option "Financial Wellness" should be present
    And the menu option "Appointments" should be present
    And the menu option "Locations" should be present
    And the menu option "Membership" should be present
    And the menu option "Help Center" should be present

  @TASK0020445 @TS-004 @TC-001
  Scenario: Verify Golden1 logo visibility
    Then the Golden1 logo should be visible

  @TASK0020445 @TS-005 @TC-001
  Scenario: Validate homepage loads without errors
    Then the Golden1 homepage should be displayed
    And the top navigation menu should be visible
    And the Golden1 logo should be visible
    And the hero banner should be visible

  @TASK0020445 @TS-006 @TC-001
  Scenario Outline: Verify navigation menu options are clickable
    When I click on the "<MenuOption>" menu option
    Then the page URL should contain "<ExpectedUrlPart>"

    Examples:
      | MenuOption          | ExpectedUrlPart |
      | Personal            | personal        |
      | Business            | business        |
      | Financial Wellness  | financial       |
      | Appointments        | appointment     |
      | Locations           | location        |
      | Help Center         | help            |