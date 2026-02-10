@TASK0020445 @TS-001 @Regression
Feature: Golden 1 Homepage Navigation
  As a user
  I want to access the Golden 1 Credit Union website
  So that I can view the homepage successfully

  Background:
    Given I launch a supported browser

  @TC-001 @Smoke
  Scenario: Verify Golden 1 homepage loads successfully in Chrome
    When I enter the URL "https://www.golden1.com/" in the address bar and press Enter
    Then Golden 1 homepage loads successfully
    And Homepage is visible and fully loaded

  @TC-002 @Smoke
  Scenario: Verify Golden 1 homepage loads without errors
    When I enter the URL "https://www.golden1.com/" in the address bar and press Enter
    Then Homepage loads successfully
    When I observe the homepage for any error messages or broken sections
    Then No error messages or broken sections are displayed

  @TC-003 @Smoke
  Scenario: Verify browser launches and navigates to Golden 1 homepage
    Then Browser opens successfully
    When I enter the website URL "https://www.golden1.com/" in the address bar and press Enter
    Then Golden 1 homepage loads

  @TC-004 @Smoke
  Scenario: Verify Golden 1 homepage displays without loading errors
    When I enter the URL "https://www.golden1.com/" in the address bar and press Enter
    Then Golden 1 homepage loads
    When I observe the homepage for successful loading
    Then Homepage is displayed without errors

  @TC-005 @Smoke
  Scenario: Verify Golden 1 homepage loads completely
    When I enter the website URL "https://www.golden1.com/" in the address bar and press Enter
    Then Golden 1 homepage begins to load
    When I wait for the homepage to fully load
    Then Homepage is displayed without loading errors