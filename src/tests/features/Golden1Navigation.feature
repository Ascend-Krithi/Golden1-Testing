Feature: Golden1 Website Navigation
  As a user
  I want to navigate through the Golden1 website
  So that I can access different banking services

  @SCTASK0010001 @TS-001 @TC-001 @AC-1
  Scenario: TC-001 - Verify Golden1 homepage loads successfully
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And no error messages or loading issues should be present

  @SCTASK0010001 @TS-002 @TC-001 @AC-2
  Scenario: TC-001 - Verify global navigation menu is visible on homepage
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And the global navigation menu should be visible at the top of the homepage

  @SCTASK0010001 @TS-003 @TC-001 @AC-3
  Scenario: TC-001 - Verify all navigation options are present in global menu
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And the global navigation menu should be visible
    And the following navigation options should be present:
      | NavigationOption   |
      | Personal           |
      | Business           |
      | Financial Wellness |
      | Appointments       |
      | Locations          |
      | Membership         |
      | Help Center        |

  @SCTASK0010001 @TS-004 @TC-001 @AC-4
  Scenario: TC-001 - Verify main product menus display on hover
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    When I hover over the "Personal" navigation option
    Then the main product menus should be displayed
    And the following product menus should be visible:
      | ProductMenu  |
      | Checking     |
      | Savings      |
      | Home Loans   |
      | Credit Cards |
      | Loans        |
      | Investing    |
      | Community    |

  @SCTASK0010001 @TS-005 @TC-001 @AC-5
  Scenario: TC-001 - Verify submenu items are selectable
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    When I hover over the "Personal" navigation option
    Then the main product menus should be displayed
    When I hover over the "Checking" product menu
    Then the submenu items under "Checking" should be displayed
    And all submenu items should be clickable

  @SCTASK0010001 @TS-006 @TC-001 @AC-6
  Scenario: TC-001 - Verify navigation to Checking page
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    When I hover over the "Personal" navigation option
    And I click on the "Checking" submenu item
    Then I should be redirected to the Checking page
    And the Checking page should load completely without errors

  @SCTASK0010001 @TS-007 @TC-001 @AC-7
  Scenario Outline: TC-001 - Verify navigation to all mapped submenu pages
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    When I navigate to "<SubmenuItem>" from "<MainMenu>"
    Then I should be redirected to the "<DestinationPage>"
    And the destination URL should contain "<URLIdentifier>"

    Examples:
      | MainMenu | SubmenuItem      | DestinationPage        | URLIdentifier    |
      | Personal | Checking         | Checking Page          | checking         |
      | Personal | Savings          | Savings Page           | savings          |
      | Personal | Home Loans       | Home Loans Page        | home-loans       |
      | Personal | Credit Cards     | Credit Cards Page      | credit-cards     |
      | Personal | Loans            | Loans Page             | loans            |
      | Personal | Investing        | Investing Page         | investing        |
      | Personal | Community        | Community Page         | community        |
      | Business | Business Checking| Business Checking Page | business-checking|
      | Business | Business Savings | Business Savings Page  | business-savings |

  @SCTASK0010001 @TS-008 @TC-001 @AC-8
  Scenario: TC-001 - Verify Golden1 logo is visible in header
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And the Golden1 logo should be visible in the top header area

  @SCTASK0010001 @TS-009 @TC-001 @AC-9
  Scenario: TC-001 - Verify homepage displays without visual defects
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And no broken layouts should be present
    And no missing images should be present
    And no misplaced elements should be present
    And no error messages should be displayed