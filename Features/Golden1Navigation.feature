@Golden1Navigation
Feature: Golden 1 Website Navigation
  As a user
  I want to navigate through the Golden 1 website
  So that I can access different sections and verify functionality

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Launch browser and verify Golden 1 homepage loads
    Given I launch the browser
    When I navigate to the Golden 1 homepage
    Then the homepage should load successfully without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu visibility
    Given I launch the browser
    When I navigate to the Golden 1 homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all top menu options are present
    Given I launch the browser
    When I navigate to the Golden 1 homepage
    Then the following top menu options should be present:
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
    When I navigate to the Golden 1 homepage
    Then the following main product category menus should be displayed:
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |
    And each main product category menu should be accessible

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    Given I launch the browser
    When I navigate to the Golden 1 homepage
    And I expand the "Checking" main product menu
    Then submenu items should be displayed
    And I should be able to select the "Free Checking" submenu item

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to submenu destination page
    Given I launch the browser
    When I navigate to the Golden 1 homepage
    And I expand the "Checking" main product menu
    And I select the "Free Checking" submenu item
    Then I should be redirected to the Free Checking destination page
    And the destination page should load without errors

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given I launch the browser
    When I navigate to the Golden 1 homepage
    And I expand the "Checking" main product menu
    And I select the "Free Checking" submenu item
    Then the destination page URL should contain "checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible in header
    Given I launch the browser
    When I navigate to the Golden 1 homepage
    Then the Golden 1 logo should be visible in the top header

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given I launch the browser
    When I navigate to the Golden 1 homepage
    Then the homepage should display correctly
    And there should be no broken layouts
    And there should be no missing content
    And there should be no system errors