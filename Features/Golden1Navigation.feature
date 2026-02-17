@Golden1Navigation
Feature: Golden1 Website Navigation
  As a user of Golden1 Credit Union website
  I want to navigate through different pages
  So that I can access various banking services

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully in Chrome browser
    Given I launch the "Chrome" browser
    When I navigate to the Golden1 homepage
    Then the homepage should load successfully without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Given I navigate to the Golden1 homepage
    When I observe the top section of the homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all menu options are present
    Given I navigate to the Golden1 homepage
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

  @TASK0020445 @TS-004 @TC-001
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    Given I navigate to the Golden1 homepage
    When I locate the global navigation menu
    Then the following main product category menus should be displayed:
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |
    And each product category menu should be accessible

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    Given I navigate to the Golden1 homepage
    When I expand the "Checking" product menu
    Then submenu items should be displayed
    And I should be able to select submenu items

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    Given I navigate to the Golden1 homepage
    When I expand the "Checking" product menu
    And I select the "Free Checking" submenu item
    Then I should be redirected to the Free Checking destination page
    And the destination page should load without errors

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given I navigate to the Golden1 homepage
    When I expand the "Checking" product menu
    And I select the "Free Checking" submenu item
    Then the destination page URL should contain "/checking/free-checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden1 logo is visible in header
    Given I navigate to the Golden1 homepage
    When I observe the top header area
    Then the Golden1 logo should be visible in the header

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given I navigate to the Golden1 homepage
    Then the homepage should display correctly
    And there should be no broken layouts
    And there should be no missing content
    And there should be no system errors

  @TASK0020445 @TS-010 @TC-001
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given I launch the "<Browser>" browser
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible and functional
    And the Golden1 logo should be visible in the header
    And there should be no layout issues or errors

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TASK0020445 @TS-011 @TC-001
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify responsive design across devices
    Given I navigate to the Golden1 homepage on "<Device>" device
    Then the navigation menu should be visible and functional on "<Device>"
    And the Golden1 logo should be visible on "<Device>"
    And there should be no layout issues on "<Device>"

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |