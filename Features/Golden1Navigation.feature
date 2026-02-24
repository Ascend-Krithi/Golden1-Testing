@Regression @Navigation
Feature: Golden1 Website Navigation
  As a user of Golden 1 Credit Union website
  I want to navigate through the website
  So that I can access various banking services and information

@TestCaseId:TASK0020445_TS-001_TC-001 @Smoke
Scenario: TASK0020445 TS-001 TC-001 - Verify browser launches and homepage loads successfully
  Given I launch the browser
  When I navigate to the Golden1 homepage
  Then the homepage should load successfully
  And there should be no error messages

@TestCaseId:TASK0020445_TS-002_TC-001 @Smoke
Scenario: TASK0020445 TS-002 TC-001 - Verify global navigation menu is visible
  Given I launch the browser
  When I navigate to the Golden1 homepage
  Then the global navigation menu should be visible at the top

@TestCaseId:TASK0020445_TS-003_TC-001
Scenario: TASK0020445 TS-003 TC-001 - Verify all top menu options are present
  Given I launch the browser
  When I navigate to the Golden1 homepage
  Then the global navigation menu should be visible
  And the following top menu options should be present:
    | MenuOption         |
    | Personal           |
    | Business           |
    | Financial Wellness |
    | Appointments       |
    | Locations          |
    | Membership         |
    | Help Center        |

@TestCaseId:TASK0020445_TS-004_TC-001
Scenario: TASK0020445 TS-004 TC-001 - Verify main product category menus are accessible
  Given I launch the browser
  When I navigate to the Golden1 homepage
  Then the following main product menus should be displayed:
    | ProductMenu  |
    | Checking     |
    | Savings      |
    | Home Loans   |
    | Credit Cards |
    | Loans        |
    | Investing    |
    | Community    |
  And each product menu should be clickable

@TestCaseId:TASK0020445_TS-005_TC-001
Scenario: TASK0020445 TS-005 TC-001 - Verify submenu items are selectable
  Given I launch the browser
  When I navigate to the Golden1 homepage
  And I click on the "Checking" menu
  Then the submenu should display
  And I should be able to select "Free Checking" from the submenu

@TestCaseId:TASK0020445_TS-006_TC-001
Scenario: TASK0020445 TS-006 TC-001 - Verify navigation to destination page
  Given I launch the browser
  When I navigate to the Golden1 homepage
  And I click on the "Checking" menu
  And I select "Free Checking" from the submenu
  Then I should be redirected to the Free Checking page
  And the destination page should load without errors

@TestCaseId:TASK0020445_TS-007_TC-001
Scenario: TASK0020445 TS-007 TC-001 - Verify destination page URL contains correct identifier
  Given I launch the browser
  When I navigate to the Golden1 homepage
  And I click on the "Checking" menu
  And I select "Free Checking" from the submenu
  Then the page URL should contain "checking"

@TestCaseId:TASK0020445_TS-008_TC-001 @Smoke
Scenario: TASK0020445 TS-008 TC-001 - Verify Golden 1 logo is visible
  Given I launch the browser
  When I navigate to the Golden1 homepage
  Then the Golden 1 logo should be visible in the header

@TestCaseId:TASK0020445_TS-009_TC-001 @Smoke
Scenario: TASK0020445 TS-009 TC-001 - Verify homepage displays without layout issues
  Given I launch the browser
  When I navigate to the Golden1 homepage
  Then the homepage should display correctly
  And there should be no broken layouts
  And there should be no missing content
  And there should be no system errors