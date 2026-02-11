@TASK0020445
Feature: Golden1 Website Navigation
  As a user
  I want to navigate the Golden1 website
  So that I can access different banking services

  @TS-001 @TC-001 @AC-1
  Scenario: TS-001 TC-001 - Verify browser launches and Golden1 homepage loads successfully
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then the homepage should be displayed without errors

  @TS-002 @TC-001 @AC-2
  Scenario: TS-002 TC-001 - Verify global navigation menu is visible
    Given I navigate to the Golden1 homepage
    Then the global navigation menu should be visible at the top

  @TS-003 @TC-001 @AC-3
  Scenario: TS-003 TC-001 - Verify all top navigation menu options are present
    Given I navigate to the Golden1 homepage
    Then the following top navigation options should be present
      | MenuOption         |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @TS-004 @TC-001 @AC-4
  Scenario: TS-004 TC-001 - Verify main product category menus are accessible
    Given I navigate to the Golden1 homepage
    When I interact with the global navigation menu
    Then the following main product categories should be accessible
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |

  @TS-005 @TC-001 @AC-5
  Scenario: TS-005 TC-001 - Verify submenu items are selectable
    Given I navigate to the Golden1 homepage
    When I hover over the "Checking" menu
    Then the submenu items should be displayed
    When I click on the "Free Checking" submenu item
    Then the submenu item should respond to click

  @TS-006 @TC-001 @AC-6
  Scenario: TS-006 TC-001 - Verify navigation to destination page from submenu
    Given I navigate to the Golden1 homepage
    When I hover over the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then I should be redirected to the destination page
    And the destination page should load completely

  @TS-007 @TC-001 @AC-7
  Scenario: TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given I navigate to the Golden1 homepage
    When I hover over the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then the URL should contain the expected page identifier

  @TS-008 @TC-001 @AC-8
  Scenario: TS-008 TC-001 - Verify Golden1 logo is visible in header
    Given I navigate to the Golden1 homepage
    Then the Golden1 logo should be visible in the top header area

  @TS-009 @TC-001 @AC-9
  Scenario: TS-009 TC-001 - Verify homepage displays correctly without errors
    Given I navigate to the Golden1 homepage
    Then the homepage should display all content correctly
    And there should be no broken layouts or error messages

  @TS-010 @TC-001 @AC-2 @AC-9
  Scenario Outline: TS-010 TC-001 - Verify cross-browser compatibility
    Given I launch the "<Browser>" browser
    When I navigate to the Golden1 homepage
    Then the navigation menu should be displayed correctly
    And the homepage elements should be consistent

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TS-011 @TC-001 @AC-2 @AC-9
  Scenario Outline: TS-011 TC-001 - Verify responsive design across devices
    Given I launch the browser on "<Device>" device
    When I navigate to the Golden1 homepage
    Then the navigation menu should be displayed correctly
    And the homepage elements should be responsive

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |

  @TS-012 @TC-001 @AC-2 @AC-3 @AC-4 @AC-5
  Scenario: TS-012 TC-001 - Verify keyboard navigation accessibility
    Given I navigate to the Golden1 homepage
    When I use keyboard navigation to access the global navigation menu
    Then all menu items should be accessible via keyboard
    And all submenu items should be accessible via keyboard
    When I press Enter on menu items
    Then the menu items should respond to keyboard selection