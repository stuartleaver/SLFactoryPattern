using SLFactoryPattern.Code.Interfaces;

namespace SLFactoryPattern.Code.PaymentGateways
{
	public class WorldPay : IPaymentGateway
	{
		public string PaymentGatewayName()
		{
			return "WorldPay";
		}

		public bool ProcessPayment(string accountNumber, string sortCode, double amount)
		{
			return true;
		}
	}
}