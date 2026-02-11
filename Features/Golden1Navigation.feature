@Golden1Navigation
Feature: Golden1 Website Navigation
  As a user
  I want to navigate through the Golden 1 website
  So that I can access different product and service pages

  Background:
    Given the browser is launched

  @TASK0020445 @TS-001 @TC-001 @AC-1
  Scenario: TASK0020445 TS-001 TC-001 - Verify browser launches and homepage loads
    When I navigate to the Golden 1 homepage
    Then the Golden 1 homepage should be displayed successfully
    And the homepage should be visible without errors

  @TASK0020445 @TS-002 @TC-001 @AC-2
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Given I navigate to the Golden 1 homepage
    When I check the top section of the homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001 @AC-3
  Scenario: TASK0020445 TS-003 TC-001 - Verify top navigation menu options are present
    Given I navigate to the Golden 1 homepage
    When I inspect the top navigation menu
    Then the following menu options should be present:
      | MenuOption         |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @TASK0020445 @TS-004 @TC-001 @AC-4
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    Given I navigate to the Golden 1 homepage
    When I interact with the global navigation menu
    Then the following main product category menus should be displayed:
      | CategoryMenu |
      | Checking     |
      | Savings      |
      | Home Loans   |
      | Credit Cards |
      | Loans        |
      | Investing    |
      | Community    |
    And each main product category menu should be accessible

  @TASK0020445 @TS-005 @TC-001 @AC-5
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    Given I navigate to the Golden 1 homepage
    When I hover over the "Checking" main product menu
    Then submenu items should be displayed under the main product menu
    When I click the "Free Checking" submenu item
    Then the submenu item should respond to the click

  @TASK0020445 @TS-006 @TC-001 @AC-6
  Scenario: TASK0020445 TS-006 TC-001 - Verify submenu item redirects to destination page
    Given I navigate to the Golden 1 homepage
    When I select the "Free Checking" submenu item under "Checking" menu
    Then I should be redirected to the destination page
    And the destination page should load completely without errors

  @TASK0020445 @TS-007 @TC-001 @AC-7
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given I navigate to the Golden 1 homepage
    When I select the "Free Checking" submenu item under "Checking" menu
    Then the URL should contain the expected page identifier "/checking"

  @TASK0020445 @TS-008 @TC-001 @AC-8
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    Given I navigate to the Golden 1 homepage
    When I check the top header area
    Then the Golden 1 logo should be visible in the header

  @TASK0020445 @TS-009 @TC-001 @AC-9
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given I navigate to the Golden 1 homepage
    When I inspect the homepage for layout and content
    Then the homepage should display all content correctly
    And there should be no broken layouts or error messages

  @TASK0020445 @TS-010 @TC-001 @AC-2 @AC-9
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify navigation menu across different browsers
    Given I launch the "<Browser>" browser
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly
    And the homepage elements should be consistent

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TASK0020445 @TS-011 @TC-001 @AC-2 @AC-9
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify navigation menu across different devices
    Given I set the viewport to "<Device>" size
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly
    And the homepage elements should be responsive

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |

  @TASK0020445 @TS-012 @TC-001 @AC-2 @AC-3 @AC-4 @AC-5
  Scenario: TASK0020445 TS-012 TC-001 - Verify keyboard navigation accessibility
    Given I navigate to the Golden 1 homepage
    When I use keyboard navigation to move to the global navigation menu
    Then the focus should move to the global navigation menu
    When I use keyboard navigation to access each main menu item
    Then all menu items should be accessible via keyboard
    When I press Enter on a menu item
    Then the menu item should respond to keyboard selection