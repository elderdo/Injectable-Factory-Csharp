using Injectable_Factory_Csharp.Payments.DTO;
using Injectable_Factory_Csharp.Payments.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Injectable_Factory_Csharp.Payments.Controllers
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

        /// <summary>
        /// Processes a payment request.
        /// </summary>
        /// <param name="request">The payment request details.</param>
        /// <returns>Returns Ok if the payment method is valid, otherwise returns BadRequest.</returns>
        /// <response code="200">Payment processed successfully.</response>
        /// <response code="400">Invalid payment method.</response>
        [HttpPost("makePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<String> PayAsync([FromBody] PaymentRequestDto request)
        {
            if (Enum.IsDefined(typeof(PaymentMethod), request.PaymentMethod))
            {
                IPaymentService payment = _paymentFactoryResolver(request.PaymentMethod);
                string result = payment.Pay(request.Amount);
                return Ok(result);
            }
            else
            {
                var values = Enum.GetValues(typeof(PaymentMethod))
                    .Cast<PaymentMethod>()
                    .Select(pm => $"{(int)pm} ({pm})")
                    .ToArray();
                return BadRequest($"Invalid payment method. Must be one of the following values: {string.Join(", ", values)}");
            }
        }

    }
}