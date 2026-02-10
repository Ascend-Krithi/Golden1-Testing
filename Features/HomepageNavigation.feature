Feature: Golden1 Homepage Navigation
  As a user
  I want to access the Golden1 website
  So that I can view the homepage

  @TS-001 @Smoke
  Scenario: TC-2482 - Verify Golden1 homepage loads successfully in Chrome
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then the homepage should be displayed without errors
    And the homepage should be fully loaded

  @TS-001 @Smoke
  Scenario: TC-2483 - Verify Golden1 homepage loads in multiple browsers
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then the homepage should load without delay
    And the homepage should be visible and fully loaded

  @TS-001 @Smoke
  Scenario: TC-2484 - Verify Golden1 homepage displays without errors
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then the homepage should be displayed without errors

  @TS-001 @Smoke
  Scenario: TC-2517 - Verify Golden1 homepage loads in supported browsers
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then the homepage should load without errors

  @TS-001 @Smoke
  Scenario: TC-2518 - Verify Golden1 homepage loads with no broken sections
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then no errors or broken sections should be displayed

  @TS-001 @Smoke
  Scenario: TC-2519 - Verify Golden1 homepage displays all expected elements
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then the homepage should load without errors
    And the homepage should display all expected elements

  @TS-001 @Smoke
  Scenario: TC-2530 - Verify Golden1 homepage loads without loading errors
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then the homepage should be displayed without errors

  @TS-001 @Smoke
  Scenario: TC-2531 - Verify Golden1 homepage is visible and fully loaded
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then the homepage should be visible and fully loaded

  @TS-001 @Smoke
  Scenario: TC-2532 - Verify no error messages on Golden1 homepage
    Given I launch the browser
    When I navigate to the Golden1 homepage
    Then no error messages should be displayed
    And the homepage should be visible