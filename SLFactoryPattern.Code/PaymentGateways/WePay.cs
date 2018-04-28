using SLFactoryPattern.Code.Interfaces;

namespace SLFactoryPattern.Code.PaymentGateways
{
	public class WePay : IPaymentGateway
	{
		public string PaymentGatewayName()
		{
			return "WePay";
		}

		public bool ProcessPayment(string accountNumber, string sortCode, double amount)
		{
			return true;
		}
	}
}
