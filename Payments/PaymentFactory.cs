using Inectable_Factory_Csharp.Payments.Enums;
using Inectable_Factory_Csharp.Payments.Impl;

namespace Inectable_Factory_Csharp.Payments
{
    public class PaymentFactory
    {
        public IPaymentService Create(IServiceCollection services)
        {
            // register all possible implementations of IPayment
            services.AddScoped<CreditCardPaymentService>();
            services.AddScoped<PayPalPaymentService>();
            services.AddScoped<GooglePayPaymentService>();

            services.AddTransient<Func<PaymentMethod, IPaymentService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case PaymentMethod.CreditCard:
                        return serviceProvider.GetService<CreditCardPaymentService>();

                    case PaymentMethod.PayPal:
                        return serviceProvider.GetService<PayPalPaymentService>();

                    case PaymentMethod.GooglePay:
                        return serviceProvider.GetService<GooglePayPaymentService>();

                    default:
                        throw new NotSupportedException(
                            $"{key} is not currently supported as a payment method."
                        );
                }
            });
            return null;
        }
    }
}