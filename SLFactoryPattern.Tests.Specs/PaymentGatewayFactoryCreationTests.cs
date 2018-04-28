using System;
using Rhino.Mocks;
using SLFactoryPattern.Code;
using SLFactoryPattern.Code.Enum;
using SLFactoryPattern.Code.Interfaces;
using SLFactoryPattern.Code.PaymentGateways;
using TechTalk.SpecFlow;
// ReSharper disable UnusedMember.Global

namespace SLFactoryPattern.Tests.Specs
{
    [Binding]
    public class PaymentGatewayFactoryCreationTests
    {
	    private IPaymentGatewayFactory _mockPaymentGatewayFactory;

	    private IPaymentProcessor _paymentProcessor;

        [Given(@"I have a mock Payment Gateway Factory")]
        public void GivenIHaveAMockPaymentGatewayFactory()
        {
	        _mockPaymentGatewayFactory = MockRepository.GenerateMock<IPaymentGatewayFactory>();
        }
        
        [Given(@"The mock Payment Gateway returns the PayPal Payment Gateway")]
        public void GivenTheMockPaymentGatewayReturnsThePayPalPaymentGateway()
        {
	        _mockPaymentGatewayFactory.Expect(m => m.CreatePaymentGateway(PaymentGateway.PayPal)).Return(new PayPal());
        }
        
        [Given(@"I have a Payment Processor using the mock")]
        public void GivenIHaveAPaymentProcessorUsingTheMock()
        {
	        _paymentProcessor = new PaymentProcessor(_mockPaymentGatewayFactory);
		}
        
        [When(@"I process a payment for PayPal")]
        public void WhenIProcessAPaymentForPayPal()
        {
			_paymentProcessor.ProcessPayment(PaymentGateway.PayPal);
		}
        
        [Then(@"the Payment Gateway factory should be called")]
        public void ThenThePaymentGatewayFactoryShouldBeCalled()
        {
            _mockPaymentGatewayFactory.AssertWasCalled(m => m.CreatePaymentGateway(PaymentGateway.PayPal));
        }
    }
}
