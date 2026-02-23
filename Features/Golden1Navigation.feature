Feature: Golden1 Navigation
  As a user of Golden 1 Credit Union website
  I want to navigate through the website menus and pages
  So that I can access different banking products and services

  # ============================================================
  # SMOKE TESTS - Critical functionality
  # ============================================================
  @Navigation @Smoke @Critical @TASK0020445
  Scenario: TASK0020445 TS-001 TC-001 - Verify homepage opens successfully in Chrome browser
    Given User launches Chrome browser
    When User navigates to Golden 1 homepage
    Then Homepage should load successfully without errors

  @Navigation @Smoke @Critical @TASK0020445
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible on homepage
    Given User navigates to Golden 1 homepage
    When User observes the top section of the homepage
    Then Global navigation menu should be visible at the top of the page

  @Navigation @Regression @P1 @TASK0020445
  Scenario: TASK0020445 TS-003 TC-001 - Verify all menu options are present in global navigation
    Given User navigates to Golden 1 homepage
    When User locates the global navigation menu
    Then The following menu options should be present:
      | Menu Option        |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  # ============================================================
  # FUNCTIONAL TESTS - Product Category Navigation
  # ============================================================
  @Navigation @Regression @P1 @TASK0020445
  Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
    Given User navigates to Golden 1 homepage
    When User locates the global navigation menu
    Then The following main product category menus should be displayed:
      | Product Category |
      | Checking         |
      | Savings          |
      | Home Loans       |
      | Credit Cards     |
      | Loans            |
      | Investing        |
      | Community        |
    And Each product category menu should be accessible

  @Navigation @Regression @P1 @TASK0020445
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable under Checking menu
    Given User navigates to Golden 1 homepage
    When User expands the Checking product menu
    Then Submenu items should be displayed under Checking menu
    And User should be able to select Free Checking submenu item

  @Navigation @Regression @P1 @TASK0020445
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to Free Checking page from submenu
    Given User navigates to Golden 1 homepage
    When User expands the Checking product menu
    And User selects Free Checking submenu item
    Then User should be redirected to Free Checking destination page
    And Destination page should load without errors

  @Navigation @Regression @P1 @TASK0020445
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given User navigates to Golden 1 homepage
    When User expands the Checking product menu
    And User selects Free Checking submenu item
    Then Destination page URL should contain "checking"

  # ============================================================
  # UI ELEMENT VERIFICATION
  # ============================================================
  @Navigation @Smoke @P1 @TASK0020445
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible in header
    Given User navigates to Golden 1 homepage
    When User observes the top header area
    Then Golden 1 logo should be visible in the header

  @Navigation @Smoke @Critical @TASK0020445
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given User navigates to Golden 1 homepage
    Then Homepage should display correctly with no broken layouts
    And There should be no missing content
    And There should be no system errors