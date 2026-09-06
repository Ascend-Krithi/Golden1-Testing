@Navigation @Regression
Feature: Golden1 Website Navigation
  As a user of the Golden1 website
  I want to navigate through different sections
  So that I can access various banking services

  Background:
    Given I am on the Golden1 homepage

  @Smoke
  Scenario: Verify main navigation menu is displayed
    When I view the homepage
    Then the navigation menu should be displayed
    And the top tabs should be visible

  @Smoke
  Scenario: Navigate to Personal tab
    When I click on the Personal tab
    Then I should see the main menu options

  Scenario: Navigate to Business tab
    When I click on the Business tab
    Then the top tabs should be visible

  Scenario: Navigate to Financial Wellness tab
    When I click on the Financial Wellness tab
    Then the navigation menu should be displayed

  Scenario: Navigate to Checking from Personal
    When I click on the Personal tab
    And I click on the Checking menu
    Then the URL should contain "checking"

  Scenario: Navigate to Free Checking page
    When I click on the Personal tab
    And I click on the Checking menu
    And I click on Free Checking link
    Then the URL should contain "checking"

  Scenario: Navigate to Savings from Personal
    When I click on the Personal tab
    And I click on the Savings menu
    Then the URL should contain "savings"

  Scenario: Navigate to Savings Account page
    When I navigate to Savings Account page
    Then the URL should contain "savings"

  Scenario: Navigate to Loans section
    When I click on the Personal tab
    And I click on the Loans menu
    Then the navigation menu should be displayed

  Scenario: Navigate to Auto Loans page
    When I navigate to Auto Loans page
    Then the URL should contain "loan"

  Scenario: Navigate to Home Loans
    When I click on the Personal tab
    And I click on the Home Loans menu
    Then the URL should contain "loan"

  Scenario: Navigate to Credit Cards
    When I click on the Personal tab
    And I click on the Credit Cards menu
    Then the URL should contain "credit"

  Scenario: Navigate to Investing
    When I click on the Personal tab
    And I click on the Investing menu
    Then the navigation menu should be displayed

  Scenario: Navigate to Community
    When I click on the Personal tab
    And I click on the Community menu
    Then the navigation menu should be displayed

  Scenario: Navigate to Appointments tab
    When I click on the Appointments tab
    Then the URL should contain "appointment"

  Scenario: Navigate to Locations tab
    When I click on the Locations tab
    Then the URL should contain "location"

  Scenario: Navigate to Membership tab
    When I click on the Membership tab
    Then the navigation menu should be displayed

  Scenario: Navigate to Help Center tab
    When I click on the Help Center tab
    Then the URL should contain "help"