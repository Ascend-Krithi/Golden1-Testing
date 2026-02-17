Feature: Golden1 Website Navigation
  As a user of Golden 1 Credit Union website
  I want to navigate through different sections
  So that I can access various banking products and services

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully
    Given I launch the browser
    When I navigate to Golden1 homepage
    Then the homepage should load successfully without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Given I launch the browser
    When I navigate to Golden1 homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all top menu options are present
    Given I launch the browser
    When I navigate to Golden1 homepage
    Then the navigation menu should display all top menu options
      | MenuOption         |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @TASK0020445 @TS-004 @TC-001
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    Given I launch the browser
    When I navigate to Golden1 homepage
    Then all main product category menus should be displayed
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |
    And each product category menu should be clickable

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    Given I launch the browser
    When I navigate to Golden1 homepage
    And I expand the "Checking" menu
    Then submenu items should be displayed
    And I should be able to select "Free Checking" submenu item

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    Given I launch the browser
    When I navigate to Golden1 homepage
    And I expand the "Checking" menu
    And I click on "Free Checking" submenu item
    Then I should be redirected to the Free Checking page
    And the destination page should load without errors

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given I launch the browser
    When I navigate to Golden1 homepage
    And I expand the "Checking" menu
    And I click on "Free Checking" submenu item
    Then the page URL should contain "/checking/free-checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    Given I launch the browser
    When I navigate to Golden1 homepage
    Then the Golden1 logo should be visible in the header

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given I launch the browser
    When I navigate to Golden1 homepage
    Then the homepage should display without layout issues
    And there should be no error messages
    And there should be no missing content