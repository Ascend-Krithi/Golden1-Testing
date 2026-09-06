@HomePage @Regression
Feature: Golden1 Homepage Verification
  As a user visiting the Golden1 website
  I want to see all homepage elements
  So that I can access banking services and information

  @Smoke
  Scenario: Verify homepage loads successfully
    Given I navigate to the Golden1 website
    Then the Golden1 logo should be displayed
    And the navigation menu should be displayed

  @Smoke
  Scenario: Verify homepage main elements
    Given the homepage is loaded
    Then the Golden1 logo should be displayed
    And the Login button should be visible
    And the Open Account button should be visible
    And the navigation menu should be displayed

  Scenario: Verify hero banner is displayed
    Given the homepage is loaded
    Then the hero banner should be displayed

  Scenario: Verify all homepage elements are visible
    Given the homepage is loaded
    Then all homepage elements should be visible
    And the top tabs should be visible

  Scenario: Click on Login button
    Given the homepage is loaded
    When I click on the Login button
    Then the URL should contain "login"

  Scenario: Click on Open Account button
    Given the homepage is loaded
    When I click on the Open Account button
    Then the URL should contain "open"