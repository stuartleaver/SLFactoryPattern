using SLFactoryPattern.Code.Enum;

namespace SLFactoryPattern.Code.Interfaces
{
	public interface IPaymentProcessor
	{
		void ProcessPayment(PaymentGateway paymentGatewayType);

		string PaymentGatewayName();
	}
}