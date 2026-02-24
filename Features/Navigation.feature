@Regression @Navigation @P1
Feature: TASK0020445 - Golden1 Website Navigation
  As a user of Golden1 Credit Union website
  I want to navigate through different sections
  So that I can access various banking products and services

  Background:
    Given User is on the Golden1 homepage

  @Smoke
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage loads successfully
    Then User should see the main navigation menu
    And User should see the top tabs container

  @Smoke
  Scenario: TASK0020445 TS-001 TC-002 - Verify cookie banner appears and can be accepted
    Then User should see the cookie consent banner
    When User clicks Accept Cookies button
    Then Cookie banner should disappear

  Scenario: TASK0020445 TS-002 TC-001 - Verify Personal tab is accessible
    When User clicks on Personal tab
    Then Personal tab should be active
    And User should see the main menu options

  Scenario: TASK0020445 TS-003 TC-001 - Navigate to Checking menu
    When User clicks on Personal tab
    And User clicks on Checking menu
    Then Checking submenu should be displayed

  Scenario: TASK0020445 TS-003 TC-002 - Navigate to Free Checking page
    When User clicks on Personal tab
    And User clicks on Checking menu
    And User clicks on Free Checking link
    Then User should be navigated to Free Checking page
    And Page heading should contain "Free Checking"

  Scenario: TASK0020445 TS-004 TC-001 - Navigate to Savings menu
    When User clicks on Personal tab
    And User clicks on Savings menu
    Then Savings submenu should be displayed

  Scenario: TASK0020445 TS-004 TC-002 - Navigate to Savings Account page
    When User clicks on Personal tab
    And User clicks on Savings menu
    And User clicks on Savings Account link
    Then User should be navigated to Savings Account page

  Scenario Outline: TASK0020445 TS-005 TC-001 - Verify all top navigation tabs are accessible
    When User clicks on "<TabName>" tab
    Then "<TabName>" tab should be active
    And User should see relevant content for "<TabName>"

    Examples:
      | TabName             |
      | Personal            |
      | Business            |
      | Financial Wellness  |
      | Appointments        |
      | Locations           |
      | Membership          |
      | Help Center         |

  Scenario Outline: TASK0020445 TS-006 TC-001 - Verify all main menu options under Personal tab
    When User clicks on Personal tab
    And User clicks on "<MenuOption>" menu
    Then "<MenuOption>" submenu should be displayed

    Examples:
      | MenuOption    |
      | Checking      |
      | Savings       |
      | Home Loans    |
      | Credit Cards  |
      | Loans         |
      | Investing     |
      | Community     |