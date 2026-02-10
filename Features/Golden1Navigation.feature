Feature: Golden 1 Website Navigation
  As a user of Golden 1 website
  I want to navigate through different sections
  So that I can access banking services and information

  Background:
    Given the user opens the Golden 1 website

  Scenario: Verify homepage loads successfully
    Then the homepage should load successfully
    And the user should see the top navigation menu

  Scenario: Navigate to Personal section and view submenu
    When the user clicks on the Personal menu
    Then the Personal section page should load
    And the user should see submenu options

  Scenario: Navigate to Checking page from Personal section
    When the user clicks on the Personal menu
    And the user selects the Checking submenu
    Then the Checking page should open
    And the page should display the page heading
    And the page should display section content
    And the page should display product information

  Scenario: Verify footer section is visible
    Then the user should see the footer section
    And the footer should contain contact information

  Scenario: Access Login functionality
    When the user clicks Log In button
    Then the homepage should load successfully

  Scenario: Access Open Account functionality
    When the user clicks Open Account button
    Then the homepage should load successfully