Feature: Printing
	In order to display map
	As a sea battle game engine
	I want to print map on the screen to see happened

Scenario: Printing at the beginning
	Given I have a ships map
	And ships map is empty
	And I have a shots map
	And shots map is empty
	When I make the result map
	And I print the result map
	Then the output should be all water

Scenario: Printing after one shot
	Given I have a ships map
	And ships map is empty
	And I have a shots map
	And shots map contains one shot at random point
	When I make the result map
	And I print the result map
	Then the output should be all water except target point that should be miss 
