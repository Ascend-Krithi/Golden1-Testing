Feature: Golden1 Website Navigation
  As a user of Golden 1 Credit Union website
  I want to navigate through the website
  So that I can access various banking services

  @TASK0020445 @TS-001 @TC-001 @AC1
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage loads successfully in supported browser
    Given I launch the browser "Chrome"
    When I navigate to the Golden1 homepage
    Then the homepage should load successfully without errors

  @TASK0020445 @TS-002 @TC-001 @AC2
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Given I launch the browser "Chrome"
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001 @AC3
  Scenario: TASK0020445 TS-003 TC-001 - Verify all menu options are present
    Given I launch the browser "Chrome"
    When I navigate to the Golden1 homepage
    And I locate the global navigation menu
    Then the following menu options should be present
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
    Given I launch the browser "Chrome"
    When I navigate to the Golden1 homepage
    And I locate the global navigation menu
    Then the following main product category menus should be displayed
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |
    And each main product category menu should be clickable

  @TASK0020445 @TS-005 @TC-001 @AC5
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    Given I launch the browser "Chrome"
    When I navigate to the Golden1 homepage
    And I expand the "Checking" main product menu
    Then submenu items should be displayed under the menu
    And I should be able to select submenu items

  @TASK0020445 @TS-006 @TC-001 @AC6
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page from submenu
    Given I launch the browser "Chrome"
    When I navigate to the Golden1 homepage
    And I expand the "Checking" main product menu
    And I select the "Free Checking" submenu item
    Then I should be redirected to the destination page
    And the destination page should load without errors

  @TASK0020445 @TS-007 @TC-001 @AC7
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given I launch the browser "Chrome"
    When I navigate to the Golden1 homepage
    And I expand the "Checking" main product menu
    And I select the "Free Checking" submenu item
    Then the destination page URL should contain "/checking/free-checking"

  @TASK0020445 @TS-008 @TC-001 @AC8
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible in header
    Given I launch the browser "Chrome"
    When I navigate to the Golden1 homepage
    Then the Golden 1 logo should be visible in the top header

  @TASK0020445 @TS-009 @TC-001 @AC9
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given I launch the browser "Chrome"
    When I navigate to the Golden1 homepage
    Then the homepage should display correctly
    And there should be no broken layouts
    And there should be no missing content
    And there should be no system errors

  @TASK0020445 @TS-010 @TC-001 @CrossBrowser
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given I launch the browser "<Browser>"
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible
    And the Golden 1 logo should be visible in the header
    And there should be no layout issues
    And there should be no system errors

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TASK0020445 @TS-011 @TC-001 @Responsive
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify responsive design across devices
    Given I launch the browser "Chrome" on "<Device>" device
    When I navigate to the Golden1 homepage
    Then the navigation menu should be visible and functional
    And the Golden 1 logo should be visible in the header
    And there should be no layout issues
    And there should be no system errors

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |