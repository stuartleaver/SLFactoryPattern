using SLFactoryPattern.Code.Enum;

namespace SLFactoryPattern.Code.Interfaces
{
	public interface IPaymentGatewayFactory
	{
		IPaymentGateway CreatePaymentGateway(PaymentGateway paymentGatewayType);
	}
}