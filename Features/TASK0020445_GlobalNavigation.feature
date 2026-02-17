Feature: TASK0020445 - Global Navigation Menu Testing
  As a user of Golden 1 Credit Union website
  I want to navigate through the global navigation menu
  So that I can access different product pages

  Background:
    Given the browser is launched

  @TASK0020445 @TS-001 @TC-001 @AC1
  Scenario: TS-001 TC-001 - Verify browser launches and homepage loads successfully
    When I navigate to the Golden 1 homepage
    Then the homepage should load without errors
    And the page should display correctly

  @TASK0020445 @TS-002 @TC-001 @AC2
  Scenario: TS-002 TC-001 - Verify global navigation menu is visible
    When I navigate to the Golden 1 homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001 @AC3
  Scenario: TS-003 TC-001 - Verify navigation menu options are present
    When I navigate to the Golden 1 homepage
    Then the navigation menu should display the following options:
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @TASK0020445 @TS-004 @TC-001 @AC4
  Scenario: TS-004 TC-001 - Verify main product category menus are accessible
    When I navigate to the Golden 1 homepage
    Then the following main product category menus should be displayed:
      | Checking   |
      | Savings    |
      | Home Loans |
      | Credit Cards |
      | Loans      |
      | Investing  |
      | Community  |
    And each product category menu should be clickable

  @TASK0020445 @TS-005 @TC-001 @AC5
  Scenario: TS-005 TC-001 - Verify submenu items are selectable
    When I navigate to the Golden 1 homepage
    And I expand the "Checking" product menu
    Then submenu items should be displayed
    And I should be able to select the "Free Checking" submenu item

  @TASK0020445 @TS-006 @TC-001 @AC6
  Scenario: TS-006 TC-001 - Verify navigation to destination page
    When I navigate to the Golden 1 homepage
    And I expand the "Checking" product menu
    And I click on the "Free Checking" submenu item
    Then the destination page should load successfully
    And the page should display without errors

  @TASK0020445 @TS-007 @TC-001 @AC7
  Scenario: TS-007 TC-001 - Verify destination page URL contains expected identifier
    When I navigate to the Golden 1 homepage
    And I expand the "Checking" product menu
    And I click on the "Free Checking" submenu item
    Then the page URL should contain "/checking/free-checking"

  @TASK0020445 @TS-008 @TC-001 @AC8
  Scenario: TS-008 TC-001 - Verify Golden 1 logo is visible in header
    When I navigate to the Golden 1 homepage
    Then the Golden 1 logo should be visible in the top header

  @TASK0020445 @TS-009 @TC-001 @AC9
  Scenario: TS-009 TC-001 - Verify homepage displays without errors
    When I navigate to the Golden 1 homepage
    Then the homepage should display correctly with no layout issues
    And there should be no missing content
    And there should be no system error messages

  @TASK0020445 @TS-010 @TC-001 @CrossBrowser
  Scenario Outline: TS-010 TC-001 - Verify cross-browser compatibility
    Given the browser "<Browser>" is launched
    When I navigate to the Golden 1 homepage
    Then the global navigation menu should be visible and functional
    And the Golden 1 logo should be visible in the header
    And the page should display without layout issues in "<Browser>"

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TASK0020445 @TS-011 @TC-001 @Responsive
  Scenario Outline: TS-011 TC-001 - Verify responsive design across devices
    Given the browser is launched on "<Device>" device
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be visible and functional on "<Device>"
    And the header elements should be visible on "<Device>"
    And the page should display without layout issues on "<Device>"

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |