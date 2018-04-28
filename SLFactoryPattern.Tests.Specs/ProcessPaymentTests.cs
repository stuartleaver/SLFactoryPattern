using Microsoft.VisualStudio.TestTools.UnitTesting;
using SLFactoryPattern.Code;
using SLFactoryPattern.Code.Enum;
using TechTalk.SpecFlow;
// ReSharper disable UnusedMember.Global

namespace SLFactoryPattern.Tests.Specs
{
    [Binding]
    public class ProcessPaymentTests
    {
	    private PaymentProcessor _paymentProcessor;

        [Given(@"I have a Payment Processor")]
        public void GivenIHaveAPaymentProcessor()
        {
			_paymentProcessor = new PaymentProcessor(new PaymentGatewayFactory());
		}
        
        [When(@"I process a payment using WorldPay")]
        public void WhenIProcessAPaymentUsingWorldPay()
        {
			_paymentProcessor.ProcessPayment(PaymentGateway.WorldPay);
		}
        
        [Then(@"the WorldPay Payment Gateway should be used")]
        public void ThenTheWorldPayPaymentGatewayShouldBeUsed()
        {
			Assert.AreEqual("WorldPay", _paymentProcessor.PaymentGatewayName());
		}
    }
}
