Feature: Golden1 Homepage Navigation
  As a user
  I want to access the Golden 1 Credit Union website
  So that I can view the homepage successfully

  @Smoke @Regression
  Scenario: TC-001 - Verify Golden 1 homepage loads successfully in Chrome
    Given I launch the Chrome browser
    When I navigate to the Golden 1 homepage
    Then the homepage should be displayed without errors
    And the page title should contain "Golden 1"

  @CrossBrowser
  Scenario Outline: TC-001 - Verify Golden 1 homepage loads in multiple browsers
    Given I launch the "<Browser>" browser
    When I navigate to the Golden 1 homepage
    Then the homepage should be displayed without errors
    And no error messages should be visible

    Examples:
      | Browser |
      | Chrome  |
      | Firefox |
      | Edge    |