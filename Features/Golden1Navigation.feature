@Golden1Navigation
Feature: Golden1 Website Navigation
  As a user of Golden 1 Credit Union website
  I want to navigate through the website
  So that I can access different banking services and information

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully
    Given I launch a supported browser
    When I navigate to the Golden 1 homepage
    Then the homepage should be displayed without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Given I navigate to the Golden 1 homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all top navigation options are present
    Given I navigate to the Golden 1 homepage
    Then the top navigation menu should contain the following options:
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
    Given I navigate to the Golden 1 homepage
    When I interact with the global navigation menu
    Then the following main product category menus should be displayed:
      | CategoryMenu  |
      | Checking      |
      | Savings       |
      | Home Loans    |
      | Credit Cards  |
      | Loans         |
      | Investing     |
      | Community     |
    And each main product category menu should be accessible

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    Given I navigate to the Golden 1 homepage
    When I hover over the "Checking" main product menu
    Then submenu items should be displayed under "Checking"
    When I click the "Free Checking" submenu item
    Then the submenu item should respond to the click

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify submenu navigation to destination page
    Given I navigate to the Golden 1 homepage
    When I hover over the "Checking" main product menu
    And I click the "Free Checking" submenu item
    Then I should be redirected to the Free Checking destination page
    And the destination page should load completely

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given I navigate to the Golden 1 homepage
    When I hover over the "Checking" main product menu
    And I click the "Free Checking" submenu item
    Then the URL should contain the expected page identifier "checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    Given I navigate to the Golden 1 homepage
    Then the Golden 1 logo should be visible in the top header area

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given I navigate to the Golden 1 homepage
    Then the homepage should display all content correctly
    And there should be no broken layouts
    And there should be no error messages

  @TASK0020445 @TS-010 @TC-001
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given I launch "<Browser>" browser
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly
    And the homepage elements should be consistent

    Examples:
      | Browser |
      | chrome  |
      | firefox |
      | edge    |

  @TASK0020445 @TS-011 @TC-001
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify responsive design across devices
    Given I set the browser viewport to "<Device>" size
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly for "<Device>"
    And the homepage elements should be responsive

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |

  @TASK0020445 @TS-012 @TC-001
  Scenario: TASK0020445 TS-012 TC-001 - Verify keyboard navigation accessibility
    Given I navigate to the Golden 1 homepage
    When I use keyboard navigation to access the global navigation menu
    Then I should be able to navigate to all main menu items using keyboard
    And I should be able to navigate to all submenu items using keyboard
    And I should be able to select menu items by pressing Enter