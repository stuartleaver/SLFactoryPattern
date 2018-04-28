Feature: PaymentGatewayFactoryCreation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: When a payment is made using PayPay
	Given I have a mock Payment Gateway Factory
	And The mock Payment Gateway returns the PayPal Payment Gateway
	And I have a Payment Processor using the mock
	When I process a payment for PayPal
	Then the Payment Gateway factory should be called
