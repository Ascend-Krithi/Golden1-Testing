Feature: Golden1 Homepage Navigation and Verification
  As a user of Golden1 Credit Union website
  I want to navigate and interact with the homepage and navigation menu
  So that I can access different banking services

  @TASK0020445 @TS-001 @TC-001 @AC1
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully in Chrome
    Given I launch Chrome browser
    When I navigate to Golden1 homepage
    Then the Golden1 homepage should load successfully
    And there should be no error messages or loading issues

  @TASK0020445 @TS-002 @TC-001 @AC2
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Given I navigate to Golden1 homepage
    When I observe the top section of the homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001 @AC3
  Scenario: TASK0020445 TS-003 TC-001 - Verify all main menu options are present
    Given I navigate to Golden1 homepage
    When I locate the global navigation menu
    Then the following menu options should be present:
      | MenuOption        |
      | Personal          |
      | Business          |
      | Financial Wellness|
      | Appointments      |
      | Locations         |
      | Membership        |
      | Help Center       |

  @TASK0020445 @TS-004 @TC-001 @AC4
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    Given I navigate to Golden1 homepage
    When I locate the global navigation menu
    Then the following product category menus should be displayed:
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |
    And each product category menu should be clickable and expandable

  @TASK0020445 @TS-005 @TC-001 @AC5
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    Given I navigate to Golden1 homepage
    When I expand the "Checking" product menu
    Then submenu items should be displayed
    And I should be able to select "Free Checking" submenu item

  @TASK0020445 @TS-006 @TC-001 @AC6
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    Given I navigate to Golden1 homepage
    When I expand the "Checking" product menu
    And I select the "Free Checking" submenu item
    Then I should be redirected to the Free Checking destination page
    And the destination page should load without errors

  @TASK0020445 @TS-007 @TC-001 @AC7
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given I navigate to Golden1 homepage
    When I expand the "Checking" product menu
    And I select the "Free Checking" submenu item
    Then the destination page URL should contain "/checking/free-checking"

  @TASK0020445 @TS-008 @TC-001 @AC8
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden1 logo is visible in header
    Given I navigate to Golden1 homepage
    When I observe the top header area
    Then the Golden1 logo should be visible in the header

  @TASK0020445 @TS-009 @TC-001 @AC9
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays without errors
    Given I navigate to Golden1 homepage
    Then the homepage should display correctly
    And there should be no broken layouts
    And there should be no missing content
    And there should be no system errors

  @TASK0020445 @TS-010 @TC-001 @AC2 @AC3 @AC4 @AC8 @AC9 @CrossBrowser
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given I launch <Browser> browser
    When I navigate to Golden1 homepage
    Then the global navigation menu should be visible and functional
    And the header elements including Golden1 logo should be visible
    And there should be no layout issues or system errors

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TASK0020445 @TS-011 @TC-001 @AC2 @AC3 @AC4 @AC8 @AC9 @Responsive
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify responsive design across devices
    Given I set the browser viewport to <Device> size
    When I navigate to Golden1 homepage
    Then the navigation menu should be visible and functional on <Device>
    And the header elements should be visible and functional on <Device>
    And there should be no layout issues on <Device>

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |