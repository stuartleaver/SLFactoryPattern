using System;
using SLFactoryPattern.Code.Enum;
using SLFactoryPattern.Code.Interfaces;
using SLFactoryPattern.Code.PaymentGateways;

namespace SLFactoryPattern.Code
{
    public class PaymentGatewayFactory : IPaymentGatewayFactory
    {
	    public IPaymentGateway CreatePaymentGateway(PaymentGateway paymentGatewayType)
	    {
		    IPaymentGateway paymentGateway;

		    switch (paymentGatewayType)
		    {
			    case PaymentGateway.WorldPay:
					paymentGateway = new WorldPay();

				    break;
			    case PaymentGateway.WePay:
					paymentGateway = new WePay();

				    break;
			    case PaymentGateway.PayPal:
				    paymentGateway = new PayPal();

				    break;
			    default:
				    throw new ArgumentOutOfRangeException(nameof(paymentGateway), paymentGatewayType, null);
		    }

		    return paymentGateway;
	    }
    }
}
