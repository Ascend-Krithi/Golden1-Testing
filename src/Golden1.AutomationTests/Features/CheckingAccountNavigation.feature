Feature: Checking Account Navigation
  As a Golden1 customer
  I want to navigate to checking account pages
  So that I can view checking account information

  @Smoke @Navigation
  Scenario: Navigate to Checking page from homepage
    Given I navigate to the Golden1 homepage
    When I click on the Checking menu
    Then I should see the Checking page
    And I should see the Free Checking link

  @Regression @Navigation
  Scenario: Navigate to Free Checking page
    Given I navigate to the Golden1 homepage
    When I click on the Checking menu
    And I click on the Free Checking link
    Then I should see the Free Checking page details