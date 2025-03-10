namespace Injectable_Factory_Csharp.Payments.Impl;

public class GooglePayPaymentService : IPaymentService
{
    public string Pay(double amount)
    {
        return $"Successfully paid ${amount} to merchant using Google Pay";
    }
}