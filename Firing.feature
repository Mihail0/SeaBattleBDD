Feature: Firing
	In order to destroy all ships
	As a sea battle game engine
	I want to break every ship on map

Scenario: Firing at origin of empty map
	Given I have a map of shots
	And the map of shots is empty
	When I'm shooting at origin
	Then map of shots should contains one shot at origin
