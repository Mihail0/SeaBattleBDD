Feature: Firing
	In order to destroy all ships
	As a sea battle game engine
	I want to break every ship on map

Scenario: Firing at origin of empty map
	Given I have a map of shots
	And the map of shots is empty
	When I'm shooting at origin
	Then map of shots should contains one shot at origin

Scenario: Firing at random point of empty map
	Given I have a map of shots
	And the map of shots is empty
	And I have a random point
	When I'm shooting at random point
	Then map of shots should contains one shot at target point

Scenario: Firing and destroying
	Given I have a map of shots
	And the map of shots is empty
	And I have a ships map
	And I have a random point
	And ships map contains single ship at the random point
	When I'm shooting at the random point via new function
	Then map of shots should contains explosion around the target
