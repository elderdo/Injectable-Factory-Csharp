namespace Inectable_Factory_Csharp.Payments.Impl
{
    public class PayPalPaymentService : IPaymentService
    {
        public string Pay(double amount)
        {
            return $"Successfully paid ${amount} to merchant using PayPal.";
        }
    }
}