Feature: Golden1 Global Navigation Validation
  As a user of the Golden1 website
  I want to validate the navigation menu functionality
  So that I can access different sections of the website easily

Background:
  Given User is on Golden1 homepage

@Navigation @Smoke @Critical
Scenario: TC_NAV_000 - Verify global navigation is visible
  Then Navigation should be visible
  And The following menu options should be present in top navigation:
    | Menu                 |
    | Personal             |
    | Business             |
    | Financial Wellness   |
    | Appointments         |
    | Locations            |
    | Membership           |
    | Help Center          |

@Navigation @Regression @P1
Scenario Outline: <TC_ID> - Validate navigation link functionality
  When User navigates to "<SubMenu>" under "<MainMenu>"
  Then User should be on "<UrlPart>" page

  Examples: Checking Accounts
    | TC_ID      | MainMenu     | SubMenu                     | UrlPart                         |
    | TC_NAV_001 | Checking     | Free Checking               | free-checking-account           |
    | TC_NAV_002 | Checking     | Easy Checking               | easy-checking-account           |
    | TC_NAV_009 | Checking     | MarketRate Checking         | marketrate-checking-account     |



  Examples: Savings Accounts
    | TC_ID      | MainMenu     | SubMenu                     | UrlPart                         |
    | TC_NAV_003 | Savings      | Money Market                | money-market-savings-account    |
  
  Examples: Home Loans
    | TC_ID      | MainMenu     | SubMenu                     | UrlPart                         |
    | TC_NAV_004 | Home Loans   | Buy a Home                  | home-loans/purchase             |

  Examples: Credit Cards
    | TC_ID      | MainMenu     | SubMenu                     | UrlPart                         |
    | TC_NAV_005 | Credit Cards | Member Cash Rewards+ Card   | member-cash-rewards-plus        |

  Examples: Loans
    | TC_ID      | MainMenu     | SubMenu                     | UrlPart                         |
    | TC_NAV_006 | Loans        | Personal Loans              | personal-loans                  |

  Examples: Investing
    | TC_ID      | MainMenu     | SubMenu                     | UrlPart                         |
    | TC_NAV_007 | Investing    | Make an Investment Plan     | investment-services             |

  Examples: Community
    | TC_ID      | MainMenu     | SubMenu                     | UrlPart                         |
    | TC_NAV_008 | Community    | Community Commitment        | our-commitment                  |

@Navigation @Regression @P2
Scenario: TC_NAV_010 - Verify main menu items are displayed
  Then The main menu should display the following items:
    | Main Menu    |
    | Checking     |
    | Savings      |
    | Home Loans   |
    | Credit Cards |
    | Loans        |
    | Investing    |
    | Community    |
