namespace Injectable_Factory_Csharp.Payments.Impl;

public class CreditCardPaymentService : IPaymentService
{
    public string Pay(double amount)
    {
        return $"Successfully paid ${amount} to merchant using a Credit Card.";
    }
}