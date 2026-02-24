Feature: TASK0020445 - Golden1 Homepage Navigation
  As a user
  I want to navigate the Golden1 website
  So that I can access banking services and verify navigation functionality

  Background:
    Given the user launches the browser

  @Navigation @Smoke @Critical @TASK0020445
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully
    When the user navigates to the Golden1 homepage
    Then the homepage should load successfully
    And no error messages should be displayed

  @Navigation @Smoke @Critical @TASK0020445
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    When the user navigates to the Golden1 homepage
    Then the global navigation menu should be visible at the top of the page

  @Navigation @Regression @P1 @TASK0020445
  Scenario: TASK0020445 TS-003 TC-001 - Verify all menu options are present
    When the user navigates to the Golden1 homepage
    Then the navigation menu should be visible
    And the menu should contain the following options:
      | MenuOption         |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @Navigation @Regression @P1 @TASK0020445
  Scenario Outline: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible - <ProductMenu>
    When the user navigates to the Golden1 homepage
    Then the navigation menu should be visible
    And the "<ProductMenu>" product menu should be displayed
    When the user clicks on the "<ProductMenu>" product menu
    Then the "<ProductMenu>" menu should expand or display submenu items

    Examples:
      | ProductMenu  |
      | Checking     |
      | Savings      |
      | Home Loans   |
      | Credit Cards |
      | Loans        |
      | Investing    |
      | Community    |

  @Navigation @Regression @P1 @TASK0020445
  Scenario Outline: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable - <MainMenu> > <SubmenuItem>
    Given the user is on the Golden1 homepage
    When the user expands the "<MainMenu>" menu
    And the user clicks on the "<SubmenuItem>" submenu item
    Then the submenu item should be selectable

    Examples:
      | MainMenu | SubmenuItem   |
      | Checking | Free Checking |

  @Navigation @Regression @P1 @TASK0020445
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    Given the user is on the Golden1 homepage
    When the user expands the "Checking" menu
    And the user clicks on the "Free Checking" submenu item
    Then the user should be redirected to the destination page
    And the destination page should load without errors

  @Navigation @Regression @P1 @TASK0020445
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given the user is on the Golden1 homepage
    When the user expands the "Checking" menu
    And the user clicks on the "Free Checking" submenu item
    Then the destination page URL should contain "/checking/free-checking"

  @Navigation @Smoke @Critical @TASK0020445
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
    When the user navigates to the Golden1 homepage
    Then the Golden 1 logo should be visible in the top header

  @Navigation @Smoke @Critical @TASK0020445
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    When the user navigates to the Golden1 homepage
    Then the homepage should display correctly with no broken layouts
    And there should be no missing content
    And there should be no system errors displayed