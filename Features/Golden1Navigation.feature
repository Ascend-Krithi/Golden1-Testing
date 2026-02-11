@Golden1Navigation
Feature: Golden1 Website Navigation
  As a user
  I want to navigate through the Golden 1 website
  So that I can access various banking products and services

  Background:
    Given the browser is launched

  @TASK0020445 @TS-001 @TC-001 @AC-1
  Scenario: TASK0020445 TS-001 TC-001 - Verify browser launches and homepage loads
    When I navigate to the Golden 1 homepage
    Then the Golden 1 homepage should be displayed successfully
    And the homepage should be visible without errors

  @TASK0020445 @TS-002 @TC-001 @AC-2
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    When I navigate to the Golden 1 homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001 @AC-3
  Scenario: TASK0020445 TS-003 TC-001 - Verify all top navigation menu options are present
    When I navigate to the Golden 1 homepage
    Then all top navigation menu options should be present
      | Personal            |
      | Business            |
      | Financial Wellness  |
      | Appointments        |
      | Locations           |
      | Membership          |
      | Help Center         |

  @TASK0020445 @TS-004 @TC-001 @AC-4
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    When I navigate to the Golden 1 homepage
    Then all main product category menus should be displayed
      | Checking      |
      | Savings       |
      | Home Loans    |
      | Credit Cards  |
      | Loans         |
      | Investing     |
      | Community     |
    And each main product category menu should be accessible

  @TASK0020445 @TS-005 @TC-001 @AC-5
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    When I navigate to the Golden 1 homepage
    And I hover over the "Checking" menu
    Then submenu items should be displayed under "Checking"
    When I click on the "Free Checking" submenu item
    Then the submenu item should respond to click

  @TASK0020445 @TS-006 @TC-001 @AC-6
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    When I navigate to the Golden 1 homepage
    And I hover over the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then I should be redirected to the destination page
    And the destination page should load completely without errors

  @TASK0020445 @TS-007 @TC-001 @AC-7
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    When I navigate to the Golden 1 homepage
    And I hover over the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then the URL should contain the expected page identifier "checking"

  @TASK0020445 @TS-008 @TC-001 @AC-8
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    When I navigate to the Golden 1 homepage
    Then the Golden 1 logo should be visible in the top header area

  @TASK0020445 @TS-009 @TC-001 @AC-9
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    When I navigate to the Golden 1 homepage
    Then the homepage should display all content correctly
    And there should be no broken layouts or error messages

  @TASK0020445 @TS-010 @TC-001 @AC-2 @AC-9
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given the browser type is "<Browser>"
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly
    And the homepage elements should be consistent

    Examples:
      | Browser |
      | chrome  |
      | firefox |
      | edge    |

  @TASK0020445 @TS-011 @TC-001 @AC-2 @AC-9
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify cross-device compatibility
    Given the device type is "<Device>"
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly on "<Device>"
    And the homepage elements should be responsive on "<Device>"

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |

  @TASK0020445 @TS-012 @TC-001 @AC-2 @AC-3 @AC-4 @AC-5
  Scenario: TASK0020445 TS-012 TC-001 - Verify keyboard navigation accessibility
    When I navigate to the Golden 1 homepage
    And I use keyboard navigation to focus on the global navigation menu
    Then the focus should move to the global navigation menu
    When I use keyboard navigation to access each main menu item
    Then all menu items should be accessible via keyboard
    When I press Enter on a menu item
    Then the menu item should respond to keyboard selection