Feature: GoogleModel

@Google
Scenario:  GoogleModel
	Given Google URL
	When Search <search>
	And Navigate 
	Then Verify

	Examples:
  | search |
  | lala   |
  | ura    |
