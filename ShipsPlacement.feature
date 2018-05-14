Feature: Ships Placement
	In order to place ships
	As a sea battle game engine
	I want to create all ships and put them on map

Scenario: Ship creation at origin
	Given I have a sea battle map
	And the map is empty
	When I put a ship at origin
	Then map should contains one ship at origin

Scenario: Ship creation at random point
	Given I have a sea battle map
	And the map is empty
	When I put a ship at random point
	Then map should contains one ship at random point

Scenario: Big ship creation at random point
	Given I have a sea battle map
	And the map is empty
	When I put a big ship at random point
	Then map should contains one big ship at random point
