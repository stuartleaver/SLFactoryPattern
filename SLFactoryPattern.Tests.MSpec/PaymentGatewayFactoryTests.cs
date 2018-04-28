using FakeItEasy;
using Machine.Specifications;
using SLFactoryPattern.Code;
using SLFactoryPattern.Code.Enum;
using SLFactoryPattern.Code.Interfaces;

// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

namespace SLFactoryPattern.Tests.MSpec
{
    public class when_a_payment_is_made_using_worldpay : with_payment_setup
    {
		Because of = () =>
		{
			paymentProcessor.ProcessPayment(PaymentGateway.WorldPay);
		};

		It should_create_the_correct_payment_gateway = () =>
		{
			paymentProcessor.PaymentGatewayName().ShouldEqual("WorldPay");
		};
    }

	public class when_a_payment_is_made_using_paypal : with_fake_payment_setup
	{
		Because of = () =>
		{
			paymentProcessor.ProcessPayment(PaymentGateway.PayPal);
		};

		private It should_have_called_the_payment_gateway_factory_once = () =>
		{
			A.CallTo(() => paymentGatewayFactory.CreatePaymentGateway(PaymentGateway.PayPal)).MustHaveHappenedOnceExactly();
		};
	}

	public class with_payment_setup
	{
		protected static PaymentProcessor paymentProcessor;

		private Establish context = () => { paymentProcessor = new PaymentProcessor(new PaymentGatewayFactory()); };
	}

	public class with_fake_payment_setup
	{
		protected static PaymentProcessor paymentProcessor;

		protected static readonly IPaymentGatewayFactory paymentGatewayFactory = A.Fake<IPaymentGatewayFactory>();

		private Establish context = () => { paymentProcessor = new PaymentProcessor(paymentGatewayFactory); };
	}
}
