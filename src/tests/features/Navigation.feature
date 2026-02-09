Feature: Golden1 Homepage Navigation
  As a visitor to the Golden 1 website
  I want to verify the homepage loads and navigation menu is visible
  So that I can access different sections of the site

  Background:
    Given I navigate to the Golden1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: Verify homepage opens successfully
    Then the Golden1 homepage should be displayed

  @TASK0020445 @TS-002 @TC-001
  Scenario: Verify main navigation menu is visible
    Then the top navigation menu should be visible

  @TASK0020445 @TS-003 @TC-001
  Scenario: Verify all required menu options are present
    Then the top navigation menu should be visible
    And the "Personal" menu option should be visible
    And the "Business" menu option should be visible
    And the "Financial Wellness" menu option should be visible
    And the "Appointments" menu option should be visible
    And the "Locations" menu option should be visible
    And the "Membership" menu option should be visible
    And the "Help Center" menu option should be visible

  @TASK0020445 @TS-004 @TC-001
  Scenario: Verify Golden 1 logo is visible
    Then the Golden1 logo should be visible

  @TASK0020445 @TS-005 @TC-001
  Scenario: Verify homepage loads without errors
    Then the Golden1 homepage should be displayed
    And no broken sections should be visible

  @TASK0020445 @TS-006 @TC-001
  Scenario Outline: Verify menu options are clickable and navigate correctly
    When I click on the "<MenuOption>" menu option
    Then the page URL should contain "<ExpectedUrlPart>"

    Examples:
      | MenuOption          | ExpectedUrlPart       |
      | Personal            | personal              |
      | Business            | business              |
      | Financial Wellness  | financial-wellness    |
      | Appointments        | appointments          |
      | Locations           | locations             |
      | Membership          | membership            |
      | Help Center         | help                  |

  @TASK0020445 @TS-010 @TC-001
  Scenario: Verify homepage loads after clearing cache
    Given browser cache is cleared
    When I navigate to the Golden1 homepage
    Then the Golden1 homepage should be displayed