namespace SLFactoryPattern.Code.Interfaces
{
	public interface IPaymentGateway
	{
		string PaymentGatewayName();

		bool ProcessPayment(string accountNumber, string sortCode, double amount);
	}
}