using SLFactoryPattern.Code.Interfaces;

namespace SLFactoryPattern.Code.PaymentGateways
{
	public class PayPal : IPaymentGateway
	{
		public string PaymentGatewayName()
		{
			return "PayPal";
		}

		public bool ProcessPayment(string accountNumber, string sortCode, double amount)
		{
			return true;
		}
	}
}