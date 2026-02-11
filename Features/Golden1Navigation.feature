Feature: Golden1 Website Navigation
  As a user
  I want to navigate through the Golden 1 website
  So that I can access different banking services

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify browser launches and homepage loads
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then the homepage should be displayed without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Given I navigate to the Golden1 homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify top navigation menu options are present
    Given I navigate to the Golden1 homepage
    Then the following menu options should be present in the top navigation:
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
    Given I navigate to the Golden1 homepage
    When I hover over the global navigation menu
    Then the following main product categories should be displayed:
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
    Given I navigate to the Golden1 homepage
    When I hover over the "Checking" menu
    Then submenu items should be displayed
    When I click the "Free Checking" submenu item
    Then the submenu item should respond to the click

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    Given I navigate to the Golden1 homepage
    When I hover over the "Checking" menu
    And I click the "Free Checking" submenu item
    Then I should be redirected to the Free Checking page
    And the destination page should load completely

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given I navigate to the Golden1 homepage
    When I hover over the "Checking" menu
    And I click the "Free Checking" submenu item
    Then the URL should contain "checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    Given I navigate to the Golden1 homepage
    Then the Golden1 logo should be visible in the header

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given I navigate to the Golden1 homepage
    Then the homepage should display all content correctly
    And there should be no broken layouts
    And there should be no error messages

  @TASK0020445 @TS-010 @TC-001
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given I launch the "<Browser>" browser
    When I navigate to the Golden1 homepage
    Then the navigation menu should be displayed correctly
    And the homepage elements should be consistent

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |

  @TASK0020445 @TS-011 @TC-001
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify responsive design across devices
    Given I open the browser on "<Device>" device
    When I navigate to the Golden1 homepage
    Then the navigation menu should be displayed correctly on "<Device>"
    And the homepage elements should be responsive on "<Device>"

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |

  @TASK0020445 @TS-012 @TC-001
  Scenario: TASK0020445 TS-012 TC-001 - Verify keyboard navigation accessibility
    Given I navigate to the Golden1 homepage
    When I use keyboard navigation to access the global menu
    Then all menu items should be accessible via keyboard
    And all submenu items should be accessible via keyboard
    When I press Enter on a menu item
    Then the menu item should respond to keyboard selection