Feature: Golden1 Website Navigation and Menu Functionality
  As a user of Golden1 website
  I want to navigate through the website and access product menus
  So that I can find information about banking products and services

  @SCTASK0010001 @TS-001 @TC-001 @AC-1
  Scenario: TC-001 - Verify Golden1 homepage loads successfully
    Given I launch the web browser
    When I navigate to the Golden1 homepage
    Then the homepage should load completely without errors
    And no error messages or loading issues should be present

  @SCTASK0010001 @TS-002 @TC-001 @AC-2
  Scenario: TC-001 - Verify global navigation menu is visible on homepage
    Given I launch the web browser
    When I navigate to the Golden1 homepage
    Then the global navigation menu should be visible at the top of the page

  @SCTASK0010001 @TS-003 @TC-001 @AC-3
  Scenario: TC-001 - Verify all top navigation options are present
    Given I launch the web browser
    When I navigate to the Golden1 homepage
    And I locate the global navigation menu
    Then the following navigation options should be visible:
      | NavigationOption   |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @SCTASK0010001 @TS-004 @TC-001 @AC-4
  Scenario: TC-001 - Verify submenus display on hover for product menus
    Given I launch the web browser
    When I navigate to the Golden1 homepage
    Then hovering over each main product menu should display corresponding submenu:
      | ProductMenu  |
      | Checking     |
      | Savings      |
      | Home Loans   |
      | Credit Cards |
      | Loans        |
      | Investing    |
      | Community    |

  @SCTASK0010001 @TS-005 @TC-001 @AC-5
  Scenario: TC-001 - Verify submenu items are clickable
    Given I launch the web browser
    When I navigate to the Golden1 homepage
    And I hover over each main product menu to display submenu
    Then each submenu item should be selectable and clickable

  @SCTASK0010001 @TS-006 @TC-001 @AC-6
  Scenario: TC-001 - Verify submenu items navigate to correct destination pages
    Given I launch the web browser
    When I navigate to the Golden1 homepage
    And I hover over each main product menu to display submenu
    And I click on each submenu item
    Then I should be redirected to the expected destination page
    And the destination page should load completely without errors

  @SCTASK0010001 @TS-007 @TC-001 @AC-7
  Scenario: TC-001 - Verify destination page URLs contain correct identifiers
    Given I launch the web browser
    When I navigate to the Golden1 homepage
    And I hover over each main product menu to display submenu
    And I click on each submenu item to navigate to destination page
    Then each URL should contain the correct identifier as per mapping

  @SCTASK0010001 @TS-008 @TC-001 @AC-8
  Scenario: TC-001 - Verify Golden1 logo is visible in header
    Given I launch the web browser
    When I navigate to the Golden1 homepage
    Then the Golden1 logo should be visible in the top header area

  @SCTASK0010001 @TS-009 @TC-001 @AC-9
  Scenario: TC-001 - Verify homepage layout displays without errors
    Given I launch the web browser
    When I navigate to the Golden1 homepage
    And I wait for the homepage to load fully
    Then no broken layouts or error messages should be present on the homepage