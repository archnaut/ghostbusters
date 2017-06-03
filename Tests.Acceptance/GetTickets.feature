Feature: GetTickets
	In order to see tickets for an events
	As api consumer 
	I want to be retrieve tickets by event ID

@Ticket
Scenario: Current event with tickets
	Given the following event(s) exist
	| ID | Name                 | On Sale Date | Doors Open Date          | Event Start Date         | Event End Date           |
	| 1  | Annual Charity Event | 30 days ago  | 4 days 13 hours from now | 5 days 14 hours from now | 5 days 17 hours from now |          
	And the following tickets are available 
	| Event ID | Name                | Price | Quantity Available |
	| 1        | General Adminission | 10.00 | 500                |
	| 1        | VIP                 | 30.00 | 100                |
	When I make a call to "http://localhost:53735/api/Tickets/1" 
	Then the response status code is 200
	And the content type is "application/json" and charset "utf-8"
	And the response should include the following tickets
	| ID | Name                | Price |
	| 1  | General Adminission | 10.00 |
	| 2  | VIP                 | 30.00 |
