Feature: ProcessPayment
	In order to take payments
	As an online eCommerce website
	I want to be able to process payments from multiple gateways

Scenario: When a payment is made using WorldPay
	Given I have a Payment Processor
	When I process a payment using WorldPay
	Then the WorldPay Payment Gateway should be used