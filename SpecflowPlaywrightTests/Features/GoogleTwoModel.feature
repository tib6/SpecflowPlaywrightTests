Feature: GoogleTwoModel

@GoogleTwo
Scenario:  GoogleTwoModel
	Given Enter the google URL Google Two
	When Google Search <searchTwo> and <var>
	And Navigate Google Two
	Then Verify Google Two

	Examples:
  | searchTwo       | var       |
  | google search   | add var 2 |
  | fish            | add var 3 |