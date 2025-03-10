using Injectable_Factory_Csharp.Payments.Enums;

namespace Injectable_Factory_Csharp.Payments.DTO;

public class PaymentRequestDto
{
    public Double Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}