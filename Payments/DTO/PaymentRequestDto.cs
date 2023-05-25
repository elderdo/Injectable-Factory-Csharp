using Inectable_Factory_Csharp.Payments.Enums;

namespace Inectable_Factory_Csharp.Payments.DTO
{
    public class PaymentRequestDto
    {
        public Double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}