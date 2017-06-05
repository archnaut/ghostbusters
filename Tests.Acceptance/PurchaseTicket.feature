Feature: PurchaseTicket
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Purchase Single Ticket for Current Event 
	Given the following event(s) exist
         | ID | Name          | On Sale Date | Doors Open Date          | Event Start Date         | Event End Date           |
         | 1  | Current Event | 30 days ago  | 4 days 13 hours from now | 5 days 14 hours from now | 5 days 17 hours from now |
	And the following tickets are available
         | Event ID | Name              | Price | Quantity Available |
         | 1        | General Admission | 10    | 500                |
         | 1        | VIP               | 30    | 100                |
	When I submit the following order to "http://localhost:53735/api/Orders"
		| Field              | Value               |
		| Event ID           | 1                   |
		| First Name         | Billy-Ray           |
		| Last Name          | Cowfarmer           |
		| Credit Card Number | 0000-0000-0000-0000 |
		| Security Code      | 000                 |
		| Expiration Month   | 01                  |
		| Expiration Year    | 2018                |
	And the order includes the following line items 
		| Ticket ID | Quantity |
		| 1         | 1        |
	Then I should receive the following receipt
		| Field         | Value     |
		| Order ID      | 1         |
		| First Name    | Billy-Ray |
		| Last Name     | Cowfarmer |
		| Purchase Date | Today     |
		| Amount Paid   | 10.975     |
	And receipt includes the following line items
		| Ticket ID | Name              | Barcode | Ticket Amout Paid | Sales Tax Paid |
		| 1         | General Admission | 1       | 10                | 0.975          |
	And the quantity available of ticket with ID 1 should be 499

@mytag
Scenario: Past Event
	Given the following event(s) exist
         | ID | Name       | On Sale Date | Doors Open Date     | Event Start Date    | Event End Date      |
         | 1  | Past Event | 30 days ago  | 5 days 17 hours ago | 5 days 14 hours ago | 4 days 13 hours ago |
	And the following tickets are available
         | Event ID | Name              | Price | Quantity Available |
         | 1        | General Admission | 10    | 500                |
         | 1        | VIP               | 30    | 100                |
	When I submit the following order to "http://localhost:53735/api/Orders"
		| Field              | Value               |
		| Event ID           | 1                   |
		| First Name         | Billy-Ray           |
		| Last Name          | Cowfarmer           |
		| Credit Card Number | 0000-0000-0000-0000 |
		| Security Code      | 000                 |
		| Expiration Month   | 01                  |
		| Expiration Year    | 2018                |
	And the order includes the following line items 
		| Ticket ID | Quantity |
		| 1         | 1        |
	Then the response status code is 400
	And I should receive the message "Event Passed: Cannot purchase tickets for events that have already passed."

@mytag
Scenario: Sold Out Event
	Given the following event(s) exist
         | ID | Name           | On Sale Date | Doors Open Date     | Event Start Date    | Event End Date      |
         | 1  | Current Event | 30 days ago  | 4 days 13 hours from now | 5 days 14 hours from now | 5 days 17 hours from now |
	And the following tickets are available
         | Event ID | Name              | Price | Quantity Available |
         | 1        | General Admission | 10    | 0                  |
         | 1        | VIP               | 30    | 100                |
	When I submit the following order to "http://localhost:53735/api/Orders"
		| Field              | Value               |
		| Event ID           | 1                   |
		| First Name         | Billy-Ray           |
		| Last Name          | Cowfarmer           |
		| Credit Card Number | 0000-0000-0000-0000 |
		| Security Code      | 000                 |
		| Expiration Month   | 01                  |
		| Expiration Year    | 2018                |
	And the order includes the following line items 
		| Ticket ID | Quantity |
		| 1         | 1        |
	Then the response status code is 400
	And I should receive the message "Sold Out: Insufficient tickets available to satisfy your request."
	
