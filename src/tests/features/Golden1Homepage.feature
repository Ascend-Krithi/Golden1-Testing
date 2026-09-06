Feature: Golden1 Homepage Functionality
  As a user of Golden 1 Credit Union website
  I want to verify the homepage and navigation functionality
  So that I can access all sections of the website

  @Smoke @Homepage
  Scenario: TS-001 TC-101 - Verify homepage loads with all main UI components
    Given I launch the browser and navigate to Golden1 homepage
    When the homepage loads
    Then I should see the Golden1 logo
    And I should see the top navigation menu
    And I should see Login and Open Account options
    And I should see the main banner

  @Regression @Navigation
  Scenario: TS-002 TC-102 - Verify the top navigation menu displays all main options
    Given I am on the Golden1 homepage
    When I view the top navigation menu
    Then I should see the following navigation options:
      | Personal            |
      | Business            |
      | Financial Wellness  |
      | Appointments        |
      | Locations           |
      | Help Center         |

  @Smoke @Navigation
  Scenario: TS-003 TC-103 - Verify navigation to a main menu section Personal
    Given I am on the Golden1 homepage
    When I click on the Personal tab in the top navigation menu
    Then the Personal section page should load successfully

  @Regression @Navigation
  Scenario: TS-004 TC-104 - Verify submenu navigation after selecting a main menu
    Given I am on the Golden1 homepage
    When I click on the Personal tab
    And I select Checking from the submenu
    Then the Checking page should open with correct content
    When I navigate back to homepage
    And I click on the Personal tab
    And I select Savings from the submenu
    Then the Savings page should open with correct content
    When I navigate back to homepage
    And I click on the Personal tab
    And I select Loans from the submenu
    Then the Loans page should open with correct content

  @Regression @Content
  Scenario: TS-005 TC-105 - Verify page content display for selected sections
    Given I am on the Golden1 homepage
    When I click on the Personal tab
    And I select Checking from the submenu
    Then I should see the page heading
    And I should see the section content
    And I should see product or service information

  @Smoke @UtilityActions
  Scenario: TS-006 TC-106 - Verify utility actions Log In Open Account Search
    Given I am on the Golden1 homepage
    When I click on Log In button
    Then the online banking login page should be displayed
    When I navigate back to homepage
    And I click on Open Account button
    Then the account opening page should be initiated

  @Regression @Footer
  Scenario: TS-007 TC-107 - Verify footer section is present on all pages
    Given I am on the Golden1 homepage
    When I scroll to the bottom of the page
    Then I should see the footer section
    And the footer should contain contact information
    And the footer should contain privacy policy link
    And the footer should contain terms and conditions link