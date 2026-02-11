@Golden1Navigation
Feature: Golden 1 Website Navigation
  As a user
  I want to navigate through Golden 1 website
  So that I can access different product pages

  Background:
    Given the browser is launched

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify browser launches and homepage loads successfully
    When user navigates to Golden 1 homepage
    Then the homepage should be displayed without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Given user navigates to Golden 1 homepage
    When user checks the top section of the homepage
    Then the global navigation menu should be visible

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all top navigation menu options are present
    Given user navigates to Golden 1 homepage
    When user inspects the top navigation menu
    Then the following menu options should be present:
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
    Given user navigates to Golden 1 homepage
    When user hovers over the global navigation menu
    Then the following main product category menus should be displayed:
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
    Given user navigates to Golden 1 homepage
    When user hovers over "Checking" main product menu
    Then submenu items should be displayed
    When user clicks on "Free Checking" submenu item
    Then the submenu item should respond to click

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    Given user navigates to Golden 1 homepage
    When user hovers over "Checking" main product menu
    And user clicks on "Free Checking" submenu item
    Then user should be redirected to the destination page
    And the destination page should load completely without errors

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given user navigates to Golden 1 homepage
    When user hovers over "Checking" main product menu
    And user clicks on "Free Checking" submenu item
    Then the destination page URL should contain "checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    Given user navigates to Golden 1 homepage
    When user checks the top header area
    Then the Golden 1 logo should be visible

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given user navigates to Golden 1 homepage
    When user inspects the homepage
    Then the homepage should display all content correctly
    And there should be no broken layouts or error messages

  @TASK0020445 @TS-010 @TC-001
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given user launches "<Browser>" browser
    When user navigates to Golden 1 homepage
    Then the navigation menu should be displayed correctly
    And the homepage elements should be consistent

    Examples:
      | Browser |
      | chrome  |
      | firefox |
      | edge    |

  @TASK0020445 @TS-011 @TC-001
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify responsive design across devices
    Given user opens browser on "<Device>" device
    When user navigates to Golden 1 homepage
    Then the navigation menu should be displayed correctly on "<Device>"
    And the homepage elements should be responsive on "<Device>"

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |

  @TASK0020445 @TS-012 @TC-001
  Scenario: TASK0020445 TS-012 TC-001 - Verify keyboard navigation accessibility
    Given user navigates to Golden 1 homepage
    When user uses keyboard navigation to access the global navigation menu
    Then all menu items should be accessible via keyboard
    And user should be able to select menu items using Enter key
    When user navigates to "Checking" menu using keyboard
    And user presses Enter on "Free Checking" submenu item
    Then the menu item should respond to keyboard selection