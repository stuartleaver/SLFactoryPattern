using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SLFactoryPattern.Code;
using SLFactoryPattern.Code.Enum;
using SLFactoryPattern.Code.Interfaces;
using SLFactoryPattern.Code.PaymentGateways;

namespace SLFactoryPattern.Tests.MSTest
{
	[TestClass]
	public class PaymentGatewayFactoryTests
	{
		[TestMethod]
		public void WhenAPaymentIsMadeUsingWorldpay_CorrectPaymentGatewayIsCreated()
		{
			// Arrange
			var paymentProcessor = new PaymentProcessor(new PaymentGatewayFactory());

			// Act
			paymentProcessor.ProcessPayment(PaymentGateway.WorldPay);

			// Assert
			Assert.AreEqual("WorldPay", paymentProcessor.PaymentGatewayName());
		}

		[TestMethod]
		public void WhenAPaymentIsMadeUsingPayPal_CreatePaymentGatewayIsCalled()
		{
			// Arrange
			var mockPaymentGatewayFactory = new Mock<IPaymentGatewayFactory>();

			mockPaymentGatewayFactory.Setup(m => m.CreatePaymentGateway(PaymentGateway.PayPal)).Returns(new PayPal());

			var paymentProcessor = new PaymentProcessor(mockPaymentGatewayFactory.Object);

			// Act
			paymentProcessor.ProcessPayment(PaymentGateway.PayPal);

			// Assert
			mockPaymentGatewayFactory.Verify(m => m.CreatePaymentGateway(PaymentGateway.PayPal));
		}
	}
}
