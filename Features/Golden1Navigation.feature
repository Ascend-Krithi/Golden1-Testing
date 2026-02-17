@Golden1Navigation
Feature: Golden1 Website Navigation and Homepage Verification
  As a user
  I want to navigate the Golden1 website
  So that I can access different banking products and services

  Background:
    Given the browser is launched

  @TASK0020445 @TS-001 @TC-001 @AC1
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage loads successfully
    When I navigate to the Golden1 homepage
    Then the homepage should load successfully without errors

  @TASK0020445 @TS-002 @TC-001 @AC2
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible at the top of the page

  @TASK0020445 @TS-003 @TC-001 @AC3
  Scenario: TASK0020445 TS-003 TC-001 - Verify all menu options are present
    When I navigate to the Golden1 homepage
    Then the navigation menu should display all required menu options
      | MenuOption         |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @TASK0020445 @TS-004 @TC-001 @AC4
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    When I navigate to the Golden1 homepage
    Then the main product category menus should be displayed
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |
    And each product category menu should be clickable

  @TASK0020445 @TS-005 @TC-001 @AC5
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    When I navigate to the Golden1 homepage
    And I expand the "Checking" product menu
    Then the submenu should display "Free Checking" option
    And the "Free Checking" submenu item should be selectable

  @TASK0020445 @TS-006 @TC-001 @AC6
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    When I navigate to the Golden1 homepage
    And I expand the "Checking" product menu
    And I click on the "Free Checking" submenu item
    Then I should be redirected to the destination page
    And the destination page should load without errors

  @TASK0020445 @TS-007 @TC-001 @AC7
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    When I navigate to the Golden1 homepage
    And I expand the "Checking" product menu
    And I click on the "Free Checking" submenu item
    Then the destination page URL should contain "/checking/free-checking"

  @TASK0020445 @TS-008 @TC-001 @AC8
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden1 logo is visible
    When I navigate to the Golden1 homepage
    Then the Golden1 logo should be visible in the top header

  @TASK0020445 @TS-009 @TC-001 @AC9
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays without errors
    When I navigate to the Golden1 homepage
    Then the homepage should display correctly with no broken layouts
    And there should be no missing content
    And there should be no system errors

  @TASK0020445 @TS-010 @TC-001 @CrossBrowser
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given the browser "<Browser>" is launched
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible and functional
    And the header elements should be visible and functional
    And there should be no layout issues or system errors

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TASK0020445 @TS-011 @TC-001 @Responsive
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify responsive design across devices
    Given the browser is launched on "<Device>" device
    When I navigate to the Golden1 homepage
    Then the navigation menu should be visible and functional on "<Device>"
    And the header elements should be visible and functional on "<Device>"
    And there should be no layout issues on "<Device>"

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |