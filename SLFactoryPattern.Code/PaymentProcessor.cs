using SLFactoryPattern.Code.Enum;
using SLFactoryPattern.Code.Interfaces;

namespace SLFactoryPattern.Code
{
	public class PaymentProcessor : IPaymentProcessor
	{
		private readonly IPaymentGatewayFactory _paymentGatewayFactory;

		private IPaymentGateway _paymentGateway;

		public PaymentProcessor(IPaymentGatewayFactory paymentGatewayFactory)
		{
			_paymentGatewayFactory = paymentGatewayFactory;
		}

		public void ProcessPayment(PaymentGateway paymentGatewayType)
		{
			_paymentGateway = _paymentGatewayFactory.CreatePaymentGateway(paymentGatewayType);

			_paymentGateway.ProcessPayment("0123456", "12-34-56", 45.32);
		}

		public string PaymentGatewayName()
		{
			return _paymentGateway.GetType().Name;
		}
	}
}