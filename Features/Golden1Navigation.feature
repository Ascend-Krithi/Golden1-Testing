@Golden1Navigation
Feature: Golden1 Website Navigation
  As a user
  I want to navigate the Golden1 website
  So that I can access different sections and services

  Background:
    Given the browser is launched

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify browser launches and homepage loads
    When I navigate to the Golden1 homepage
    Then the homepage should load successfully without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu visibility
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible at the top of the page

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all top menu options are present
    When I navigate to the Golden1 homepage
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
    When I navigate to the Golden1 homepage
    Then the following main product category menus should be displayed:
      | ProductMenu  |
      | Checking     |
      | Savings      |
      | Home Loans   |
      | Credit Cards |
      | Loans        |
      | Investing    |
      | Community    |
    And each main product category menu should be accessible

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    When I navigate to the Golden1 homepage
    And I expand the "Checking" menu
    Then the submenu items should be displayed
    And I should be able to select the "Free Checking" submenu item

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    When I navigate to the Golden1 homepage
    And I expand the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then I should be redirected to the Free Checking destination page
    And the destination page should load without errors

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    When I navigate to the Golden1 homepage
    And I expand the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then the destination page URL should contain "checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden1 logo is visible in header
    When I navigate to the Golden1 homepage
    Then the Golden1 logo should be visible in the top header

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    When I navigate to the Golden1 homepage
    Then the homepage should display correctly with no broken layouts
    And there should be no missing content
    And there should be no system errors

  @TASK0020445 @TS-010 @TC-001
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given the browser "<Browser>" is launched
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible and functional
    And the header elements including Golden1 logo should be visible
    And there should be no layout issues or system errors

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TASK0020445 @TS-011 @TC-001
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