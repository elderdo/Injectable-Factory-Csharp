using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inectable_Factory_Csharp.Payments
{
    public interface IPayment
    {
        void Pay(Double amount);
    }
}