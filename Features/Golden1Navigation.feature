@Golden1Navigation
Feature: Golden1 Website Navigation
  As a user
  I want to navigate the Golden1 website
  So that I can access different product pages

  Background:
    Given the browser is launched

  @TASK0020445 @TS-001 @TC-001 @AC-1
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage loads successfully
    When I navigate to the Golden1 homepage
    Then the homepage should be displayed without errors

  @TASK0020445 @TS-002 @TC-001 @AC-2
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001 @AC-3
  Scenario: TASK0020445 TS-003 TC-001 - Verify all top navigation menu options are present
    When I navigate to the Golden1 homepage
    Then the following top navigation options should be present:
      | Personal            |
      | Business            |
      | Financial Wellness  |
      | Appointments        |
      | Locations           |
      | Membership          |
      | Help Center         |

  @TASK0020445 @TS-004 @TC-001 @AC-4
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    When I navigate to the Golden1 homepage
    Then the following main product category menus should be accessible:
      | Checking      |
      | Savings       |
      | Home Loans    |
      | Credit Cards  |
      | Loans         |
      | Investing     |
      | Community     |

  @TASK0020445 @TS-005 @TC-001 @AC-5
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    When I navigate to the Golden1 homepage
    And I hover over the "Checking" menu
    Then the submenu items should be displayed
    And I should be able to click the "Free Checking" submenu item

  @TASK0020445 @TS-006 @TC-001 @AC-6
  Scenario: TASK0020445 TS-006 TC-001 - Verify submenu navigation to destination page
    When I navigate to the Golden1 homepage
    And I hover over the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then I should be redirected to the Free Checking page
    And the destination page should load completely

  @TASK0020445 @TS-007 @TC-001 @AC-7
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    When I navigate to the Golden1 homepage
    And I hover over the "Checking" menu
    And I click on the "Free Checking" submenu item
    Then the URL should contain "checking"

  @TASK0020445 @TS-008 @TC-001 @AC-8
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden1 logo is visible
    When I navigate to the Golden1 homepage
    Then the Golden1 logo should be visible in the header

  @TASK0020445 @TS-009 @TC-001 @AC-9
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    When I navigate to the Golden1 homepage
    Then the homepage should display all content correctly
    And there should be no broken layouts
    And there should be no error messages

  @TASK0020445 @TS-010 @TC-001 @AC-2 @AC-9 @CrossBrowser
  Scenario Outline: TASK0020445 TS-010 TC-001 - Verify navigation menu across browsers
    Given the browser type is "<Browser>"
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible at the top
    And the homepage should display all content correctly

    Examples:
      | Browser |
      | chrome  |
      | firefox |
      | edge    |

  @TASK0020445 @TS-011 @TC-001 @AC-2 @AC-9 @Responsive
  Scenario Outline: TASK0020445 TS-011 TC-001 - Verify navigation menu across devices
    Given the viewport is set to "<Device>"
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible
    And the homepage should display correctly for the device

    Examples:
      | Device  |
      | Desktop |
      | Tablet  |
      | Mobile  |

  @TASK0020445 @TS-012 @TC-001 @AC-2 @AC-3 @AC-4 @AC-5 @Accessibility
  Scenario: TASK0020445 TS-012 TC-001 - Verify keyboard navigation accessibility
    When I navigate to the Golden1 homepage
    And I use keyboard navigation to access the global navigation menu
    Then all menu items should be accessible via keyboard
    And all submenu items should be accessible via keyboard
    And I should be able to select menu items using Enter key