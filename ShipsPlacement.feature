Feature: Ships Placement
	In order to place ships
	As a sea battle game engine
	I want to create all ships and put them on map

Scenario: 
	Given I have a sea battle map
	And the map is empty
	When I put a ship at origin
	Then map should contains one ship at origin
