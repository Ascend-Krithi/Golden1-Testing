Feature: Golden 1 Homepage Navigation
  As a user
  I want to access the Golden 1 Credit Union website
  So that I can view the homepage and access banking services

  @Smoke @Homepage @TS-001
  Scenario: TC-2482 - Verify Golden 1 homepage loads successfully in supported browser
    Given I launch a supported browser
    When I navigate to the Golden 1 website 'https://www.golden1.com/'
    Then the browser should open successfully
    And the Golden 1 homepage should load
    And the homepage should be visible and accessible

  @Smoke @Homepage @TS-001
  Scenario: TC-2483 - Verify Golden 1 homepage accessibility across browsers
    Given I launch a supported browser
    When I navigate to the Golden 1 website 'https://www.golden1.com/'
    Then the browser should open successfully
    And the Golden 1 homepage loads without delay
    And the homepage is visible and fully loaded

  @Smoke @Homepage @TS-001
  Scenario: TC-2484 - Verify Golden 1 homepage displays without errors
    Given I launch a supported browser
    When I navigate to the Golden 1 website 'https://www.golden1.com/'
    Then the browser launches successfully
    And the Golden 1 homepage loads
    And the homepage is displayed without errors

  @Smoke @Homepage @TS-001
  Scenario: TC-2517 - Verify Golden 1 homepage loads in multiple browsers
    Given I launch a supported browser
    When I navigate to the Golden 1 website 'https://www.golden1.com/'
    Then the browser launches successfully
    And the Golden 1 homepage loads without errors

  @Smoke @Homepage @TS-001
  Scenario: TC-2518 - Verify Golden 1 homepage has no broken sections
    Given I launch a supported browser
    When I navigate to the Golden 1 website 'https://www.golden1.com/'
    And I observe the page for any loading errors or broken sections
    Then the browser is launched successfully
    And the Golden 1 homepage loads successfully
    And no errors or broken sections are displayed

  @Smoke @Homepage @TS-001
  Scenario: TC-2519 - Verify Golden 1 homepage displays expected content
    Given I launch a supported browser
    When I enter the website URL 'https://www.golden1.com/' and press Enter
    And I press Enter to load the website
    And I verify that the homepage displays expected content
    Then the browser is launched successfully
    And the URL should be entered in the address bar
    And the homepage should load without errors
    And the homepage should display all expected elements

  @Smoke @Homepage @TS-001
  Scenario: TC-2530 - Verify Golden 1 homepage loads without loading errors
    Given I launch a supported browser
    When I navigate to the Golden 1 website 'https://www.golden1.com/'
    And I verify that the homepage is displayed without any loading errors
    Then the browser launches successfully
    And the Golden 1 homepage loads successfully
    And the homepage is displayed without errors

  @Smoke @Homepage @TS-001
  Scenario: TC-2531 - Verify Golden 1 homepage full load verification
    Given I launch a supported browser
    When I navigate to the Golden 1 website 'https://www.golden1.com/'
    And I verify that the homepage is displayed without any loading errors
    Then the browser should open successfully
    And the Golden 1 homepage loads
    And the homepage is visible and fully loaded

  @Smoke @Homepage @TS-001
  Scenario: TC-2532 - Verify Golden 1 homepage displays with no error messages
    Given I launch a supported browser
    When I navigate to the Golden 1 website 'https://www.golden1.com/'
    And I observe the page load and verify that no error messages are displayed
    Then the browser should open successfully
    And the Golden 1 homepage loads successfully
    And no error messages should be displayed