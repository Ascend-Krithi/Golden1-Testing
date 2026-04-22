Feature: Golden1 Website Navigation
  As a user of Golden1 website
  I want to navigate through different sections
  So that I can access banking services

  @TS-001 @TC-001
  Scenario: TS-001 TC-001 - Verify Golden1 homepage loads successfully
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And no error messages or loading issues should be present

  @TS-002 @TC-001
  Scenario: TS-002 TC-001 - Verify global navigation menu is visible
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And the global navigation menu should be visible at the top

  @TS-003 @TC-001
  Scenario: TS-003 TC-001 - Verify all navigation options are present
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And the global navigation menu should be visible
    And all navigation options should be present
      | NavigationOption  |
      | Personal          |
      | Business          |
      | Financial Wellness|
      | Appointments      |
      | Locations         |
      | Membership        |
      | Help Center       |

  @TS-004 @TC-001
  Scenario: TS-004 TC-001 - Verify main product menus display on hover
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    When I hover over each top navigation option
    Then the main product menus should be displayed on hover

  @TS-005 @TC-001
  Scenario: TS-005 TC-001 - Verify submenu items are selectable
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    When I hover over each main product menu
    Then submenu items should be displayed
    And each submenu item should be clickable

  @TS-006 @TC-001
  Scenario: TS-006 TC-001 - Verify navigation to Checking page
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    When I hover over the "Personal" menu
    And I click on the "Checking" submenu item
    Then I should be redirected to the Checking page
    And the Checking page should load completely without errors

  @TS-007 @TC-001
  Scenario: TS-007 TC-001 - Verify all mapped submenu links redirect correctly
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    When I navigate through all mapped submenu links
    Then each submenu link should redirect to the correct destination page
    And the destination URL should contain the expected identifier

  @TS-008 @TC-001
  Scenario: TS-008 TC-001 - Verify Golden1 logo is visible
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And the Golden1 logo should be visible in the top header area

  @TS-009 @TC-001
  Scenario: TS-009 TC-001 - Verify homepage has no visual defects
    Given I launch the Golden1 website
    Then the Golden1 homepage should load successfully
    And no broken layouts should be present
    And no missing images should be present
    And no misplaced elements should be present
    And no error messages should be displayed