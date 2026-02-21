@Homepage @Smoke
Feature: Homepage Verification
  As a user
  I want to verify the homepage loads correctly
  So that I can ensure the website is accessible and functional

  @TASK0020445 @TS-009 @TC-001
  Scenario: TASK0020445 TS-009 TC-001 - Verify that the homepage loads completely without broken layouts, missing content, or system error messages
    Given User launches the Golden 1 homepage
    Then User should see the homepage loaded successfully
    And User should verify no broken layouts or error messages are displayed