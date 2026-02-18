@Golden1Navigation
Feature: Golden1 Website Navigation
  As a user
  I want to navigate the Golden1 website
  So that I can access different banking products and services

  @TASK0020445 @TS-001 @TC-001
  Scenario: TASK0020445 TS-001 TC-001 - Verify Golden1 homepage loads successfully
    Given User launches the browser
    When User navigates to Golden1 homepage
    Then Homepage should load successfully without errors

  @TASK0020445 @TS-002 @TC-001
  Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
    Given User launches the browser
    When User navigates to Golden1 homepage
    Then Global navigation menu should be visible at the top

  @TASK0020445 @TS-003 @TC-001
  Scenario: TASK0020445 TS-003 TC-001 - Verify all top menu options are present
    Given User launches the browser
    When User navigates to Golden1 homepage
    Then Navigation menu should be visible
    And All top menu options should be present
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
    Given User launches the browser
    When User navigates to Golden1 homepage
    Then Navigation menu should be visible
    And All main product category menus should be displayed
      | ProductCategory |
      | Checking        |
      | Savings         |
      | Home Loans      |
      | Credit Cards    |
      | Loans           |
      | Investing       |
      | Community       |
    And Each product category menu should be clickable

  @TASK0020445 @TS-005 @TC-001
  Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
    Given User launches the browser
    When User navigates to Golden1 homepage
    And User expands "Checking" menu
    Then Submenu items should be displayed
    And User should be able to select "Free Checking" submenu item

  @TASK0020445 @TS-006 @TC-001
  Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
    Given User launches the browser
    When User navigates to Golden1 homepage
    And User expands "Checking" menu
    And User clicks on "Free Checking" submenu item
    Then User should be redirected to destination page
    And Destination page should load without errors

  @TASK0020445 @TS-007 @TC-001
  Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains expected identifier
    Given User launches the browser
    When User navigates to Golden1 homepage
    And User expands "Checking" menu
    And User clicks on "Free Checking" submenu item
    Then Destination page URL should contain "checking"

  @TASK0020445 @TS-008 @TC-001
  Scenario: TASK0020445 TS-008 TC-001 - Verify Golden1 logo is visible in header
    Given User launches the browser
    When User navigates to Golden1 homepage
    Then Golden1 logo should be visible in the header

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays correctly without errors
    Given User launches the browser
    When User navigates to Golden1 homepage
    Then Homepage should display correctly without layout issues
    And No error messages should be displayed
    And No missing content should be present