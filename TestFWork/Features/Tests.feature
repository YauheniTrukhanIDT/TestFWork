Feature: Test
	My first test project on specflow

@dropdown
Scenario: Dropdown list unread letters
	Given I click on dropdown list
	When I click on unread letters
	Then I successfully receive a list of unread letters

@flages
Scenario: Mark flages letters
	Given I flag letters
	Then I see letters a flagged

@search
Scenario: Search letters
	Given I click on the search input
	When I enter addressee
	And I press the search button
	Then I see successfully addressee letters

@spam
Scenario: Send letter in spam
	Given I take the number letter
	When I take the subject of the letter
	And I move the the letter to spam
	And I get a confirmation letter
	When I go to the spam window
	Then I see a successfully moved letter

@message
Scenario: Write message
	Given I open writing window
	When I write addressee
	And I write subject
	And I write message
	When I click to on send letter button
	Then I see a message sending a letter successfully
