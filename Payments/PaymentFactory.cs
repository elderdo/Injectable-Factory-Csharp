using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inectable_Factory_Csharp.Payments.Enums;
using Inectable_Factory_Csharp.Payments.Impl;

namespace Inectable_Factory_Csharp.Payments
{
    public class PaymentFactory
    {
        public static IPayment Create(PaymentMethod paymentMethod) 
        {
            switch(paymentMethod) 
            {
                case PaymentMethod.CreditCard:
                    return new CreditCardPayment();
                    
                case PaymentMethod.PayPal:
                    return new PayPalPayment();
                
                case PaymentMethod.GooglePay:
                    return new GooglePayPayment();

                default:
                    throw new NotSupportedException(
                        $"{paymentMethod} is not currently supported as a payment method."
                    );
            }
        }

       public IPayment Create(IServiceCollection services) {
            // register all possible implementations of IPayment
            services.AddScoped<CreditCardPayment>();
            services.AddScoped<PayPalPayment>();
            services.AddScoped<GooglePayPayment>();

            services.AddTransient<Func<PaymentMethod, IPayment>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case PaymentMethod.CreditCard:
                        return serviceProvider.GetService<CreditCardPayment>();

                    case PaymentMethod.PayPal:
                        return serviceProvider.GetService<PayPalPayment>();

                    case PaymentMethod.GooglePay:
                        return serviceProvider.GetService<GooglePayPayment>();

                    default:
                        return null;
                }
            });

            return null;
       }


    }
}