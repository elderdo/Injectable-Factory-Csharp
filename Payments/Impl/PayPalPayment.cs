using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inectable_Factory_Csharp.Payments.Impl
{
    public class PayPalPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Successfully paid ${amount} to merchant using a Credit Card.");
        }
    }
}