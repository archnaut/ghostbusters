Feature: GetEvents
	In order to browse upcoming events
	As api consumer 
	I want to be given available events

@mytag
Scenario: Get Upcoming Event
	Given upcoming event
	| ID | Name                 | On Sale Date | Doors Open Date          | Event Start Date         | Event End Date           |
	| 1  | Annual Charity Event | 30 days ago  | 4 days 13 hours from now | 5 days 14 hours from now | 5 days 17 hours from now |
	When I make a  call to
	| Port  | Method | Path       |
	| 53735 | GET    | api/Events |
	Then the response status code is 200
	And the response body contains the event
