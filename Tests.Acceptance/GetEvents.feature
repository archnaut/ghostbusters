Feature: GetEvents
	In order to browse upcoming events
	As api consumer 
	I want to be given available events

@mytag
Scenario: Get Upcoming Event
	Given the following event(s) exist
	| ID | Name                 | On Sale Date | Doors Open Date          | Event Start Date         | Event End Date           |
	| 1  | Annual Charity Event | 30 days ago  | 4 days 13 hours from now | 5 days 14 hours from now | 5 days 17 hours from now |          
	When I make a call to "http://localhost:53735/api/Events"
	Then the response status code is 200
	And the content type is "application/json" and charset "utf-8"
	And the response contains the event

Scenario: No Current Events
	Given the following event(s) exist
	| Name               | On Sale Date | Doors Open Date | Event Start Date | Event End Date      |
	| Past Charity Event | 60 days ago  | 26 days ago     | 24 days ago      | 23 days 21 hour ago |
	When I make a call to "http://localhost:53735/api/Events"
	Then the response status code is 200
	And the content type is "application/json" and charset "utf-8"
	And the response should not contain any events