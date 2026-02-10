Feature: Homepage Navigation
  As a user
  I want to access the Golden 1 Credit Union website
  So that I can view the homepage

  @Smoke @Regression
  Scenario: TS-001 TC-001 - Verify Golden 1 homepage loads successfully
    Given I launch a supported browser
    When I navigate to the Golden 1 website
    Then the Golden 1 homepage should load successfully
    And the homepage should display without any errors