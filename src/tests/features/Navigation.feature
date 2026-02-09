Feature: Golden1 Homepage Navigation
  As a visitor to the Golden 1 website
  I want to verify the homepage loads and navigation elements are visible
  So that I can navigate the site effectively

  Background:
    Given I navigate to the Golden1 homepage

  @TASK0020445 @TS-001 @TC-001
  Scenario: Verify Golden 1 homepage loads successfully
    Then the Golden1 homepage should be displayed

  @TASK0020445 @TS-002 @TC-001
  Scenario: Verify main navigation menu is visible
    Then the main navigation menu should be visible

  @TASK0020445 @TS-003 @TC-001
  Scenario: Verify all menu options are present in top navigation
    Then the "Personal" menu option should be visible
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
    Then the homepage should load without broken sections
    And no error messages should be displayed

  @TASK0020445 @TS-006 @TC-001
  Scenario Outline: Verify menu options are clickable and navigate correctly
    When I click on the "<MenuOption>" menu option
    Then the URL should contain "<ExpectedURL>"
    And I navigate back to the homepage

    Examples:
      | MenuOption         | ExpectedURL          |
      | Personal           | /personal            |
      | Business           | /business            |
      | Financial Wellness | /financial-wellness  |
      | Appointments       | /appointments        |
      | Locations          | /locations           |
      | Membership         | /membership          |
      | Help Center        | /help-center         |

  @TASK0020445 @TS-007 @TC-001
  Scenario: Verify hero banner and featured product section are displayed
    Then the hero banner should be displayed
    And the featured product section should be displayed