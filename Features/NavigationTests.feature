@NavigationTests
Feature: Golden 1 Website Navigation Tests
  As a user of Golden 1 Credit Union website
  I want to verify navigation functionality
  So that I can access different sections of the website

  Background:
    Given the browser is launched

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify Golden 1 homepage loads successfully
    When I navigate to the Golden 1 homepage
    Then the homepage should be displayed without errors
    And the page title should be visible

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    When I navigate to the Golden 1 homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all main menu options are present
    When I navigate to the Golden 1 homepage
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
    When I navigate to the Golden 1 homepage
    Then the following main product categories should be accessible:
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    When I navigate to the Golden 1 homepage
    And I hover over the "Checking" menu
    Then submenu items should be displayed
    And I should be able to click on submenu items

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    When I navigate to the Golden 1 homepage
    And I hover over the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then the destination page should load completely
    And the page should be displayed without errors

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    When I navigate to the Golden 1 homepage
    And I hover over the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then the URL should contain "checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    When I navigate to the Golden 1 homepage
    Then the Golden 1 logo should be visible in the header

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    When I navigate to the Golden 1 homepage
    Then the homepage should display all content correctly
    And there should be no broken layouts or error messages

  @TASK0020445 @TS-010 @TC-001
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify cross-browser compatibility
    Given the browser type is "<Browser>"
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly
    And homepage elements should be consistent

    Examples:
      | Browser |
      | chrome  |
      | firefox |
      | edge    |

  @TASK0020445 @TS-011 @TC-001
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify responsive design across devices
    Given the viewport is set to "<Device>"
    When I navigate to the Golden 1 homepage
    Then the navigation menu should be displayed correctly
    And homepage elements should be responsive

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |

  @TASK0020445 @TS-012 @TC-001
  Scenario: TASK0020445 TS-012 TC-001 - Verify keyboard navigation accessibility
    When I navigate to the Golden 1 homepage
    And I use keyboard navigation to access the global menu
    Then all menu items should be accessible via keyboard
    And I should be able to select menu items using Enter key