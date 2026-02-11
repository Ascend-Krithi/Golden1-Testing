@Navigation @Regression
Feature: Golden1 Website Navigation
  As a user of Golden1 website
  I want to navigate through different sections
  So that I can access various banking services and information

  Background:
    Given User opens the Golden1 homepage

  @Smoke @TC001
  Scenario: TC-001 - Verify homepage loads successfully
    Then The homepage should load successfully
    And The main menu should be visible
    And The top tabs should be visible

  @TC002
  Scenario: TC-002 - Verify Personal tab is visible
    Then The Personal tab should be visible

  @TC003
  Scenario: TC-003 - Verify navigation to Checking menu
    When User clicks on the Checking menu
    Then The Checking menu should be visible

  @TC004
  Scenario: TC-004 - Verify navigation to Free Checking page
    When User navigates to Free Checking page
    Then The Free Checking page should be displayed
    And The page URL should contain "checking"

  @TC005
  Scenario: TC-005 - Verify navigation to Savings Account page
    When User navigates to Savings Account page
    Then The Savings Account page should be displayed
    And The page URL should contain "savings"

  @TC006
  Scenario: TC-006 - Verify navigation to Auto Loans page
    When User navigates to Auto Loans page
    Then The Auto Loans page should be displayed

  @TC007
  Scenario: TC-007 - Verify top tab navigation to Business
    When User clicks on the Business tab
    Then The page URL should contain "business"

  @TC008
  Scenario: TC-008 - Verify top tab navigation to Financial Wellness
    When User clicks on the Financial Wellness tab
    Then The page title should contain "Financial Wellness"

  @TC009
  Scenario: TC-009 - Verify top tab navigation to Locations
    When User clicks on the Locations tab
    Then The page URL should contain "locations"

  @TC010
  Scenario Outline: TC-010 - Verify navigation to different menu sections
    When User clicks on the <MenuName> menu
    Then The page URL should contain "<ExpectedUrlPart>"

    Examples:
      | MenuName      | ExpectedUrlPart |
      | Savings       | savings         |
      | Home Loans    | home            |
      | Credit Cards  | credit          |
      | Loans         | loans           |
      | Investing     | invest          |
      | Community     | community       |