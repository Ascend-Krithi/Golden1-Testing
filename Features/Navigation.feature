@Navigation @Regression
Feature: Golden1 Website Navigation
  As a user of Golden1 Credit Union website
  I want to navigate through different sections
  So that I can access various banking services and information

  Background:
    Given the user opens the Golden1 website
    And the user accepts cookies if banner is displayed

  @TC001 @Smoke
  Scenario: TC-001 - Verify user can navigate to Personal tab
    When the user clicks on the "Personal" tab
    Then the Personal section should be displayed
    And the page URL should contain "personal"

  @TC002
  Scenario: TC-002 - Verify user can navigate to Checking page from Personal tab
    When the user clicks on the "Personal" tab
    And the user clicks on "Checking" menu option
    Then the Checking page should be displayed
    And the page title should contain "Checking"

  @TC003
  Scenario: TC-003 - Verify user can navigate to Free Checking page
    When the user clicks on the "Personal" tab
    And the user clicks on "Checking" menu option
    And the user clicks on "Free Checking" link
    Then the Free Checking page should be displayed
    And the page URL should contain "free-checking"

  @TC004
  Scenario: TC-004 - Verify user can navigate to Savings page
    When the user clicks on the "Personal" tab
    And the user clicks on "Savings" menu option
    Then the Savings page should be displayed
    And the page title should contain "Savings"

  @TC005
  Scenario: TC-005 - Verify user can navigate to Savings Account page
    When the user clicks on the "Personal" tab
    And the user clicks on "Savings" menu option
    And the user clicks on "Savings Account" link
    Then the Savings Account page should be displayed

  @TC006
  Scenario: TC-006 - Verify all top navigation tabs are visible
    Then the following top navigation tabs should be visible:
      | TabName              |
      | Personal             |
      | Business             |
      | Financial Wellness   |
      | Appointments         |
      | Locations            |
      | Membership           |
      | Help Center          |

  @TC007
  Scenario: TC-007 - Verify user can navigate to Business tab
    When the user clicks on the "Business" tab
    Then the Business section should be displayed

  @TC008
  Scenario: TC-008 - Verify user can navigate to Home Loans page
    When the user clicks on the "Personal" tab
    And the user clicks on "Home Loans" menu option
    Then the Home Loans page should be displayed

  @TC009
  Scenario: TC-009 - Verify user can navigate to Credit Cards page
    When the user clicks on the "Personal" tab
    And the user clicks on "Credit Cards" menu option
    Then the Credit Cards page should be displayed

  @TC010
  Scenario: TC-010 - Verify user can navigate to Auto Loans page
    When the user clicks on the "Personal" tab
    And the user clicks on "Loans" menu option
    And the user clicks on "Auto Loan" link
    Then the Auto Loans page should be displayed