Feature: Golden 1 Homepage Navigation
  As a user
  I want to navigate to Golden 1 Credit Union website
  So that I can access the homepage successfully

  @TS-001 @TC-2482
  Scenario: TC-2482 - Verify Golden 1 homepage loads successfully in Chrome
    Given I launch a supported browser
    When I enter the website URL 'https://www.golden1.com/' in the address bar and press Enter
    And I observe if the homepage is displayed without delay
    Then Browser opens successfully
    And Golden 1 homepage loads
    And Homepage is visible and accessible

  @TS-001 @TC-2483
  Scenario: TC-2483 - Verify Golden 1 homepage loads in compatible browsers
    Given I launch a compatible browser
    When I enter the website URL 'https://www.golden1.com/' in the address bar and press Enter
    And I verify that the homepage is displayed without any errors
    Then Browser opens successfully
    And Golden 1 homepage loads without delay
    And Homepage is visible and fully loaded

  @TS-001 @TC-2484
  Scenario: TC-2484 - Verify Golden 1 homepage loads without errors
    Given I launch a supported browser
    When I enter the website URL 'https://www.golden1.com/' in the address bar and press Enter
    And I observe the page for successful loading without errors
    Then Browser launches successfully
    And Golden 1 homepage loads
    And Homepage is displayed without errors

  @TS-001 @TC-2517
  Scenario: TC-2517 - Verify Golden 1 homepage basic load
    Given I launch a supported browser
    When I enter the website URL 'https://www.golden1.com/' in the address bar and press Enter
    Then Browser launches successfully
    And Golden 1 homepage loads without errors

  @TS-001 @TC-2518
  Scenario: TC-2518 - Verify Golden 1 homepage loads without broken sections
    Given I launch a supported browser
    When I enter the website URL 'https://www.golden1.com/' in the address bar and press Enter
    And I observe the page for any loading errors or broken sections
    Then Browser is launched successfully
    And Golden 1 homepage loads successfully
    And No errors or broken sections are displayed

  @TS-001 @TC-2519
  Scenario: TC-2519 - Verify Golden 1 homepage with element validation
    Given I launch a supported web browser
    When I enter the website URL https://www.golden1.com/ in the address bar
    And I press Enter to load the website
    And I verify that the homepage displays expected content (header, navigation menu, logo, etc.)
    Then Browser is launched successfully
    And URL is entered in the address bar
    And Homepage loads without errors
    And Homepage is displayed with all expected elements

  @TS-001 @TC-2530
  Scenario: TC-2530 - Verify Golden 1 homepage loads successfully without loading errors
    Given I launch a supported browser
    When I enter the URL https://www.golden1.com/ in the address bar and press Enter
    And I verify that the homepage is displayed without any loading errors
    Then Browser launches successfully
    And Golden 1 homepage loads successfully
    And Homepage is displayed without errors

  @TS-001 @TC-2531
  Scenario: TC-2531 - Verify Golden 1 homepage visibility and full load
    Given I launch a supported browser
    When I enter the website URL 'https://www.golden1.com/' in the address bar and press Enter
    And I verify that the homepage is displayed without any loading errors
    Then Browser opens successfully
    And Golden 1 homepage loads
    And Homepage is visible and fully loaded

  @TS-001 @TC-2532
  Scenario: TC-2532 - Verify Golden 1 homepage with no error messages
    Given I launch a supported browser
    When I enter the website URL 'https://www.golden1.com/' in the address bar and press Enter
    And I observe the page load and verify that no error messages are displayed
    Then Browser opens successfully
    And Golden 1 homepage loads successfully
    And No error messages are displayed; homepage is visible

  @TS-001 @TC-2560
  Scenario: TC-2560 - Verify Golden 1 homepage in Chrome browser
    Given I launch a supported browser
    When I enter https://www.golden1.com/ in the address bar and press Enter
    And I verify that the homepage is displayed without errors
    Then Browser opens successfully
    And Golden 1 homepage loads
    And Homepage is visible and accessible

  @TS-001 @TC-2561
  Scenario: TC-2561 - Verify Golden 1 homepage loads without delays
    Given I launch a supported browser
    When I enter the website URL 'https://www.golden1.com/' in the address bar and press Enter
    And I observe the page load process
    Then Browser launches successfully
    And Golden 1 homepage loads
    And Homepage is displayed without delays or loading errors

  @TS-001 @TC-2566
  Scenario: TC-2566 - Verify Golden 1 homepage in Chrome with no broken sections
    Given I launch a supported web browser
    When I enter the website URL https://www.golden1.com/ in the address bar and press Enter
    And I observe the page loading process
    Then Browser opens successfully
    And Golden 1 homepage loads successfully
    And No errors or broken sections are displayed