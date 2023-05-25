using Inectable_Factory_Csharp.Payments.DTO;
using Inectable_Factory_Csharp.Payments.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Inectable_Factory_Csharp.Payments.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly Func<PaymentMethod, IPaymentService> _paymentFactoryResolver;

        public PaymentsController(Func<PaymentMethod, IPaymentService> paymentFactoryResolver)
        {
            _paymentFactoryResolver = paymentFactoryResolver;
        }

        [HttpPost("makePayment")]
        public ActionResult<String> PayAsync([FromBody] PaymentRequestDto request)
        {
            IPaymentService payment = _paymentFactoryResolver(request.PaymentMethod);
            string result = payment.Pay(request.Amount);

            return Ok(result);
        }
    }
}