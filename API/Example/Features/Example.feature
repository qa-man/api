Feature: Example

@001
@Example
@Priotiy_1
Scenario: Test example
	Given User sends Get request with "/example" suffix
	Then The response code should be equal '200'
	And The response should contain the following values
		| name | value |
		| NAME |  ONE  |
		| NAME |  TWO  |